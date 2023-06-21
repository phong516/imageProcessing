import tkinter as tk
from tkinter import filedialog
from PIL import Image, ImageTk
import numpy as np
import cv2
from keras.models import model_from_json
from skimage.color import rgb2lab, lab2rgb
from keras.utils import img_to_array
from tkinter import messagebox


json_file = open('model.json', 'r')
loaded_model_json = json_file.read()
json_file.close()
loaded_model = model_from_json(loaded_model_json)
loaded_model.load_weights("model.h5")

img_raw = img_loc_nhieu = img_lam_net = None
rawImg_label = loc_nhieu_label = lam_net_label = output_label =result_label= None
saved_img = None

def program_():
    window.destroy()
    global program 
    program = tk.Tk()
    program.title("Program")
    program.geometry("590x750")

    global img_raw
    global img_loc_nhieu
    global img_lam_net
    open_button = tk.Button(program, text="Open", command=open_file)
    open_button.place(x = 20, y = 20, width = 100, height = 50)

    loc_nhieu_button = tk.Button(program, text="Lọc nhiễu", command=lambda:loc_nhieu(img_raw))
    loc_nhieu_button.place(x = 300, y = 20, width = 100, height = 50)

    output_button = tk.Button(program, text="Output", command=lambda:output(img_loc_nhieu))
    output_button.place(x = 20, y = 350, width = 100, height = 50)

    loc_nhieu_dau_ra_button = tk.Button(program, text="LỌC",command=lambda:open_new_window())
    loc_nhieu_dau_ra_button.place(x = 300, y = 350, width = 100, height = 50)

    save_button = tk.Button(program, text = "Save output image", command=save_img)
    save_button.place(x=400, y = 350)

    global rawImg_label, loc_nhieu_label, lam_net_label, output_label,result_label

    rawImg_label = tk.Label(program)
    rawImg_label.place(x = 20, y = 80, width = 256, height = 256)

    lam_net_label = tk.Label(program)
    lam_net_label.place(x = 300, y = 80, width = 256, height = 256)

    output_label = tk.Label(program)
    output_label.place(x = 20, y = 410, width = 256, height = 256)
    
    result_label = tk.Label(program)
    result_label.place(x = 300, y = 410, width = 256, height = 256)
    
    program.mainloop()

def open_file():
    global img_raw
    file_path = filedialog.askopenfilename(filetypes=[('image files', '.jpg')])
    if file_path:
        image = Image.open(file_path)
        image = image.resize((256, 256))

        img_raw = cv2.imread(file_path, 0)
        #img_raw = cv2.resize(img_raw, (256, 256))
        image_tk = ImageTk.PhotoImage(image)

        rawImg_label.configure(image=image_tk)
        rawImg_label.image = image_tk

def loc_nhieu(img):
    ksize = 7
    global img_loc_nhieu
    if img is None:
        return
    m, n = img.shape
    img_ket_qua_anh_loc_Trung_vi = np.zeros([m, n])
    h = (ksize - 1) // 2
    padded_img = np.pad(img, (h, h), mode='reflect')
    for i in range(m):
        for j in range(n):
            vung_anh_kich_thuoc_k = padded_img[i:i+ksize, j:j+ksize]
            gia_tri_TV = np.median(vung_anh_kich_thuoc_k)
            img_ket_qua_anh_loc_Trung_vi[i, j] = gia_tri_TV  
    imgTV_3x3=lam_net(img_ket_qua_anh_loc_Trung_vi)
    imgTV_3x3 = imgTV_3x3.astype(np.uint8)
    imgTV_3x3_3 = cv2.cvtColor(imgTV_3x3, cv2.COLOR_GRAY2RGB)
    imgTV_3x3_3 = Image.fromarray(imgTV_3x3_3)
    img_loc_nhieu = imgTV_3x3_3.resize((256, 256))
    
    img_tk = ImageTk.PhotoImage(img_loc_nhieu)

    lam_net_label.configure(image=img_tk)
    lam_net_label.image = img_tk
    
def lam_net(img):
    if img is None:
        return
    m, n = img.shape
    img_new = np.zeros([m, n])
    for i in range(1, m - 1):
        for j in range(1, n - 1):
            temp = [img[i - 1, j - 1],
                    img[i - 1, j],
                    img[i - 1, j + 1],
                    img[i, j - 1],
                    img[i, j],
                    img[i, j + 1],
                    img[i + 1, j - 1],
                    img[i + 1, j],
                    img[i + 1, j + 1]]
            temp = sorted(temp)
            img_new[i, j] = temp[4]
    return img_new


def output(input_img):
    
    global resImg,resImg_PIL,resImage_BGR
   
    colorize = []
    colorize.append(img_to_array(input_img))
    colorize = np.array(colorize, dtype=float)

    colorize = rgb2lab(1.0 / 255.0 * colorize)[:, :, :, 0]
    colorize = colorize.reshape(colorize.shape + (1,))

    output = loaded_model.predict(colorize)
    output = output * 128

    for i in range(len(output)):
        cur = np.zeros((256, 256, 3))
        sharpened_img_L = cv2.GaussianBlur(colorize[i][:, :, 0], (0, 0), 3)
        colorize[i][:, :, 0] = cv2.addWeighted(colorize[i][:, :, 0], 1.5, sharpened_img_L, -0.5, 0)
        cur[:, :, 0] = colorize[i][:, :, 0]

        for x in range(256):
            for y in range(256):
                cur[x, y, 1] = output[i, x, y, 0] * 2
                cur[x, y, 2] = output[i, x, y, 1] * 2

        resImg = lab2rgb(cur)
        resImg = (resImg * 255).astype(np.uint8)
        resImg_PIL = Image.fromarray(resImg)
        resImage_BGR = cv2.cvtColor(resImg, cv2.COLOR_RGB2BGR)
        

        output_img = ImageTk.PhotoImage(resImg_PIL)
    
        global output_label, saved_img
        saved_img = resImg_PIL
        output_label.configure(image=output_img)
        output_label.image = output_img


def linear_interpolation_channel_x(channel_image,threshold,pixel,x,y,dividend):
    pixel_extra=pixel
    neighbor_x, neighbor_y = x, y
    while (pixel_extra > threshold):
        if(neighbor_x>=255):break
        neighbor_x += 1      
        _,_,pixel_extra = channel_image.getpixel((neighbor_x,neighbor_y))
    _,_,neighbor_value = channel_image.getpixel((neighbor_x,neighbor_y))
    pixel_return_x = np.interp(x, [x, neighbor_x], [pixel, neighbor_value])
    pixel_return_x = pixel_return_x/dividend
    return float(pixel_return_x)
def linear_interpolation_channel_y(channel_image,threshold,pixel,x,y,dividend):
    pixel_extra=pixel
    neighbor_x, neighbor_y = x, y
    while (pixel_extra > threshold):
        if(neighbor_y>=255):break
        neighbor_y += 1
            
        _,_,pixel_extra = channel_image.getpixel((neighbor_x,neighbor_y))
    _,_,neighbor_value = channel_image.getpixel((neighbor_x,neighbor_y))
    pixel_return_y = np.interp(y, [y, neighbor_y], [pixel, neighbor_value])
    pixel_return_y = pixel_return_y/dividend
    return float(pixel_return_y)

def in_anh(RGB_channel,x,y):
    RGB_channel_tk = Image.fromarray(RGB_channel)
    img_RGB_channel = ImageTk.PhotoImage(RGB_channel_tk)

    canvas.images.append(img_RGB_channel)  # Thêm hình ảnh vào danh sách
    canvas.create_image(x, y, anchor=tk.NW, image=img_RGB_channel)

def update_threshold(channel, value,x,y):
    _, mask = cv2.threshold(channel, value, 255, cv2.THRESH_BINARY_INV)
    in_anh(mask, x, y)
    return mask



def apply_threshold(red_channel,green_channel, blue_channel,entry):
    # global  result_label  
    try:
        threshold_value = int(entry.get())
        mask_red=update_threshold(red_channel, threshold_value,0,280)
        mask_green=update_threshold(green_channel, threshold_value,260,280)
        mask_blue = update_threshold(blue_channel, threshold_value,520,280)
        
        masked_image_red = cv2.bitwise_and(resImage_BGR,resImage_BGR, mask=mask_red)
        masked_image_green = cv2.bitwise_and(resImage_BGR,resImage_BGR, mask=mask_green)
        masked_image_blue = cv2.bitwise_and(resImage_BGR,resImage_BGR, mask=mask_blue)
        
        image_rgb_red = cv2.cvtColor(masked_image_red, cv2.COLOR_BGR2RGB)
        image_rgb_green = cv2.cvtColor(masked_image_green, cv2.COLOR_BGR2RGB)
        image_rgb_blue = cv2.cvtColor(masked_image_blue, cv2.COLOR_BGR2RGB)

        in_anh(image_rgb_red,0,540)
        in_anh(image_rgb_green,260,540)
        in_anh(image_rgb_blue,520,540)
        
        masked_image_red = Image.fromarray(masked_image_red)
        masked_image_green = Image.fromarray(masked_image_green)
        masked_image_blue = Image.fromarray(masked_image_blue)
        
        result = Image.new(resImg_PIL.mode, resImg_PIL.size)
        red_c2 = Image.new(resImg_PIL.mode,resImg_PIL.size)
        blue_c0 = Image.new(resImg_PIL.mode,resImg_PIL.size)
        green_c1 = Image.new(resImg_PIL.mode,resImg_PIL.size)
        
        for x in range(256):
            for y in range(256):
                b_r,g_r,r_r = masked_image_red.getpixel((x,y))
                b_g,g_g,r_g = masked_image_green.getpixel((x,y)) #anh RGB
                b_b,g_b,r_b = masked_image_blue.getpixel((x,y))
                
                r,g,b=resImg_PIL.getpixel((x,y)) # anh BGR
                
                if(r_b>100):
                    b_x= linear_interpolation_channel_x(masked_image_blue,100,r_b,x,y,3.03)
                    b_y = linear_interpolation_channel_y(masked_image_blue,100,r_b,x,y,3.03)
                    b=(b_x+b_y)/2
                    b=(np.uint8(b)) 
                  
                if(r_g>100):
                    g_x = linear_interpolation_channel_x(masked_image_green,100,r_g,x,y,2.05)
                    g_y = linear_interpolation_channel_y(masked_image_green,100,r_g,x,y,2.05)
                    g=(g_x+g_y)/2 
                    g=(np.uint8(g))
                  
                if(r_r>10):
                    r_x = linear_interpolation_channel_x(masked_image_red,10,r_r,x,y,0.9)
                    r_y = linear_interpolation_channel_y(masked_image_red,10,r_r,x,y,0.9)
                    r=(r_x+r_y)*0.5
                    r=(np.uint8(r)) 
     
                    
                result.putpixel((x,y),(r,g,b))  
                red_c2.putpixel((x,y),(r,0,0))  
                green_c1.putpixel((x,y),(0,g,0))
                blue_c0.putpixel((x,y),(0,0,b))
                    
        # result = np.array(result, dtype=np.uint8)
        red_c2 = np.array(red_c2, dtype=np.uint8)
        blue_c0 = np.array(blue_c0, dtype=np.uint8)
        green_c1 = np.array(green_c1, dtype=np.uint8)
        
        in_anh(red_c2,0,800)
        in_anh(green_c1,260,800)
        in_anh(blue_c0,520,800)
        
        #in ảnh kết quả
        img_tk_result = ImageTk.PhotoImage(result)
        result_label.configure(image=img_tk_result)
        result_label.image = img_tk_result
 
        global saved_img
        saved_img = result
             
        canvas.config(scrollregion=canvas.bbox(tk.ALL))
        
    except ValueError:
        messagebox.showerror("Error", "Invalid threshold value. Please enter an integer.")


def open_new_window():
    new_window = tk.Toplevel(program)
    new_window.title("LỌC")
    new_window.geometry("1068x530")
    
    frame = tk.Frame(new_window)
    frame.pack(fill=tk.BOTH, expand=True)
    
    # Tạo thanh cuộn dọc
    scrollbar = tk.Scrollbar(frame)
    scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
    
    # Tạo một Canvas để hiển thị hình ảnh
    global canvas
    canvas = tk.Canvas(frame, yscrollcommand=scrollbar.set)
    canvas.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
    
    canvas.images = []  # Danh sách lưu trữ các hình ảnh
    
    # Thiết lập thanh cuộn để điều khiển Canvas
    scrollbar.config(command=canvas.yview)

    # resImage_BGR = cv2.cvtColor(resImg, cv2.COLOR_RGB2BGR)
    
    red_channel = resImg[:, :, 0]
    green_channel = resImg[:, :, 1]
    blue_channel = resImg[:, :, 2]
    
    in_anh(red_channel,0,20)
    in_anh(green_channel,260,20)
    in_anh(blue_channel,520,20)
    
     # Tạo ô nhập giá trị
    label = tk.Label(new_window, text="Threshold Value:")
    label.place(x = 800, y = 100, width = 100, height = 50)

    entry = tk.Entry(new_window)
    entry.place(x = 800, y = 150, width = 100, height = 25)

    # Tạo nút "OK"
    button = tk.Button(new_window, text="OK", command=lambda: apply_threshold(red_channel,green_channel,blue_channel,entry))
    button.place(x = 910, y = 150, width = 100, height = 25)
    
    update_threshold(red_channel, 60,0,280)
    update_threshold(green_channel, 60,260,280)
    update_threshold(blue_channel, 60,520,280)
    
    canvas.config(scrollregion=canvas.bbox(tk.ALL))
    
    new_window.mainloop()
    
def save_img():
    file = filedialog.asksaveasfile(defaultextension=".jpg")
    if file:
        saved_img.save(file)
        messagebox.showinfo("Saved", "Your image has been saved successfully!")
    else:
        messagebox.showerror("Error", "Your image has not been saved!")

window = tk.Tk()
window.title("Term Project")
window.geometry("1200x700")

img_path = r'trangBia3.jpg'
img = Image.open(img_path)
img_tk = ImageTk.PhotoImage(img)

img_label = tk.Label(window, image=img_tk)
img_label.place(x = 0, y= 0, width = 1200, height= 700)

button = tk.Button(window, text="Click me!", command=program_)
#place button at the right bottom corner
button.place(x = 900, y = 600, width = 100, height = 50)
img_label.lower(button)

window.mainloop()
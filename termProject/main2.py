import tkinter as tk
from tkinter import filedialog
from PIL import ImageTk, Image
import numpy as np
import cv2
from keras.models import model_from_json
from skimage.color import rgb2lab, lab2rgb
from keras.utils import img_to_array
from tkinter import messagebox


"""Load model để tô màu ảnh"""
json_file = open('model.json', 'r')
loaded_model_json = json_file.read()
json_file.close()
loaded_model = model_from_json(loaded_model_json)
loaded_model.load_weights("model.h5")

"""Tạo các biến ảnh, label để dùng trong các hàm"""
inputImage = filteredInputImage = None
inputImage_label = filterInputImage_label = outputImage_label =filteredOutputImage_label= None
outputImage = outputImagePIL = outputImageBGR = None

"""Cửa số làm việc chính, hiển thị ảnh đầu vào, ảnh đầu vào đã lọc nhiễu, ảnh đầu ra, ảnh đầu ra đã lọc nhiễu"""
def program_():
    window.destroy()
    global program 
    program = tk.Tk()
    program.title("Program")
    program.geometry("1100x600")
    
    #TRANG TRÍ NỀN MÀU
    canvasBack = tk.Canvas(program, bg="#97FFFF")
    canvasBack.place(x=0, y=0, width=1100, height=230)
    #THÊM LABEL
    caption_label = tk.Label(program, text="COLORIZING GRAYSCALE IMAGE", font=("Arial", 30), bg="#97FFFF")
    caption_label.place(x=300, y=100, width=600, height=40)


    global inputImage
    global filteredInputImage
    
    open_button = tk.Button(program, text="OPEN", command=openFile)
    open_button.place(x = 10, y = 10, width = 150, height = 50)

    filteredInputImage_button = tk.Button(program, text="FILTER INPUT IMAGE", command=lambda:filterInputImage(inputImage))
    filteredInputImage_button.place(x = 10, y = 60, width = 150, height = 50)

    outputImage_button = tk.Button(program, text="COLORIZE IMAGE", command=lambda:colorizeImage(filteredInputImage))
    outputImage_button.place(x = 10, y = 110, width = 150, height = 50)

    filteredOutputImage_button = tk.Button(program, text="FILTER OUTPUT IMAGE",command=lambda:filterOutputImage_window())
    filteredOutputImage_button.place(x = 10, y = 160, width = 150, height = 50)
    
    saveImage_button = tk.Button(program, text="SAVE IMAGE", command=save_image)
    saveImage_button.place(x=900, y=540,width = 150, height = 50)

    global inputImage_label, filterInputImage_label, outputImage_label,filteredOutputImage_label

    inputImage_label = tk.Label(program,highlightthickness=1, highlightbackground="black", borderwidth=1, relief="solid")
    inputImage_label.place(x = 10, y = 250, width = 256, height = 256)
    # Tạo một Label mới để hiển thị chú thích
    caption_label = tk.Label(program, text="ORIGINAL IMAGE", bg="white")
    caption_label.place(x=10, y=510, width=256, height=20)

    filterInputImage_label = tk.Label(program,highlightthickness=1, highlightbackground="black", borderwidth=1, relief="solid")
    filterInputImage_label.place(x = 270, y = 250, width = 256, height = 256)
    # Tạo một Label mới để hiển thị chú thích
    caption_label = tk.Label(program, text="FILTERED INPUT IMAGE", bg="white")
    caption_label.place(x=270, y=510, width=256, height=20)

    outputImage_label = tk.Label(program,highlightthickness=1, highlightbackground="red", borderwidth=1, relief="solid")
    outputImage_label.place(x = 530, y = 250, width = 256, height = 256)
    # Tạo một Label mới để hiển thị chú thích
    caption_label = tk.Label(program, text="COLORED IMAGE", bg="white")
    caption_label.place(x=530, y=510, width=256, height=20)

    filteredOutputImage_label = tk.Label(program,highlightthickness=1, highlightbackground="red", borderwidth=1, relief="solid")
    filteredOutputImage_label.place(x = 790, y = 250, width = 256, height = 256)
    # Tạo một Label mới để hiển thị chú thích
    caption_label = tk.Label(program, text="FILTERED OUTPUT IMAGE", bg="white")
    caption_label.place(x=790, y=510, width=256, height=20)
    
    program.mainloop()

"""Function to open and display an external image, save it to the global var inputImage"""
def openFile():
    global inputImage
    filePath = filedialog.askopenfilename(filetypes=[('image files', '.jpg')])
    if filePath:
        image = Image.open(filePath)
        image = image.resize((256, 256))

        inputImage = cv2.imread(filePath, 0)
        image_tk = ImageTk.PhotoImage(image)

        inputImage_label.configure(image=image_tk)
        inputImage_label.image = image_tk

"""Hàm dùng để lưu ảnh sau khi được tô màu ở dạng .png"""

def save_image():
    if filteredOutputImage_label["image"]:
        imageSaved = ImageTk.getimage(filteredOutputImage_label.image)
    elif outputImage_label["image"]:
        imageSaved = ImageTk.getimage(outputImage_label.image)
    else:
        messagebox.showwarning(message="No image to be saved")
        return
        
    filename = filedialog.asksaveasfilename(defaultextension=".png", filetypes=[("PNG files", "*.png")])
    if filename:
        imageSaved.save(filename)
        messagebox.showinfo(message="Image has been saved")
    else:
        messagebox.showwarning(message="Not found file path")

"""Hàm dùng cho việc làm sắc nét ảnh"""
def sharpenImage(image):
    if image is None:
        return
    width, height = image.shape
    sharpenedImage = np.zeros([width, height])
    for i in range(1, width - 1):
        for j in range(1, height - 1):
            temp = [image[i - 1, j - 1],
                    image[i - 1, j],
                    image[i - 1, j + 1],
                    image[i, j - 1],
                    image[i, j],
                    image[i, j + 1],
                    image[i + 1, j - 1],
                    image[i + 1, j],
                    image[i + 1, j + 1]]
            temp = np.median(temp)
            sharpenedImage[i, j] = temp
    return sharpenedImage

"""Hàm lọc nhiễu ảnh dùng thuật toán lọc trung vị"""
def medianFilterImage(image):
    if image is None:
        return
    kSize = 7
    width, height = image.shape
    medianFilteredImage = np.zeros([width, height])
    h = (kSize-1) // 2
    paddedImage = np.pad(image, (h, h), mode='reflect')
    for i in range(width):
        for j in range(height):
            windowSizeK = paddedImage[i:i+kSize, j:j+kSize]
            medianValue = np.median(windowSizeK)
            medianFilteredImage[i, j] = medianValue  
    return medianFilteredImage

"""Hàm kết hợp hầm lọc nhiễu và sắc nét, sau đó resize về (256, 256) và hiển thị ảnh """
def filterInputImage(image):
    if image is None:
        return
    global filteredInputImage
    imageSmoothed = medianFilterImage(image)
    imageSharpenedGray = sharpenImage(imageSmoothed).astype(np.uint8)
    imageSharpenedRgbCv2 = cv2.cvtColor(imageSharpenedGray, cv2.COLOR_GRAY2RGB)
    imageSharpenedRgbPil = Image.fromarray(imageSharpenedRgbCv2).resize((256, 256))

    filteredInputImage = imageSharpenedRgbPil

    image_tk = ImageTk.PhotoImage(imageSharpenedRgbPil)
    filterInputImage_label.configure(image=image_tk)
    filterInputImage_label.image = image_tk

"""Hàm dùng model đã được load từ đầu chương trình để tô màu ảnh với kích thước đầu vào là (1, 256, 256, 3)"""
def colorizeImage(input_img):
    
    global outputImage,outputImagePIL,outputImageBGR
   
    colorizedImage = []
    colorizedImage.append(img_to_array(input_img))
    colorizedImage = np.array(colorizedImage, dtype=float)

    colorizedImage = rgb2lab(1.0 / 255.0 * colorizedImage)[:, :, :, 0]
    colorizedImage = colorizedImage.reshape(colorizedImage.shape + (1,))

    output = loaded_model.predict(colorizedImage)
    output = output * 128

    cur = np.zeros((256, 256, 3))
    colorizedImageBlurChannelL = cv2.GaussianBlur(colorizedImage[:, :, :, 0], (0, 0), 3)
    colorizedImage[:, :, :, 0] = cv2.addWeighted(colorizedImage[:, :, :, 0], 1.5, colorizedImageBlurChannelL, -0.5, 0)
    cur[:, :, 0] = colorizedImage[:, :, :, 0]

    for x in range(256):
        for y in range(256):
            cur[x, y, 1] = output[:, x, y, 0] * 2
            cur[x, y, 2] = output[:, x, y, 1] * 2

    outputImage = lab2rgb(cur)
    outputImage = (outputImage * 255).astype(np.uint8)
    outputImagePIL = Image.fromarray(outputImage)
    outputImageBGR = cv2.cvtColor(outputImage, cv2.COLOR_RGB2BGR)

    outputImagePIL_tk = ImageTk.PhotoImage(outputImagePIL)

    global outputImage_label
    outputImage_label.configure(image=outputImagePIL_tk)
    outputImage_label.image = outputImagePIL_tk

"""Hàm trả về giá trị nội suy tuyết tính trên trục X của ảnh"""
def linear_interpolation_axis_x(channel_image,threshold,pixel,x,y,dividend):
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

"""Hàm trả về giá trị nội suy tuyết tính trên trục Y của ảnh"""
def linear_interpolation_axis_y(channel_image,threshold,pixel,x,y,dividend):
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

"""Hàm hiển thị ảnh tại tọa độ x, y trên cửa sổ filteredOutputImage_window"""
def displayImage(imageArray,x,y):
    imagePIL = Image.fromarray(imageArray)
    image_tk = ImageTk.PhotoImage(imagePIL)

    canvas.images.append(image_tk)  # Thêm hình ảnh vào danh sách
    canvas.create_image(x, y, anchor=tk.NW, image=image_tk)

"""Hàm cập nhật giá trị ngưỡng của ảnh và hiển thị lên cửa số dùng hàm displayImage"""
def updateThreshold(channel, value,x,y):
    _, mask = cv2.threshold(channel, value, 255, cv2.THRESH_BINARY_INV)
    displayImage(mask, x, y)
    return mask

"""Hàm lấy giá trị ngưỡng từ người dùng để xử lý và hiển thị ảnh đầu ra đã được lọc,
và các mask của ảnh đó"""
def applyThreshold(channelRed,channelGreen, channelBlue,entry):
    # global  filteredOutputImage_label  
    try:
        thresholdValue = int(entry.get())
        maskRed     = updateThreshold(channelRed, thresholdValue,0,280)
        maskGreen   = updateThreshold(channelGreen, thresholdValue,260,280)
        maskBlue    = updateThreshold(channelBlue, thresholdValue,520,280)
        
        maskImageRed    = cv2.bitwise_and(outputImageBGR,outputImageBGR, mask=maskRed)
        maskImageGreen  = cv2.bitwise_and(outputImageBGR,outputImageBGR, mask=maskGreen)
        maskImageBlue   = cv2.bitwise_and(outputImageBGR,outputImageBGR, mask=maskBlue)
        
        rgbImageRed     = cv2.cvtColor(maskImageRed, cv2.COLOR_BGR2RGB)
        rgbImageGreen   = cv2.cvtColor(maskImageGreen, cv2.COLOR_BGR2RGB)
        rgbImageBlue    = cv2.cvtColor(maskImageBlue, cv2.COLOR_BGR2RGB)

        displayImage(rgbImageRed,0,540)
        displayImage(rgbImageGreen,260,540)
        displayImage(rgbImageBlue,520,540)
        
        global maskedImageBlue_getPixel,maskedImageGreen_getPixel,maskedImageRed_getPixel
        
        maskedImageRed_getPixel     = Image.fromarray(maskImageRed)
        maskedImageGreen_getPixel   = Image.fromarray(maskImageGreen)
        maskedImageBlue_getPixel    = Image.fromarray(maskImageBlue)
        
        global filteredOutputImage,maskedFilteredImageRed,maskedFilteredImageGreen,maskedFilteredImageBlue
        
        filteredOutputImage     = Image.new(outputImagePIL.mode, outputImagePIL.size)
        maskedFilteredImageRed  = Image.new(outputImagePIL.mode,outputImagePIL.size)
        maskedFilteredImageBlue = Image.new(outputImagePIL.mode,outputImagePIL.size)
        maskedFilteredImageGreen= Image.new(outputImagePIL.mode,outputImagePIL.size)
        
        for x in range(256):
            for y in range(256):
                b_r,g_r,red_imageRed    = maskedImageRed_getPixel.getpixel((x,y))
                b_g,g_g,red_imageGreen  = maskedImageGreen_getPixel.getpixel((x,y)) #anh RGB
                b_b,g_b,red_imageBlue   = maskedImageBlue_getPixel.getpixel((x,y))
                
                r,g,b = outputImagePIL.getpixel((x,y)) # anh BGR
                
                if(red_imageBlue>100):
                    xBlue   = linear_interpolation_axis_x(maskedImageBlue_getPixel,100,red_imageBlue,x,y,3.03)
                    yBlue   = linear_interpolation_axis_y(maskedImageBlue_getPixel,100,red_imageBlue,x,y,3.03)
                    b       =(xBlue+yBlue)/2
                    b       = np.uint8(b)
                  
                if(red_imageGreen>100):
                    xGreen  = linear_interpolation_axis_x(maskedImageGreen_getPixel,100,red_imageGreen,x,y,2.05)
                    yGreen  = linear_interpolation_axis_y(maskedImageGreen_getPixel,100,red_imageGreen,x,y,2.05)
                    g       =(xGreen+yGreen)/2 
                    g       = np.uint8(g)
                  
                if(red_imageRed>10):
                    xRed    = linear_interpolation_axis_x(maskedImageRed_getPixel,10,red_imageRed,x,y,0.9)
                    yRed    = linear_interpolation_axis_y(maskedImageRed_getPixel,10,red_imageRed,x,y,0.9)
                    r       =(xRed+yRed) / 2
                    r       = np.uint8(r)
     
                filteredOutputImage.putpixel((x,y),(r,g,b))  
                maskedFilteredImageRed.putpixel((x,y),(r,0,0))  
                maskedFilteredImageGreen.putpixel((x,y),(0,g,0))
                maskedFilteredImageBlue.putpixel((x,y),(0,0,b))
                    
        maskedFilteredImageRed_array = np.array(maskedFilteredImageRed, dtype=np.uint8)
        maskedFilteredImageGreen_array = np.array(maskedFilteredImageBlue, dtype=np.uint8)
        maskedFilteredImageBlue_array = np.array(maskedFilteredImageGreen, dtype=np.uint8)
        
        displayImage(maskedFilteredImageRed_array,0,800)
        displayImage(maskedFilteredImageBlue_array,260,800)
        displayImage(maskedFilteredImageGreen_array,520,800)
        
        #in ảnh kết quả
        img_tk_result = ImageTk.PhotoImage(filteredOutputImage)
        filteredOutputImage_label.configure(image=img_tk_result)
        filteredOutputImage_label.image = img_tk_result
 
             
        canvas.config(scrollregion=canvas.bbox(tk.ALL))
        
    except ValueError:
        messagebox.showerror("Error", "Invalid threshold value. Please enter an integer.")

"""Hàm lấy giá trị ngưỡng theo từng kênh RGB từ người dùng để xử lý và hiển thị ảnh đầu ra đã được lọc,
và các mask của ảnh đó"""
def applyLinearFilter(entryRed,entryGreen,entryBlue,entry_division_red,entry_division_green,entry_division_blue):
    global filteredOutputImage,maskedFilteredImageRed,maskedFilteredImageGreen,maskedFilteredImageBlue
    try:
        thresholdRed = int(entryRed.get())
        thresholdGreen = int(entryGreen.get())
        thresholdBlue = int(entryBlue.get())
        
        divisionRed = float(entry_division_red.get())
        divisionGreen = float(entry_division_green.get())
        divisionBlue = float(entry_division_blue.get())
        
        for x in range(256):
            for y in range(256):
                b_r,g_r,red_imageRed = maskedImageRed_getPixel.getpixel((x,y))
                b_g,g_g,red_imageGreen = maskedImageGreen_getPixel.getpixel((x,y)) #anh RGB
                b_b,g_b,red_imageBlue = maskedImageBlue_getPixel.getpixel((x,y))
                
                r,g,b=outputImagePIL.getpixel((x,y)) # anh BGR
                
                if(red_imageBlue>thresholdBlue):
                    xBlue = linear_interpolation_axis_x(maskedImageBlue_getPixel,thresholdBlue,red_imageBlue,x,y,divisionBlue)
                    yBlue = linear_interpolation_axis_y(maskedImageBlue_getPixel,thresholdBlue,red_imageBlue,x,y,divisionBlue)
                    b   =(xBlue+yBlue)/2
                    b   =(np.uint8(b)) 
                  
                if(red_imageGreen>thresholdGreen):
                    xGreen = linear_interpolation_axis_x(maskedImageGreen_getPixel,thresholdGreen,red_imageGreen,x,y,divisionGreen)
                    yGreen = linear_interpolation_axis_y(maskedImageGreen_getPixel,thresholdGreen,red_imageGreen,x,y,divisionGreen)
                    g   =(xGreen+yGreen)/2 
                    g   =(np.uint8(g))
                  
                if(red_imageRed>thresholdRed):
                    xRed = linear_interpolation_axis_x(maskedImageRed_getPixel,thresholdRed,red_imageRed,x,y,divisionRed)
                    yRed = linear_interpolation_axis_y(maskedImageRed_getPixel,thresholdRed,red_imageRed,x,y,divisionRed)
                    r   =(xRed+yRed)*0.5
                    r   =(np.uint8(r)) 
     
                    
                filteredOutputImage.putpixel((x,y),(r,g,b))  
                maskedFilteredImageRed.putpixel((x,y),(r,0,0))  
                maskedFilteredImageGreen.putpixel((x,y),(0,g,0))
                maskedFilteredImageBlue.putpixel((x,y),(0,0,b))
                    
        maskedFilteredImageRed_array = np.array(maskedFilteredImageRed, dtype=np.uint8)
        maskedFilteredImageGreen_array = np.array(maskedFilteredImageBlue, dtype=np.uint8)
        maskedFilteredImageBlue_array = np.array(maskedFilteredImageGreen, dtype=np.uint8)
        
        displayImage(maskedFilteredImageRed_array,0,800)
        displayImage(maskedFilteredImageBlue_array,260,800)
        displayImage(maskedFilteredImageGreen_array,520,800)
        
        #in ảnh kết quả
        filterOutputImage_tk = ImageTk.PhotoImage(filteredOutputImage)
        filteredOutputImage_label.configure(image=filterOutputImage_tk)
        filteredOutputImage_label.image = filterOutputImage_tk
       
        
    except ValueError:
        messagebox.showerror("Error", "Invalid threshold value. Please enter an integer.")

"""Hàm tạo cửa số mới, dùng để nhập các giá trị để lọc ảnh đầu ra"""
def filterOutputImage_window():
    
    new_window = tk.Toplevel(program)
    new_window.title("Linear interpolation filter")
    new_window.geometry("1200x700")
    
    frame = tk.Frame(new_window)
    frame.pack(fill=tk.BOTH, expand=True)
    
     #TRANG TRÍ NỀN MÀU
    canvasBack = tk.Canvas(new_window, bg="#79CDCD")
    canvasBack.place(x=780, y=92, width=400, height=100)
    
    canvasBack = tk.Canvas(new_window, bg="#EEE8AA")
    canvasBack.place(x=780, y=192, width=400, height=300)
    
    label = tk.Label(new_window, text="LINEAR INTERNAL FILTERS",font=("Arial", 15), bg="#EEE8AA")
    label.place(x = 820, y = 420, width = 300, height = 50)
    
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

    channelRed = outputImage[:, :, 0]
    channelGreen = outputImage[:, :, 1]
    channelBlue = outputImage[:, :, 2]
    
    displayImage(channelRed,0,20)
    displayImage(channelGreen,260,20)
    displayImage(channelBlue,520,20)
    
     # Tạo ô nhập giá trị
    thresholdValue_label = tk.Label(new_window, text="Threshold Value of binary image:",bg="#79CDCD")
    thresholdValue_label.place(x = 850, y = 100, width = 200, height = 50)

    entry = tk.Entry(new_window)
    entry.place(x = 830, y = 150, width = 100, height = 25)

    # Tạo nút "khoanh vùng"
    applyThreshold_button = tk.Button(new_window, text="ZONING", command=lambda: applyThreshold(channelRed,channelGreen,channelBlue,entry))
    applyThreshold_button.place(x = 950, y = 150, width = 100, height = 25)
    
    # Tạo nút "OKE"
    ok_button = tk.Button(new_window, text="OK",command=lambda: applyLinearFilter(entryRed,entryGreen,entryBlue,entry_division_red,entry_division_green,entry_division_blue))
    ok_button.place(x = 930, y = 380, width = 100, height = 25)
    
    # Tạo ô nhập giá trị 1
    thresholdRed_label = tk.Label(new_window, text="Threshold red", bg="#EEE8AA")
    thresholdRed_label.place(x = 820, y = 200, width = 100, height = 50)

    entryRed = tk.Entry(new_window)
    entryRed.place(x = 820, y = 250, width = 100, height = 25)
    
    # Tạo ô nhập giá trị 2
    thresholdGreen_label = tk.Label(new_window, text="Threshold green", bg="#EEE8AA")
    thresholdGreen_label.place(x = 930, y = 200, width = 100, height = 50)

    entryGreen = tk.Entry(new_window)
    entryGreen.place(x = 930, y = 250, width = 100, height = 25)
    
    # Tạo ô nhập giá trị 3
    thresholdBlue_label = tk.Label(new_window, text="Threshold blue", bg="#EEE8AA")
    thresholdBlue_label.place(x = 1040, y = 200, width = 100, height = 50)

    entryBlue = tk.Entry(new_window)
    entryBlue.place(x = 1040, y = 250, width = 100, height = 25)
    
    # Tạo ô nhập giá trị 4
    divisionRed_label = tk.Label(new_window, text="Division red", bg="#EEE8AA")
    divisionRed_label.place(x = 820, y = 280, width = 100, height = 50)

    entry_division_red = tk.Entry(new_window)
    entry_division_red.place(x = 820, y = 330, width = 100, height = 25)
    
    # Tạo ô nhập giá trị 5
    divisionGreen_label = tk.Label(new_window, text="Division green", bg="#EEE8AA")
    divisionGreen_label.place(x = 930, y = 280, width = 100, height = 50)

    entry_division_green = tk.Entry(new_window)
    entry_division_green.place(x = 930, y = 330, width = 100, height = 25)
    
    # Tạo ô nhập giá trị 6
    divisionBlue_label = tk.Label(new_window, text="Division blue", bg="#EEE8AA")
    divisionBlue_label.place(x = 1040, y = 280, width = 100, height = 50)

    entry_division_blue = tk.Entry(new_window)
    entry_division_blue.place(x = 1040, y = 330, width = 100, height = 25)
    
    updateThreshold(channelRed, 60,0,280)
    updateThreshold(channelGreen, 60,260,280)
    updateThreshold(channelBlue, 60,520,280)
    
    canvas.config(scrollregion=canvas.bbox(tk.ALL))
    
    new_window.mainloop()
    
"""Cửa số ban đầu, hiển thị thông tin môn học, đề tài"""    
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

window.mainloop()
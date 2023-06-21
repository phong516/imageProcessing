#hàm của Tú nên trả về ảnh xám 3 kênh màu + sửa lại cái tên gọi lọc nhiễu hoặc có (đã sửa)
# thể xóa lun hàm đó hoặc tìm 1 lý do khác để hàm đó có thể sử dụng như trong code

#Hàm tuyến tính hóa sửa lại xíu do có chỗ thừa (đã sưa)

# nếu có tg train lại AI sao cho đầu vào chuẩn hơn để khỏi phải thêm vào mảng (colorizedImage = [])

#các biến nào global dồn về 1 chỗ khai báo (nếu được)

#khi xét giá trị các kênh màu thì nên sửa lại tùy theo từng kênh mà lấy màu đó xét (trong code đều lấy của kênh red) (không sửa)

#kiểm tra lại có biến nào dư thừa không để xoá


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
json_file = open('model.json', 'r') #file json chứa kiến trúc mô hình, cấu hình, thông tin của các trọng số trong mô hình
loaded_model_json = json_file.read()
json_file.close()
loaded_model = model_from_json(loaded_model_json)
loaded_model.load_weights("model.h5") #file h5 chứa các trọng số đã được học

"""Tạo các biến ảnh, label để dùng trong các hàm"""
inputImage = filteredInputImage = None
inputImage_label = filterInputImage_label = outputImage_label =filteredOutputImage_label= None #phục vụ cho việc hiển thị tkinter
outputImage = outputImagePIL = outputImageBGR = None #phục vụ cho việc xử lý tính toán bên dưới



"""Cửa số làm việc chính, hiển thị ảnh đầu vào, ảnh đầu vào đã lọc nhiễu, ảnh đầu ra, ảnh đầu ra đã lọc nhiễu"""
def program_():
    window.destroy()
    global program 
    program = tk.Tk()
    program.title("Program")
    program.geometry("1100x600")
    
    #TRANG TRÍ NỀN MÀU
    canvasBack = tk.Canvas(program, bg="#97FFFF") #xanh nhạt
    canvasBack.place(x=0, y=0, width=1100, height=230)
    #THÊM LABEL
    caption_label = tk.Label(program, text="COLORIZE GRAYSCALE IMAGE", font=("Arial", 30), bg="#97FFFF")
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

    inputImage_label = tk.Label(program,highlightthickness=1, highlightbackground="black")
    inputImage_label.place(x = 10, y = 250, width = 256, height = 256)
    # Tạo một Label mới để hiển thị chú thích
    caption_label = tk.Label(program, text="ORIGINAL IMAGE", bg="white")
    caption_label.place(x=10, y=510, width=256, height=20)

    filterInputImage_label = tk.Label(program,highlightthickness=1, highlightbackground="black")
    filterInputImage_label.place(x = 270, y = 250, width = 256, height = 256)
    # Tạo một Label mới để hiển thị chú thích
    caption_label = tk.Label(program, text="FILTERED INPUT IMAGE", bg="white")
    caption_label.place(x=270, y=510, width=256, height=20)

    outputImage_label = tk.Label(program,highlightthickness=1, highlightbackground="red")
    outputImage_label.place(x = 530, y = 250, width = 256, height = 256)
    # Tạo một Label mới để hiển thị chú thích
    caption_label = tk.Label(program, text="COLORED IMAGE", bg="white")
    caption_label.place(x=530, y=510, width=256, height=20)

    filteredOutputImage_label = tk.Label(program,highlightthickness=1, highlightbackground="red")
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

"""Hàm lọc nhiễu ảnh dùng thuật toán lọc trung vị"""
def medianFilterImage(image):
    if image is None:
        return
    kSize = 7
    width, height = image.shape
    medianFilteredImage = np.zeros([width, height,3])
    h = (kSize-1) // 2
    paddedImage = np.pad(image, (h, h), mode='reflect')
    for i in range(width):
        for j in range(height):
            windowSizeK = paddedImage[i:i+kSize, j:j+kSize]
            medianValue = np.median(windowSizeK)
            medianFilteredImage[i, j,:] = medianValue  
    return medianFilteredImage

"""Hàm kết hợp hầm lọc nhiễu và sắc nét, sau đó resize về (256, 256) và hiển thị ảnh """
def filterInputImage(image):
    if image is None:
        return
    global filteredInputImage
    
    #Tiền xử lý
    imageSmoothed = medianFilterImage(image)
    imageSharpenedRgbPil = Image.fromarray(imageSmoothed.astype(np.uint8)).resize((256, 256))
    
    #dùng để hiển thị ảnh đầu vào sau khi đã xử lý
    filteredInputImage = imageSharpenedRgbPil 
    image_tk = ImageTk.PhotoImage(imageSharpenedRgbPil)
    filterInputImage_label.configure(image=image_tk)
    filterInputImage_label.image = image_tk

"""Hàm dùng model đã được load từ đầu chương trình để tô màu ảnh với kích thước đầu vào là (1, 256, 256, 3)"""
def colorizeImage(input_img):
    
    global outputImage,outputImagePIL,outputImageBGR
   
    #chuẩn hóa giá trị đầu vào cho model
    colorizedImage = []
    colorizedImage.append(img_to_array(input_img)) #(1,256,256,3)
    colorizedImage = np.array(colorizedImage, dtype=float) 
    colorizedImage = rgb2lab(1.0 / 255.0 * colorizedImage)[:, :, :, 0] #(1,256,256)
    colorizedImage = colorizedImage.reshape(colorizedImage.shape + (1,)) #(1,256,256,1)

    #giá trị đầu ra của model AI
    output = loaded_model.predict(colorizedImage)
    output = output * 128

    #Tạo ma trận 3 kênh
    cur = np.zeros((256, 256, 3))       
    
    #lọc nhiễu và làm nét kênh l để tiến hành gán giá trị
    colorizedImageBlurChannelL = cv2.GaussianBlur(colorizedImage[:,:, :, 0], (3, 3), 3)
    colorizedImage[:,:, :, 0] = cv2.addWeighted(colorizedImage[:,:, :, 0], 1.5, colorizedImageBlurChannelL, -0.5, 0)

    #Tiến hành gán giá trị màu kênh l a b cho các kênh
    for x in range(256):
        for y in range(256):

            l = colorizedImage[:,x,y,0]
            a = output[:, x, y, 0] * 2
            b = output[:, x, y, 1] * 2
            
            if(l<0):l=0
            if(l>100):l=100
             
            cur[x, y, 0] = l    
            cur[x, y, 1] = a
            cur[x, y, 2] = b
            
    #chuyển lại sang kênh màu RGB để xử lý
    outputImage = lab2rgb(cur) #giá trị pixel nằm trong khoảng 0-1
    
    #chuẩn hóa lại giá trị pixel của ảnh đầu ra (chưa qua lọc đầu ra - hậu xử lý)
    outputImage = (outputImage * 255).astype(np.uint8)
    
    #xử lý bên dưới (trong hàm bitwise_and)
    outputImageBGR = cv2.cvtColor(outputImage, cv2.COLOR_RGB2BGR) 
    
    #Hiển thị ảnh đầu ra khi chưa qua hậu xử lý
    outputImagePIL = Image.fromarray(outputImage) 
    outputImagePIL_tk = ImageTk.PhotoImage(outputImagePIL) 
    global outputImage_label 
    outputImage_label.configure(image=outputImagePIL_tk)
    outputImage_label.image = outputImagePIL_tk

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

"""Hàm lấy giá trị ngưỡng từ người dùng để xử lý và hiển thị ảnh đầu ra đã được lọc, và các mask của ảnh đó"""
def applyThreshold(channelRed,channelGreen, channelBlue,entry):
    global thresholdValue  
    try:
        thresholdValue = int(entry.get())
        maskRed=updateThreshold(channelRed, thresholdValue,0,280)
        maskGreen=updateThreshold(channelGreen, thresholdValue,260,280)
        maskBlue = updateThreshold(channelBlue, thresholdValue,520,280)
        
        global maskedBlue_getPixel,maskedGreen_getPixel,maskedRed_getPixel
        maskedRed_getPixel = Image.fromarray(maskRed)
        maskedGreen_getPixel = Image.fromarray(maskGreen)
        maskedBlue_getPixel = Image.fromarray(maskBlue)
        
        maskImageRed = cv2.bitwise_and(outputImageBGR,outputImageBGR, mask=maskRed)
        maskImageGreen = cv2.bitwise_and(outputImageBGR,outputImageBGR, mask=maskGreen)
        maskImageBlue = cv2.bitwise_and(outputImageBGR,outputImageBGR, mask=maskBlue)
        
        rgbImageRed = cv2.cvtColor(maskImageRed, cv2.COLOR_BGR2RGB)
        rgbImageGreen = cv2.cvtColor(maskImageGreen, cv2.COLOR_BGR2RGB)
        rgbImageBlue = cv2.cvtColor(maskImageBlue, cv2.COLOR_BGR2RGB)

        displayImage(rgbImageRed,0,540)
        displayImage(rgbImageGreen,260,540)
        displayImage(rgbImageBlue,520,540)
        
        global filteredOutputImage,maskedFilteredImageRed,maskedFilteredImageGreen,maskedFilteredImageBlue
        
        filteredOutputImage = Image.new(outputImagePIL.mode, outputImagePIL.size)
        maskedFilteredImageRed = Image.new(outputImagePIL.mode,outputImagePIL.size)
        maskedFilteredImageBlue = Image.new(outputImagePIL.mode,outputImagePIL.size)
        maskedFilteredImageGreen = Image.new(outputImagePIL.mode,outputImagePIL.size)
        
        
        for x in range(256):
            for y in range(256):
                
                pixelR = maskedRed_getPixel.getpixel((x,y))
                pixelG = maskedGreen_getPixel.getpixel((x,y)) #anh nhi phan
                pixelB = maskedBlue_getPixel.getpixel((x,y))
                
                r,g,b=outputImagePIL.getpixel((x,y)) # anh BGR
                
                if((b>=0) &(pixelB!=0) ):
                    b=r/3.03
                    b=(np.uint8(b)) 
                  
                if((g>=0)&(pixelG!=0)):
                    g=r/2.05
                    g=(np.uint8(g))
                  
                if((r>=10)&(pixelR!=0)):
                    r=r/0.9
                    r=(np.uint8(r))
      
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
def applyFilter(entryRed,entryGreen,entryBlue,entry_division_red,entry_division_green,entry_division_blue):
    global filteredOutputImage,maskedFilteredImageRed,maskedFilteredImageGreen,maskedFilteredImageBlue
    try:
        #Lấy giá trị các ô
        thresholdRed = int(entryRed.get())
        thresholdGreen = int(entryGreen.get())
        thresholdBlue = int(entryBlue.get())
        
        divisionRed = float(entry_division_red.get())
        divisionGreen = float(entry_division_green.get())
        divisionBlue = float(entry_division_blue.get())
        
        for x in range(256):
            for y in range(256):
                pixelR = maskedRed_getPixel.getpixel((x,y))
                pixelG = maskedGreen_getPixel.getpixel((x,y)) # ảnh nhị phân nên hàm getpixel chỉ trả về 1 giá trị
                pixelB = maskedBlue_getPixel.getpixel((x,y))
                
                r,g,b=outputImagePIL.getpixel((x,y)) # anh RGB
                
                if((b>=thresholdBlue)&(pixelB!=0)):
                    b=r/divisionBlue
                    b   =(np.uint8(b))
                  
                if((g>=thresholdGreen)&(pixelG!=0)):

                    g=r/divisionGreen
                    g   =(np.uint8(g))
                  
                if((r>=thresholdRed)&(pixelR!=0)):
                    
                    r=r/divisionRed
                    r  = (np.uint8(r))
                     
                filteredOutputImage.putpixel((x,y),(r,g,b))  #ảnh đầu ra qua hậu xử lý
                maskedFilteredImageRed.putpixel((x,y),(r,0,0))  #kênh màu r khi qua hậu xử lý
                maskedFilteredImageGreen.putpixel((x,y),(0,g,0)) #kênh màu green khi qua hậu xử lý
                maskedFilteredImageBlue.putpixel((x,y),(0,0,b)) #kênh màu blue khi qua hậu xử lý
        
        #Tiến hành chuyển đổi để có thể sử dụng hàm displayImage để hiển thị            
        maskedFilteredImageRed_array = np.array(maskedFilteredImageRed, dtype=np.uint8)
        maskedFilteredImageGreen_array = np.array(maskedFilteredImageBlue, dtype=np.uint8)
        maskedFilteredImageBlue_array = np.array(maskedFilteredImageGreen, dtype=np.uint8)
        #Hiển thị các ảnh kênh r,g,b qua hậu xử lý
        displayImage(maskedFilteredImageRed_array,0,800)
        displayImage(maskedFilteredImageBlue_array,260,800)
        displayImage(maskedFilteredImageGreen_array,520,800)
        
        #Hiển thị giá trị ảnh đầu ra khi khi đã qua hậu xử lý
        filterOutputImage_tk = ImageTk.PhotoImage(filteredOutputImage)
        filteredOutputImage_label.configure(image=filterOutputImage_tk)
        filteredOutputImage_label.image = filterOutputImage_tk 
        
    except ValueError:
        messagebox.showerror("Error", "Invalid threshold value. Please enter an integer.")

"""Hàm tạo cửa số mới, dùng để nhập các giá trị để lọc ảnh đầu ra"""
def filterOutputImage_window():
    
    #cấu hình
    new_window = tk.Toplevel(program)
    new_window.title("FILTERS PARAMETERS")
    new_window.geometry("1200x700")
    
    #tạo frame để tạo thanh cuộn
    frame = tk.Frame(new_window)
    frame.pack(fill=tk.BOTH, expand=True)
    
     #TRANG TRÍ NỀN MÀU
    canvasBack = tk.Canvas(new_window, bg="#79CDCD")
    canvasBack.place(x=780, y=92, width=400, height=100)
    
    canvasBack = tk.Canvas(new_window, bg="#EEE8AA")
    canvasBack.place(x=780, y=192, width=400, height=300)
    
    label = tk.Label(new_window, text="FILTERS PARAMETERS",font=("Arial", 15), bg="#EEE8AA")
    label.place(x = 820, y = 420, width = 300, height = 50)
    
    # Tạo thanh cuộn dọc
    scrollbar = tk.Scrollbar(frame)
    scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
    
    # Tạo một Canvas để hiển thị hình ảnh, liên kết với cái thanh cuộn
    global canvas
    canvas = tk.Canvas(frame, yscrollcommand=scrollbar.set)
    canvas.pack(side=tk.LEFT, fill=tk.BOTH, expand=True) #vị trí
    
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
    ok_button = tk.Button(new_window, text="OK",command=lambda: applyFilter(entryRed,entryGreen,entryBlue,entry_division_red,entry_division_green,entry_division_blue))
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

#hiển thị ảnh nền
img_path = r'trangBia3.jpg'
img = Image.open(img_path)
img_tk = ImageTk.PhotoImage(img)
img_label = tk.Label(window, image=img_tk)
img_label.place(x = 0, y= 0, width = 1200, height= 700)

#nút ấn
button = tk.Button(window, text="Click me!", command=program_)

#vị trí nút ấn
button.place(x = 900, y = 600, width = 100, height = 50)
window.mainloop()   

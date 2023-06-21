import cv2
import numpy as np
from PIL import Image
from scipy.signal import convolve2d
def SharpenImage(hinhgoc):
    imgPIL = Image.open(hinhgoc) #mở ảnh gốc
    rgb = np.zeros((3,3,3)) #ma trận chứa giá trị điểm ảnh tại 4 điểm lân cận và điểm đang xét
    mask = (-1) * np.array([[0, 1, 0], 
                            [1, -4, 1], #mặt nạ với c = -1
                            [0, 1, 0]])
    imgSharpenImage = Image.new(imgPIL.mode, imgPIL.size) #tạo ảnh mới để lưu ảnh sắc nét có kích thước giống ảnh gốc
    
    for x in range(1, imgPIL.width - 1):
        for y in range(1, imgPIL.height - 1):
                rgb[:3, 1, 1] = imgPIL.getpixel((x, y))
                rgb[:3, 1, 2] = imgPIL.getpixel((x + 1, y))
                rgb[:3, 1, 0] = imgPIL.getpixel((x - 1, y))  #lấy giá trị điểm ảnh tại 4 điểm lân cận và điểm đang xét
                rgb[:3, 2, 1] = imgPIL.getpixel((x, y + 1))
                rgb[:3, 0, 1] = imgPIL.getpixel((x, y - 1))
                
                Rs = convolve2d(rgb[0], mask, mode = 'valid') + rgb[0, 1, 1]
                Gs = convolve2d(rgb[1], mask, mode = 'valid') + rgb[1, 1, 1] #nhân tích chập của ma trận điểm ảnh với mặt nạ
                Bs = convolve2d(rgb[2], mask, mode = 'valid') + rgb[2, 1, 1] # + với giá trị điểm ảnh tại điểm đang xét

                """if (Rs > 255): 
                    Rs = int(255)
                elif (Rs < 0):
                    Rs = int(0)
                else: Rs = int(Rs)"""

                Rs = int(max(0, min(Rs, 255))) #giới hạn giá trị điểm ảnh trong khoảng 0-255

                """if (Gs > 255):
                    Gs = int(255)
                elif (Gs < 0):
                    Gs = int(0)
                else:Gs = int(Gs)"""

                Gs = int(max(0, min(Gs, 255))) #giới hạn giá trị điểm ảnh trong khoảng 0-255

                """if (Bs > 255):
                    Bs = int(255)
                elif (Bs < 0):
                    Bs = int(0)
                else: Bs = int(Bs)"""

                Bs = int(max(0, min(Bs, 255))) #giới hạn giá trị điểm ảnh trong khoảng 0-255
                
                imgSharpenImage.putpixel((x, y), (Bs, Gs, Rs)) #gán giá trị điểm ảnh sau khi xử lý cho điểm ảnh tại vị trí (x,y)
    return np.array(imgSharpenImage)


FileHinh = r'lena_color.jpg'
HinhGoc = cv2.imread(FileHinh,cv2.IMREAD_COLOR)
HinhSharpen = SharpenImage(FileHinh)
cv2.imshow('HinhGoc', HinhGoc)
cv2.imshow('Hinh SharpenImage',HinhSharpen)
cv2.waitKey(0)
cv2.destroyAllWindows()
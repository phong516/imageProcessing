import numpy as np
from PIL import Image
import cv2

def RGBtoBinary(hinhGoc):
    binary = Image.open(hinhGoc)
    for x in range(binary.width):
        for y in range(binary.height):
            R, G, B = binary.getpixel((x, y))

            b = np.uint8(0.2126 * R + 0.7152 * G + 0.0722 * B)

            binaryValue = 0 if (b < 100) else 255

            binary.putpixel((x, y), (binaryValue, binaryValue, binaryValue))
    return np.array(binary)

"""Co"""

def erosion(imgBinary):
    imgErosion = np.array(imgBinary)
    mask = np.array([[0, 1, 0], 
                     [1, 1, 1], 
                     [0, 1, 0]])
    for x in range(0, imgBinary.shape[0]):
        for y in range(0, imgBinary.shape[1]):
            is_match = True
            for i in range(0, 3):
                for j in range(0, 3):
                    pixelX = x - 1 + i
                    pixelY = y - 1 + j
                    if (pixelX < 0 or pixelY < 0 or pixelX > (imgBinary.shape[0] - 1) or pixelY > (imgBinary.shape[1] -1)):
                        continue
                    b = imgBinary[pixelX, pixelY, 0]
                    if mask[i, j] == 1 and b != 0:  #trắng, khác mask đen
                        is_match = False
                        break
                if not is_match:
                    break
            if is_match:
                imgErosion[x, y, :3] = [0, 0, 0]
            else: 
                imgErosion[x, y, :3] = [255, 255, 255]
    return imgErosion


"""Giãn"""
def dilation(imgBinary):
    imgDilation = np.array(imgBinary)
    mask = np.array([[0, 1, 0], 
                     [1, 1, 1], 
                     [0, 1, 0]])
    for x in range(0, imgBinary.shape[0]):
        for y in range(0, imgBinary.shape[1]):
            is_match = False
            for i in range(0, 3):
                for j in range(0, 3):
                    pixelX = x - 1 + i
                    pixelY = y - 1 + j
                    if (pixelX < 0 or pixelY < 0 or pixelX > (imgBinary.shape[0] - 1) or pixelY > (imgBinary.shape[1] -1)):
                        continue
                    b = imgBinary[pixelX, pixelY, 0]
                    if mask[i, j] == 1 and b == 0: #trùng 1 pixel đen, mask đen
                        is_match = True
                        break
                if is_match:
                    break
            if is_match:
                imgDilation[x, y, :3] = [0, 0, 0] #gán màu đen
            else:
                imgDilation[x, y, :3] = [255, 255, 255] #gán màu trắng
    return imgDilation

"""Mở"""
"""Xóa bỏ những đoạn mảnh, loại bỏ nhiễu nhưng làm tăng số đoạn đứt gãy"""
def opening(imgBinary):
    imgEro = erosion(imgBinary)
    imgOpening = dilation(imgEro)
    return imgOpening

"""Đóng"""
"""Làm trơn biên ảnh và kết nối các vùng của cùng một đối tượng"""
def closing(imgBinary):
    imgDil = dilation(imgBinary)
    imgOpening = erosion(imgDil)
    return imgOpening

def boundary_extraction(imgBinary):
    eroImg = erosion(imgBinary)
    img = np.array(imgBinary)
    for x in range(0, img.shape[0]):
        for y in range(0, img.shape[1]):
            if eroImg[x, y, 0] == 255:
                eroImg[x, y, :3] = [0, 0, 0]
            else:
                eroImg[x, y, :3] = [255, 255, 255]

            if img[x, y, 0] == 255:
                eroImg[x, y, :3] = [255, 255, 255]
                
    return eroImg

fileHinh = r'lena_color.jpg'
imgBin = RGBtoBinary(fileHinh)
dilationImg = dilation(imgBin)
erosionImg = erosion(imgBin)
openingImg = opening(imgBin)
closingImg = closing(imgBin)
boundaryImg = boundary_extraction(imgBin)
cv2.imshow('imgBinary', imgBin)
cv2.imshow('dilationImg', dilationImg)
cv2.imshow('erosionImg', erosionImg)
cv2.imshow('openingsImg', openingImg)
cv2.imshow('closingsImg', closingImg)
cv2.imshow('boundaryImg', boundaryImg)
cv2.waitKey(0)
cv2.destroyAllWindows()
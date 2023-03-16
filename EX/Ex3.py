import numpy as np
from PIL import Image
import cv2

def RGBtoBinary(hinhGoc):
    binary = Image.open(hinhGoc)
    for x in range(binary.width):
        for y in range(binary.height):
            R, G, B = binary.getpixel((x, y))

            gray = np.uint8(0.2126 * R + 0.7152 * G + 0.0722 * B)

            binaryValue = 0 if (gray < 125) else 255

            binary.putpixel((x, y), (binaryValue, binaryValue, binaryValue))
    return np.array(binary)

def dilation(imgBinary):
    imgDilation = np.array(imgBinary)
    mask =   np.array([[255, 0, 255], 
                       [0, 0, 0], 
                       [255, 0, 255]])
    for x in range(1, imgBinary.shape[0] - 1):
        for y in range(1, imgBinary.shape[1] - 1):
            for i in range(0, 3):
                for j in range(0, 3):
                    pixelX = x - 1 + i
                    pixelY = y - 1 + j
                    g = imgBinary[pixelX, pixelY, 0]
                    if ((mask[i, j] == 0) and (mask[i, j] == g)):
                        imgDilation[x, y, :3] = [0, 0, 0]
                        break
                else:
                    continue
                break   
    return imgDilation

def erosion(imgBinary):
    imgErosion = np.array(imgBinary)
    mask =   np.array([[255, 0, 255], 
                       [ 0,  0,  0], 
                       [255, 0, 255]])
    for x in range(1, imgBinary.shape[0] - 1):
        for y in range(1, imgBinary.shape[1] - 1):
            count = 0
            for i in range(0, 3):
                for j in range(0, 3):
                    pixelX = x - 1 + i
                    pixelY = y - 1 + j
                    g = imgBinary[pixelX, pixelY, 0]
                    if ((mask[i, j] == 0) and (mask[i, j] == g)):
                        count += 1
            if (count == 5):
                imgErosion[x, y, :3] = [0, 0, 0]
            else:
                imgErosion[x, y, :3] = [255, 255, 255]
    return imgErosion 

def opening(imgBinary):
    imgEro = erosion(imgBinary)
    imgOpening = dilation(imgEro)
    return imgOpening

def closing(imgBinary):
    imgDil = dilation(imgBinary)
    imgOpening = erosion(imgDil)
    return imgOpening

fileHinh = r'lena_color.jpg'
imgBin = RGBtoBinary(fileHinh)
dilationImg = dilation(imgBin)
erosionImg = erosion(imgBin)
openingImg = opening(imgBin)
closingImg = closing(imgBin)
cv2.imshow('imgBinary', imgBin)
cv2.imshow('dilationImg', dilationImg)
cv2.imshow('erosionImg', erosionImg)
cv2.imshow('openingsImg', openingImg)
cv2.imshow('closingsImg', closingImg)
cv2.waitKey(0)
cv2.destroyAllWindows()
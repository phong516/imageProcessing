import numpy as np
from PIL import Image
import cv2

def RGBtoBinary(hinhGoc):
    binary = Image.open(hinhGoc)
    for x in range(binary.width):
        for y in range(binary.height):
            R, G, B = binary.getpixel((x, y))

            gray = np.uint8(0.2126 * R + 0.7152 * G + 0.0722 * B)

            binaryValue = 0 if (gray < 100) else 255

            binary.putpixel((x, y), (binaryValue, binaryValue, binaryValue))
    return np.array(binary)

def dilation(imgBinary):
    imgDilation = np.array(imgBinary)
    mask =   np.array([[255, 0, 255], 
                       [0, 0, 0], 
                       [255, 0, 255]])
    for x in range(1, imgBinary.shape[0] - 1):
        for y in range(1, imgBinary.shape[1] - 1):
            is_mask = False
            for i in range(0, 3):
                for j in range(0, 3):
                    pixelX = x - 1 + i
                    pixelY = y - 1 + j
                    g = imgBinary[pixelX, pixelY, 0]
                    if mask[i, j] == 255 and g == 255:
                        is_mask = True
                        break
                if is_mask:
                    break
            if is_mask:
                imgDilation[x, y, :3] = [255, 255, 255]
    return imgDilation

def erosion(imgBinary):
    imgErosion = np.array(imgBinary)
    mask = np.array([[255, 0, 255], 
                     [0, 0, 0], 
                     [255, 0, 255]])
    for x in range(1, imgBinary.shape[0] - 1):
        for y in range(1, imgBinary.shape[1] - 1):
            is_mask = True
            for i in range(0, 3):
                for j in range(0, 3):
                    pixelX = x - 1 + i
                    pixelY = y - 1 + j
                    g = imgBinary[pixelX, pixelY, 0]
                    if mask[i, j] == 255 and g != 255:
                        is_mask = False
                        break
                if not is_mask:
                    break
            if is_mask:
                imgErosion[x, y, :3] = [255, 255, 255]
            else:
                imgErosion[x, y, :3] = [0, 0, 0]
    return imgErosion


def opening(imgBinary):
    imgEro = erosion(imgBinary)
    imgOpening = dilation(imgEro)
    return imgOpening

def closing(imgBinary):
    imgDil = dilation(imgBinary)
    imgOpening = erosion(imgDil)
    return imgOpening

def boundary_extraction(imgBinary):
    eroImg = erosion(imgBinary)
    img = np.array(imgBinary)
    for x in range(0, imgBinary.shape[0]):
        for y in range(0, imgBinary.shape[1]):
            if img[x, y, 0] == 0:
                eroImg[x, y, :3] = [255, 255, 255]
                
            if eroImg[x, y, 0] == 255:
                eroImg[x, y, :3] = [0, 0, 0]
            else:
                eroImg[x, y, :3] = [255, 255, 255]

    return eroImg

fileHinh = r'lena_color.jpg'
imgBin = RGBtoBinary(fileHinh)
#dilationImg = dilation(imgBin)
#erosionImg = erosion(imgBin)
#openingImg = opening(imgBin)
#closingImg = closing(imgBin)
boundaryImg = boundary_extraction(imgBin)
#cv2.imshow('imgBinary', imgBin)
#cv2.imshow('dilationImg', dilationImg)
#cv2.imshow('erosionImg', erosionImg)
#cv2.imshow('openingsImg', openingImg)
#cv2.imshow('closingsImg', closingImg)
cv2.imshow('boundaryImg', boundaryImg)
cv2.waitKey(0)
cv2.destroyAllWindows()
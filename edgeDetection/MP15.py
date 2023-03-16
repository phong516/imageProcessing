import cv2
import numpy as np
from PIL import Image
from math import atan2, sqrt

def edgeDetectionRGB(directory, threshold):
    imgPIL = Image.open(directory)
    imgEdgeRGB = Image.new(imgPIL.mode, imgPIL.size)
    sobelX = np.array([[-1, -2, -1], 
                       [0, 0, 0], 
                       [1, 2, 1]])
    sobelY = np.array([[-1, 0, 1], 
                       [-2, 0, 2], 
                       [-1, 0, 1]])
    for x in range(1, imgEdgeRGB.width - 1):
        for y in range(1, imgEdgeRGB.height - 1):
            gxR = gyR = gxG = gyG = gxB = gyB = 0
            gxX = gyY = gXY = 0
            f0 = 0
            theta = 0
            for i in range(0, 3):
                for j in range(0, 3):
                    pixelX = x - 1 + i
                    pixelY = y - 1 + j
                    R, G, B = imgPIL.getpixel((pixelX, pixelY))
                    gxR += sobelX[i, j] * R
                    gyR += sobelY[i, j] * R

                    gxG += sobelX[i, j] * G
                    gyG += sobelY[i, j] * G

                    gxB += sobelX[i, j] * B
                    gyB += sobelY[i, j] * B

            
            gxX = gxR * gxR + gxG * gxG + gxB * gxB
            gyY = gyR * gyR + gyG * gyG + gyB * gyB
            gXY = gxR * gyR + gxG * gyG + gxB * gyB

            theta = atan2(2 * gXY, gxX - gyY) / 2   

            f0 = sqrt(0.5 * ((gxX + gyY) \
                              + (gxX - gyY) * np.cos(2 * theta) \
                              + 2 * gXY * np.sin(2 * theta) ))
            if (f0 <= threshold): imgEdgeRGB.putpixel((x, y), (0, 0, 0))
            else: imgEdgeRGB.putpixel((x, y), (255, 255, 255))

    return np.array(imgEdgeRGB)

fileHinh = r'lena_color.jpg'
hinhRGB = cv2.imread(fileHinh, cv2.IMREAD_COLOR)
hinhEdgeRGB = edgeDetectionRGB(fileHinh, 130)
cv2.imshow('Hinh RGB',hinhRGB)
cv2.imshow('hinh Edge RGB',hinhEdgeRGB)
cv2.waitKey(0)
cv2.destroyAllWindows()

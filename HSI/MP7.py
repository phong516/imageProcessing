import cv2
import numpy as np
from PIL import Image
from math import sqrt
from math import acos
from math import pi

def RGBtoHSI(filehinh):
    imgPIL = Image.open(filehinh)
    imgH = Image.new(imgPIL.mode, imgPIL.size)
    imgS = Image.new(imgPIL.mode, imgPIL.size)
    imgI = Image.new(imgPIL.mode, imgPIL.size)
    imgHSI = Image.new(imgPIL.mode, imgPIL.size)
    HSI = []
    for x in range(imgPIL.width):
        for y in range(imgPIL.height):
            R, G, B = imgPIL.getpixel((x, y))
            theta1 = ((R - G) + (R - B)) * 0.5
            theta2 = sqrt((R - G) * (R - G) + (R - B) * (G - B))
            theta = acos(theta1 / theta2)
            H = theta if (B <= G) else (2 * pi - theta)
            # convert radians to degrees
            H *= 180 / pi

            S = 1.0 - 3.0 * min(R, G, B) / (R + G + B)
            S *= 255.0

            I = (R + G + B) / 3.0

            H = np.uint8(H)
            S = np.uint8(S)
            I = np.uint8(I)
            
            imgH.putpixel((x, y), (H, H, H))
            imgS.putpixel((x, y), (S, S, S))
            imgI.putpixel((x, y), (I, I, I))
            imgHSI.putpixel((x, y), (I, S, H))

    HSI.append(np.array(imgH))
    HSI.append(np.array(imgS))
    HSI.append(np.array(imgI))
    HSI.append(np.array(imgHSI))
    return HSI

FileHinh = r'lena_color.jpg'
HinhRGB = cv2.imread(FileHinh, cv2.IMREAD_COLOR)
AnhH, AnhS, AnhI, AnhHSI = RGBtoHSI(FileHinh)
cv2.imshow('Hinh RGB', HinhRGB)
cv2.imshow('Hinh Hue', AnhH)
cv2.imshow('Hinh Saturation', AnhS)
cv2.imshow('Hinh Intensity', AnhI)
cv2.imshow('Hinh HSI', AnhHSI)

cv2.waitKey(0)
cv2.destroyAllWindows()
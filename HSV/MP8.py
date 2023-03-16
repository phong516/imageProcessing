import cv2
import numpy as np
from PIL import Image
from math import sqrt
from math import acos
from math import pi
def RGBtoHSV(filehinh):
    imgPIL = Image.open(filehinh)
    imgH = Image.new(imgPIL.mode, imgPIL.size)
    imgS = Image.new(imgPIL.mode, imgPIL.size)
    imgV = Image.new(imgPIL.mode, imgPIL.size)
    imgHSV = Image.new(imgPIL.mode, imgPIL.size)
    HSV = []
    for x in range(imgPIL.width):
        for y in range(imgPIL.height):
            R, G, B = imgPIL.getpixel((x, y))
            theta1 = ((R - B) + (R - G)) * 0.5
            theta2 = sqrt((R - G) * (R - G) + (R - B) * (G - B))
            theta = acos(theta1 / theta2)
            H = theta if (B <= G) else (2 * pi - theta)
            # convert radians to degrees
            H *= 180 / pi
            
            S = 1 - 3 * min(R, G, B) / (R + G + B)
            S *= 255

            V = max(R, G, B)

            H = np.uint8(H)
            S = np.uint8(S)
            V = np.uint8(V)

            imgH.putpixel((x, y), (H, H, H))
            imgS.putpixel((x, y), (S, S, S))
            imgV.putpixel((x, y), (V, V, V))
            imgHSV.putpixel((x, y), (V, S, H))

    HSV.append(np.array(imgH))
    HSV.append(np.array(imgS))
    HSV.append(np.array(imgV))
    HSV.append(np.array(imgHSV))
    return HSV

FileHinh = r'lena_color.jpg'
HinhRGB = cv2.imread(FileHinh, cv2.IMREAD_COLOR)
AnhH, AnhS, AnhV, AnhHSV = RGBtoHSV(FileHinh)

cv2.imshow('Hinh RGB', HinhRGB)
cv2.imshow('Hinh Hue', AnhH)
cv2.imshow('Hinh Saturation', AnhS)
cv2.imshow('Hinh Value', AnhV)
cv2.imshow('Hinh HSV', AnhHSV)

cv2.waitKey(0)
cv2.destroyAllWindows()
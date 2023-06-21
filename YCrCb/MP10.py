import cv2
import numpy as np
from PIL import Image

def RGBtoYCbCr(filehinh):
    imgPIL = Image.open(filehinh)
    imgY = Image.new(imgPIL.mode, imgPIL.size)
    imgCr = Image.new(imgPIL.mode, imgPIL.size)
    imgCb = Image.new(imgPIL.mode, imgPIL.size)
    imgYCbCr = Image.new(imgPIL.mode, imgPIL.size)
    YCbCr = []

    for x in range(imgPIL.width):
        for y in range(imgPIL.height):
            R, G, B = imgPIL.getpixel((x, y))

            Y = 16 + (65.738 / 256) * R + (129.057 / 256) * G + (25.064 / 256) * B
            Cr = 128 - (37.945 / 256) * R - (74.494 / 256) * G + (112.439 / 256) * B
            Cb = 128 + (112.439 / 256) * R - (94.154 / 256) * G - (18.285 / 256) * B

            Y = np.uint8(Y)
            Cr = np.uint8(Cr)
            Cb = np.uint8(Cb)

            imgY.putpixel((x, y), (Y, Y, Y))
            imgCr.putpixel((x, y), (Cr, Cr, Cr))
            imgCb.putpixel((x, y), (Cb, Cb, Cb))
            imgYCbCr.putpixel((x, y), (Cr, Cb, Y))

    YCbCr.append(np.array(imgY))
    YCbCr.append(np.array(imgCb))
    YCbCr.append(np.array(imgCr))
    YCbCr.append(np.array(imgYCbCr))
    return YCbCr

FileHinh = r'lena_color.jpg'
HinhRGB = cv2.imread(FileHinh, cv2.IMREAD_COLOR)
AnhY, AnhCr, AnhCb, AnhYCbCr = RGBtoYCbCr(FileHinh)

cv2.imshow('Hinh RGB', HinhRGB)
cv2.imshow('Hinh Y', AnhY)
cv2.imshow('Hinh Cr', AnhCr)
cv2.imshow('Hinh Cb', AnhCb)
cv2.imshow('Hinh YCbCr', AnhYCbCr)

cv2.waitKey(0)
cv2.destroyAllWindows()

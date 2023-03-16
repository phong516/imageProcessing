import cv2
import numpy as np
from PIL import Image

def RGBtoXYZ(filehinh):
    imgPIL = Image.open(filehinh)
    imgX = Image.new(imgPIL.mode, imgPIL.size)
    imgY = Image.new(imgPIL.mode, imgPIL.size)
    imgZ = Image.new(imgPIL.mode, imgPIL.size)
    imgXYZ = Image.new(imgPIL.mode, imgPIL.size)
    XYZ = []
    cf = np.array([[0.4124564, 0.3575761, 0.01804375],
                  [0.2126729, 0.7151522, 0.0721750],
                  [0.0193339, 0.1191920, 0.9503041]])
    for x in range(imgPIL.width):
        for y in range(imgPIL.height):
            R, G, B = imgPIL.getpixel((x, y))
            X, Y, Z = np.dot(cf, [R, G, B])

            X = np.uint8(X)
            Y = np.uint8(Y)
            Z = np.uint8(Z)

            imgX.putpixel((x, y), (X, X, X))
            imgY.putpixel((x, y), (Y, Y, Y))
            imgZ.putpixel((x, y), (Z, Z, Z))
            imgXYZ.putpixel((x, y), (Z, Y, X))

    XYZ.append(np.array(imgX))
    XYZ.append(np.array(imgY))
    XYZ.append(np.array(imgZ))
    XYZ.append(np.array(imgXYZ))
    return XYZ

FileHinh = r'lena_color.jpg'
HinhRGB = cv2.imread(FileHinh, cv2.IMREAD_COLOR)
AnhX, AnhY, AnhZ, AnhXYZ = RGBtoXYZ(FileHinh)

cv2.imshow('Hinh RGB', HinhRGB)
cv2.imshow('Hinh X', AnhX)
cv2.imshow('Hinh Y', AnhY)
cv2.imshow('Hinh Z', AnhZ)
cv2.imshow('Hinh XYZ', AnhXYZ)

cv2.waitKey(0)
cv2.destroyAllWindows()
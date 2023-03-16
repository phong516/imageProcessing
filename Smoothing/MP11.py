import cv2
import numpy as np
from PIL import Image

def SmoothingImg(filehinh, mask):
    imgPIL = Image.open(filehinh)
    imgSmooth = Image.new(imgPIL.mode, imgPIL.size)
    K = mask * mask
    offset = int(mask / 2)
    for x in range(offset, imgPIL.width - offset):
        for y in range(offset, imgPIL.height - offset):
            Rs = 0
            Gs = 0
            Bs = 0
            for i in range(x - offset, x + offset + 1):
                for j in range(y - offset, y + offset + 1):
                    R, G, B = imgPIL.getpixel((i, j))
                    Rs += R
                    Gs += G
                    Bs += B
            Rs = int(Rs / K)
            Gs = int(Gs / K)
            Bs = int(Bs / K)
            imgSmooth.putpixel((x, y), (Bs, Gs, Rs))
    return np.array(imgSmooth)

FileHinh = r'lena_color.jpg'
HinhRGB = cv2.imread(FileHinh, cv2.IMREAD_COLOR)

Hinh3x3 = SmoothingImg(FileHinh, 3)
Hinh5x5 = SmoothingImg(FileHinh, 5)
Hinh7x7 = SmoothingImg(FileHinh, 7)
Hinh9x9 = SmoothingImg(FileHinh, 9)

cv2.imshow('Hinh RGB', HinhRGB)
cv2.imshow('Hinh 3x3', Hinh3x3)
cv2.imshow('Hinh 5x5', Hinh5x5)
cv2.imshow('Hinh 7x7', Hinh7x7)
cv2.imshow('Hinh 9x9', Hinh9x9)

cv2.waitKey(0)
cv2.destroyAllWindows()
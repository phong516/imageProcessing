import cv2
import numpy as np
from PIL import Image
import matplotlib.pyplot as plt

def RGBtoLuminanceGrayScale(imgPIL):
    imgPIL = Image.open(filehinh)

    luminance = Image.new(imgPIL.mode, imgPIL.size)

    for y in range(imgPIL.size[1]):
        for x in range(imgPIL.size[0]):
            r, g, b = imgPIL.getpixel((x, y))

            gray = np.uint8(0.2126 * r + 0.7152 * g + 0.0722 * b)

            luminance.putpixel((x, y), (gray, gray, gray))
    return luminance

def TinhHistogram(HinhXamPIL):
    his = np.zeros(256)
    w = HinhXamPIL.size[0]
    h = HinhXamPIL.size[1]
    for y in range (h):
        for x in range(w):
            gR, gG, gB = HinhXamPIL.getpixel((x ,y))

            his[gR]+=1
    return his

def VeBieuDoHistogram(his):
    plt.figure('Bieu do Histogram anh xam', figsize = (5, 4), dpi = 100)
    trucX = np.zeros(256)
    trucX = np.linspace(0, 256, 256)
    plt.plot(trucX, his, color = 'orange')
    plt.title('Bieu do Histogram')
    plt.xlabel('Gia tri muc xam')
    plt.ylabel('So diem cung gia tri muc xam')
    plt.show()


filehinh = r'bird_small.jpg'
img = cv2.imread(filehinh, cv2.IMREAD_COLOR)

imgPIL = Image.open(filehinh)

HinhxamPIL = RGBtoLuminanceGrayScale(imgPIL)

his = TinhHistogram(HinhxamPIL)

hinhxamCV = np.array(HinhxamPIL)
cv2.imshow('Anh goc RGB', img)
cv2.imshow('Anh muc xam', hinhxamCV)

VeBieuDoHistogram(his)

cv2.waitKey(0)
cv2.destroyAllWindows

import cv2
import numpy as np
from PIL import Image

def RGBtoGrayScale(directory):
    imgPIL = Image.open(directory)
    imgGray = Image.new(imgPIL.mode, imgPIL.size)
    for x in range(imgPIL.width):
        for y in range(imgPIL.height):
            R, G, B = imgPIL.getpixel((x, y))
            gray = np.uint8((max(R, G, B) + min(R, G, B))/2)
            imgGray.putpixel((x, y), (gray, gray, gray))
    return imgGray

def TinhHistogram(HinhXamPIL):
    his = np.zeros(256)
    w = HinhXamPIL.size[0]
    h = HinhXamPIL.size[1]
    for y in range (h):
        for x in range(w):
            g= HinhXamPIL.getpixel((x ,y))[0]
            his[g]+=1
    return his

def hisSegmentation(grayImg, Tvalue):
    imgResult = np.array(grayImg)
    for x in range(len(imgResult[0])):
        for y in range(len(imgResult[1])):
            if imgResult[x, y, 0] < Tvalue: 
                imgResult[x, y, :3] = [255 , 255, 255]
            else: 
                imgResult[x, y, :3] = [0, 0, 0]
    return imgResult


def nguongToanCucCoBan(hinhXamPIL, his):
    bins = np.arange(256)
    T_old = np.average(bins, weights= his)
    T_new = 0
    while (abs(T_old - T_new) >= 1 ):
        T_old = T_new
        G1 = []
        G2 = []
        for x in range(hinhXamPIL.size[0]):
            for y in range(hinhXamPIL.size[1]):
                g= hinhXamPIL.getpixel((x ,y))[0]
                if (g > T_old): 
                    G1.append(g)
                else:
                    G2.append(g)
        m1 = np.average(G1)
        m2 = np.average(G2)
        T_new = (m1 + m2) / 2
        if np.isnan(T_new):
            break
    
    if np.isnan(T_new):
        return int(T_old)
    else:
        return int(T_new)

fileHinh = r'lena_color.jpg'
hinhXam = RGBtoGrayScale(fileHinh)

#cv2.imshow('Hinh Xam', np.array(hinhXam))
histogram = TinhHistogram(hinhXam)
#nguongToanCucCoBan(hinhXam, histogram)
hinhHisSegmentation = hisSegmentation(hinhXam, nguongToanCucCoBan(hinhXam, histogram))
cv2.imshow('Hinh Histogram Segmentation', hinhHisSegmentation)
cv2.waitKey(0)
cv2.destroyAllWindows()

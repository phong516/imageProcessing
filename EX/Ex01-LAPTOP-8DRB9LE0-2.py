import cv2
import numpy as np
from PIL import Image

def RGBtoGrayScale(directory):
    imgPIL = Image.open(directory)
    imgGray = Image.new(imgPIL.mode, imgPIL.size)
    for x in range(imgPIL.width):
        for y in range(imgPIL.height):
            R, G, B = imgPIL.getpixel((x, y))
            gray = np.uint8(0.2126*R+0.7152*G+0.0722*B)
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


def calculate_threshold(his, h, w):
    A=[0,0]
    P1=0
    m1=0
    max=0
    for i1 in range(256):
        P1+=his[i1]/(h*w)       # Tính P1(k) theo công thức 4 và 3
        m1+=his[i1]*i1/(h*w)    # Tính m1(k) theo công thức 5
        #print(A)
        P2=0
        m2=0
        for i2 in range(i1+1,256):
            P2+=his[i2]/(h*w)       # Tính P2(k) theo công thức 4 và 3
            m2+=his[i2]*i2/(h*w)    # Tính m2(k) theo công thức 5
            P3=0
            m3=0
            for i3 in range(i2+1,256):
                P3+=his[i3]/(h*w)
                m3+=his[i3]*i3/(h*w)
                
                m1_=m1/P1
                m2_=m2/P2
                m3_=m3/P3
                
                mg=m1+m2+m3
                
                vB = P1*(m1_-mg)*(m1_-mg)+P2*(m2_-mg)*(m2_-mg)+P3*(m3_-mg)*(m3_-mg)
                #print(vB)
                if(vB>max):
                    max=vB
                    A[0]=i1
                    A[1]=i2
    print(A[0])
    return A

fileHinh = r'lena_color.jpg'
hinhXam = RGBtoGrayScale(fileHinh)

#cv2.imshow('Hinh Xam', np.array(hinhXam))
histogram = TinhHistogram(hinhXam)
#nguongToanCucCoBan(hinhXam, histogram)
B = calculate_threshold(histogram, hinhXam.size[0], hinhXam.size[1])
hinhHisSegmentation = hisSegmentation(hinhXam, B[0])
cv2.imshow('Hinh Histogram Segmentation', hinhHisSegmentation)
cv2.waitKey(0)
cv2.destroyAllWindows()

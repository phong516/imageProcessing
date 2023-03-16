import cv2
import numpy as np
from PIL import Image
import matplotlib.pyplot as plt

def TinhHistogram(hinhPIL):
    histogram = np.zeros((3, 256))
    for y in range(hinhPIL.size[1]):
        for x in range(hinhPIL.size[0]):
            r, g, b = hinhPIL.getpixel((x, y))
            histogram[2, r]+=1
            histogram[1, g]+=1
            histogram[0, b]+=1
    return histogram

def VeBieuDoHistogram(his):
    plt.figure("Biểu đồ Histogram RGB", figsize= (7, 4), dpi = 100)
    trucX = np.zeros(256)
    trucX = np.linspace(start= 0, stop= 256, num= 256)
    plt.plot(trucX, his[2], color = 'red')
    plt.plot(trucX, his[1], color = 'green')
    plt.plot(trucX, his[0], color = 'blue')

    plt.title("Biểu đồ Histogram")
    plt.xlabel("Giá trị mức")
    plt.ylabel("Số điểm ảnh có cùng giá trị mức")
    plt.show()

FileHinh = r'bird_small.jpg'
HinhPIL = Image.open(FileHinh)
HinhRGB = cv2.imread(FileHinh, cv2.IMREAD_COLOR)
cv2.imshow("Hinh RGB", HinhRGB)
Histogram = TinhHistogram(HinhPIL)
VeBieuDoHistogram(Histogram)
cv2.waitKey(0)
cv2.destroyAllWindows()
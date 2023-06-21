import cv2
import numpy as np
from PIL import Image
from math import sqrt

def segmentationRGB(imgDirectory, x1, y1, x2, y2, threshold):
    imgPIL = Image.open(imgDirectory)
    imgSegments = Image.new(imgPIL.mode, imgPIL.size)
    size = abs(x1 - x2) * abs(y1 - y2)
    aR = aG = aB = 0
    for i in range(x1, x2):
        for j in range(y1, y2):
            R, G, B = imgPIL.getpixel((i, j))
            aR += R
            aG += G
            aB += B
    aR /=  size
    aG /= size
    aB /= size
    for x in range(imgPIL.width):
        for y in range(imgPIL.height):
            zR, zG, zB = imgPIL.getpixel((x, y))
            Dza = sqrt(pow(zR - aR, 2) + pow(zG - aG, 2) + pow(zB - aB, 2))
            if (Dza <= threshold): imgSegments.putpixel((x, y), (255, 255, 255))
            else: imgSegments.putpixel((x, y), (zB, zG, zR))
    return np.array(imgSegments)

fileHinh = r'lena_color.jpg'
hinhRGB = cv2.imread(fileHinh, cv2.IMREAD_COLOR)
segImg = segmentationRGB(fileHinh, 80, 400, 150, 500, threshold = 45)
cv2.imshow('Hinh RGB', hinhRGB)
cv2.imshow('Hinh Segmentation', segImg)
cv2.waitKey(0)
cv2.destroyAllWindows()

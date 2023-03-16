
import cv2
import numpy as np
from PIL import Image

def RGBtoGrayScale(directory):
    imgPIL = Image.open(directory)
    imgGray = Image.new(imgPIL.mode, imgPIL.size)
    for x in range(imgPIL.width):
        for y in range(imgPIL.height):
            R, G, B = imgPIL.getpixel((x, y))
            gray = int((R + G + B) / 3)
            imgGray.putpixel((x, y), (gray, gray, gray))
    return imgGray

def edgeDetectionGrayscale(imgG, threshold):
    imgEdge = Image.new(imgG.mode, imgG.size)
    sobelX = np.array([[-1, -2, -1], 
                       [0, 0, 0], 
                       [1, 2, 1]])
    sobelY = np.array([[-1, 0, 1], 
                       [-2, 0, 2], 
                       [-1, 0, 1]])    
    for x in range(1, imgG.width - 1):
        for y in range(1, imgG.height - 1):
            gX = 0
            gY = 0

            for i in range (0, 3):
                for j in range (0, 3):
                    pixelX = x - 1 + i
                    pixelY = y - 1 + j
                    G = imgG.getpixel((pixelX, pixelY))[1]
                    gX += sobelX[i, j] * G
                    gY += sobelY[i, j] * G   
            Mxy = abs(gX) + abs(gY)
            if (Mxy <= threshold): imgEdge.putpixel((x, y), (0, 0, 0))
            else: imgEdge.putpixel((x, y), (255, 255, 255))
    return np.array(imgEdge)

fileHinh = r'lena_color.jpg'
hinhGoc = cv2.imread(fileHinh, cv2.IMREAD_COLOR)
anhXam = RGBtoGrayScale(fileHinh)
anhEdgeDetection = edgeDetectionGrayscale(anhXam, 130)
cv2.imshow('Hinh goc', hinhGoc)
cv2.imshow('Anh Edge Detection', anhEdgeDetection)
cv2.waitKey(0)
cv2.destroyAllWindows()
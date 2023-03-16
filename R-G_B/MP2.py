import cv2
import numpy as np

img = cv2.imread('lena_color.jpg', cv2.IMREAD_COLOR)

#height, width, channel = img.shape

height = len(img[0])
width = len(img[1])


red = np.zeros((width, height, 3), np.uint8)
green = np.zeros((width, height, 3), np.uint8)
blue = np.zeros((width, height, 3), np.uint8)

red[:] = [0, 0, 0]
green[:] = [0, 0, 0]
blue[:] = [0, 0, 0]

for y in range(height):
    for x in range(width):
        r = img[x, y, 2]
        g = img[x, y, 1]
        b = img[x, y, 0]
        
        red[x, y, 2] = r 
        green[x, y, 1] = g
        blue[x, y, 0] = b


cv2.imshow('Hinh mau RGB goc - NguyenLePhong_20146516', img)


cv2.imshow('Red - NguyenLePhong_20146516', red)
cv2.imshow('Green - NguyenLePhong_20146516', green)
cv2.imshow('Blue - NguyenLePhong_20146516', blue)

cv2.waitKey(0)

cv2.destroyAllWindows()

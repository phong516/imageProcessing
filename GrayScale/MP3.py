import cv2
import numpy as np
from PIL import Image

filehinh = r'bird_small.jpg'


img = cv2.imread(filehinh, cv2.IMREAD_COLOR)

imgPIL = Image.open(filehinh)

average = Image.new(imgPIL.mode, imgPIL.size)
lightness = Image.new(imgPIL.mode, imgPIL.size)
luminance = Image.new(imgPIL.mode, imgPIL.size)

width = imgPIL.size[0]
height = imgPIL.size[1]

for x in range(width):
    for y in range(height):
        R, G, B = imgPIL.getpixel((x, y))

        gray_average = np.uint8((R + G + B) / 3)
        gray_lightness = np.uint8((max(R, G, B) + min(R, G, B))/2)
        gray_luminance = np.uint8(0.2126 * R + 0.7152 * G + 0.0722 * B)

        average.putpixel((x, y), (gray_average, gray_average, gray_average))
        lightness.putpixel((x, y), (gray_lightness, gray_lightness, gray_lightness))
        luminance.putpixel((x, y), (gray_luminance, gray_luminance, gray_luminance))

anhmucxamAverage = np.array(average)
anhmucxamLightness = np.array(lightness)
anhmucxamLuminance = np.array(luminance)

cv2.imshow('Anh goc RGB', img)
cv2.imshow('Anh muc xam Average', anhmucxamAverage)
cv2.imshow('Anh muc xam Lightness', anhmucxamLightness)
cv2.imshow('Anh muc xam Luminance', anhmucxamLuminance)

cv2.waitKey(0)
cv2.destroyAllWindows()
import cv2
import numpy as np
from PIL import Image

filehinh = r'lena_color.jpg'


img = cv2.imread(filehinh, cv2.IMREAD_COLOR)

imgPIL = Image.open(filehinh)

luminance = Image.new(imgPIL.mode, imgPIL.size)
binary = Image.new(imgPIL.mode, imgPIL.size)

width = imgPIL.size[0]
height = imgPIL.size[1]

for x in range(width):
    for y in range(height):
        R, G, B = imgPIL.getpixel((x, y))

        gray_luminance = np.uint8(0.2126 * R + 0.7152 * G + 0.0722 * B)

        if (gray_luminance < 100):
            giatri_binary = 0
        else: giatri_binary = 255

        binary.putpixel((x, y), (giatri_binary, giatri_binary, giatri_binary))
        luminance.putpixel((x, y), (gray_luminance, gray_luminance, gray_luminance))

anhmucxamLuminance = np.array(luminance)
AnhBinary = np.array(binary)
cv2.imshow('Anh goc RGB', img)
cv2.imshow('Anh muc xam Luminance', anhmucxamLuminance)
cv2.imshow('Anh Binary', AnhBinary)

cv2.waitKey(0)
cv2.destroyAllWindows()
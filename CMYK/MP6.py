import cv2
import numpy as np
from PIL import Image

FileHinh = r'lena_color.jpg'
HinhRGB = cv2.imread(FileHinh, cv2.IMREAD_COLOR)
imgPIL = Image.open(FileHinh)
Cyan = Image.new(imgPIL.mode, imgPIL.size)
Magenta = Image.new(imgPIL.mode, imgPIL.size)
Yellow = Image.new(imgPIL.mode, imgPIL.size)
blacK = Image.new(imgPIL.mode, imgPIL.size)

for x in range(imgPIL.size[0]):
    for y in range(imgPIL.size[1]):
        R, G, B = imgPIL.getpixel((x, y))
        K = min(R, G, B)
        Cyan.putpixel((x, y), (B, G, 0))    
        Magenta.putpixel((x, y), (B, 0, R))
        Yellow.putpixel((x, y), (0, G, R))
        blacK.putpixel((x, y), (K, K, K))

HinhCyan = np.array(Cyan)
HinhMagenta = np.array(Magenta)
HinhYellow = np.array(Yellow)
HinhblacK = np.array(blacK)

cv2.imshow("Hinh RGB", HinhRGB)
cv2.imshow("Hinh Cyan", HinhCyan)
cv2.imshow("Hinh Magenta", HinhMagenta)
cv2.imshow("Hinh Yellow", HinhYellow)
cv2.imshow("Hinh blacK", HinhblacK)

cv2.waitKey(0)
cv2.destroyAllWindows()
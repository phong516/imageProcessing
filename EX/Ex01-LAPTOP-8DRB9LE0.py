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

def segmentation(img, thresh):
    imgPIL = Image.open(img)
    imgSegments = Image.new(imgPIL.mode, imgPIL.size)
    for x in range(imgPIL.width):
        for y in range(imgPIL.height):
            g = imgPIL.getpixel((x, y))[0]
            if (g <= thresh): imgSegments.putpixel((x, y), (0, 0, 0))
            else: imgSegments.putpixel((x, y), (255, 255, 255))
    return np.array(imgSegments)

def compute_otsu_criteria(im, th):
    thresholded_im = np.zeros(im.shape)
    thresholded_im[im >= th] = 1

    np_pixels = im.size
    np_pixels1 = np.count_nonzero(thresholded_im)
    weight1 = np_pixels1 / np_pixels
    weight0 = 1 - weight1

    if weight1 == 0 or weight0 == 0:
        return np.inf
    
    val_pixels1 = im[thresholded_im == 1]
    val_pixels0 = im[thresholded_im == 0]

    var1 = np.var(val_pixels1) if len(val_pixels1) > 0 else 0
    var0 = np.var(val_pixels0) if len(val_pixels0) > 0 else 0

    return weight1 * var1 + weight0 * var0

im = cv2.imread(r'lena_color.jpg')
im = cv2.cvtColor(im, cv2.COLOR_BGR2GRAY)
im = np.array(im)

threshold_range = range(np.max(im) + 1)
criterias = [compute_otsu_criteria(im, th) for th in threshold_range]
best_threshold = threshold_range[np.argmin(criterias)]

img = segmentation(r'lena_color.jpg', best_threshold)
cv2.imshow('Hinh Segmentation', img)
cv2.waitKey(0)
cv2.destroyAllWindows()

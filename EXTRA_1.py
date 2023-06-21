import cv2
import numpy as np
from PIL import Image
import matplotlib.pyplot as plt

def calculate_threshold(his):
    """Args:
    his (list): The histogram of the image.
    Returns:
    list: A list of two values. The first value is the threshold value 
            and the second value is the index of the pixel value that corresponds to the threshold value.
    """
    A = [0,0] # A list to store the threshold value and the index of the pixel value that corresponds to the threshold value.
    P1 = 0    # The probability of a pixel value occurring in the image.
    m1 = 0    # The mean of the pixel values that have a given value.
    max = 0   # The maximum variance of the foreground pixels.

    # Loop over all pixel values in the histogram.
    for i1 in range(256):
        # Loop over all pixel values in the histogram.
        P1 += his[i1] / (h * w)       # Tính P1(k) theo công thức 4 và 3
        # Loop over all pixel values in the histogram.
        m1 += his[i1] * i1 / (h*w)    # Tính m1(k) theo công thức 5
        #print(A)
         # Initialize the probabilities and means for the next two groups of pixel values.
        P2 = 0
        m2 = 0
         # Initialize the probabilities and means for the next two groups of pixel values.
        for i2 in range(i1+1,256):
            P2 += his[i2] / (h * w)       # Tính P2(k) theo công thức 4 và 3
            m2 += his[i2] * i2 / (h * w)    # Tính m2(k) theo công thức 5
            P3 = 0
            m3 = 0
            for i3 in range(i2 + 1, 256):
                P3 += his[i3] / (h * w)
                m3 += his[i3] * i3 / (h * w)
                
                 # Initialize the probabilities and means for the next two groups of pixel values.
                m1_ = m1 / P1
                m2_ = m2 / P2
                m3_ = m3 / P3
                
                # Calculate the variance of all three groups of pixel values.
                mg = m1 + m2 + m3
                vB = P1 * (m1_ - mg) * (m1_ - mg) + P2 * (m2_ - mg) * (m2_ - mg) + P3 * (m3_ - mg) * (m3_ - mg)
                #print(vB)
                 # If the variance of the current group of pixel values is greater than the maximum variance, update the maximum variance and the threshold value.
                if(vB > max):
                    max = vB
                    A[0] = i1
                    A[1] = i2
    return A
   
                  
hinhgoc_PIL = Image.open(r'lena_color.jpg')

h = hinhgoc_PIL.height
w = hinhgoc_PIL.width

LUMINANCE = Image.new(hinhgoc_PIL.mode,hinhgoc_PIL.size)


hisR = np.zeros(256)

for x in range (w):
    for y in range (h):
        gR,gG,gB = hinhgoc_PIL.getpixel((x,y))
        hisR[gR]+=1 
     
B = calculate_threshold(hisR)

print(B[0])

for x in range (w):
    for y in range (h):
        r,g,b = hinhgoc_PIL.getpixel((x,y))
        gray_luminance = np.uint8(0.2126 * r + 0.7152 * g + 0.0722 * b)
        
        if(gray_luminance <= B[0]): gray = 0
        elif(B[0] < gray_luminance <= B[1]): gray = 125
        elif(B[1] < gray_luminance): gray = 255
        
        
        LUMINANCE.putpixel((x, y),(gray, gray, gray))
        
LUMINANCE=np.array(LUMINANCE)

cv2.imshow('xdcx',LUMINANCE)
               
#cv2.imshow('GRAY_LUMINANCE',HinhXamCV)


#VeBieuDoHistogram(his)

cv2.waitKey(0)
cv2.destroyAllWindows()

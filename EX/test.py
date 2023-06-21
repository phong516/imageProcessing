import cv2
import numpy as np

# Read the image
image = cv2.imread(r"lena_color.jpg")

# Convert the image to grayscale
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

# Apply thresholding to the image
thresholded = cv2.threshold(gray, 100, 255, cv2.THRESH_BINARY)[1]

# Create a kernel
kernel = np.ones((3, 3), np.uint8)

# Dilate the image
dilated = cv2.dilate(thresholded, kernel, iterations=1)

# Erode the image
eroded = cv2.erode(thresholded, kernel, iterations=1)

# Open the image
opened = cv2.morphologyEx(thresholded, cv2.MORPH_OPEN, kernel)

# Close the image
closed = cv2.morphologyEx(thresholded, cv2.MORPH_CLOSE, kernel)

boundary_image = cv2.morphologyEx(thresholded, cv2.MORPH_GRADIENT, np.ones((3, 3), np.uint8))


# Display the images
cv2.imshow("Original Image", image)
cv2.imshow("Thresholded Image", thresholded)
cv2.imshow("Dilated Image", dilated)
cv2.imshow("Eroded Image", eroded)
cv2.imshow("Opened Image", opened)
cv2.imshow("Closed Image", closed)
cv2.imshow("Boundary Image", boundary_image)

# Wait for a key to be pressed
cv2.waitKey(0)

# Close all windows
cv2.destroyAllWindows()
import tkinter as tk
from PIL import ImageTk, Image
def program():
    root.withdraw()
    program = tk.Toplevel(root)
    program.title("Program")
    program.geometry(str(width_window) + "x" + str(height_window))


""" Kích thước, tọa độ đối tượng """
width_window = 1024
height_window = 768

width_img = 512
height_img = 200
x_img = (width_window / 2) - (width_img / 2)
y_img = (height_img / 2) - 100

width_button = 100
height_button = 50
x_button = width_window - width_button - 50
y_button = height_window - height_button - 50

width_school = 300
height_school = 50
x_school = (width_window / 2) - (width_school / 2)
y_school = y_img + height_img - 10

width_topic = 300
height_topic = 50
x_topic = (width_window / 2) - (width_topic / 2)
y_topic = y_school + height_school + 10

width_topicName = 300
height_topicName = 50
x_topicName = (width_window / 2) - (width_topicName / 2)
y_topicName = y_topic + height_topic + 10

width_gvhd = 300
height_gvhd = 50
x_gvhd = (width_window / 2) 
y_gvhd = y_topicName + height_topicName + 10

width_gvhdName = 300
height_gvhdName = 50
x_gvhdName = (width_window / 2)
y_gvhdName = y_gvhd + height_gvhd - 15

width_svth = 300
height_svth = 50
x_svth = (width_window / 2)
y_svth = y_gvhdName + height_gvhdName + 10

width_mssv = 300
height_mssv = 50
x_mssv = x_svth + width_svth - 55
y_mssv = y_svth

width_svthList = 300
height_svthList = 100
x_svthList = (width_window / 2)
y_svthList = y_svth + height_svth - 15

width_mssvList = 300
height_mssvList = 100
x_mssvList = x_mssv
y_mssvList = y_svthList

fg = "#3155a6"

""" Tạo cửa sổ chính """
root = tk.Tk()
root.title("Term Project")
root.geometry(str(width_window) + "x" + str(height_window))

""" Logo trường"""
img_path = r'logo.png'
img = Image.open(img_path)
img_tk = ImageTk.PhotoImage(img)

img_label = tk.Label(root, image=img_tk)    
img_label.place(x = x_img, y= y_img, width = width_img, height= height_img)


""" Tên khoa, ngành"""
school_label = tk.Label(root, text="Khoa Cơ khí - Chế tạo máy\nNgành Cơ điện tử", font=("Helvetica", 15, "bold"), fg=fg)
school_label.place(x = x_school, y = y_school, width= width_school, height= height_school)

""" Đề tài"""
topic_label = tk.Label(root, text="ĐỀ TÀI", font=("Helvetica", 15, "bold"))
topic_label.place(x = x_topic, y = y_topic, width= width_topic, height= height_topic)

"""Tên đề tài"""
topicName_label = tk.Label(root, text="Phục hồi ảnh xám", font=("Helvetica", 20, "bold"))
topicName_label.place(x = x_topicName, y = y_topicName, width= width_topicName, height= height_topicName)

""" Giáo viên hướng dẫn"""
gvhd_label = tk.Label(root, text="Giáo viên hướng dẫn:", font=("Helvetica", 15, "bold"))
gvhd_label.place(x = x_gvhd, y = y_gvhd, width= width_gvhd, height= height_gvhd)

""" Tên giáo viên hướng dẫn"""
gvhdName_label = tk.Label(root, text="TS. Nguyễn Văn Thái", font=("Helvetica", 15))
gvhdName_label.place(x = x_gvhdName, y = y_gvhdName, width= width_gvhdName, height= height_gvhdName)

""" Sinh viên thực hiện"""
svth_label = tk.Label(root, text="Sinh viên thực hiện:", font=("Helvetica", 15, "bold"))
svth_label.place(x = x_svth, y = y_svth, width= width_svth, height= height_svth)

""" Mã số sinh viên"""
mssv_label = tk.Label(root, text="MSSV:", font=("Helvetica", 15, "bold"))
mssv_label.place(x = x_mssv, y = y_mssv, width= width_mssv, height= height_mssv)

""" Tên sinh viên"""
svthList_label = tk.Label(root, text="Diệp Khải Hoàn\nNguyễn Lê Phong\nHồ Đăng Tú", font=("Helvetica", 15))
svthList_label.place(x = x_svthList, y = y_svthList, width= width_svthList, height= height_svthList)

""" Danh sách Mã số sinh viên"""
mssvList_label = tk.Label(root, text="20146090\n 20146516\n 20146150", font=("Helvetica", 15))
mssvList_label.place(x = x_mssvList, y = y_mssvList, width= width_mssvList, height= height_mssvList)

""" Nút nhấn chuyên đến chương trình"""
button = tk.Button(root, text="Program", command=program)
button.place(x = x_button, y = y_button, width= width_button, height= height_button)

root.mainloop()
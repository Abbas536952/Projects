from tkinter import *
from PIL import ImageTk,Image

window = Tk()
window.title("Calculator")
window.iconbitmap('d:/Downloads/Icon.png')

# image1 = ImageTk.PhotoImage(Image.open('d:/Downloads/Banner.jpg'))
# my_label = Label(window,image = image1)
# my_label.grid(row = 10,columnspan=3,column = 0)


entry_1 = Entry(window,width=30,borderwidth=5)
entry_1.grid(row=0,column=0,columnspan=3)

#Defining Functions

index = 0

def showup(button_clicked):
	global index
	index += 1
	entry_1.insert(index,button_clicked)

total = 0
def addition():
	global total
	global index
	total += int(entry_1.get())
	entry_1.delete(0,END)
	index = 0

def subtraction():
	return

def equal():
	global total
	global index
	try:
		total += int(entry_1.get())
	except ValueError:
		pass
	entry_1.delete(0,END)
	entry_1.insert(0,total)
	total = 0;index = 0

def clear():
	global index
	entry_1.delete(index-1,END)
	index -= 1

def clearall():
	entry_1.delete(0,END)

#Defining Buttons

button_1 = Button(window,text="1",padx=20,pady=10,borderwidth=4,command=lambda : showup(1))
button_2 = Button(window,text="2",padx=20,pady=10,borderwidth=4,command=lambda : showup(2))
button_3 = Button(window,text="3",padx=20,pady=10,borderwidth=4,command=lambda : showup(3))
button_4 = Button(window,text="4",padx=20,pady=10,borderwidth=4,command=lambda : showup(4))
button_5 = Button(window,text="5",padx=20,pady=10,borderwidth=4,command=lambda : showup(5))
button_6 = Button(window,text="6",padx=20,pady=10,borderwidth=4,command=lambda : showup(6))
button_7 = Button(window,text="7",padx=20,pady=10,borderwidth=4,command=lambda : showup(7))
button_8 = Button(window,text="8",padx=20,pady=10,borderwidth=4,command=lambda : showup(8))
button_9 = Button(window,text="9",padx=20,pady=10,borderwidth=4,command=lambda : showup(9))
button_0 = Button(window,text="0",padx=20,pady=10,borderwidth=4,command=lambda : showup(0))

button_add = Button(window,text="+",borderwidth=4,pady=10,padx=19,command=addition)
button_subtract = Button(window,text="-",borderwidth=4,pady=10,padx=20,command=subtraction)
button_multiply = Button(window,text="*",borderwidth=4,pady=10,padx=20,command=addition)
button_division = Button(window,text="/",borderwidth=4,pady=10,padx=20,command=addition)

button_equal = Button(window,text="=",borderwidth=4,pady=10,padx=19,command=equal)
button_clear = Button(window,text="DEL",borderwidth=4,pady=10,padx=12.5,command=clear)
button_clearall = Button(window,text="CLEAR ALL",borderwidth=4,pady=10,padx=26,command=clearall)

#Placing Buttons

button_1.grid(row=3,column=0)
button_2.grid(row=3,column=1)
button_3.grid(row=3,column=2)

button_4.grid(row=2,column=0)
button_5.grid(row=2,column=1)
button_6.grid(row=2,column=2)

button_7.grid(row=1,column=0)
button_8.grid(row=1,column=1)
button_9.grid(row=1,column=2)

button_0.grid(row=4,column=0)

button_equal.grid(row=6,column=2)

button_add.grid(row=5,column=0)
button_subtract.grid(row=5,column=1)
button_division.grid(row=5,column=2)
button_multiply.grid(row=4,column=1)

button_clear.grid(row=4,column=2)
button_clearall.grid(row=6,column=0,columnspan=2)

#Exit

button_exit = Button(window,text="Exit Calculator!",padx=48,pady=10,borderwidth=4,command=window.quit)
button_exit.grid(row=7,column=0,columnspan=3)

window.mainloop()


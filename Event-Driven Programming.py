# Event-Driven Programming Example (using tkinter)
import tkinter as tk

def on_click():
    print("Button was clicked!")

window = tk.Tk()
button = tk.Button(window, text="Click Me", command=on_click)
button.pack()

window.mainloop()

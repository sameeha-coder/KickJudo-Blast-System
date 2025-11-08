# Object-Oriented Programming 
class Car:
    def __init__(self, brand, color):
        self.brand = brand
        self.color = color

    def start_engine(self):
        print(f"The {self.color} {self.brand} car engine has started!")

my_car = Car("Toyota", "Red")
my_car.start_engine()

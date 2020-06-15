class Employee:

	raise_amount = 1.04
	emp_count = 0

	def __init__(self, first, last, pay):
		self.first = first
		self.last = last
		self.email = first + "." + last + "@gmail.com"
		self.pay = pay

		Employee.emp_count += 1

	@property #Will help us to consider this as an attribute and call without brackets.	
	def fullname(self):
		return f'{self.first} {self.last}'

	@fullname.setter #Agar emp_1.fullname = "Abbas Shabbir" set krenge to error ayega thats why setter used.
	def fullname(self, name):
		first, last = name.split(" ")
		self.first = first
		self.last = last

	@fullname.deleter #Fullname delete krdene k liye.
	def fullname(self):
		self.first = None
		self.last = None

	def __repr__(self):
		return f'Employee({self.first},{self.last},{self.pay})'

	def __str__(self):
		return self.fullname

	def __add__(emp1, emp2):
		return emp_1.pay + emp2.pay

	def __len__(self):
		return len(self.fullname)

	@classmethod
	def raise1(cls, amount):
		cls.raise_amount = amount

	@classmethod
	def make_emp(cls, emp_string):
		first, last, pay = emp_string.split("-")
		return cls(first, last, pay)

class Manager(Employee):
	def __init__(self, first, last, pay, emp_list = None):
		super().__init__(first, last, pay)
		self.emp_list = emp_list

	def show_emps(self):
		if self.emp_list != None:
			for employees in self.emp_list:
				print(employees.fullname)
		else:
			print("No employees under this manager.")

	def add_emps(self, emp_name):
		if self.emp_list != None:
			if emp_name not in self.emp_list:
				self.emp_list.append(emp_name)
		else:
			self.emp_list = []
			if emp_name not in self.emp_list:
				self.emp_list.append(emp_name)
	
	def rem_emps(self, emp_name):
		if emp_name in self.emp_list:
			self.emp_list.remove(emp_name)

class Accountant(Employee):
	raise_amount = 1.05 #Only changes value for subclass without affecting parentclass.

	def apply_raise(self):
		self.pay = int(self.pay * self.raise_amount)

emp_1 = Employee("Faiq", "Khan", 50000)
emp_2 = Employee("Aaqib", "Nazeer", 50000)

# These are very helpful in understanding class method and object method.

# Accountant.raise1(1.06)
# print(Employee.raise_amount)
# print(Accountant.raise_amount)

# Accountant.apply_raise(emp_1)
# print(emp_1.pay)
# print(emp_2.pay)

# print(emp_1.__repr__())
# print(emp_1.__str__())
# print(emp_1 + emp_2) #This is equal to print(emp.__add__(emp_1, emp_2)) and tells the computer how to add two employees.

mgr_1 = Manager("Abbas", "Shabbir", 50000, [emp_1, emp_2])

# print(len(emp_1)) #Uses __len__ function and gives length of fullname.

# print(mgr_1.fullname) # Words without brackets because of @property.
# emp_1.fullname = "Rafay Zia"
# print(emp_1.__repr__())
# del emp_1.fullname
# print(emp_1.fullname)

#print(Employee.make_emp("Abbas-Shabbir-25000").__repr__())


#***MULTIPLE __INIT__ CANNOT BE USED IN A SINGLE CLASS AND IF USEN, THE LAST ONE OVERRIDES ALL THE PREVIOUS ONES***

#TO USE MORE THAN ONE __INIT__ WE CAN ASSIGN ONE A DEFAULT VALUE WITH SELF OR USE *ARGS OR **kwargs

class PracticeEmployee:
	def __init__(self, name=None):
		self.name = name

emp1 = PracticeEmployee()
emp2 = PracticeEmployee("Abbas")

#print(emp1.name, emp2.name)

#USE __(varname) TO MAKE THE VAR PRIVATE.

class Car:
	def __init__(self, color, speed):
		self.__color = color
		self.__speed = speed

	def set_speed(self, val):
		self._speed = val

	def get_speed(self):
		return self.__speed

car1 = Car("Black", 300)

# print(car1.__color)
# print(car1.color) # Both will give an error because the variable color is private.

car1.set_speed(500)
car1.__speed = 300 #Doesn't do anything because the variable is private

#print(car1.get_speed()) 
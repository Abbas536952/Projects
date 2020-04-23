try:
	create = open("employee.txt","x")
except FileExistsError:
	create = open("employee.txt",'a')
finally:
	t = int(input("Enter number of employees:"));list1 = []
	for i in range(t):
		list1.append([]);user_id = input("Enter Your ID:")
		name = input("Please Enter Your Name:")
		salary = input("Please Enter Your Salary:")
		list1[i].append(user_id);list1[i].append(name)
		list1[i].append(salary)
	temp_list = ["\nEmployee ID: ","\nEmployee Name: ","\nEmployee Salary: "]
	for emp in range(len(list1)):
		create.write("** For Employee "+str(emp+1)+" **")
		for x in range(3):
			create.write(temp_list[x]+list1[emp][x])
		create.write('\n')
	create = open("employee.txt",'r')
	for i in create:	print(i)
	create.close()




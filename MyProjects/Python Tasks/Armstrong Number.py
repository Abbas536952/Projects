def check_armstrong(n):
      n = str(n)
      arm_count = 0
      for i in n:
            arm_count += int(i)**len(n)
      return arm_count
x = int(input("Enter a number to check if Armstrong ot not:"))
if check_armstrong(x) == x:
      print(x,"is an Armstrong Number")
else:
      print(x,"is not an Armstrong Number")

def check_armstrong(n):
      str_len = len(str(n))
      arm_count = 0
      while n > 0:
            n1 = n % 10
            arm_count += n1 ** str_len
            n = n // 10
      return arm_count
x = int(input("Enter a number to check if Armstrong ot not:"))
if check_armstrong(x) == x:
      print(x,"is an Armstrong Number")
else:
      print(x,"is not an Armstrong Number")
      

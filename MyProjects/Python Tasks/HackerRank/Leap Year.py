year = int(input("Enter a year:"))
if year % 100 == 0 and year % 400 != 0 or year % 4 != 0:
      print(year,"is not a leap year")
elif year % 100 == 0 and year % 400 == 0 or year % 4 == 0:
      print(year,"is a leap year")

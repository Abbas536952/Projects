x = []
y = []
n = int(input("Enter no. of elements to add in x:"))
for i in range(n):
      z = int(input("Enter a number:"))
      x.append(z)
n = int(input("Enter no. of elements to add in y:"))
for j in range(n):
      z = int(input("Enter a number:"))
      y.append(z)
for i in range(len(x)):
      x[i] = x[i] + y[i]
      y[i] = x[i] - y[i]
      x[i] = x[i] - y[i]
print(x)
print(y)














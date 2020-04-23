a,b = 0,1
n = int(input("To which limit do you want the series?:"))
for i in range(n):
    result = a + b
    print(result,end='')
    if i<n-1:
        print(",",end='')
    a,b = b,result


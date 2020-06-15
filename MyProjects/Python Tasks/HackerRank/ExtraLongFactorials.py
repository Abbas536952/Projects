def extraLongFactorials(n):
    result = 1
    for i in range(n,1,-1):
        if i == n:
            result = result * (i*(i-1))
        elif i != n and i>0:
            result = result * (i-1)
    print(result)

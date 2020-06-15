def beautifulDays(i, j, k):
    beautiful_days = []
    for x in range(i,j+1):
        x = str(x)
        y = str(x[::-1])
        y = int(y)
        x = int(x)
        if abs(x-y)%k==0:
            beautiful_days.append(x)
    return len(beautiful_days)

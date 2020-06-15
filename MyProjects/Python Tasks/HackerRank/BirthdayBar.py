def birthday(s, d, m):
    count = 0
    sumup = 0
    x = 0 ; l = len(s)
    if l == 1:
        sumup += s[l-1]
        if sumup == d:
            count += 1
    while x != l and len(s) >= m:
        for i in range(m):
            sumup += s[i]
        if sumup == d:
            count += 1
        sumup = 0
        x += 1
        s = s[1:]
    return count

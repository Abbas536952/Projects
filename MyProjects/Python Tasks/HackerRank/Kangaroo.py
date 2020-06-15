def kangaroo(x1, v1, x2, v2):
    
    a = 'NO'
    while x1 != x2:
        x1 += v1
        x2 += v2
        if x1 == x2:
            a = 'YES'
            break
        elif v2 >= v1 and x2 >= x1:
            break
        elif x2 <= x1 and v2 <= v1:
            break
            
    return a

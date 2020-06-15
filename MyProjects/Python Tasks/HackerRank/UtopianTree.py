def utopianTree(n):
    H = 1
    for i in range(1,n+1):
        if i % 2 == 0:
            H += 1
        else:
            H = H * 2
    return H

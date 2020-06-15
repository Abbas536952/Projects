def minimumDistances(a):#7 1 3 4 1 7
    list1 = []
    for i in range(len(a)):
        for j in range(i+1,len(a)):
            if a[i] == a[j]:
                list1.append(abs(i-j))
    if len(list1) == 0:
        return -1
    else:
        return min(list1)

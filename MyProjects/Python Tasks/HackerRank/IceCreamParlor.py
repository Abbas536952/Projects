def icecreamParlor(m, arr):
    list1 = []
    for i in range(len(arr)):
        for j in range(i+1,len(arr)):
            if arr[i] + arr[j] == m:
                list1.append(i+1)
                list1.append(j+1)
    return list1

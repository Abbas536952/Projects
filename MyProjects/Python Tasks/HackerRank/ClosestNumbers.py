def closestNumbers(arr):
    pair_lst = []
    sumup = []
    arr.sort()
    for i in range(len(arr)):
        for j in range(i+1,len(arr)):
            x = abs((arr[i]-arr[j]))
            if len(sumup) == 0:
                pair_lst.append([arr[i],arr[j]])
                sumup.append(x)
            elif x <= min(sumup):
                pair_lst.append([arr[i],arr[j]])
                sumup.append(x)
    return pair_lst[sumup.index(min(sumup))]

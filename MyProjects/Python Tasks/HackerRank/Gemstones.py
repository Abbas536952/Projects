def gemstones(arr):
    len_lst = []
    index_lst = []
    for i in arr:
        len_lst.append(len(i))
        index_lst.append(arr.index(i))
    for i in range(len(len_lst)):
        if len_lst[i] == max(len_lst):
            highest_index = index_lst[i]
    h = arr[highest_index]
    arr.remove(h)
    gem_count = []
    count = 0
    for i in h: #asdlkjfdjsa
#basdfj
#bnafvfnsd
#oafhdlasd 
        for j in range(len(arr)):
            if i in arr[j]:
                count += 1
        if count == len(arr) and i not in gem_count:
            gem_count.append(i)
        count = 0
    return len(gem_count)

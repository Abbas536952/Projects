def equalizeArray(arr):
    count = 0
    count_list = []

    for i in range(len(arr)):
        for j in range(len(arr)):
            if arr[i] != arr[j]:
                count += 1
        count_list.append(count)
        count = 0
    return min(count_list)

def miniMaxSum(arr):
    minimum = []
    min_length = int(len(minimum))
    for elements in arr:
        if elements != max(arr) and len(minimum) != 4:
            minimum.append(elements)
            min_length += 1
    while len(minimum) != 4:
        minimum.append(max(arr))
        min_length += 1
    total = 0
    for i in minimum:
        total += i
    maximum = []
    max_length = int(len(maximum))
    for elements in arr:
        if elements != min(arr) and len(maximum) != 4:
            maximum.append(elements)
            max_length += 1
    while len(maximum) != 4:
        maximum.append(min(arr))
        max_length += 1
    total1 = 0
    for i in maximum:
        total1 += i
    print(total,total1)

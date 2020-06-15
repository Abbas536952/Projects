def kaprekarNumbers(p, q):
    kaprekars = []
    for i in range(p,q+1):
        squares = i ** 2
        squares = str(squares)
        squares = squares[::-1]
        list1 = []
        list1.append(squares[:len(str(i))])
        # for i in range(len(list1)):
        #     list1[i] = str(list1[i])[::-1]
        list1.append(squares[len(str(i)):])
        for y in range(len(list1)):
            list1[y] = str(list1[y])[::-1]
        for x in list1:
            if x == '':
                list1.remove(x)
        list1 = list1[::-1]
        #print(list1)
        a = 0
        for j in list1:
            a += int(j)
        if a == i:
            kaprekars.append(a)
    if len(kaprekars) == 0:
        print("INVALID RANGE")
    else:
        for z in kaprekars:
            print(z,end=' ')

def formingMagicSquare(s):
    to_check = [
    [[8,3,4],[1,5,9],[6,7,2]],
    [[6,7,2],[1,5,9],[8,3,4]],
    [[4,3,8],[9,5,1],[2,7,6]],
    [[2,7,6],[9,5,1],[4,3,8]],
    [[8,1,6],[3,5,7],[4,9,2]],
    [[4,9,2],[3,5,7],[8,1,6]],
    [[6,1,8],[7,5,3],[2,9,4]],
    [[2,9,4],[7,5,3],[6,1,8]]
    ]
    list1=[]

    for i in to_check:
        for j,k in zip(i,s):
            for a,b in zip(j,k):
                list1.append(abs(a-b))
    leng = len(list1)
    total = []
    sumup = 0 ; n = 1
    while n != leng:
        sumup = sumup + list1[n-1]
  
        if n % 9 == 0 and n != 0:
            total.append(sumup)
            sumup = 0
        n += 1
    return (min(total))

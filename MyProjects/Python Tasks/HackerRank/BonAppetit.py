def bonAppetit(bill, k, b):
    b1 = 0
    for i in range(len(bill)):
        if i != k:
            b1 += bill[i]
    #b = int(b)
    #b1 = int(b1)

    if int(b - b1//2) == 0:
        print("Bon Appetit")
    else:
        print(int(b - b1//2))

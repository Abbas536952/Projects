def diagonalDifference(arr):
    # Write your code 
    diagonal1 = []
    for diagonals in range(n):
        diagonal1.append(arr[diagonals][diagonals])
    total1 = 0
    for elements in diagonal1:
        total1 += elements

    diagonal2 = []
    for diagonals in range(n):
        diagonal2.append(arr[diagonals][-(diagonals)-1])
    total2 = 0
    for elements in diagonal2:
        total2 += elements
    return (abs(total1-total2))

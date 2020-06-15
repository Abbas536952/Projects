def getMoneySpent(keyboards, drives, b):
    amount_list = []
    for i in keyboards:
        for j in range(len(drives)):
            if i + drives[j] <= b:
                amount_list.append(i + drives[j])
    if len(amount_list) != 0:
        return max(amount_list)
    else:
        return -1

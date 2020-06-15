def marcsCakewalk(calorie):
    calorie.sort() # 1 3 2 # 3 2 1
    calorie.reverse()
    calc = 0
    for i in range(len(calorie)):
        cal_count = (2 ** i) * calorie[i]
        calc += cal_count
    return calc

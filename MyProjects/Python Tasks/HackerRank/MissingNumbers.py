def missingNumbers(arr, brr):
    missing = []
    checked = []
    for i in range(len(brr)):
        a = brr[i]
        if a not in checked:
            checked.append(a)
            if brr.count(a) != arr.count(a):
                if a not in missing:
                    missing.append(a)
    missing.sort()
    return missing

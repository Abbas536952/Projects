def marsExploration(s):
    l = len(s) // 3
    msg = "SOS"
    count = 0
    for i in range(l):
        for j in range(3):
            if s[j] != msg[j]:
                count += 1
        s = s[3:]
    return count

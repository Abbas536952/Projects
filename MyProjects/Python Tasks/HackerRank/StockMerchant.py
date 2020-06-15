def sockMerchant(n, ar):
    count = []
    counter = []
    pairs = 0
    for i in ar:
        if i not in count:
            count.append(i)
    for j in count:
        counter.append(ar.count(j))
    for k in counter:
        if k % 2 == 0 and k > 2:
            pairs += k/2
        elif k == 2:
            pairs += 1
        elif k > 2:
            a = (k - k % 2)
            pairs += a/2
    return int(pairs)

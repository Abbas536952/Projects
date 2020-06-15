def divisibleSumPairs(n, k, ar):
    sumup = 0
    z = 0 ; l = len(ar)
    while z != l:
        for i in range(z+1,len(ar)):
            if (ar[z] + ar[i]) % k == 0:
                sumup += 1

        z += 1
    return sumup

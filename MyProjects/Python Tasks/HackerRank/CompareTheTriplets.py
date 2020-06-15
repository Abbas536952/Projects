def compareTriplets(a, b):
    alice_score = 0
    bob_score = 0
    if a[0]>b[0] and a[0]!=b[0]:
        alice_score += 1
    elif b[0]>a[0] and a[0]!=b[0]:
        bob_score += 1
    if a[1]>b[1] and a[1]!=b[1]:
        alice_score += 1
    elif b[1]>a[1] and a[1]!=b[1]:
        bob_score += 1
    if a[2]>b[2] and a[2]!=b[2]:
        alice_score += 1
    elif b[2]>a[2] and a[2]!=b[2]:
        bob_score += 1
    return ([alice_score,bob_score])

def countApplesAndOranges(s, t, a, b, apples, oranges):

    count_apple =0
    count_orange =0
    for i in apples:
        if s <= (a+i)<=t:
            count_apple +=1

    for j in oranges:
        if s <= (b+j) <= t:
            count_orange +=1

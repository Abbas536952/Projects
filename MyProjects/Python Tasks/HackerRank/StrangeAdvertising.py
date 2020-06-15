def viralAdvertising(n):
    recipients = int()
    cumulative = int()
    for i in range(1,n+1):
        if i == 1:
            recipients = 5
            liked = math.floor(recipients/2)
            cumulative += liked
        if i > 1:
            recipients = (math.floor(recipients/2))*3
            liked = math.floor(recipients/2)
            cumulative = cumulative + liked
    return cumulative

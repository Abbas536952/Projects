def staircase(n):
    spaces = n
    y = ' '
    for drawing in range(n):
        x = '#'
        x += "#" * drawing
        print((spaces-(drawing+1))*y+x)

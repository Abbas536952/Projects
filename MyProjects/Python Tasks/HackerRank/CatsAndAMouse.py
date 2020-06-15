def catAndMouse(x, y, z):
    for i in range(q):
        if abs(z-x) > abs(z-y):
            return("Cat B")
        elif abs(z-x) < abs(z-y):
            return("Cat A")
        elif abs(z-x) == abs(z-y):
            return("Mouse C")

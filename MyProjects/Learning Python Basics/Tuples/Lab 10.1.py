TUP = () ; TUP = list(TUP)
n = int(input("Enter no. of elements:"))
for j in range(n):
    x = int(input("Enter no.")) ; TUP.append(x)
TUP = tuple(TUP) ; maxv = TUP[0] ; minv = TUP[0]
for j in TUP:
    if j >= maxv:   maxv = j
    elif j <= minv:   minv = j
print("Max value >>",maxv,",Min Value >>",minv)
    















decimal = int(input("Enter a number to be converted:"))
n = 0 ; remainder = ''
while n != 1:
      division = decimal // 2
      remainder1 = str(decimal - division * 2)
      remainder = remainder + remainder1
      decimal = division
      if division == 1:
            remainder = remainder + "1"
            n += 1
      elif division == 0:
            n += 1
if int(len(remainder)) % 4 == 0:
    remainder = remainder[::-1]
else:
    while int(len(remainder)) % 4 != 0:
        remainder = remainder + '0'
        if int(len(remainder)) % 4 == 0:
            remainder = remainder[::-1]
print("Binary Number >>",remainder)
a = ''; b = 0 ; n = 0 ; x = ''
while n != len(remainder):
    a += remainder[n]
    if len(a) == 4:
        a = a[::-1]
        for i in range(3,-1,-1):
            if int(a[i])==1:
                b = b + 2**i
        alphabets = 'ABCDEF'
        if b >= 10:
            for i in range(6):
                if b == 10 + i:
                    b = alphabets[i]
        remainder = remainder[len(a):]
        a = '' ; n = -1
        x = x + str(b) ; b = 0
    n += 1
print("Hexadecimal Number >>",x)

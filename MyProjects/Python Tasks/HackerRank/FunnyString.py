def funnyString(s):
    t = len(s)
    r = s[::-1]
    ascii_codes = []
    for letters in s:
        ascii_codes.append(ord(letters))
    differences = []
    for i in range(t - 1):
        differences.append(abs(ascii_codes[i] - ascii_codes[i + 1]))
    reverse_ascii = []
    differences1 = []
    for letters in r:
        reverse_ascii.append(ord(letters))
    for i in range(t - 1):
        differences1.append(abs(reverse_ascii[i] - reverse_ascii[i + 1]))
    if differences1 == differences:
        return ("Funny")
    else:
        return ("Not Funny")

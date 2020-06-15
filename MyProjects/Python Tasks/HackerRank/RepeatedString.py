def repeatedString(s, n):
    x = n // len(s)
    y = n % len(s)
    xyz = s.count('a') * x + s[:y].count('a')
    return xyz

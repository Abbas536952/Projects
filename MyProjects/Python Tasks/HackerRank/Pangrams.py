def pangrams(s):
    alphabets = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
    list1 = []
    for letters in s:
        if letters in alphabets and letters.lower() not in list1:
            list1.append(letters.lower())
    if len(list1)==26:
        return('pangram')
    else:
        return('not pangram')

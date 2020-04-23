word = input("Please enter a word:")
dict_count = {}
for j in word:
    if j not in dict_count:
        dict_count[j] = 1
    else:
        dict_count[j] += 1
print(dict_count)



















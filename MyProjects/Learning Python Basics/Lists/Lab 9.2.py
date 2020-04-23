to_sort = []
n = int(input("No. of terms to enter in the list is?:"))
for j in range(n):
    el = int(input("Enter a number:"))
    to_sort.append(el)

for i in range(len(to_sort)):
    for j in range(i+1, len(to_sort)):
        if to_sort[j] < to_sort[i]:
            to_sort[i] = to_sort[i] + to_sort[j]
            to_sort[j] = to_sort[i] - to_sort[j]
            to_sort[i] = to_sort[i] - to_sort[j]
print(to_sort)

























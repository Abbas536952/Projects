#Check if the given string is a substring of another.

def count_substring(string, sub_string):
    counter = 0
    spacing = len(sub_string)    #ABCDCDC #CDC
    length = len(string)

    for i in range(len(string)):
        
        if length < len(sub_string):
            break
        else:
            a = string[i]
            for j in range(i+1, spacing):
                a += string[j]
            length -= 1
            if a == sub_string:
                counter += 1  
            spacing += 1  
    
    return counter

#Find if there is an element in the list where the sum of elements from its
#right is equal to the sum from its left.

def balancedSums(arr): #[5, 6, 8, 11]
    if len(arr) == 1:
        return "YES"
    for i in range(len(arr)):
        sum_of_right = 0
        sum_of_left = 0
        for j in range(i+1, len(arr)):
            sum_of_right += arr[j]
        for k in range(i-1, -1, -1):
            sum_of_left += arr[k]
        if sum_of_right == sum_of_left:
            return "YES"
            break
    else:
        return "NO"

#Find out Maximum XOR Value in a given range.

l = 10 ; r = 15
max_xor = []
for i in range(l, r+1):
    for j in range(l, r+1):
        print(i ^ j)
print(10 ^ 10)

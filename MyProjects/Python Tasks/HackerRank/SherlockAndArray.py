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
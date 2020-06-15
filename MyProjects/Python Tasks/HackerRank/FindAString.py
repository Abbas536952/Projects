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

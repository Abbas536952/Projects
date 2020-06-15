def minimumNumber(n, password):
    password = str(password)
    # Return the minimum number of characters to make the password strong
    numbers = "0123456789" #4700
    lower_case = "abcdefghijklmnopqrstuvwxyz"
    upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    special_characters = "!@#$%^&*()-+"
    num_count = 0
    upper_count = 0
    lower_count = 0
    spec_count = 0
    num_in_password = False
    for dig in numbers:
        if dig not in password:
            num = False
        else:
            num = True
            break
    if num == False:
        num_count = 1
    upper_in_password = False
    for dig in upper_case:
        if dig not in password:
            upper_in_password = False
        else:
            upper_in_password = True
            break
    if upper_in_password == False:
        upper_count = 1
    lower_in_password = False
    for dig in lower_case:
        if dig not in password:
            lower_in_password = False
        else:
            lower_in_password = True
            break
    if lower_in_password == False:
        lower_count = 1
    spec_in_password = False
    for dig in special_characters:
        if dig not in password:
            spec_in_password = False
        else:
            spec_in_password = True
            break
    if spec_in_password == False:
        spec_count = 1
    counter = 0
    if num_count == 1:
        counter += 1
    if spec_count == 1:
        counter += 1
    if lower_count == 1:
        counter += 1
    if upper_count == 1:
        counter += 1
    if n < 6 and n + counter < 6:
        counter = counter + (6 - (counter+len(password)))
        return counter
    else:
        return counter

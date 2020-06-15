num = int(input("Enter a no. to convert in-words(upto 4-digits):"))
len_num = len(str(num))
dict_1 = {0: "Zero", 1: "One", 2: "Two", 3: "Three", 4: "Four",
          5: "Five", 6: "Six", 7: "Seven", 8: "Eight", 9: "Nine"}
dict_2 = {11: "Eleven", 12: "Twelve", 13: "Thirteen", 14: "Fourteen",
          15: "Fifteen", 16: "Sixteen", 17: "Seventeen", 18: "Eighteen", 19: "Nineteen"}
dict_3 = {10: "Ten", 20: "Twenty", 30: "Thirty", 40: "Forty", 50: "Fifty",
          60: "Sixty", 70: "Seventy", 80: "Eighty", 90: "Ninety", 100: "Hundred"}
if len_num == 1:
    print("Number In-Words >>", dict_1[num])
elif len_num == 2:
    if num % 10 == 0:
        print("Number In-Words >>", dict_3[num])
    else:
        if num in dict_2:
            print("Number In-Words >>", dict_2[num])
        else:
            print("Number In-Words >>", dict_3[num - (num % 10)],
                  dict_1[num % 10])
elif len_num == 3:
    if num % 10 == 0:
        if (num // 10) % 10 == 0:
            print("Number In-Words >>", dict_1[(num//10)//10],
                  "Hundred")
        else:
            print("Number In-Words >> ", dict_1[(num//10)//10],
                  "Hundred and", dict_3[num % 100])
    elif (num // 10) % 10 == 0:
        print("Number In-Words >>", dict_1[(num//10)//10],
              "Hundred and", dict_1[num % 10])
    else:
        if num % 100 not in dict_2:
            print("Number In-Words >>", dict_1[(num//10)//10],
                  "Hundred and", dict_3[num % 100 - (num % 100) % 10],
                  dict_1[num % 10])
        else:
            print("Number In-Words >>", dict_1[(num//10)//10],
                  "Hundred and", dict_2[num % 100])
elif len_num == 4:
    if num % 1000 == 0:
        print("Number In-Words >>", dict_1[num // 1000], "Thousand")
    elif num % 100 == 0 and ((num // 100 % 10) != 0 and
                             (num // 100 % 10) % 10 != 0):
        print("Number In-Words >>", dict_1[num // 1000], "Thousand and",
              dict_1[(num % 1000) // 100], "Hundred")
    elif num % 10 == 0 and (num // 100 % 10 != 0 and num // 10 % 10 != 0):
        print("Number In-Words >>", dict_1[num // 1000], "Thousand",
              dict_1[num % 1000 // 100], "Hundred and",
              dict_3[(num % 1000) % 100])
    elif num % 1000 // 10 % 10 == 0 and num // 100 % 10 != 0:
        print("Number In-Words >>", dict_1[num // 1000], "Thousand",
              dict_1[num % 1000 // 100], "Hundred and",
              dict_1[num % 10])
    elif num // 100 % 10 == 0 and (num % 10 != 0 and
                                   num % 1000 // 10 != 0):
        if num % 100 not in dict_2:
            print("Number In-Words >>", dict_1[num // 1000],
                  "Thousand and", dict_3[num % 1000-(num % 1000) % 10],
                  dict_1[num % 10])
        else:
            print("Number In-Words >>", dict_1[num // 1000],
                  "Thousand and", dict_2[num % 100])
    elif num // 100 % 10 == 0 and num % 10 == 0:
        print("Number In-Words >>", dict_1[num // 1000],
              "Thousand and", dict_3[num % 100])
    elif num // 10 % 100 == 0:
        print("Number In-Words >>", dict_1[num // 1000],
              "Thousand and", dict_1[num % 10])
    else:
        if num % 100 not in dict_2:
            print("Number In-Words >>", dict_1[num // 1000],
                  "Thousand", dict_1[num // 100 % 10],
                  "Hundred and", dict_3[num % 100 - num % 100 % 10],
                  dict_1[num % 10])
        else:
            print("Number In-Words >>", dict_1[num // 1000],
                  "Thousand", dict_1[num // 100 % 10], "Hundred and",
                  dict_2[num % 100])

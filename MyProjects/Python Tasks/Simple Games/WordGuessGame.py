'''This is a game where a user thinks of a word,tells us the length of the word and the columns where the alphabets lie one by one
and our task is to simply predict/guess the word.'''
print("Think of any word and I will try to guess it!")
print("\n1\t2\t3\t4\n\nA\tB\tC\tD\nE\tF\tG\tH\nI\tJ\tK\tL\nM\tN\tO\tP\nQ\tR\tS\tT\nU\tV\tW\tX\nY\tZ\n")
column_list = ["\n1\t2\t3\t4\t5\t6\t7\n","A\tE\tI\tM\tQ\tU\tY\n",
               "B\tF\tJ\tN\tR\tV\tZ\n","C\tG\tK\tO\tS\tW\n",
               "D\tH\tL\tP\tT\tX\n"] #Storing all the 4 alphabet columns as a list.
word_len = int(input("How many letters are there in your word?:"))
count = 0
a = []
for i in range(word_len):
      a.append([]) # Until the length of the word is reached,empty lists are appended into list(a).
while count != word_len:
      for i in range(1,word_len+1): #Range is started from 1 so the user can be prompted easily what number of alphabet is
      #being asked now.
            print("\nEnter the column number for letter",str(i)+":",end='') #Prompts user to enter the column numbers in which
            #the alphabets lie respectively.
            letter = int(input()) #Waits for input.
            for x in range(1,5): #(1,5) range is taken so that the columns can be appended into list(a) easily without taking the 0th index
                  #as it contains only column numbers.
                  if letter == x:
                        a[i-1] = a[i-1] + list(column_list[x]) #When the user enters the column number,the whole column is appended
                        #into list(a) and [i-1] is the index of list(a) which is to be appended,and we want it to start with zero.
            count += 1
print(column_list[0]) #Prints column numbers 1-7.
#The part below prints those columns transversed as rows in which the alphabets lie respectively.
for i in a:
      for j in i:
            print(j,end='')
      print("",end='')
#This part is to remove /t and /n from the list(a) so it contains alphabets only.
n = 0
for i in a:
      for j in i:
            if j == "\t" or j == "\n":
                  a[n].remove(j) #Removes /t and /n if found.
      n += 1
guessed_word = '' #The variable where our guess will be stored.
for i in range(1,word_len+1): #Range is started from 1 so the user can be prompted easily what number of alphabet is
      #being asked now.
      print("\nEnter now the column number for letter",str(i)+":",end='')
      letter1 = int(input())
      guessed_word += a[i-1][letter1-1] #Adds the guessed alphabet into variable guessed_word.
      #[i-1] is to get the parent index(i.e the column) of list(a) where the 1st,2nd etc.. alphabet lies
      #and [letter1-1] is for the index of the alphabet.-1 is used because we want the indexing to start from the beginning
      #of list[i.e. 0]
print("\n** I guess your word is",guessed_word,"**")

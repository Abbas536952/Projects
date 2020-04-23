"""This is a simple game where user will be given three turns,I would be given two,user can select any two digit number
and I'll predict the answer in the beginning which will amaze the user in the end,when we sum up our results."""
import time#Imports time module for delaying output.
input_1 = int(input("Enter the first two digit number:"))#Prompts the user to input a 2-digit number.
print("Please Hold..")#Prompts the user to wait.
time.sleep(0.5)#Delays output for 0.5 seconds by putting Python to sleep.
print("\n** The final answer as per my prediction would be",input_1 + 198,"**\n")#Depending on our game,we want
#the total of user inputs(excluding input1) and our automated inputs to be exactly 198,so we simply predict the final answer
#by adding 198 to user's first number.
input_2 = int(input("Enter the second two digit number:"))#Takes input.
trick1 = int(99 - input_2)#Assigns the variable a number which will add up with input2 to make 99.
print("Please Wait..")#Prompts to wait.
time.sleep(0.5)#Sleeps.
print("\nMy turn,so let's choose",trick1,"\n")#Prints the statement along with the variable we assigned.
input_3 = int(input("Enter the third two digit number:"))#Takes input from the user.
trick2 = int(99 - input_3)#Assigns the variable a number which will add up with input3 to make 99.
print("Please Wait...")#Prompts to wait.
time.sleep(0.5)#Sleeps.
print("\nAgain my turn,I'll go with",trick2,"this time!\n")#Prints our choice.
time.sleep(0.5)#Sleeps.
print("Calculating Result...")#Prompts the statement.
time.sleep(1.3)#Sleep.
print("\n**After adding all values",(input_1 + input_2 + trick1 + input_3 + trick2),"seems to be our answer**")#Calculates
# the sum of all inputs and displays to make our game look realistic.
print("\nTake a look at our prediction!Isn't it amazing?")


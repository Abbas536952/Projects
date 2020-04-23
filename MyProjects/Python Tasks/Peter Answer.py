from msvcrt import getch
import time
petition = "Please predict the answer of the question given below....."
answer = ''
n,x = 0,0
print("\nEnter a Petition:",end='',flush=True)
while n != len(petition):
    char = getch()
    if char.decode() == "\r":
        break
    elif char.decode() == "\b":
        print("\b \b",end='',flush=True)
        n -= 2
    elif char.decode() != "/":
        print(char.decode(),end='',flush=True)
    elif char.decode() == "/":
        x = 1
        print(petition[n],end='',flush=True)
        while char.decode() == "/":
            char1 = getch()
            n += 1
            print(petition[n],end='',flush=True)
            if char1.decode() == "/":
                break
            else:
                answer = answer + char1.decode()
    n += 1
print("\n")
quest = input("Please Enter Your Question:")
print()
for j in "Hold on...":
    print(j,end='',flush=True)
    time.sleep(0.3)
if x == 1:
    print("\n\nThe answer as per my prediction is >>> "+
          str(answer))
else:
    print("\n\nI don't think I am supposed to answer you.")



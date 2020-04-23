import mysql.connector
prime_db = mysql.connector.connect(host="localhost",user="Abbas",passwd="Srfaasbl123!!")
prime_cursor = prime_db.cursor()
try:
        prime_cursor.execute("CREATE DATABASE PrimeNumbers")
except mysql.connector.errors.DatabaseError:
        pass
finally:
        prime_db = mysql.connector.connect(host="localhost",user="Abbas",passwd="Srfaasbl123!!",database="PrimeNumbers")
        prime_cursor = prime_db.cursor()
        try:
                prime_cursor.execute("CREATE TABLE PrimeCheck(Numbers varchar(255),PrimeORNot varchar(255))")
        except mysql.connector.errors.ProgrammingError:
                pass
        finally:
                n = int(input("Please Enter a Number:"))
                q1 = ("SELECT PrimeORNot FROM PrimeCheck WHERE Numbers = '%s'")
                v1 = n
                prime_cursor.execute(q1,(v1,))
                prime_result = prime_cursor.fetchone()
                if prime_result == None:
                        check = "Not Prime"
                        for i in range(2,n+1):
                                if i != n and n % i == 0:
                                        check = "Not Prime"
                                        break
                                else:
                                        check = "Prime"
                        q = ("INSERT INTO PrimeCheck(Numbers,PrimeORNot) VALUES(%s,%s)")
                        val = (n,check)
                        prime_cursor.execute(q,val)
                        prime_db.commit()
                        print(prime_cursor.rowcount,"record inserted.")
                else:
                        print("\n"+str(n)," is already in our record.\nAs per our record,this number is",prime_result[0])
















































































# import mysql.connector
# d_base = mysql.connector.connect(host='localhost',user='Abbas',passwd='Srfaasbl123!!')
# d_cursor = d_base.cursor()
# try:
#         d_cursor.execute("CREATE DATABASE StudentRecords")
# except mysql.connector.errors.DatabaseError:
#         pass
# finally:
#         d_base = mysql.connector.connect(host='localhost',user='Abbas',passwd='Srfaasbl123!!',database="StudentRecords")
#         d_cursor = d_base.cursor()
#         try:
#                 d_cursor.execute("CREATE TABLE Records(Name varchar(255),EnrollmentNum varchar(255))")
#         except mysql.connector.errors.ProgrammingError:
# 		# d_cursor.execute("DROP TABLE Records")
# 		# d_cursor.execute("CREATE TABLE Records(Name varchar(255),EnrollmentNum varchar(255))")
#                 pass
#         finally:
#                 d_cursor.execute("TRUNCATE TABLE Records")
#                 for i in range(3):
#                         query = ("INSERT INTO Records (Name,EnrollmentNum) VALUES(%s,%s)")
#                         name = input("Enter Your Name:")
#                         enrollment = input("Enter Enrollment:")
#                         val = (name,enrollment)
#                         d_cursor.execute(query,val)
#                 d_cursor.execute("SELECT * FROM Records")
#                 my_result = d_cursor.fetchone()
#                 print(my_result)
		






	






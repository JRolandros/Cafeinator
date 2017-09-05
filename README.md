# Cafeinator

## Set Everything Up
To run This project correctly, you must:
- Firstly Create a database called "CafeinatorDB"
- Then run the data model script: CafeinatorDBScript.sql (find it in /Cafeinator.DataAccess/Script folder) to create all db objects. 
- Now, run your sample data script:dbData.sql (in the same folder)

- Lastly, Update you EF model (connected to the previous database created): make sure to give the name CafeinatorDBModel to your EF model and CafeinatorDBEntities to your EF db context.
Nota: For this solution, you don't need to import table objects from your database in EF, because everything related to database is hanled via stored procedures
 
- When everything is set up, check if the app runs (you can begin checking if all services run as expected by running units tests).
 
 ## Important !
 I will add the last part of this project when I will be a little more free. The most important missing part is the capability of the app to run offline
 this is the aim of Cafeinator.Config project (which is still in developpment, coming soon...).
 
 ## ENJOY YOUR COFFEE... !

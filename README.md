# Project_Assignment_Store

This is a project assignment on the jewellery store.
I'll keep adding more details here.

**The solution is 3-tier architecture and has component : database, backend and front end.**

**Database:** The databse is in MS-SQL Server. So, you will need SQL server installed on your system.
Once the server is avilable. Please run these below scripts in order as defined below for basic structure setup.
 1. Create.sql
 2. CreateTables.sql
 3. Insert.sql

**Backend:** The backend is based on .Net Core Framework. So, you will need .Net Core SDK to be installed to setup the system(and VSCode/VS Studio for development machine).
The backend is using Layered architecture with Repository Pattern and dependency injection. Also, the api use openAPI swagger for quick GUI based testing of api endpoints.
It has 4 layers: 
1. API :To accept the request and send response
2. Business: To pre-process data before the operation
3. DataAccess: To Process the data from/to SQL Database
4. Core: It include the DTO(Data Transfer Objects) and helper functions and this layer is common and used in all others.

**Frontend:** The frontend is in Angular 10.x. So, you will need node.js and angular cli installed on system. It is using JWT based authentication and lazy loading.
Also, It is using Angular material and bootstrap components and JSPDF to print the calculation details in pdf format.


**Instructions: How to run the solution:**
After setup of all the required softwares and runtime. You need to first run the backend(.Net core solution) and then frontend (Angular).

**Note:** To install dependencies and run the soltion
1. Backend: Visual studio will restore automatically, but if not please run 'dotnet restore' in the root of backend folder where "Store.Api" soln file is avialable.
2. Frontend: Please run 'npm install' to add all dependencies in local before you run the "ng serve" to the frontend solution.

Once backend is up, please notice the URL and cross check in frontend appsettings.js file avilable under path 'frontend\src\appsettings.js'
Once frontend is up, you will be able to see the login screen and you can login using below credentials:

| Type| Login-Name | Password |
| :- | - |
| **Privileged User** |  verma_0795| Password|
| **Normal User** |  vermas0795| Password|

After, login you will be able to see jewellery store home screen and can perform calculation operations.
By default, all the buttons will be disabled and only after user input values to be calculate the "Calculation" button to calulate final price with/without discount and "Cancel"
to clear data will be enabled.
Once you caluculate value all the print related buttons "Print To Screen" to print in modal pop up, "Print To File" to print in pdf downloadable format and "Print To Page" which is a feature to be added soon will get enbaled.

**Note:** If you are logged in as Normal user the discount will not be aplicable and visible
If you are logged in as Privileged user the discount will be aplicable automatically and default value is setup by owner using database.





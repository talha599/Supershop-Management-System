# Supershop Management System

The Supershop Management System is a comprehensive software solution designed to streamline the operations of retail businesses. This system integrates various functionalities such as inventory management, sales tracking, customer relationship management, and reporting into a user-friendly interface, enabling shop owners to efficiently manage their daily activities.




## Prerequisites

- .NET Framework (version 4.7.2 or higher)
- SQL Server (version 2012 or higher)
- SQL Server Management Studio (SSMS)
- Visual Studio (Community Edition or higher)



## How to Run

Step 1: Setup the Database

1. Create a New Database:

- Open SQL Server Management Studio (SSMS).
- Right-click on `Databases` and select `New Database`.
- Name the database  `ContactDB`.

2. Generate the Table Script:

- Copy the following SQL script and execute it in SSMS to create the `Contacts` table:

```bash
  CREATE TABLE Contacts (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LasttName NVARCHAR(50),
    Phone NVARCHAR(20),
    Age INT
);
```
3. Backup the Database (Optional):

- Right-click on `ContactDB` in SSMS.
- Select `Tasks` -> `Back Up`.
- Choose the destination and backup the database for future use.

Step 2: Configure the Application
1. Clone the Repository:

- Clone this repository to your local machine using:

```bash
  git clone < https://github.com/talha599/CrudApp-Readme >
```
2. Open the Solution:

- Open the solution file `(.sln)` in Visual Studio.
3. Modify the Connection String:

- Open the `app.config` file.
- Update the connection string to point to your local SQL Server instance and the ContactDB database:

```bash
  <connectionStrings>
    <add name="ContactDB" connectionString="Data Source=TALHA;Initial Catalog=MyCURD;Integrated Security=True;TrustServerCertificate=True" />
</connectionStrings>

```

Step 3: Run the Application
1. Build the Solution:

- Build the solution in Visual Studio to restore all necessary packages.
2. Run the Application:

- Press `F5` or click `Start` in Visual Studio to run the application.
3. Perform CRUD Operations:

 You can now perform the following operations:
- Create: Add new contacts.
- Read: View the list of contacts.
- Update: Modify contact details.
- Delete: Remove a contact.
## Database Backup

To backup the `smarket` database:

1. Open SSMS and right-click on the `smarket`.
2. Navigate to `Tasks` -> `Back Up`.
3. Select the destination and click `OK` to create a backup file.
## Support

For support, Email: talhasedubd@gmail.com or Watch: https://youtu.be/mzeUKQjJK5c?si=DE7m4-4V1Ae4Wrq1


## License

This project is licensed under the [MIT](https://choosealicense.com/licenses/mit/) License - see the LICENSE.md file for details.



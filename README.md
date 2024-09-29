# Supershop Management System

The Supershop Management System is a comprehensive software solution designed to streamline the operations of retail businesses. This system integrates various functionalities such as inventory management, sales tracking, customer relationship management, and reporting into a user-friendly interface, enabling shop owners to efficiently manage their daily activities.

## Features

- Inventory Management: Track products, manage stock levels, and receive alerts for low inventory.
- Sales Tracking: Monitor sales transactions, generate receipts, and view daily/weekly/monthly sales reports.
- Customer Relationship Management: Store customer information, purchase history, and provide better service through insights.
- Reporting: Generate detailed reports on sales, inventory, and customer activity to facilitate informed decision-making.
- Real-time Data Analysis: View real-time metrics to track performance and growth.
- Scalability: Easily expand the system for use in larger stores or chains.

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
 CREATE TABLE [dbo].[SellerTbl] (
    [SellerId]       INT          NOT NULL,
    [SellerName]     VARCHAR (50) NOT NULL,
    [SellerAge]      INT          NOT NULL,
    [SellerPhone]    VARCHAR (50) NOT NULL,
    [SellerPassword] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([SellerId] ASC)
);
```
```bash
    [ProdId]    INT          NOT NULL,
    [ProdName]  VARCHAR (50) NOT NULL,
    [ProdQty]   INT          NOT NULL,
    [ProdPrice] INT          NOT NULL,
    [ProdCat]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProdId] ASC)
);

```
```bash
CREATE TABLE [dbo].[CategoryTbl] (
    [CatId]   INT           NOT NULL,
    [CatName] VARCHAR (50)  NOT NULL,
    [CatDesc] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([CatId] ASC)
);

```
```bash
CREATE TABLE [dbo].[BillTbl] (
    [BillId]     INT          NOT NULL,
    [SellerName] VARCHAR (50) NOT NULL,
    [BillDate]   VARCHAR (50) NOT NULL,
    [TotAmt]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([BillId] ASC)
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
  git clone < https://github.com/talha599/Supershop-Management-System >
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
- Create: Add new Data.
- Read: View the list of contacts.
- Update: Modify contact details.
- Delete: Remove a contact.

## Table Structure
![Screenshot 2024-09-29 022037](https://github.com/user-attachments/assets/5db41f8d-6c3a-46b9-82d8-ffa98ab0aee4)

![Screenshot 2024-09-29 022220](https://github.com/user-attachments/assets/4f151c1e-899f-41f1-8be2-8adb8b88d2fe)

![Screenshot 2024-09-29 022702](https://github.com/user-attachments/assets/7f4c3cfd-8272-4c97-a727-cb43aa81d95e)

![Screenshot 2024-09-29 024016](https://github.com/user-attachments/assets/eae38943-cc30-4d32-9b09-a4b60b3cb7d7)

## Technologies Used
- C#
- ASP.NET Core / .NET Framework
- Entity Framework Core
- Microsoft SQL Server
- Bootstrap (UI Framework)

## Database Backup

To backup the `smarket` database:

1. Open SSMS and right-click on the `smarket`.
2. Navigate to `Tasks` -> `Back Up`.
3. Select the destination and click `OK` to create a backup file.

## Screenshorts of Forms
![Screenshot 2024-09-29 025217](https://github.com/user-attachments/assets/c3f9b98f-47a9-4aa1-a44f-d423c3d2576d)

![Screenshot 2024-09-29 024214](https://github.com/user-attachments/assets/ee4b12a0-e480-4779-8858-9f877fd986a7)

![Screenshot 2024-09-29 024259](https://github.com/user-attachments/assets/5fbc1e40-2bfd-4470-a22e-7d4fa04ef155)

![Screenshot 2024-09-29 024334](https://github.com/user-attachments/assets/094f0b4e-5e8d-4331-8d5a-fcb2fb4763c5)

![Screenshot 2024-09-29 024355](https://github.com/user-attachments/assets/1b237e25-889e-4e80-b6a8-b08176ac6163)

![Screenshot 2024-09-29 024459](https://github.com/user-attachments/assets/b32b04f5-9ac9-422e-96e7-5954ceae3d48)

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you have any suggestions for improving the system.

1. Fork the repository.
2. Create a new branch `(git checkout -b feature-branch)`.
3. Commit your changes `(git commit -am 'Add new feature')`.
4. Push to the branch `(git push origin feature-branch)`.
5.Create a new Pull Request.

## Support

For support, Email: talhasedubd@gmail.com or Watch: https://youtu.be/mzeUKQjJK5c?si=DE7m4-4V1Ae4Wrq1


## License

This project is licensed under the [MIT](https://choosealicense.com/licenses/mit/) License - see the LICENSE.md file for details.



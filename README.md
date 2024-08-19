# Form Submission and Management System

## Overview

This project is a web application designed to handle form submissions, including saving form data to a database, sending email notifications, and providing an admin interface for managing forms.

## Features

- **Form Submission**: Users can submit forms with their email, name, subject, and message.
- **Email Notification**: Sends an email notification upon successful form submission.
- **Admin Panel**: Allows admins to view, edit, and delete form entries.

## Technologies Used

- ASP.NET Web Forms
- C#
- MS SQL Server
- HTML/CSS

## Setup and Configuration

1. **Open the project in Visual Studio**.

2. **Configure the database connection before using the project**:
Update the `Web.config` file with your database connection string:
```xml
<connectionStrings>
   <add name="DBConnection" connectionString="your_connection_string" providerName="System.Data.SqlClient" />
</connectionStrings>
```
   
Ensure the database has a table named "Forms".
You can create this table using the following SQL script:
   ```sql
   CREATE TABLE Forms (
    id INT PRIMARY KEY IDENTITY,
    email NVARCHAR(320) NOT NULL,
    firstName NVARCHAR(50) NOT NULL,
    lastName NVARCHAR(50),
    subject NVARCHAR(50) NOT NULL,
    message NVARCHAR(MAX) NOT NULL
	);
	```
3. **Build and run the project in Visual Studio.**

## Validation and Error Handling

Uses RequiredFieldValidator and RegularExpressionValidator for form input validation.
Displays success or error messages based on the outcome of form submissions and updates.

## Notes

Most of the code is explained within the project using comments. Please refer to the inline comments.



Use master

Create Database ForrealDB

Go

Use ForrealDB

Go

Create Table Users (

ID int Identity primary key,

Email nvarchar(100) not null,

FirstName nvarchar(30) not null,

LastName nvarchar(30) not null,

UserPswd nvarchar(30) not null,

CONSTRAINT UC_Email UNIQUE(Email)

)

Go

INSERT INTO Users VALUES
('dark@goomer.com','dark','goomer','1234');

GO
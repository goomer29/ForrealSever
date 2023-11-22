Use master

Create Database ForrealDB

Go

Use ForrealDB

Go

Create Table Users (

ID int Identity primary key,

Email nvarchar(100) not null,

UserName nvarchar(100) not null,

UserPswd nvarchar(30) not null,

CONSTRAINT UC_Email UNIQUE(Email)

)

Go

INSERT INTO Users VALUES
('dark@goomer.com','darkgoomer','1234');

GO
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

INSERT INTO [dbo].[Users] ([Email], [UserName], [UserPswd]) VALUES (N'dark@goomer.com', N'darkgoomer', N'1234')
INSERT INTO [dbo].[Users] ([Email], [UserName], [UserPswd]) VALUES (N'avig@gmail.cum', N'avigdor', N'1234569')

GO
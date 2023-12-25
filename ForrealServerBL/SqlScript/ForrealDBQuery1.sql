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
Create Table Challanges(
ID int Identity primary key,
Difficult int not null,
[Text] nvarchar(255) not null,
)

GO
Create Table Users_Challanges(
ID int Identity primary key,
UserID int not null,
ChallangeID int not null,
)
Go
Alter Table Users_Challenges Add Constraint FK_Users_Challenges_UserID Foreign Key (UserID) References Users(ID)
Alter Table Users_Challenges Add Constraint FK_Users_Challenges_ChallangeID Foreign Key (ChallangeID) References Challanges(ID)

Go

INSERT INTO [dbo].[Users] ([Email], [UserName], [UserPswd]) VALUES (N'dark@goomer.com', N'darkgoomer', N'1234')
INSERT INTO [dbo].[Users] ([Email], [UserName], [UserPswd]) VALUES (N'avig@gmail.cum', N'avigdor', N'1234569')
INSERT INTO [dbo].[Challanges] ([Difficult], [Text]) VALUES (N'1',N'say mullet')
GO
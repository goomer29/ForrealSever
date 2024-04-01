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
Create Table Challenges(
ID int Identity primary key,
Difficult int not null,
[Text] nvarchar(255) not null,
)

GO
Create Table Users_Challenges(
ID int Identity primary key,
UserID int not null,
ChallengeID int not null,
Media varchar(255) NULL,
)
SET IDENTITY_INSERT [dbo].[Users_Challenges] ON
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (1, 1, 3, N'1-3.jpg')
SET IDENTITY_INSERT [dbo].[Users_Challenges] OFF

Go
Alter Table Users_Challenges Add Constraint FK_Users_Challenges_UserID Foreign Key (UserID) References Users(ID)
Alter Table Users_Challenges Add Constraint FK_Users_Challenges_ChallangeID Foreign Key (ChallengeID) References Challenges(ID)

Go

INSERT INTO [dbo].[Users] ([Email], [UserName], [UserPswd]) VALUES (N'dark@goomer.com', N'darkgoomer', N'1234')
INSERT INTO [dbo].[Users] ([Email], [UserName], [UserPswd]) VALUES (N'avig@gmail.cum', N'avigdor', N'1234569')
SET IDENTITY_INSERT [Challenges] ON
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (1, 1, N'say mullet')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (2, 1, N'say mullet')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (3, 2, N'tell a stupid joke to a friend')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (4, 3, N'take a picture with someone with a yellow shirt')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (5, 4, N'take a picture from the grabege mountain')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (6, 4, N'do a backflip')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (7, 5, N'do a boreg')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (8, 1, N'say avigdormullet')
GO
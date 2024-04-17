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

Go
Alter Table Users_Challenges Add Constraint FK_Users_Challenges_UserID Foreign Key (UserID) References Users(ID)
Alter Table Users_Challenges Add Constraint FK_Users_Challenges_ChallangeID Foreign Key (ChallengeID) References Challenges(ID)
Go
CREATE TABLE [dbo].[Friends] (
    [ID]      INT IDENTITY (1, 1) NOT NULL,
    [User1ID] INT NOT NULL,
    [User2ID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Friends_User1ID] FOREIGN KEY ([User1ID]) REFERENCES [dbo].[Users] ([ID]),
	CONSTRAINT [FK_Friends_User2ID] FOREIGN KEY ([User2ID]) REFERENCES [dbo].[Users] ([ID])
);
Go
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (1, N'dark@goomer.com', N'darkgoomer', N'1234')
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (2, N'avig@gmail.cum', N'avigdor', N'1234569')
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (3, N'goldfish@gmail.com', N'goldfish', N'blueblue123')
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (4, N'ofiravr06@gmail.com', N'Mandi', N'ofir2856')
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (5, N'noa@gmail', N'Noa', N'123')
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (6, N'shmantul@rushi.meow', N'gilgol55', N'shmantul123')
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (7, N'bot@gmail.com', N'bot', N'bot123')
SET IDENTITY_INSERT [dbo].[Users] OFF
Go

SET IDENTITY_INSERT [Challenges] ON
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (1, 1, N'say mullet')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (2, 1, N'say mullet')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (3, 2, N'tell a stupid joke to a friend')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (4, 3, N'take a picture with someone with a yellow shirt')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (5, 4, N'take a picture from the grabege mountain')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (6, 4, N'do a backflip')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (7, 5, N'do a boreg')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (8, 1, N'say avigdormullet')
SET IDENTITY_INSERT [Challenges] OFF
GO

SET IDENTITY_INSERT [dbo].[Users_Challenges] ON
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (1, 1, 3, N'1-3.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (2, 4, 8, N'4-8.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (3, 5, 5, N'5-5.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (4, 5, 5, N'5-5.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (5, 6, 3, N'6-3.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (6, 7, 6, N'7_6_17_4_2024.jpg')
SET IDENTITY_INSERT [dbo].[Users_Challenges] OFF
Go

SET IDENTITY_INSERT [dbo].[Friends] ON
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (6, 1, 5)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (9, 3, 2)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (10, 3, 1)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (11, 3, 6)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (12, 1, 6)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (13, 1, 3)
SET IDENTITY_INSERT [dbo].[Friends] OFF

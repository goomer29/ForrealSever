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
CREATE TABLE [dbo].[Messages] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [UserChID]   INT           NOT NULL,
    [UserSentID] INT           NOT NULL,
    [Message]    VARCHAR (255) NULL,
    [Time]       SMALLDATETIME NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Friends_UserChID] FOREIGN KEY ([UserChID]) REFERENCES [dbo].[Users_Challenges] ([ID]),
    CONSTRAINT [FK_Friends_UserSentID] FOREIGN KEY ([UserSentID]) REFERENCES [dbo].[Users] ([ID])
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
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (8, N'gilramot@github.com', N'gil', N'omergolan')
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (9, N'a@', N'avital', N'123')
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (10, N'zebra@gmail.com', N'zebra', N'white')
INSERT INTO [dbo].[Users] ([ID], [Email], [UserName], [UserPswd]) VALUES (11, N'shalom@gmail.com', N'shalom', N'shalom123')
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
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (9, 2, N'go to a freinds house when they dont know')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (10, 3, N'jump in a rope 250 times')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (11, 4, N'eat a meal with only your hand')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (12, 5, N'jump to a pool with clothers on')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (13, 1, N'touch the grass outside')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (14, 2, N'take a selfy with a stranger')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (15, 3, N'sniff a sock')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (16, 4, N'eat an ice cream with something gross')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (17, 5, N'make an add for something pointless and post it on youtube')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (18, 1, N'sit on a chair not the right way')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (19, 2, N'recycle a bottle')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (20, 3, N'hold in one hand red candy and in other a blue one')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (21, 4, N'play sport game with at least one stranger')
INSERT INTO [dbo].[Challenges] ([ID], [Difficult], [Text]) VALUES (22, 5, N'go to a very crowd place with a costume ')
SET IDENTITY_INSERT [Challenges] OFF
GO

SET IDENTITY_INSERT [dbo].[Users_Challenges] ON
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (1, 1, 3, N'1-3.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (2, 4, 8, N'4-8.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (3, 5, 5, N'5-5.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (4, 5, 5, N'5-5.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (5, 6, 3, N'6-3.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (6, 7, 6, N'7_6_17_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (7, 7, 8, N'7_8_18_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (8, 1, 6, N'1_6_18_4_2024.JPG')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (9, 7, 4, N'7_4_18_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (10, 5, 3, N'5_3_18_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (11, 5, 1, N'5_1_18_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (12, 3, 5, N'3_5_18_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (13, 7, 7, N'7_7_19_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (14, 1, 7, N'1_7_22_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (15, 7, 5, N'7_5_22_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (16, 1, 6, N'1_6_22_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (17, 7, 1, N'7_1_22_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (18, 1, 4, N'1_4_25_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (19, 3, 3, N'3_3_25_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (20, 3, 4, N'3_4_25_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (21, 1, 1, N'1_1_25_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (22, 7, 7, N'7_7_25_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (23, 2, 3, N'2_3_25_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (24, 1, 3, N'1_3_27_4_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (25, 7, 5, N'7_5_27_4_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (26, 3, 6, N'3_6_27_4_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (27, 1, 3, N'1_3_28_4_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (28, 1, 4, N'1_4_29_4_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (29, 7, 6, N'7_6_29_4_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (30, 3, 5, N'3_5_29_4_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (31, 6, 4, N'6_4_1_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (32, 1, 7, N'1_7_1_5_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (33, 7, 4, N'7_4_1_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (34, 1, 3, N'1_3_1_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (35, 7, 1, N'7_1_1_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (36, 1, 1, N'1_1_1_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (37, 1, 4, N'1_4_6_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (38, 1, 3, N'1_3_6_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (39, 1, 8, N'1_8_6_5_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (40, 3, 4, N'3_4_6_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (41, 7, 7, N'7_7_6_5_2024.PNG')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (42, 7, 6, N'7_6_6_5_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (43, 7, 1, N'7_1_6_5_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (44, 3, 3, N'3_3_6_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (45, 6, 3, N'6_3_8_5_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (46, 1, 5, N'1_5_8_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (47, 1, 3, N'1_3_11_5_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (48, 7, 5, N'7_5_11_5_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (49, 1, 10, N'1_10_12_5_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (50, 7, 5, N'7_5_12_5_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (51, 1, 9, N'1_9_15_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (52, 7, 9, N'7_9_15_5_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (53, 3, 4, N'3_4_15_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (54, 3, 10, N'3_10_15_5_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (55, 1, 5, N'1_5_15_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (56, 8, 9, N'8_9_15_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (57, 9, 3, N'9_3_15_5_2024.png')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (58, 1, 12, N'1_12_15_5_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (59, 7, 6, N'7_6_16_5_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (60, 1, 3, N'1_3_16_5_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (61, 11, 3, N'11_3_6_6_2024.mp4')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (62, 1, 13, N'1_13_6_6_2024.jpg')
INSERT INTO [dbo].[Users_Challenges] ([ID], [UserID], [ChallengeID], [Media]) VALUES (63, 7, 4, N'7_4_6_6_2024.jpeg')
SET IDENTITY_INSERT [dbo].[Users_Challenges] OFF
Go

SET IDENTITY_INSERT [dbo].[Friends] ON
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (9, 3, 2)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (11, 3, 6)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (15, 5, 4)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (17, 5, 2)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (18, 7, 1)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (20, 7, 3)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (22, 1, 7)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (23, 1, 5)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (24, 1, 3)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (26, 3, 4)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (27, 3, 1)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (28, 1, 4)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (30, 2, 3)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (31, 7, 2)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (32, 2, 7)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (33, 6, 3)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (34, 6, 1)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (35, 6, 5)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (36, 6, 2)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (38, 1, 6)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (39, 1, 11)
INSERT INTO [dbo].[Friends] ([ID], [User1ID], [User2ID]) VALUES (40, 11, 1)
SET IDENTITY_INSERT [dbo].[Friends] OFF
Go

SET IDENTITY_INSERT [dbo].[Messages] ON
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (1, 50, 1, N'no pain no gain', N'2024-05-12 11:46:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (2, 50, 1, N'Lol', N'2024-05-12 11:46:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (3, 50, 7, N'bomboclattttt', N'2024-05-12 12:34:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (4, 50, 7, N'bomboclattttt', N'2024-05-12 12:34:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (5, 51, 1, N'this is the best post', N'2024-05-15 13:08:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (6, 51, 1, N'ahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh', N'2024-05-15 13:08:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (7, 59, 1, N'Wow! very cool', N'2024-05-16 09:37:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (8, 59, 7, N'Thank you :D', N'2024-05-16 09:38:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (9, 59, 7, N'took me alot of time', N'2024-05-16 09:39:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (10, 59, 7, N'What was your challenge?', N'2024-05-16 09:42:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (11, 61, 1, N'Hahaha so funny', N'2024-06-06 02:15:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (12, 61, 11, N'thank you :D', N'2024-06-06 02:17:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (13, 62, 7, N'very nice post!', N'2024-06-06 11:24:00')
INSERT INTO [dbo].[Messages] ([ID], [UserChID], [UserSentID], [Message], [Time]) VALUES (14, 62, 1, N'thank you', N'2024-06-06 11:25:00')
SET IDENTITY_INSERT [dbo].[Messages] OFF

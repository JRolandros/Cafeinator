USE [CafeinatorDB]
GO

/****** Object:  Table [dbo].[User]    Script Date: 30/08/2017 18:37:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--User table
CREATE TABLE [dbo].[CafeinatorUser](
	[BCode] [nvarchar](50) NULL,
	[usrName] [nvarchar](50) NULL,
	[usrID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
 )

 GO

 --Drink Type table
 CREATE TABLE [dbo].[DrinkType](
	[drkID] [int] IDENTITY(1,1) NOT NULL,
	[drkLabel] [nchar](10) NULL,
 CONSTRAINT [PK_DrinkType] PRIMARY KEY CLUSTERED 
(
	[drkID] ASC
)
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Menu](
	[MenuUsrID] [int] NOT NULL,
	[MenuDrkID] [int] NOT NULL,
	[SugarQty] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuUsrID] ASC,
	[MenuDrkID] ASC
)
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_DrinkType_Menu] FOREIGN KEY([MenuDrkID])
REFERENCES [dbo].[DrinkType] ([drkID])
GO

ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_DrinkType_Menu]
GO

ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_User_Menu] FOREIGN KEY([MenuUsrID])
REFERENCES [dbo].[CafeinatorUser] ([usrID])
GO

ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_User_Menu]
GO

-------PROCEDURE ------
--GetUSer
create procedure GetUser
@bcode nvarchar(50)
AS
SELECT [BCode], [usrName], [usrID] FROM dbo.[CafeinatorUser] WHERE BCode=@bcode

Go

--AddNewUser
create procedure AddNewUser
@bcode nvarchar(50),@usrName nvarchar(50)
AS
INSERT INTO dbo.[CafeinatorUser]([BCode], [usrName])VALUES(@bcode,@usrName)

SELECT [BCode], [usrName], [usrID] FROM dbo.[CafeinatorUser] WHERE BCode=@bcode

Go
--GetUserLastChoice
create procedure GetUserLastChoice
@userID int
AS
DECLARE @drkID int=(SELECT MenuDrkID FROM Menu WHERE MenuUsrID=@userID)
DECLARE @sugarQty int =(SELECT SugarQty FROM Menu WHERE MenuUsrID=@userID)

SELECT drkID,drkLabel, @sugarQty AS sugarQty FROM DrinkType WHERE drkID=@drkID

Go
--SaveUserLastChoice

--SaveUserLastChoice 1001,1,2
create procedure SaveUserLastChoice
@userID int,@drkID int,@sugarQty int
AS
IF(EXISTS(SELECT MenuDrkID FROM Menu WHERE MenuUsrID=@userID))
BEGIN
UPDATE Menu
SET MenuDrkID=@drkID, SugarQty=@sugarQty
WHERE MenuUsrID=@userID
END
ELSE
INSERT INTO Menu(MenuUsrID,MenuDrkID,SugarQty) VALUES (@userID,@drkID,@sugarQty)

Go
--GetAllDrinkType
create procedure GetAllDrinkType
AS 
SELECT drkID,drkLabel FROM DrinkType

Go
--DeleteUser
CREATE PROCEDURE [dbo].[DeleteUser]
	@usrID int
AS
	DELETE dbo.CafeinatorUser where usrID=@usrID
Go

--DeleteMenu
CREATE PROCEDURE DeleteMenu
@usrID int
AS
DELETE Menu WHERE MenuUsrID=@usrID

Go


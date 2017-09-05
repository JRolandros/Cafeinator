USE [CafeinatorDB]
GO
SET IDENTITY_INSERT [dbo].[DrinkType] ON
INSERT [dbo].[DrinkType] ([drkID], [drkLabel]) VALUES (1, N'Cafe      ')
INSERT [dbo].[DrinkType] ([drkID], [drkLabel]) VALUES (2, N'The       ')
INSERT [dbo].[DrinkType] ([drkID], [drkLabel]) VALUES (3, N'Chocolat  ')
SET IDENTITY_INSERT [dbo].[DrinkType] OFF


SET IDENTITY_INSERT [dbo].[CafeinatorUser] ON
INSERT [dbo].[CafeinatorUser] ([BCode], [usrName], [usrID]) VALUES (N'2017', N'user1', 1)
SET IDENTITY_INSERT [dbo].[CafeinatorUser] OFF

INSERT [dbo].[Menu] ([MenuUsrID], [MenuDrkID], [SugarQty]) VALUES (1, 1, 2)

/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [TestDB]
GO
INSERT [dbo].[Team] ([TeamRef], [TeamName]) VALUES (N'159cbebd-9584-4d8e-ae01-2bdc304eb5a7', N'TeamA')
GO
INSERT [dbo].[Team] ([TeamRef], [TeamName]) VALUES (N'a6616c68-df9b-4518-acb0-baf3d5ae0c80', N'TeamB')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'daf46eb9-399c-4411-b816-09a9359bbd4a', N'159cbebd-9584-4d8e-ae01-2bdc304eb5a7', N'Player6')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'bc0019bd-cbf6-49d1-aebf-1d2e058fe7da', N'a6616c68-df9b-4518-acb0-baf3d5ae0c80', N'PlayerIV')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'c4b0061e-58fa-4a36-b1b1-275f9131cd71', N'159cbebd-9584-4d8e-ae01-2bdc304eb5a7', N'Player3')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'95a68c9e-1ce6-4144-932e-39ab8699af6f', N'a6616c68-df9b-4518-acb0-baf3d5ae0c80', N'PlayerII')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'9b8b3f6e-340f-4b7a-b072-4b5509f1e9fc', N'159cbebd-9584-4d8e-ae01-2bdc304eb5a7', N'Player2')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'183b53b5-37f5-4a36-be44-8646eba6af76', N'a6616c68-df9b-4518-acb0-baf3d5ae0c80', N'PlayerI')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'54c51cd0-b149-4243-a11f-97bfcd8de1d1', N'159cbebd-9584-4d8e-ae01-2bdc304eb5a7', N'Player5')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'a1e9d6dd-7687-467f-a199-9bcbdfb56a08', N'a6616c68-df9b-4518-acb0-baf3d5ae0c80', N'PlayerIII')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'42da9ae6-107a-45ee-a8a7-b0d62ed0b0f4', N'159cbebd-9584-4d8e-ae01-2bdc304eb5a7', N'Player7')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'3bb3bde5-8920-40b7-b7a8-c1b41d9bb652', N'159cbebd-9584-4d8e-ae01-2bdc304eb5a7', N'Player4')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'da77076b-5154-4c12-bdbf-c33587948e2d', N'a6616c68-df9b-4518-acb0-baf3d5ae0c80', N'PlayerV')
GO
INSERT [dbo].[Player] ([PlayerRef], [TeamRef], [PlayerName]) VALUES (N'17abe42c-5453-4f66-bf3b-d7f197aadb2b', N'159cbebd-9584-4d8e-ae01-2bdc304eb5a7', N'Palyer1')
GO


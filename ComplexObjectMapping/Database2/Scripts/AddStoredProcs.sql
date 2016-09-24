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
/****** Object:  StoredProcedure [dbo].[pGetPlayers]    Script Date: 24/09/2016 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pGetPlayers]
AS
	SELECT * FROM Player
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[pGetTeams]    Script Date: 24/09/2016 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pGetTeams]
AS
	SELECT * FROM Team;
RETURN 0
GO

SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[pGetAll]
AS
BEGIN
	SELECT * FROM Team;
	SELECT * FROM Player;
RETURN 0
GO
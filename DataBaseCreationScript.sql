﻿USE [master]
GO
/****** Object:  Database [TestDB]    Script Date: 17/09/2016 23:03:19 ******/
CREATE DATABASE [TestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\TestDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\TestDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TestDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestDB] SET  MULTI_USER 
GO
ALTER DATABASE [TestDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TestDB] SET QUERY_STORE = OFF
GO
USE [TestDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [TestDB]
GO
/****** Object:  Table [dbo].[CustomPublicHoliday]    Script Date: 17/09/2016 23:03:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomPublicHoliday](
	[CustomPublicHolidayRef] [uniqueidentifier] NOT NULL,
	[CustomPublicHolidayName] [nvarchar](50) NULL,
 CONSTRAINT [PK_CustomPublicHoliday] PRIMARY KEY CLUSTERED 
(
	[CustomPublicHolidayRef] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomPublicHolidayDay]    Script Date: 17/09/2016 23:03:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomPublicHolidayDay](
	[CustomPublicHolidayDayRef] [uniqueidentifier] NOT NULL,
	[CustomPublicHolidayRef] [uniqueidentifier] NOT NULL,
	[HolidayDayName] [nvarchar](50) NOT NULL,
	[HolidayDate] [date] NOT NULL,
 CONSTRAINT [PK_CustomPublicHolidayDay_1] PRIMARY KEY CLUSTERED 
(
	[CustomPublicHolidayDayRef] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[CustomPublicHoliday] ([CustomPublicHolidayRef], [CustomPublicHolidayName]) VALUES (N'8ae54549-54df-4582-a187-2b77bfcb8b49', N'ClanB')
GO
INSERT [dbo].[CustomPublicHoliday] ([CustomPublicHolidayRef], [CustomPublicHolidayName]) VALUES (N'281ecd4d-6eb2-4e6a-b6d6-38ffe0ed1ccf', N'ClanC')
GO
INSERT [dbo].[CustomPublicHoliday] ([CustomPublicHolidayRef], [CustomPublicHolidayName]) VALUES (N'09730aa9-3353-4416-82c5-a2b037e2da68', N'ClanA')
GO
INSERT [dbo].[CustomPublicHoliday] ([CustomPublicHolidayRef], [CustomPublicHolidayName]) VALUES (N'de54a924-5b3e-464c-8baa-f9f081127804', N'ClanD')
GO
INSERT [dbo].[CustomPublicHolidayDay] ([CustomPublicHolidayDayRef], [CustomPublicHolidayRef], [HolidayDayName], [HolidayDate]) VALUES (N'b2113eb5-58d0-4695-bd7a-902e32297830', N'09730aa9-3353-4416-82c5-a2b037e2da68', N'Guy Fawkes', CAST(N'2016-11-05' AS Date))
GO
ALTER TABLE [dbo].[CustomPublicHoliday] ADD  CONSTRAINT [DF_CustomPublicHoliday_CustomPublicHolidayRef]  DEFAULT (newid()) FOR [CustomPublicHolidayRef]
GO
ALTER TABLE [dbo].[CustomPublicHolidayDay] ADD  CONSTRAINT [DF_CustomPublicHolidayDay_CustomPublicHolidayDayRef]  DEFAULT (newid()) FOR [CustomPublicHolidayDayRef]
GO
ALTER TABLE [dbo].[CustomPublicHolidayDay]  WITH CHECK ADD  CONSTRAINT [FK_CustomPublicHolidayDay_CustomPublicHoliday] FOREIGN KEY([CustomPublicHolidayRef])
REFERENCES [dbo].[CustomPublicHoliday] ([CustomPublicHolidayRef])
GO
ALTER TABLE [dbo].[CustomPublicHolidayDay] CHECK CONSTRAINT [FK_CustomPublicHolidayDay_CustomPublicHoliday]
GO
/****** Object:  StoredProcedure [dbo].[pCustomPublicHolidays]    Script Date: 17/09/2016 23:03:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[pCustomPublicHolidays]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].[CustomPublicHoliday]
	SELECT * FROM [dbo].[CustomPublicHolidayDay]
END

GO
USE [master]
GO
ALTER DATABASE [TestDB] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [TranportCatalog]    Script Date: 05/17/2017 23:53:08 ******/
CREATE DATABASE [TranportCatalog] ON  PRIMARY 
( NAME = N'TranportCatalog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TranportCatalog.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TranportCatalog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TranportCatalog_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TranportCatalog] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TranportCatalog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TranportCatalog] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TranportCatalog] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TranportCatalog] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TranportCatalog] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TranportCatalog] SET ARITHABORT OFF
GO
ALTER DATABASE [TranportCatalog] SET AUTO_CLOSE ON
GO
ALTER DATABASE [TranportCatalog] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TranportCatalog] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TranportCatalog] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TranportCatalog] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TranportCatalog] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TranportCatalog] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TranportCatalog] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TranportCatalog] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TranportCatalog] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TranportCatalog] SET  ENABLE_BROKER
GO
ALTER DATABASE [TranportCatalog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TranportCatalog] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TranportCatalog] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TranportCatalog] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TranportCatalog] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TranportCatalog] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TranportCatalog] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [TranportCatalog] SET  READ_WRITE
GO
ALTER DATABASE [TranportCatalog] SET RECOVERY SIMPLE
GO
ALTER DATABASE [TranportCatalog] SET  MULTI_USER
GO
ALTER DATABASE [TranportCatalog] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TranportCatalog] SET DB_CHAINING OFF
GO
USE [TranportCatalog]
GO
/****** Object:  Table [dbo].[VehicleDetails]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleDetails](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Vehicle_ID] [int] NOT NULL,
	[RegisterNumber] [varchar](20) NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_VehicleDetails_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Vehicle_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TripVehicleDriverDetails]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TripVehicleDriverDetails](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[TripId] [varchar](50) NOT NULL,
	[Driver_ID] [varchar](20) NOT NULL,
	[Vehicle_ID] [int] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_TripVehicleDriverDetails_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TripStatus]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[TripStatus](
	[TripSessionId] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[TripId] [varchar](50) NOT NULL,
	[TripStatusCode] [varchar](10) NOT NULL,
	[TripStartTime] [datetime] NULL,
	[TripEndTime] [datetime] NULL,
	[Driver_ID] [varchar](20) NOT NULL,
	[Vehicle_ID] [varchar](20) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[cr_datetime] [datetime2](7) NULL,
	[updt_datetime] [datetime2](7) NULL,
 CONSTRAINT [pk_TripStatus_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC,
	[TripSessionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TripHaltTimings]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TripHaltTimings](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[TripId] [varchar](50) NOT NULL,
	[HaltName] [varchar](250) NOT NULL,
	[HaltArrivalTime] [datetime] NULL,
	[ToWordsOrgInd] [char](1) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_TripHaltTimings_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC,
	[HaltName] ASC,
	[ToWordsOrgInd] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TripGeoLocation]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[TripGeoLocation](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[TripSessionId] [int] NOT NULL,
	[Lattitude] [decimal](12, 9) NOT NULL,
	[Longitude] [decimal](12, 9) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[cr_datetime] [datetime2](7) NOT NULL,
 CONSTRAINT [pk_TripGeoLocation_01] PRIMARY KEY CLUSTERED 
(
	[TripSessionId] ASC,
	[cr_datetime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RouteTrips]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RouteTrips](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[TripId] [varchar](50) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_RouteTrips_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RouteMembers]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RouteMembers](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[TripId] [varchar](50) NOT NULL,
	[MemberID] [varchar](100) NOT NULL,
	[MemberHalt] [varchar](250) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_RouteMembers_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC,
	[MemberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RouteHalts]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RouteHalts](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[HaltName] [varchar](250) NOT NULL,
	[Seq_No] [int] NOT NULL,
	[Halt_Address] [varchar](2000) NOT NULL,
	[X_Coordinate] [decimal](18, 6) NOT NULL,
	[Y_Coordinate] [decimal](18, 6) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_RouteHalts_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[HaltName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoleDetails]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleDetails](
	[row_id] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[RoleDescription] [varchar](100) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_RoleDetails_01] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrganizationRoutes]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrganizationRoutes](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[Route_Display_Name] [varchar](50) NOT NULL,
	[End_Halt] [varchar](500) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_OrganizationRoutes_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrganizationMembers]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrganizationMembers](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[MemberID] [varchar](100) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[userName] [varchar](20) NOT NULL,
	[FirstName] [varchar](150) NOT NULL,
	[LastName] [varchar](150) NULL,
	[MiddleName] [varchar](150) NULL,
	[designation] [varchar](150) NOT NULL,
	[Address] [varchar](1000) NOT NULL,
	[AddressLandMark] [varchar](500) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NOT NULL,
	[Coutry] [varchar](100) NULL,
	[PinCode] [int] NOT NULL,
	[Email] [varchar](100) NULL,
	[PrimaryContactNo] [int] NOT NULL,
	[AlternativeContactNo] [int] NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_OrganizationMembers_01] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organization](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Organization_Name] [varchar](250) NOT NULL,
	[Organization_Type] [varchar](10) NULL,
	[AddressStreet1] [varchar](4000) NOT NULL,
	[AddressStreet2] [varchar](4000) NULL,
	[City] [varchar](4000) NOT NULL,
	[State] [varchar](4000) NOT NULL,
	[PinCode] [int] NOT NULL,
	[PrimaryContactNumner] [int] NOT NULL,
	[SecondaryContactNo] [int] NULL,
	[Email] [varchar](150) NULL,
	[IsActive] [char](1) NOT NULL,
	[Cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [pk_Organization_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MemberRole]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MemberRole](
	[row_id] [int] IDENTITY(100,1) NOT NULL,
	[MemberID] [varchar](100) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_MemberRole_01] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC,
	[Organization_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[userName] [varchar](20) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[PasswordSalt] [varchar](516) NOT NULL,
	[PasswordHash] [varchar](516) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_Login_01] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[Organization_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DriverDetails]    Script Date: 05/17/2017 23:53:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DriverDetails](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Driver_ID] [varchar](20) NOT NULL,
	[DriverName] [varchar](250) NOT NULL,
	[DriverAddress] [varchar](1000) NOT NULL,
	[DriverContactNum] [int] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_DriverDetails_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Driver_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

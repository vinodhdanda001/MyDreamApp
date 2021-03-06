USE [master]
GO
/****** Object:  Database [TranportCatalog]    Script Date: 08/28/2017 09:17:47 ******/
CREATE DATABASE [TranportCatalog] ON  PRIMARY 
( NAME = N'TranportCatalog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\TranportCatalog.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TranportCatalog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\TranportCatalog_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [TranportCatalog] SET AUTO_CLOSE OFF
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
ALTER DATABASE [TranportCatalog] SET RECOVERY FULL
GO
ALTER DATABASE [TranportCatalog] SET  MULTI_USER
GO
ALTER DATABASE [TranportCatalog] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TranportCatalog] SET DB_CHAINING OFF
GO
USE [TranportCatalog]
GO
/****** Object:  Table [dbo].[VehicleDetails]    Script Date: 08/28/2017 09:17:47 ******/
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
SET IDENTITY_INSERT [dbo].[VehicleDetails] ON
INSERT [dbo].[VehicleDetails] ([row_id], [Organization_ID], [Vehicle_ID], [RegisterNumber], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, 1111, N'AP30E1111', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[VehicleDetails] OFF
/****** Object:  Table [dbo].[TripVehicleDriverDetails]    Script Date: 08/28/2017 09:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TripVehicleDriverDetails](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [int] NOT NULL,
	[TripId] [int] NOT NULL,
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
SET IDENTITY_INSERT [dbo].[TripVehicleDriverDetails] ON
INSERT [dbo].[TripVehicleDriverDetails] ([row_id], [Organization_ID], [Route_ID], [TripId], [Driver_ID], [Vehicle_ID], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, 1001, 1, N'D10001', 1111, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[TripVehicleDriverDetails] OFF
/****** Object:  Table [dbo].[TripStatus]    Script Date: 08/28/2017 09:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[TripStatus](
	[TripSessionId] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [int] NOT NULL,
	[TripId] [int] NOT NULL,
	[TripStatusCode] [varchar](10) NOT NULL,
	[TripStartTime] [datetime] NULL,
	[TripEndTime] [datetime] NULL,
	[Driver_ID] [varchar](20) NOT NULL,
	[Vehicle_ID] [int] NULL,
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
/****** Object:  Table [dbo].[TripHaltTimings]    Script Date: 08/28/2017 09:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TripHaltTimings](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [int] NOT NULL,
	[TripId] [int] NOT NULL,
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
/****** Object:  Table [dbo].[TripGeoLocation]    Script Date: 08/28/2017 09:17:47 ******/
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
/****** Object:  Table [dbo].[RouteTrips]    Script Date: 08/28/2017 09:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RouteTrips](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [int] NOT NULL,
	[TripId] [int] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
	[TripStartTime] [time](7) NULL,
	[PickDropInd] [bit] NULL,
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
SET IDENTITY_INSERT [dbo].[RouteTrips] ON
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1032, 0, 0, 33, N'Vinodh', N'Y', CAST(0x0000A7CC0158ECB0 AS DateTime), CAST(0x0000A7CC0158ECB0 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1033, 0, 0, 34, N'Vinodh', N'Y', CAST(0x0000A7CD00937237 AS DateTime), CAST(0x0000A7CD00937237 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1034, 0, 0, 35, N'Vinodh', N'Y', CAST(0x0000A7CD0094C8B9 AS DateTime), CAST(0x0000A7CD0094C8B9 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1035, 0, 0, 36, N'Vinodh', N'Y', CAST(0x0000A7CD009522DF AS DateTime), CAST(0x0000A7CD009522DF AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1036, 0, 0, 37, N'Vinodh', N'Y', CAST(0x0000A7CD00959195 AS DateTime), CAST(0x0000A7CD00959195 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1037, 0, 0, 38, N'Vinodh', N'Y', CAST(0x0000A7CD00990F30 AS DateTime), CAST(0x0000A7CD00990F30 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1038, 0, 0, 39, N'Vinodh', N'Y', CAST(0x0000A7D20088CA0D AS DateTime), CAST(0x0000A7D20088CA0D AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1039, 0, 0, 40, N'Vinodh', N'Y', CAST(0x0000A7D2008CB519 AS DateTime), CAST(0x0000A7D2008CB519 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1040, 0, 0, 41, N'Vinodh', N'Y', CAST(0x0000A7D2009089C8 AS DateTime), CAST(0x0000A7D2009089C8 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1041, 0, 0, 42, N'Vinodh', N'Y', CAST(0x0000A7D400AC2C73 AS DateTime), CAST(0x0000A7D400AC2C73 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1042, 0, 0, 43, N'Vinodh', N'Y', CAST(0x0000A7D400AEA7D8 AS DateTime), CAST(0x0000A7D400AEA7D8 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1043, 0, 0, 44, N'Vinodh', N'Y', CAST(0x0000A7D400BF8F17 AS DateTime), CAST(0x0000A7D400BF8F17 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1044, 0, 0, 45, N'Vinodh', N'Y', CAST(0x0000A7D400C008B9 AS DateTime), CAST(0x0000A7D400C008B9 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1045, 0, 0, 46, N'Vinodh', N'Y', CAST(0x0000A7D400D086D6 AS DateTime), CAST(0x0000A7D400D086D6 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1000, 100, 1001, 1, N'vinodh', N'Y', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1001, 100, 1001, 2, N'Vinodh', N'Y', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1002, 100, 1001, 3, N'Vinodh', N'Y', CAST(0x0000A79401845E67 AS DateTime), CAST(0x0000A79401845E6C AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1003, 100, 1001, 4, N'Vinodh', N'Y', CAST(0x0000A7940185202E AS DateTime), CAST(0x0000A7940185202E AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1004, 100, 1001, 5, N'Vinodh', N'Y', CAST(0x0000A79401853E8C AS DateTime), CAST(0x0000A79401853E8C AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1005, 100, 1001, 6, N'Vinodh', N'Y', CAST(0x0000A79401853EB3 AS DateTime), CAST(0x0000A79401853EB3 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1006, 100, 1001, 7, N'Vinodh', N'Y', CAST(0x0000A79401857203 AS DateTime), CAST(0x0000A79401857203 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1007, 100, 1001, 8, N'Vinodh', N'Y', CAST(0x0000A7940185850C AS DateTime), CAST(0x0000A7940185850C AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1008, 100, 1001, 9, N'Vinodh', N'Y', CAST(0x0000A7940185BF28 AS DateTime), CAST(0x0000A7940185BF28 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1009, 100, 1001, 10, N'Vinodh', N'Y', CAST(0x0000A7940185BF51 AS DateTime), CAST(0x0000A7940185BF51 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1010, 100, 1001, 11, N'Vinodh', N'Y', CAST(0x0000A7940185D455 AS DateTime), CAST(0x0000A7940185D455 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1011, 100, 1001, 12, N'Vinodh', N'Y', CAST(0x0000A7940185D491 AS DateTime), CAST(0x0000A7940185D491 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1012, 100, 1001, 13, N'Vinodh', N'Y', CAST(0x0000A79401861A5D AS DateTime), CAST(0x0000A79401861A5D AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1013, 100, 1001, 14, N'Vinodh', N'Y', CAST(0x0000A79401861AE0 AS DateTime), CAST(0x0000A79401861AE0 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1014, 100, 1001, 15, N'Vinodh', N'Y', CAST(0x0000A79401890E74 AS DateTime), CAST(0x0000A79401890E74 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1015, 100, 1001, 16, N'Vinodh', N'Y', CAST(0x0000A79401890F65 AS DateTime), CAST(0x0000A79401890F65 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1046, 100, 1001, 47, N'Vinodh', N'Y', CAST(0x0000A7DD0091C741 AS DateTime), CAST(0x0000A7DD0091C741 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1016, 100, 1003, 17, N'Vinodh', N'Y', CAST(0x0000A79500001F6C AS DateTime), CAST(0x0000A79500001F6C AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1017, 100, 1003, 18, N'Vinodh', N'Y', CAST(0x0000A79500001F8A AS DateTime), CAST(0x0000A79500001F8A AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1018, 100, 1003, 19, N'Vinodh', N'Y', CAST(0x0000A795000034D3 AS DateTime), CAST(0x0000A795000034D3 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1019, 100, 1003, 20, N'Vinodh', N'Y', CAST(0x0000A795000034F1 AS DateTime), CAST(0x0000A795000034F1 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1020, 100, 1003, 21, N'Vinodh', N'Y', CAST(0x0000A795000071AE AS DateTime), CAST(0x0000A795000071AE AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1021, 100, 1003, 22, N'Vinodh', N'Y', CAST(0x0000A795000071CB AS DateTime), CAST(0x0000A795000071CB AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1029, 100, 1003, 30, N'Vinodh', N'Y', CAST(0x0000A795001765DF AS DateTime), CAST(0x0000A795001765E0 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1030, 100, 1003, 31, N'Vinodh', N'Y', CAST(0x0000A795001A6BBC AS DateTime), CAST(0x0000A795001A6BBC AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1022, 100, 1005, 23, N'Vinodh', N'Y', CAST(0x0000A79500009D8C AS DateTime), CAST(0x0000A79500009D8C AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1023, 100, 1005, 24, N'Vinodh', N'Y', CAST(0x0000A79500009DAE AS DateTime), CAST(0x0000A79500009DAE AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1024, 100, 1005, 25, N'Vinodh', N'Y', CAST(0x0000A79500017CFC AS DateTime), CAST(0x0000A79500017CFD AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1025, 100, 1005, 26, N'Vinodh', N'Y', CAST(0x0000A7950001B2C6 AS DateTime), CAST(0x0000A7950001B2C6 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1026, 100, 1005, 27, N'Vinodh', N'Y', CAST(0x0000A7950001BFCF AS DateTime), CAST(0x0000A7950001BFCF AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1027, 100, 1005, 28, N'Vinodh', N'Y', CAST(0x0000A7950001F72A AS DateTime), CAST(0x0000A7950001F72A AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1028, 100, 1006, 29, N'Vinodh', N'Y', CAST(0x0000A79500039870 AS DateTime), CAST(0x0000A79500039870 AS DateTime), NULL, NULL)
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime], [TripStartTime], [PickDropInd]) VALUES (1031, 100, 1007, 32, N'Vinodh', N'Y', CAST(0x0000A79500AE8C08 AS DateTime), CAST(0x0000A79500AE8C08 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[RouteTrips] OFF
/****** Object:  Table [dbo].[RouteMembers]    Script Date: 08/28/2017 09:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RouteMembers](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [int] NOT NULL,
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
SET IDENTITY_INSERT [dbo].[RouteMembers] ON
INSERT [dbo].[RouteMembers] ([row_id], [Organization_ID], [Route_ID], [TripId], [MemberID], [MemberHalt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, 1001, N'T001', N'M001', N'Jubilee Hills', N'Vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[RouteMembers] ([row_id], [Organization_ID], [Route_ID], [TripId], [MemberID], [MemberHalt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1001, 100, 1001, N'T001', N'M002', N'Madhapur', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[RouteMembers] ([row_id], [Organization_ID], [Route_ID], [TripId], [MemberID], [MemberHalt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1002, 100, 1001, N'T001', N'M003', N'Hitech City', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[RouteMembers] ([row_id], [Organization_ID], [Route_ID], [TripId], [MemberID], [MemberHalt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1003, 100, 1001, N'T001', N'M004', N'Kothatguda', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[RouteMembers] OFF
/****** Object:  Table [dbo].[RouteHalts]    Script Date: 08/28/2017 09:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RouteHalts](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [int] NOT NULL,
	[Seq_No] [int] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
	[HaltID] [int] NOT NULL,
 CONSTRAINT [pk_RouteHalts_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[HaltID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoleDetails]    Script Date: 08/28/2017 09:17:47 ******/
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
SET IDENTITY_INSERT [dbo].[RoleDetails] ON
INSERT [dbo].[RoleDetails] ([row_id], [RoleID], [RoleDescription], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1, 1, N'Student', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[RoleDetails] OFF
/****** Object:  Table [dbo].[OrganizationRoutes]    Script Date: 08/28/2017 09:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrganizationRoutes](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [int] NOT NULL,
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
SET IDENTITY_INSERT [dbo].[OrganizationRoutes] ON
INSERT [dbo].[OrganizationRoutes] ([row_id], [Organization_ID], [Route_ID], [Route_Display_Name], [End_Halt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, 1001, N'Jubilee Hills', N'Jubilee Hills', N'Vinodh', N'Y', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[OrganizationRoutes] ([row_id], [Organization_ID], [Route_ID], [Route_Display_Name], [End_Halt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1001, 100, 1002, N'Miyapur', N'Miyapur', N'Vinodh', N'Y', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[OrganizationRoutes] ([row_id], [Organization_ID], [Route_ID], [Route_Display_Name], [End_Halt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1002, 100, 1003, N'KukatPalli', N'KukatPalli bus stop', N'Vinodh', N'Y', CAST(0x0000A78701741BEC AS DateTime), CAST(0x0000A78701741BEC AS DateTime))
INSERT [dbo].[OrganizationRoutes] ([row_id], [Organization_ID], [Route_ID], [Route_Display_Name], [End_Halt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1003, 100, 1004, N'Alwin', N'Alwin Junction', N'Vinodh', N'Y', CAST(0x0000A78701749CE4 AS DateTime), CAST(0x0000A78701749CE4 AS DateTime))
INSERT [dbo].[OrganizationRoutes] ([row_id], [Organization_ID], [Route_ID], [Route_Display_Name], [End_Halt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1004, 100, 1005, N'Tolichowlik', N'Tolichowki', N'Vinodh', N'Y', CAST(0x0000A78B009B2F77 AS DateTime), CAST(0x0000A78B009B2F77 AS DateTime))
INSERT [dbo].[OrganizationRoutes] ([row_id], [Organization_ID], [Route_ID], [Route_Display_Name], [End_Halt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1005, 100, 1006, N'Mehdi Patnam', N'Mehdi Patnam', N'Vinodh', N'Y', CAST(0x0000A78B009CD87D AS DateTime), CAST(0x0000A78B009CD87D AS DateTime))
INSERT [dbo].[OrganizationRoutes] ([row_id], [Organization_ID], [Route_ID], [Route_Display_Name], [End_Halt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1006, 100, 1007, N'sklm', N'sklm', N'Vinodh', N'Y', CAST(0x0000A79500AE6AB6 AS DateTime), CAST(0x0000A79500AE6AB6 AS DateTime))
INSERT [dbo].[OrganizationRoutes] ([row_id], [Organization_ID], [Route_ID], [Route_Display_Name], [End_Halt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1007, 100, 1008, N'Begumpet', N'Lingampally', N'Vinodh', N'Y', CAST(0x0000A795012949DE AS DateTime), CAST(0x0000A795012949DE AS DateTime))
SET IDENTITY_INSERT [dbo].[OrganizationRoutes] OFF
/****** Object:  Table [dbo].[OrganizationMembers]    Script Date: 08/28/2017 09:17:47 ******/
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
SET IDENTITY_INSERT [dbo].[OrganizationMembers] ON
INSERT [dbo].[OrganizationMembers] ([row_id], [MemberID], [Organization_ID], [userName], [FirstName], [LastName], [MiddleName], [designation], [Address], [AddressLandMark], [City], [State], [Coutry], [PinCode], [Email], [PrimaryContactNo], [AlternativeContactNo], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1001, N'M001', 100, N'9100000101', N'Member 1', N'Ord100', NULL, N'student', N'Jubilee hills', N'Near Check post', N'Hyderabad', N'Telangana', N'India', 500015, NULL, 910000101, NULL, N'vinodh', N'Y', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[OrganizationMembers] ([row_id], [MemberID], [Organization_ID], [userName], [FirstName], [LastName], [MiddleName], [designation], [Address], [AddressLandMark], [City], [State], [Coutry], [PinCode], [Email], [PrimaryContactNo], [AlternativeContactNo], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1003, N'M002', 100, N'9100000102', N'Member 2', N'org100', NULL, N'student', N'Madhapur', N'Near check post', N'hyderabad', N'Telangana', N'India', 500016, NULL, 910000102, NULL, N'vinodh', N'Y', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[OrganizationMembers] ([row_id], [MemberID], [Organization_ID], [userName], [FirstName], [LastName], [MiddleName], [designation], [Address], [AddressLandMark], [City], [State], [Coutry], [PinCode], [Email], [PrimaryContactNo], [AlternativeContactNo], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1004, N'M103', 100, N'9100000103', N'Member 3', N'Org100', NULL, N'student', N'Hitech City', N'Near Image hospital', N'Hyderabad', N'Telangana', N'India', 500080, NULL, 910000103, NULL, N'vinodh', N'Y', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[OrganizationMembers] ([row_id], [MemberID], [Organization_ID], [userName], [FirstName], [LastName], [MiddleName], [designation], [Address], [AddressLandMark], [City], [State], [Coutry], [PinCode], [Email], [PrimaryContactNo], [AlternativeContactNo], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1005, N'M104', 100, N'9100000104', N'Member 4', N'Org 100', NULL, N'student', N'Kothaguda', N'Near google office', N'Hyderabad', N'Telangana', N'India', 500081, NULL, 910000104, NULL, N'vinodh', N'Y', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[OrganizationMembers] OFF
/****** Object:  Table [dbo].[OrganizationHalts]    Script Date: 08/28/2017 09:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrganizationHalts](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[HaltID] [int] NOT NULL,
	[HaltName] [varchar](250) NOT NULL,
	[Halt_Address] [varchar](2000) NOT NULL,
	[X_Coordinate] [decimal](18, 6) NOT NULL,
	[Y_Coordinate] [decimal](18, 6) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_OrganizationHalts_01] PRIMARY KEY CLUSTERED 
(
	[HaltID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 08/28/2017 09:17:47 ******/
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
SET IDENTITY_INSERT [dbo].[Organization] ON
INSERT [dbo].[Organization] ([row_id], [Organization_ID], [Organization_Name], [Organization_Type], [AddressStreet1], [AddressStreet2], [City], [State], [PinCode], [PrimaryContactNumner], [SecondaryContactNo], [Email], [IsActive], [Cr_datetime], [updt_datetime], [LastUpdatedBy]) VALUES (1000, 100, N'Sample Org 1', N'School', N'Gachibowli', N'Near ORR', N'Hyderabad', N'Telangana', 500081, 949390578, 988522242, N'vinodh5c6@gmail.com', N'Y', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime), N'vinodh')
INSERT [dbo].[Organization] ([row_id], [Organization_ID], [Organization_Name], [Organization_Type], [AddressStreet1], [AddressStreet2], [City], [State], [PinCode], [PrimaryContactNumner], [SecondaryContactNo], [Email], [IsActive], [Cr_datetime], [updt_datetime], [LastUpdatedBy]) VALUES (1001, 101, N'Sample Org2', N'School', N'Hitech City', N'Ciber Towers', N'Hyderabad', N'Telangana', 500084, 888888888, 888888888, N'vinodhdanda001@gmail.com', N'Y', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime), N'Vinodh')
SET IDENTITY_INSERT [dbo].[Organization] OFF
/****** Object:  Table [dbo].[MemberRole]    Script Date: 08/28/2017 09:17:47 ******/
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
SET IDENTITY_INSERT [dbo].[MemberRole] ON
INSERT [dbo].[MemberRole] ([row_id], [MemberID], [Organization_ID], [RoleID], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (100, N'M001', 100, 1, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[MemberRole] ([row_id], [MemberID], [Organization_ID], [RoleID], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (101, N'M002', 100, 1, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[MemberRole] ([row_id], [MemberID], [Organization_ID], [RoleID], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (102, N'M003', 100, 1, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[MemberRole] ([row_id], [MemberID], [Organization_ID], [RoleID], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (103, N'M004', 100, 1, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[MemberRole] OFF
/****** Object:  Table [dbo].[Login]    Script Date: 08/28/2017 09:17:47 ******/
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
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([row_id], [userName], [Organization_ID], [PasswordSalt], [PasswordHash], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, N'9100000101', 100, N'xxx', N'xxx', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[Login] ([row_id], [userName], [Organization_ID], [PasswordSalt], [PasswordHash], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1002, N'9100000102', 100, N'xxx', N'xxx', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[Login] ([row_id], [userName], [Organization_ID], [PasswordSalt], [PasswordHash], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1003, N'9100000103', 100, N'xxx', N'xxx', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[Login] ([row_id], [userName], [Organization_ID], [PasswordSalt], [PasswordHash], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1005, N'9100000104', 100, N'xxx', N'xxx', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Login] OFF
/****** Object:  Table [dbo].[DriverDetails]    Script Date: 08/28/2017 09:17:47 ******/
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
SET IDENTITY_INSERT [dbo].[DriverDetails] ON
INSERT [dbo].[DriverDetails] ([row_id], [Organization_ID], [Driver_ID], [DriverName], [DriverAddress], [DriverContactNum], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, N'D10001', N'Satyanarayana', N'Gachibowli', 901000000, N'Vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[DriverDetails] OFF
/****** Object:  Table [dbo].[APP_ERR_LOG]    Script Date: 08/28/2017 09:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[APP_ERR_LOG](
	[row_id] [int] IDENTITY(1,1) NOT NULL,
	[log_date] [datetime] NOT NULL,
	[log_thread] [varchar](50) NOT NULL,
	[log_level] [varchar](50) NOT NULL,
	[log_source] [varchar](50) NOT NULL,
	[log_message] [varchar](4000) NOT NULL,
	[exception] [varchar](4000) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  DdlTrigger [rds_deny_backups_trigger]    Script Date: 08/28/2017 09:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [rds_deny_backups_trigger] ON DATABASE WITH EXECUTE AS 'dbo' FOR
 ADD_ROLE_MEMBER, GRANT_DATABASE AS BEGIN
   SET NOCOUNT ON;
   SET ANSI_PADDING ON;
 
   DECLARE @data xml;
   DECLARE @user sysname;
   DECLARE @role sysname;
   DECLARE @type sysname;
   DECLARE @sql NVARCHAR(MAX);
   DECLARE @permissions TABLE(name sysname PRIMARY KEY);
   
   SELECT @data = EVENTDATA();
   SELECT @type = @data.value('(/EVENT_INSTANCE/EventType)[1]', 'sysname');
    
   IF @type = 'ADD_ROLE_MEMBER' BEGIN
      SELECT @user = @data.value('(/EVENT_INSTANCE/ObjectName)[1]', 'sysname'),
       @role = @data.value('(/EVENT_INSTANCE/RoleName)[1]', 'sysname');

      IF @role IN ('db_owner', 'db_backupoperator') BEGIN
         SELECT @sql = 'DENY BACKUP DATABASE, BACKUP LOG TO ' + QUOTENAME(@user);
         EXEC(@sql);
      END
   END ELSE IF @type = 'GRANT_DATABASE' BEGIN
      INSERT INTO @permissions(name)
      SELECT Permission.value('(text())[1]', 'sysname') FROM
       @data.nodes('/EVENT_INSTANCE/Permissions/Permission')
      AS DatabasePermissions(Permission);
      
      IF EXISTS (SELECT * FROM @permissions WHERE name IN ('BACKUP DATABASE',
       'BACKUP LOG'))
         RAISERROR('Cannot grant backup database or backup log', 15, 1) WITH LOG;       
   END
END
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
DISABLE TRIGGER [rds_deny_backups_trigger] ON DATABASE
GO
/****** Object:  Default [DF__RouteHalt__HaltI__1DE57479]    Script Date: 08/28/2017 09:17:47 ******/
ALTER TABLE [dbo].[RouteHalts] ADD  DEFAULT ((0)) FOR [HaltID]
GO
/****** Object:  DdlTrigger [rds_deny_backups_trigger]    Script Date: 08/28/2017 09:17:47 ******/
Enable Trigger [rds_deny_backups_trigger] ON Database
GO

USE [TranportCatalog]
GO
/****** Object:  Table [dbo].[VehicleDetails]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[TripVehicleDriverDetails]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[TripHaltTimings]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[RouteTrips]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[RouteMembers]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[RouteHalts]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[RoleDetails]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[OrganizationRoutes]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[OrganizationMembers]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[Organization]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[MemberRole]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 04/23/2017 11:40:21 ******/
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
/****** Object:  Table [dbo].[DriverDetails]    Script Date: 04/23/2017 11:40:21 ******/
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


CREATE TABLE [dbo].[TripStatus](
	[TripSessionId] [int] IDENTITY(1000,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[TripId] [varchar](50) NOT NULL,
	[TripStatusCode] [varchar](10) NOT NULL,
	[TripStartTime] [datetime] NULL,
	[TripEndTime] [datetime] NULL,
	[Driver_ID] [varchar](20) NOT NULL,
	[Vehicle_ID]  [varchar](20) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL,
 CONSTRAINT [pk_TripStatus_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC,
	[TripSessionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[TripGeoLocation](
	[row_id] [int] IDENTITY(1000,1) NOT NULL,
	[TripSessionId] [int] NOT NULL,
	[Lattitude] [decimal](12,9) NOT NULL,
	[Longitude] [decimal](12,9) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[cr_datetime] [datetime] NOT NULL
)
GO
ALTER TABLE [dbo].[TripGeoLocation]
ADD CONSTRAINT [pk_TripGeoLocation_01] PRIMARY KEY CLUSTERED 
(
	[TripSessionId] ASC,
	[cr_datetime] ASC
)
GO



Alter table dbo.TripStatus
Alter column cr_datetime datetime2
GO
Alter table dbo.TripStatus
Alter column updt_datetime datetime2
go


----Modifying datetime column of TripGeoLocation.
ALTER TABLE [dbo].[TripGeoLocation]
drop  CONSTRAINT [pk_TripGeoLocation_01]
GO

alter table [dbo].[TripGeoLocation]
	alter column cr_datetime datetime2 NOT NULL
GO

ALTER TABLE [dbo].[TripGeoLocation]
ADD CONSTRAINT [pk_TripGeoLocation_01] PRIMARY KEY CLUSTERED 
(
	[TripSessionId] ASC,
	[cr_datetime] ASC
)
GO
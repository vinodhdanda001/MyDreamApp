USE [TranportCatalog]
GO



CREATE TABLE [dbo].[Organization](
	[row_id] [int] Identity(1000,1),
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
	[LastUpdatedBy] [varchar](20) NOT NULL
) ON [PRIMARY]

GO

Alter table [dbo].[Organization] Add CONSTRAINT pk_Organization_01 primary key(Organization_ID asc)
GO


CREATE TABLE [dbo].[OrganizationRoutes](
	[row_id] [int] Identity(1000,1),
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[Route_Display_Name] [varchar](50) NOT NULL,
	[End_Halt] [varchar](500) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL
) ON [PRIMARY]

GO

Alter table [dbo].[OrganizationRoutes] Add CONSTRAINT pk_OrganizationRoutes_01 primary key(Organization_ID asc,Route_ID asc )
GO



CREATE TABLE [dbo].[RouteTrips](
	[row_id] [int] Identity(1000,1),
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[TripId] [varchar](50) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL
) ON [PRIMARY]

GO

Alter table [dbo].[RouteTrips] Add CONSTRAINT pk_RouteTrips_01 primary key(Organization_ID asc,Route_ID asc, TripId asc  )
GO



CREATE TABLE [dbo].[RouteMembers](
	[row_id] [int] Identity(1000,1),
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[TripId] [varchar](50) NOT NULL,
	[MemberID] varchar(100) NOT NULL,
	[MemberHalt] varchar(250) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL
) ON [PRIMARY]

GO

Alter table [dbo].[RouteMembers] Add CONSTRAINT pk_RouteMembers_01 primary key(Organization_ID asc,Route_ID asc, TripId asc , MemberID asc  )
GO


CREATE TABLE [dbo].[RouteHalts](
	[row_id] [int] Identity(1000,1),
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
	[updt_datetime] [datetime] NOT NULL
) ON [PRIMARY]

GO

Alter table [dbo].[RouteHalts] Add CONSTRAINT pk_RouteHalts_01 primary key(Organization_ID asc,Route_ID asc, HaltName asc)
GO

create table [dbo].[TripHaltTimings](
	[row_id] [int] Identity(1000,1),
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[TripId] [varchar](50) NOT NULL,
	[HaltName] [varchar](250) NOT NULL,
	[HaltArrivalTime] [datetime] NULL,
	[ToWordsOrgInd] [char](1) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL
)
 ON [PRIMARY]

GO

Alter table [dbo].[TripHaltTimings] Add CONSTRAINT pk_TripHaltTimings_01 primary key(Organization_ID asc,Route_ID asc
														, TripId asc , HaltName asc , ToWordsOrgInd asc)
GO
	
create table [dbo].[VehicleDetails](
	[row_id] [int] Identity(1000,1),
	[Organization_ID] [int] NOT NULL,
	[Vehicle_ID] [int] NOT NULL,
	[RegisterNumber] [varchar](20),
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL
) ON [PRIMARY]

GO
Alter table [dbo].[VehicleDetails] Add CONSTRAINT pk_VehicleDetails_01 primary key(Organization_ID asc, Vehicle_ID asc)
GO


create table [dbo].[DriverDetails](
	[row_id] [int] Identity(1000,1),
	[Organization_ID] [int] NOT NULL,
	[Driver_ID] [varchar](20) NOT NULL,
	[DriverName] [varchar](250) NOT NULL,
	[DriverAddress] [varchar](1000) NOT NULL,
	[DriverContactNum] [int] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL
	

) ON [PRIMARY]

GO
Alter table [dbo].[DriverDetails] Add CONSTRAINT pk_DriverDetails_01 primary key(Organization_ID asc, Driver_ID asc)
GO


create table [dbo].[TripVehicleDriverDetails](
	[row_id] [int] Identity(1000,1),
	[Organization_ID] [int] NOT NULL,
	[Route_ID] [varchar](20) NOT NULL,
	[TripId] [varchar](50) NOT NULL,
	[Driver_ID] [varchar](20) NOT NULL,
	[Vehicle_ID] [int] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL	
) ON [PRIMARY]

GO
Alter table [dbo].[TripVehicleDriverDetails] Add CONSTRAINT pk_TripVehicleDriverDetails_01 primary key(Organization_ID asc, Route_ID asc, TripId asc)
GO



create table [dbo].[Login](
	[row_id] [int] Identity(1000,1),
	[userName] [varchar](20) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[PasswordSalt] [VARCHAR](516) NOT NULL,
	[PasswordHash] [VARCHAR](516) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL	
) ON [PRIMARY]

GO
Alter table [dbo].[Login] Add CONSTRAINT pk_Login_01 primary key(userName asc, Organization_ID asc)
GO


create table [dbo].[OrganizationMembers](
	[row_id] [int] Identity(1000,1),
	[MemberID] varchar(100) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[userName] [varchar](20) NOT NULL,
	[FirstName] [varchar](150) NOT NULL,
	[LastName] [varchar](150) NULL,
	[MiddleName] [varchar](150) NULL,
	[designation] [varchar](150) NOT NULL,		---- Eg. Student, Professor
	[Address] [varchar](1000) NOT NULL,
	[AddressLandMark] [varchar](500) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NOT NULL,
	[Coutry] [varchar](100) NULL,
	[PinCode] [int] NOT NULL,
	[Email][varchar](100) NULL,
	[PrimaryContactNo][int] NOT NULL,
	[AlternativeContactNo][int] NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL	
) ON [PRIMARY]
GO
Alter table [dbo].[OrganizationMembers] Add CONSTRAINT pk_OrganizationMembers_01 primary key(MemberID asc)

GO


create table [dbo].[MemberRole](
	[row_id] [int] Identity(100,1),
	[MemberID] varchar(100) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL	
) ON [PRIMARY]
GO
Alter table [dbo].[MemberRole] Add CONSTRAINT pk_MemberRole_01 primary key(MemberID asc, Organization_ID asc)

GO


create table [dbo].[RoleDetails](
	[row_id] [int] Identity(1,1),
	[RoleID] [int] NOT NULL,
	[RoleDescription] [varchar](100) NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[cr_datetime] [datetime] NOT NULL,
	[updt_datetime] [datetime] NOT NULL	
) ON [PRIMARY]
GO
Alter table [dbo].[RoleDetails] Add CONSTRAINT pk_RoleDetails_01 primary key(RoleID asc)
GO	


USE [TranportCatalog]
GO
/****** Object:  Table [dbo].[VehicleDetails]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[VehicleDetails] ON
INSERT [dbo].[VehicleDetails] ([row_id], [Organization_ID], [Vehicle_ID], [RegisterNumber], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, 1111, N'AP30E1111', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[VehicleDetails] OFF
/****** Object:  Table [dbo].[TripVehicleDriverDetails]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[TripVehicleDriverDetails] ON
INSERT [dbo].[TripVehicleDriverDetails] ([row_id], [Organization_ID], [Route_ID], [TripId], [Driver_ID], [Vehicle_ID], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, N'R1001', N'T001', N'D10001', 1111, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[TripVehicleDriverDetails] OFF
/****** Object:  Table [dbo].[TripHaltTimings]    Script Date: 04/23/2017 11:43:20 ******/
/****** Object:  Table [dbo].[RouteTrips]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[RouteTrips] ON
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, N'R1001', N'T001', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[RouteTrips] ([row_id], [Organization_ID], [Route_ID], [TripId], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1001, 100, N'R1001', N'T002', N'Vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[RouteTrips] OFF
/****** Object:  Table [dbo].[RouteMembers]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[RouteMembers] ON
INSERT [dbo].[RouteMembers] ([row_id], [Organization_ID], [Route_ID], [TripId], [MemberID], [MemberHalt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, N'R1001', N'T001', N'M001', N'Jubilee Hills', N'Vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[RouteMembers] ([row_id], [Organization_ID], [Route_ID], [TripId], [MemberID], [MemberHalt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1001, 100, N'R1001', N'T001', N'M002', N'Madhapur', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[RouteMembers] ([row_id], [Organization_ID], [Route_ID], [TripId], [MemberID], [MemberHalt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1002, 100, N'R1001', N'T001', N'M003', N'Hitech City', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[RouteMembers] ([row_id], [Organization_ID], [Route_ID], [TripId], [MemberID], [MemberHalt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1003, 100, N'R1001', N'T001', N'M004', N'Kothatguda', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[RouteMembers] OFF
/****** Object:  Table [dbo].[RouteHalts]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[RouteHalts] ON
INSERT [dbo].[RouteHalts] ([row_id], [Organization_ID], [Route_ID], [HaltName], [Seq_No], [Halt_Address], [X_Coordinate], [Y_Coordinate], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1006, 100, N'R1001', N'Gachibowli', 5, N'Gachibowli at School', CAST(100.000000 AS Decimal(18, 6)), CAST(100.000000 AS Decimal(18, 6)), N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[RouteHalts] ([row_id], [Organization_ID], [Route_ID], [HaltName], [Seq_No], [Halt_Address], [X_Coordinate], [Y_Coordinate], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1004, 100, N'R1001', N'Hitech City', 3, N'Hitech city, ciber towers', CAST(100.000000 AS Decimal(18, 6)), CAST(100.000000 AS Decimal(18, 6)), N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[RouteHalts] ([row_id], [Organization_ID], [Route_ID], [HaltName], [Seq_No], [Halt_Address], [X_Coordinate], [Y_Coordinate], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1002, 100, N'R1001', N'Jubilee Hills', 1, N'Jubilee Hills checkpost', CAST(100.000000 AS Decimal(18, 6)), CAST(100.000000 AS Decimal(18, 6)), N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[RouteHalts] ([row_id], [Organization_ID], [Route_ID], [HaltName], [Seq_No], [Halt_Address], [X_Coordinate], [Y_Coordinate], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1005, 100, N'R1001', N'Kothaguda', 4, N'Kothaguda, X roads', CAST(100.000000 AS Decimal(18, 6)), CAST(100.000000 AS Decimal(18, 6)), N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[RouteHalts] ([row_id], [Organization_ID], [Route_ID], [HaltName], [Seq_No], [Halt_Address], [X_Coordinate], [Y_Coordinate], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1003, 100, N'R1001', N'Madhapur', 2, N'Madhapur Petrol bunk', CAST(100.000000 AS Decimal(18, 6)), CAST(100.000000 AS Decimal(18, 6)), N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[RouteHalts] ([row_id], [Organization_ID], [Route_ID], [HaltName], [Seq_No], [Halt_Address], [X_Coordinate], [Y_Coordinate], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1011, 100, N'R1002', N'Gachibowli', 5, N'Gachibowli at school', CAST(100.000000 AS Decimal(18, 6)), CAST(100.000000 AS Decimal(18, 6)), N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[RouteHalts] ([row_id], [Organization_ID], [Route_ID], [HaltName], [Seq_No], [Halt_Address], [X_Coordinate], [Y_Coordinate], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1008, 100, N'R1002', N'Hafeezpet', 2, N'Hafeex pet bus stop', CAST(100.000000 AS Decimal(18, 6)), CAST(100.000000 AS Decimal(18, 6)), N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[RouteHalts] ([row_id], [Organization_ID], [Route_ID], [HaltName], [Seq_No], [Halt_Address], [X_Coordinate], [Y_Coordinate], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1009, 100, N'R1002', N'Kondapur', 3, N'Kondapur X roads', CAST(100.000000 AS Decimal(18, 6)), CAST(100.000000 AS Decimal(18, 6)), N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[RouteHalts] ([row_id], [Organization_ID], [Route_ID], [HaltName], [Seq_No], [Halt_Address], [X_Coordinate], [Y_Coordinate], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1010, 100, N'R1002', N'Kothaguda', 4, N'Kothaguda', CAST(100.000000 AS Decimal(18, 6)), CAST(100.000000 AS Decimal(18, 6)), N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[RouteHalts] ([row_id], [Organization_ID], [Route_ID], [HaltName], [Seq_No], [Halt_Address], [X_Coordinate], [Y_Coordinate], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1007, 100, N'R1002', N'MiyaPur', 1, N'Miyapur X Roads', CAST(100.000000 AS Decimal(18, 6)), CAST(100.000000 AS Decimal(18, 6)), N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[RouteHalts] OFF
/****** Object:  Table [dbo].[RoleDetails]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[RoleDetails] ON
INSERT [dbo].[RoleDetails] ([row_id], [RoleID], [RoleDescription], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1, 1, N'Student', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[RoleDetails] OFF
/****** Object:  Table [dbo].[OrganizationRoutes]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[OrganizationRoutes] ON
INSERT [dbo].[OrganizationRoutes] ([row_id], [Organization_ID], [Route_ID], [Route_Display_Name], [End_Halt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, N'R1001', N'Jubilee Hills', N'Jubilee Hills', N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
INSERT [dbo].[OrganizationRoutes] ([row_id], [Organization_ID], [Route_ID], [Route_Display_Name], [End_Halt], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1001, 100, N'R1002', N'Miyapur', N'Miyapur', N'Vinodh', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[OrganizationRoutes] OFF
/****** Object:  Table [dbo].[OrganizationMembers]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[OrganizationMembers] ON
INSERT [dbo].[OrganizationMembers] ([row_id], [MemberID], [Organization_ID], [userName], [FirstName], [LastName], [MiddleName], [designation], [Address], [AddressLandMark], [City], [State], [Coutry], [PinCode], [Email], [PrimaryContactNo], [AlternativeContactNo], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1001, N'M001', 100, N'9100000101', N'Member 1', N'Ord100', NULL, N'student', N'Jubilee hills', N'Near Check post', N'Hyderabad', N'Telangana', N'India', 500015, NULL, 910000101, NULL, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[OrganizationMembers] ([row_id], [MemberID], [Organization_ID], [userName], [FirstName], [LastName], [MiddleName], [designation], [Address], [AddressLandMark], [City], [State], [Coutry], [PinCode], [Email], [PrimaryContactNo], [AlternativeContactNo], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1003, N'M002', 100, N'9100000102', N'Member 2', N'org100', NULL, N'student', N'Madhapur', N'Near check post', N'hyderabad', N'Telangana', N'India', 500016, NULL, 910000102, NULL, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[OrganizationMembers] ([row_id], [MemberID], [Organization_ID], [userName], [FirstName], [LastName], [MiddleName], [designation], [Address], [AddressLandMark], [City], [State], [Coutry], [PinCode], [Email], [PrimaryContactNo], [AlternativeContactNo], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1004, N'M103', 100, N'9100000103', N'Member 3', N'Org100', NULL, N'student', N'Hitech City', N'Near Image hospital', N'Hyderabad', N'Telangana', N'India', 500080, NULL, 910000103, NULL, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[OrganizationMembers] ([row_id], [MemberID], [Organization_ID], [userName], [FirstName], [LastName], [MiddleName], [designation], [Address], [AddressLandMark], [City], [State], [Coutry], [PinCode], [Email], [PrimaryContactNo], [AlternativeContactNo], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1005, N'M104', 100, N'9100000104', N'Member 4', N'Org 100', NULL, N'student', N'Kothaguda', N'Near google office', N'Hyderabad', N'Telangana', N'India', 500081, NULL, 910000104, NULL, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[OrganizationMembers] OFF
/****** Object:  Table [dbo].[Organization]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[Organization] ON
INSERT [dbo].[Organization] ([row_id], [Organization_ID], [Organization_Name], [Organization_Type], [AddressStreet1], [AddressStreet2], [City], [State], [PinCode], [PrimaryContactNumner], [SecondaryContactNo], [Email], [IsActive], [Cr_datetime], [updt_datetime], [LastUpdatedBy]) VALUES (1000, 100, N'Sample Org 1', N'School', N'Gachibowli', N'Near ORR', N'Hyderabad', N'Telangana', 500081, 949390578, 988522242, N'vinodh5c6@gmail.com', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime), N'vinodh')
INSERT [dbo].[Organization] ([row_id], [Organization_ID], [Organization_Name], [Organization_Type], [AddressStreet1], [AddressStreet2], [City], [State], [PinCode], [PrimaryContactNumner], [SecondaryContactNo], [Email], [IsActive], [Cr_datetime], [updt_datetime], [LastUpdatedBy]) VALUES (1001, 101, N'Sample Org2', N'School', N'Hitech City', N'Ciber Towers', N'Hyderabad', N'Telangana', 500084, 888888888, 888888888, N'vinodhdanda001@gmail.com', N'1', CAST(0x0000A75D00000000 AS DateTime), CAST(0x0000A75D00000000 AS DateTime), N'Vinodh')
SET IDENTITY_INSERT [dbo].[Organization] OFF
/****** Object:  Table [dbo].[MemberRole]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[MemberRole] ON
INSERT [dbo].[MemberRole] ([row_id], [MemberID], [Organization_ID], [RoleID], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (100, N'M001', 100, 1, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[MemberRole] ([row_id], [MemberID], [Organization_ID], [RoleID], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (101, N'M002', 100, 1, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[MemberRole] ([row_id], [MemberID], [Organization_ID], [RoleID], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (102, N'M003', 100, 1, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[MemberRole] ([row_id], [MemberID], [Organization_ID], [RoleID], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (103, N'M004', 100, 1, N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[MemberRole] OFF
/****** Object:  Table [dbo].[Login]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([row_id], [userName], [Organization_ID], [PasswordSalt], [PasswordHash], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, N'9100000101', 100, N'xxx', N'xxx', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[Login] ([row_id], [userName], [Organization_ID], [PasswordSalt], [PasswordHash], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1002, N'9100000102', 100, N'xxx', N'xxx', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[Login] ([row_id], [userName], [Organization_ID], [PasswordSalt], [PasswordHash], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1003, N'9100000103', 100, N'xxx', N'xxx', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
INSERT [dbo].[Login] ([row_id], [userName], [Organization_ID], [PasswordSalt], [PasswordHash], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1005, N'9100000104', 100, N'xxx', N'xxx', N'vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Login] OFF
/****** Object:  Table [dbo].[DriverDetails]    Script Date: 04/23/2017 11:43:20 ******/
SET IDENTITY_INSERT [dbo].[DriverDetails] ON
INSERT [dbo].[DriverDetails] ([row_id], [Organization_ID], [Driver_ID], [DriverName], [DriverAddress], [DriverContactNum], [LastUpdatedBy], [IsActive], [cr_datetime], [updt_datetime]) VALUES (1000, 100, N'D10001', N'Satyanarayana', N'Gachibowli', 901000000, N'Vinodh', N'1', CAST(0x0000A75E00000000 AS DateTime), CAST(0x0000A75E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[DriverDetails] OFF



update dbo.OrganizationMembers set IsActive = 'Y' where IsActive = '1'
update dbo.Organization set IsActive = 'Y' where IsActive = '1'

update dbo.RouteTrips set IsActive = 'Y' where IsActive = '1'
update dbo.OrganizationRoutes set IsActive = 'Y' where IsActive = '1'


----- Added as part of data column type change

Alter table dbo.OrganizationRoutes 
drop constraint pk_OrganizationRoutes_01
GO

update dbo.OrganizationRoutes set Route_ID = '1001' where Route_ID = 'R1001'
update dbo.OrganizationRoutes set Route_ID = '1002' where Route_ID = 'R1002'

Alter table dbo.OrganizationRoutes 
Alter column Route_ID int NOT NULL 
go

Alter table dbo.OrganizationRoutes 
Add CONSTRAINT [pk_OrganizationRoutes_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC
)
GO


Alter table dbo.RouteHalts 
drop constraint [pk_RouteHalts_01]
GO

update dbo.RouteHalts set Route_ID = '1001' where Route_ID = 'R1001'
update dbo.RouteHalts set Route_ID = '1002' where Route_ID = 'R1002'

Alter table dbo.RouteHalts 
Alter column [Route_ID] int not null
GO

Alter table dbo.RouteHalts 
Add CONSTRAINT [pk_RouteHalts_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[HaltName] ASC
)
GO


Alter table dbo.RouteMembers 
drop constraint pk_RouteMembers_01
GO

update dbo.RouteMembers set Route_ID = '1001' where Route_ID = 'R1001'
update dbo.RouteMembers set Route_ID = '1002' where Route_ID = 'R1002'

Alter table dbo.RouteMembers 
Alter column [Route_ID] int not null
GO

Alter table dbo.RouteMembers 
Add CONSTRAINT [pk_RouteMembers_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC,
	[MemberID] ASC
)
GO



Alter table dbo.RouteTrips 
drop constraint pk_RouteTrips_01
GO

update dbo.RouteTrips set Route_ID = '1001' where Route_ID = 'R1001'
update dbo.RouteTrips set Route_ID = '1002' where Route_ID = 'R1002'

Alter table dbo.RouteTrips 
Alter column [Route_ID] int not null
GO

Alter table dbo.RouteTrips 
Add CONSTRAINT [pk_RouteTrips_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC
)
GO



Alter table dbo.TripHaltTimings 
drop constraint pk_TripHaltTimings_01
GO

update dbo.TripHaltTimings set Route_ID = '1001' where Route_ID = 'R1001'
update dbo.TripHaltTimings set Route_ID = '1002' where Route_ID = 'R1002'

Alter table dbo.TripHaltTimings 
Alter column [Route_ID] int not null
GO

Alter table dbo.TripHaltTimings 
Add CONSTRAINT [pk_TripHaltTimings_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC,
	[HaltName] ASC,
	[ToWordsOrgInd] ASC
)
GO



Alter table dbo.TripVehicleDriverDetails 
drop constraint pk_TripVehicleDriverDetails_01
GO

update dbo.TripVehicleDriverDetails set Route_ID = '1001' where Route_ID = 'R1001'
update dbo.TripVehicleDriverDetails set Route_ID = '1002' where Route_ID = 'R1002'

Alter table dbo.TripVehicleDriverDetails 
Alter column [Route_ID] int not null
GO

Alter table dbo.TripVehicleDriverDetails 
Add CONSTRAINT [pk_TripVehicleDriverDetails_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC
)
GO



Alter table dbo.tripStatus 
drop constraint pk_TripStatus_01
GO

update dbo.tripStatus set Route_ID = '1001' where Route_ID = 'R1001'
update dbo.tripStatus set Route_ID = '1002' where Route_ID = 'R1002'

Alter table dbo.tripStatus 
Alter column [Route_ID] int not null
GO

Alter table dbo.tripStatus 
Add CONSTRAINT [pk_TripStatus_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC,
	[TripSessionId] ASC
)
GO

Alter table dbo.TripStatus
Alter column Vehicle_ID int
GO


Alter table dbo.RouteTrips 
drop constraint pk_RouteTrips_01
GO

update RouteTrips set  TripId = '1' where TripId = 'T001'
update RouteTrips set  TripId = '2' where TripId = 'T002'

Alter table dbo.RouteTrips 
Alter column [TripId] int not null
GO

Alter table dbo.RouteTrips 
Add CONSTRAINT [pk_RouteTrips_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC
)
GO


Alter table dbo.TripHaltTimings 
drop constraint pk_TripHaltTimings_01
GO

Alter table dbo.TripHaltTimings 
Alter column [TripId] int not null
GO

Alter table dbo.TripHaltTimings 
Add CONSTRAINT [pk_TripHaltTimings_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC,
	[HaltName] ASC,
	[ToWordsOrgInd] ASC
)
GO


Alter table dbo.TripStatus 
drop constraint pk_TripStatus_01
GO

--update RouteTrips set  TripId = '1' where TripId = 'T001'
--update RouteTrips set  TripId = '2' where TripId = 'T002'

Alter table dbo.TripStatus 
Alter column [TripId] int not null
GO

Alter table dbo.TripStatus 
Add CONSTRAINT [pk_TripStatus_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC,
	[TripSessionId] ASC
)
GO



Alter table dbo.TripVehicleDriverDetails 
drop constraint pk_TripVehicleDriverDetails_01
GO

update TripVehicleDriverDetails  set  TripId = '1' where TripId = 'T001'

Alter table dbo.TripVehicleDriverDetails 
Alter column [TripId] int not null
GO

Alter table dbo.TripVehicleDriverDetails 
Add CONSTRAINT [pk_TripVehicleDriverDetails_01] PRIMARY KEY CLUSTERED 
(
	[Organization_ID] ASC,
	[Route_ID] ASC,
	[TripId] ASC
)
GO
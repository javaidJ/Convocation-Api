USE [ConvocationDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [uniqueidentifier] NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[PostalCode] [int] NOT NULL,
	[AddressLine] [nvarchar](max) NOT NULL,
	[EntityId] [uniqueidentifier] NOT NULL,
	[Module] [tinyint] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppFiles]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppFiles](
	[Id] [uniqueidentifier] NOT NULL,
	[Module] [tinyint] NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[EntityId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_AppFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppOrders]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppOrders](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [nvarchar](max) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[GownBookingId] [uniqueidentifier] NOT NULL,
	[Receipt] [nvarchar](max) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[IsPartial] [bit] NOT NULL,
	[AmountPaid] [decimal](18, 2) NOT NULL,
	[AmountDue] [decimal](18, 2) NOT NULL,
	[CreatedAt] [int] NOT NULL,
	[Currency] [nvarchar](max) NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_AppOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppPayments]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppPayments](
	[Id] [uniqueidentifier] NOT NULL,
	[TransactionId] [nvarchar](max) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Currency] [nvarchar](max) NOT NULL,
	[PaymentMethod] [int] NOT NULL,
	[AppPaymentStatus] [int] NOT NULL,
	[RpOrderId] [nvarchar](max) NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_AppPayments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Convocations]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Convocations](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ConvocationDate] [datetimeoffset](7) NOT NULL,
	[End] [time](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[VenueId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Convocations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [uniqueidentifier] NOT NULL,
	[DepartmentName] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[EmpCode] [nvarchar](max) NULL,
	[Designation] [tinyint] NULL,
	[IsDeleted] [bit] NOT NULL,
	[DepartemntId] [uniqueidentifier] NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GownBookings]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GownBookings](
	[Id] [uniqueidentifier] NOT NULL,
	[GownId] [uniqueidentifier] NOT NULL,
	[EntityId] [uniqueidentifier] NOT NULL,
	[GownStatus] [tinyint] NOT NULL,
	[IsCancelled] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_GownBookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gowns]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gowns](
	[Id] [uniqueidentifier] NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Size] [tinyint] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Charges] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Gowns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guests]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guests](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Designation] [nvarchar](max) NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[ContactNo] [nvarchar](max) NOT NULL,
	[GuestArrivedFrom] [nvarchar](max) NOT NULL,
	[IsOutSider] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Guests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [uniqueidentifier] NOT NULL,
	[EntityId] [uniqueidentifier] NOT NULL,
	[Module] [tinyint] NOT NULL,
	[JobRole] [tinyint] NOT NULL,
	[ConvocationId] [uniqueidentifier] NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passes]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passes](
	[Id] [uniqueidentifier] NOT NULL,
	[PassNumber] [nvarchar](max) NOT NULL,
	[IUSTConvocationId] [uniqueidentifier] NOT NULL,
	[EntityId] [uniqueidentifier] NOT NULL,
	[VehicleNo] [nvarchar](max) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Passes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registrations]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrations](
	[Id] [uniqueidentifier] NOT NULL,
	[EntityId] [uniqueidentifier] NOT NULL,
	[Module] [tinyint] NOT NULL,
	[RegistrationStatus] [tinyint] NOT NULL,
	[ParticipantRole] [tinyint] NOT NULL,
	[ConvocationId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Registrations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeatAllocations]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeatAllocations](
	[Id] [uniqueidentifier] NOT NULL,
	[EntityId] [uniqueidentifier] NULL,
	[SeatId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
	[ConvocationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SeatAllocations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[Id] [uniqueidentifier] NOT NULL,
	[VenueId] [uniqueidentifier] NOT NULL,
	[SeatSection] [tinyint] NOT NULL,
	[Row] [int] NOT NULL,
	[SeatNumber] [nvarchar](max) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [uniqueidentifier] NOT NULL,
	[RegNumber] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Parentage] [nvarchar](max) NOT NULL,
	[DepartemntId] [uniqueidentifier] NULL,
	[Course] [tinyint] NOT NULL,
	[Batch] [int] NOT NULL,
	[Percentage] [float] NOT NULL,
	[Position] [tinyint] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[ContactNo] [nvarchar](max) NOT NULL,
	[ResetCode] [nvarchar](max) NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[UserRole] [tinyint] NOT NULL,
	[UserStatus] [tinyint] NOT NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[ConfirmationCode] [nvarchar](max) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venues]    Script Date: 12/3/2023 8:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venues](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TotalSeats] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Venues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231024064030_initialmig', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231024144526_venue-added', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231024145057_venues-added', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231025071704_payment', N'7.0.9')
GO
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'55aeb524-4557-441b-b7fc-b01f4794d351', 4, N'Files\ccc7d3ba-dfca-43cc-80f2-eb1f533d4d3ede3b53cc-4018-4d8d-8ef1-c652a785835dYellow-Polyester-Nursery-School-Graduation-Gown.webp', N'2e43e5e2-58a6-4a01-9a04-f8a980853556', N'2e43e5e2-58a6-4a01-9a04-f8a980853556', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T14:53:49.3674975+05:30' AS DateTimeOffset), CAST(N'2023-11-05T14:53:49.3675013+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[Convocations] ([Id], [Name], [ConvocationDate], [End], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [Description], [VenueId]) VALUES (N'7fe3b8a8-0445-4019-8985-96ac42bbd66b', N'Convocation-2023-CS', CAST(N'2023-12-08T14:02:00.0000000+05:30' AS DateTimeOffset), CAST(N'18:00:00' AS Time), 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T14:02:54.6185927+05:30' AS DateTimeOffset), CAST(N'2023-12-03T14:02:54.6185933+05:30' AS DateTimeOffset), N'where there is a will there is a way', N'12dc12a1-7e21-4f61-bf6b-1ae9ed1f4be8')
INSERT [dbo].[Convocations] ([Id], [Name], [ConvocationDate], [End], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [Description], [VenueId]) VALUES (N'6f729c16-fed2-4e7d-b54d-cc8ddc5de42f', N'aaa', CAST(N'2023-11-17T14:47:00.0000000+05:30' AS DateTimeOffset), CAST(N'15:48:00' AS Time), 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T14:47:47.9890609+05:30' AS DateTimeOffset), CAST(N'2023-11-05T14:47:47.9890626+05:30' AS DateTimeOffset), N'asds', N'974917a1-78dd-4cd3-8fb5-7192ffbcbe26')
GO
INSERT [dbo].[Departments] ([Id], [DepartmentName], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'1862046e-cdad-4663-9969-3127c15f01c0', N'Computer Science', 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T14:13:20.6558633+05:30' AS DateTimeOffset), CAST(N'2023-12-03T14:13:20.6558641+05:30' AS DateTimeOffset))
INSERT [dbo].[Departments] ([Id], [DepartmentName], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'962759d7-0e6a-4663-8d56-af65446c978a', N'Information technology', 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T14:37:04.6630939+05:30' AS DateTimeOffset), CAST(N'2023-11-05T14:37:04.6631019+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[Employees] ([Id], [Name], [EmpCode], [Designation], [IsDeleted], [DepartemntId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'faa9ba1b-37b0-44d5-9706-581026ee5d90', N'sami', N'', 2, 0, N'962759d7-0e6a-4663-8d56-af65446c978a', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T15:05:45.1998103+05:30' AS DateTimeOffset), CAST(N'2023-11-05T15:05:45.1998143+05:30' AS DateTimeOffset))
INSERT [dbo].[Employees] ([Id], [Name], [EmpCode], [Designation], [IsDeleted], [DepartemntId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'246b9829-f875-44b4-871d-63e800dc2cbd', N'Rizwan Ahmad', N'', 1, 0, N'962759d7-0e6a-4663-8d56-af65446c978a', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T15:03:15.8285087+05:30' AS DateTimeOffset), CAST(N'2023-11-05T15:03:15.8285125+05:30' AS DateTimeOffset))
INSERT [dbo].[Employees] ([Id], [Name], [EmpCode], [Designation], [IsDeleted], [DepartemntId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'df802fad-21fa-439b-b44d-8bc10ffbdf5e', N'Faizan', N'', 4, 0, N'1862046e-cdad-4663-9969-3127c15f01c0', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T18:28:03.0252456+05:30' AS DateTimeOffset), CAST(N'2023-12-03T18:28:03.0252468+05:30' AS DateTimeOffset))
INSERT [dbo].[Employees] ([Id], [Name], [EmpCode], [Designation], [IsDeleted], [DepartemntId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'06f045c3-3e40-4bf8-bb88-99f5177f1b7b', N'iram', N'', 7, 0, N'962759d7-0e6a-4663-8d56-af65446c978a', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T14:01:09.2237456+05:30' AS DateTimeOffset), CAST(N'2023-12-03T14:01:09.2237468+05:30' AS DateTimeOffset))
INSERT [dbo].[Employees] ([Id], [Name], [EmpCode], [Designation], [IsDeleted], [DepartemntId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'b68f5df4-e4ca-4405-98e2-a7c00f1bb5d2', N'Musaib', N'', 2, 0, N'1862046e-cdad-4663-9969-3127c15f01c0', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T18:39:01.1666705+05:30' AS DateTimeOffset), CAST(N'2023-12-03T18:39:01.1666715+05:30' AS DateTimeOffset))
INSERT [dbo].[Employees] ([Id], [Name], [EmpCode], [Designation], [IsDeleted], [DepartemntId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'36794c37-8e79-4119-b8d9-b172da6e27bb', N'faisal', N'', 3, 0, N'962759d7-0e6a-4663-8d56-af65446c978a', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T13:58:07.5077104+05:30' AS DateTimeOffset), CAST(N'2023-12-03T13:58:07.5077141+05:30' AS DateTimeOffset))
INSERT [dbo].[Employees] ([Id], [Name], [EmpCode], [Designation], [IsDeleted], [DepartemntId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'a0d8158e-b8d9-48f7-9aff-b3518e72989c', N'zia', N'', 4, 0, N'962759d7-0e6a-4663-8d56-af65446c978a', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T13:59:47.6691177+05:30' AS DateTimeOffset), CAST(N'2023-12-03T13:59:47.6691210+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[Gowns] ([Id], [Color], [Quantity], [Size], [IsDeleted], [Charges], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'2e43e5e2-58a6-4a01-9a04-f8a980853556', N'Green', 50, 2, 0, 500, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T14:53:49.1883509+05:30' AS DateTimeOffset), CAST(N'2023-11-05T14:53:49.1883547+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[Guests] ([Id], [Name], [Designation], [Gender], [Email], [ContactNo], [GuestArrivedFrom], [IsOutSider], [IsDeleted], [Description], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'9e18635d-1b2c-4f93-a8b9-848d7d4815af', N'Dr Rizwan Ahmad', N'Hero', 1, N'logichubss+45@gmail.com', N'11222555', N'KU', 1, 0, N'a quick brown fox jumps over the lazy dog', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T18:02:13.2879209+05:30' AS DateTimeOffset), CAST(N'2023-12-03T18:02:13.2879230+05:30' AS DateTimeOffset))
INSERT [dbo].[Guests] ([Id], [Name], [Designation], [Gender], [Email], [ContactNo], [GuestArrivedFrom], [IsOutSider], [IsDeleted], [Description], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'136ec164-a4c5-43af-ba48-88001f1f9f86', N'Musaib Ahmad', N'Don', 1, N'logichubss+46@gmail.com', N'112225555', N'KU', 1, 0, N'a quick brown fox jumps over the lazy dog', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T18:02:45.6909564+05:30' AS DateTimeOffset), CAST(N'2023-12-03T18:02:45.6909577+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[Member] ([Id], [EntityId], [Module], [JobRole], [ConvocationId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'48c39e6d-fd75-494b-9a50-585e2d531a8b', N'b68f5df4-e4ca-4405-98e2-a7c00f1bb5d2', 2, 4, N'7fe3b8a8-0445-4019-8985-96ac42bbd66b', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T19:03:08.9322685+05:30' AS DateTimeOffset), CAST(N'2023-12-03T19:03:08.9322696+05:30' AS DateTimeOffset))
INSERT [dbo].[Member] ([Id], [EntityId], [Module], [JobRole], [ConvocationId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'c1f4c649-b55b-4ae8-b713-88ac103c5b67', N'06f045c3-3e40-4bf8-bb88-99f5177f1b7b', 2, 3, N'7fe3b8a8-0445-4019-8985-96ac42bbd66b', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T16:02:13.1063327+05:30' AS DateTimeOffset), CAST(N'2023-12-03T16:02:13.1063337+05:30' AS DateTimeOffset))
INSERT [dbo].[Member] ([Id], [EntityId], [Module], [JobRole], [ConvocationId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'c7df6cae-8d9c-4f18-a246-931e39c7c651', N'36794c37-8e79-4119-b8d9-b172da6e27bb', 2, 1, N'7fe3b8a8-0445-4019-8985-96ac42bbd66b', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T16:01:41.7139628+05:30' AS DateTimeOffset), CAST(N'2023-12-03T16:01:41.7139641+05:30' AS DateTimeOffset))
INSERT [dbo].[Member] ([Id], [EntityId], [Module], [JobRole], [ConvocationId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'5f713f78-a7a7-49f3-ba84-fe09f4e99861', N'a0d8158e-b8d9-48f7-9aff-b3518e72989c', 2, 2, N'7fe3b8a8-0445-4019-8985-96ac42bbd66b', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T16:01:53.4368302+05:30' AS DateTimeOffset), CAST(N'2023-12-03T16:01:53.4368311+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[Registrations] ([Id], [EntityId], [Module], [RegistrationStatus], [ParticipantRole], [ConvocationId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'6a77de70-ceb8-48f9-aaa9-4357d7a3671d', N'df802fad-21fa-439b-b44d-8bc10ffbdf5e', 2, 2, 3, N'7fe3b8a8-0445-4019-8985-96ac42bbd66b', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T19:08:28.3310693+05:30' AS DateTimeOffset), CAST(N'2023-12-03T19:08:28.3310707+05:30' AS DateTimeOffset))
INSERT [dbo].[Registrations] ([Id], [EntityId], [Module], [RegistrationStatus], [ParticipantRole], [ConvocationId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'a4852042-49f7-4c12-8bd3-6421bb7044a2', N'54488c3d-4ce9-452d-966e-e22732734251', 0, 1, 11, N'7fe3b8a8-0445-4019-8985-96ac42bbd66b', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T20:18:12.1104602+05:30' AS DateTimeOffset), CAST(N'2023-12-03T20:18:12.1104613+05:30' AS DateTimeOffset))
INSERT [dbo].[Registrations] ([Id], [EntityId], [Module], [RegistrationStatus], [ParticipantRole], [ConvocationId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'7c3cc83a-ab18-436f-ad39-fa4de0c6cbf7', N'faa9ba1b-37b0-44d5-9706-581026ee5d90', 2, 2, 6, N'6f729c16-fed2-4e7d-b54d-cc8ddc5de42f', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-06T13:24:33.4120861+05:30' AS DateTimeOffset), CAST(N'2023-11-06T13:24:33.4120880+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[SeatAllocations] ([Id], [EntityId], [SeatId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [ConvocationId]) VALUES (N'bbd99c37-8e61-4b23-94e8-8bd953db10f3', N'6a77de70-ceb8-48f9-aaa9-4357d7a3671d', N'361c3839-5d1b-4494-a4ab-2364d044fe37', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T19:46:19.8759786+05:30' AS DateTimeOffset), CAST(N'2023-12-03T19:46:19.8759800+05:30' AS DateTimeOffset), N'7fe3b8a8-0445-4019-8985-96ac42bbd66b')
INSERT [dbo].[SeatAllocations] ([Id], [EntityId], [SeatId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [ConvocationId]) VALUES (N'b785bb3d-99f9-4ba2-a0fa-9ee9c06588ba', N'7c3cc83a-ab18-436f-ad39-fa4de0c6cbf7', N'41e89118-2bb8-4eb1-af6d-906cbe81679e', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-06T13:24:53.7688528+05:30' AS DateTimeOffset), CAST(N'2023-11-06T13:24:53.7688541+05:30' AS DateTimeOffset), N'6f729c16-fed2-4e7d-b54d-cc8ddc5de42f')
GO
INSERT [dbo].[Seats] ([Id], [VenueId], [SeatSection], [Row], [SeatNumber], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'361c3839-5d1b-4494-a4ab-2364d044fe37', N'12dc12a1-7e21-4f61-bf6b-1ae9ed1f4be8', 1, 1, N's101', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T16:31:15.6675108+05:30' AS DateTimeOffset), CAST(N'2023-11-05T16:31:15.6675143+05:30' AS DateTimeOffset))
INSERT [dbo].[Seats] ([Id], [VenueId], [SeatSection], [Row], [SeatNumber], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'5d743709-938d-42d7-865e-6ca2d789a72e', N'12dc12a1-7e21-4f61-bf6b-1ae9ed1f4be8', 1, 1, N's103', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T16:31:23.0011015+05:30' AS DateTimeOffset), CAST(N'2023-11-05T16:31:23.0011051+05:30' AS DateTimeOffset))
INSERT [dbo].[Seats] ([Id], [VenueId], [SeatSection], [Row], [SeatNumber], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'41e89118-2bb8-4eb1-af6d-906cbe81679e', N'974917a1-78dd-4cd3-8fb5-7192ffbcbe26', 1, 1, N'a1', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T16:32:35.1432804+05:30' AS DateTimeOffset), CAST(N'2023-11-05T16:32:35.1432813+05:30' AS DateTimeOffset))
INSERT [dbo].[Seats] ([Id], [VenueId], [SeatSection], [Row], [SeatNumber], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'c5269a6e-8533-47c8-b85a-9be00d80be01', N'12dc12a1-7e21-4f61-bf6b-1ae9ed1f4be8', 1, 1, N's100', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T16:31:07.3686193+05:30' AS DateTimeOffset), CAST(N'2023-11-05T16:31:07.3686227+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[Students] ([Id], [RegNumber], [Name], [Parentage], [DepartemntId], [Course], [Batch], [Percentage], [Position], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'78ef8476-e452-4acb-9cb3-002014d5c4f2', N'reg548', N'waseem', N'akram', N'1862046e-cdad-4663-9969-3127c15f01c0', 1, 2020, 77, 2, 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T15:52:19.9686388+05:30' AS DateTimeOffset), CAST(N'2023-12-03T15:52:19.9686400+05:30' AS DateTimeOffset))
INSERT [dbo].[Students] ([Id], [RegNumber], [Name], [Parentage], [DepartemntId], [Course], [Batch], [Percentage], [Position], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'dfa855c0-8dfb-419b-8e25-4e2dd4a0ed81', N'refg123', N'haidar', N'ali', N'1862046e-cdad-4663-9969-3127c15f01c0', 1, 2020, 68, 3, 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T15:53:48.1407223+05:30' AS DateTimeOffset), CAST(N'2023-12-03T15:53:48.1407233+05:30' AS DateTimeOffset))
INSERT [dbo].[Students] ([Id], [RegNumber], [Name], [Parentage], [DepartemntId], [Course], [Batch], [Percentage], [Position], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'54488c3d-4ce9-452d-966e-e22732734251', N'reg123', N'adnan', N'Yoqoub Baba', N'1862046e-cdad-4663-9969-3127c15f01c0', 1, 2020, 89, 1, 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T15:49:48.6626529+05:30' AS DateTimeOffset), CAST(N'2023-12-03T15:49:48.6626569+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'78ef8476-e452-4acb-9cb3-002014d5c4f2', N'waseem', N'$2a$11$r0CcXbtWEH4Ffj7T47U9eO.eoiZaWWJWSk4DyC0Saz2EkhI1iyvtW', N'$2a$11$r0CcXbtWEH4Ffj7T47U9eO', N'logichubss+78@gmail.com', N'9879879877', N'', 1, 2, 3, 1, N'', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T15:52:19.7424582+05:30' AS DateTimeOffset), CAST(N'2023-12-03T15:52:19.7424595+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', N'admin', N'$2a$11$TYYBxfFaSET3Oizd0CXEleNVtkdE7FEE.p60NpoAT13WT38X2OP5q', N'$2a$11$TYYBxfFaSET3Oizd0CXEle', N'samiaullah1@gmail.com', N'8828084050', N'', 1, 1, 1, 1, N'', N'3d992083-03c9-43b1-b25d-54fd1e862254', N'a379e688-68e8-4271-92aa-a80b65d45efa', CAST(N'2023-10-25T12:47:03.6278306+05:30' AS DateTimeOffset), CAST(N'2023-10-25T12:47:03.6278317+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'dfa855c0-8dfb-419b-8e25-4e2dd4a0ed81', N'haidar', N'$2a$11$up3smcmXMh8A/uaYADapA.4nA9RPqKbJ4x1ESUhCkuFRF9gmr9RQq', N'$2a$11$up3smcmXMh8A/uaYADapA.', N'logichubss+79@gmail.com', N'9876546544', N'', 1, 2, 3, 1, N'', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T15:53:47.9139129+05:30' AS DateTimeOffset), CAST(N'2023-12-03T15:53:47.9139138+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'faa9ba1b-37b0-44d5-9706-581026ee5d90', N'logichubss+13@gmail.com', N'$2a$11$OdGE14gO1UUmBLMT0M23pO3Kp8VhHz.KW8vWv2mTyWoYkgDQ6RuSq', N'$2a$11$OdGE14gO1UUmBLMT0M23pO', N'logichubss+13@gmail.com', N'98769877', N'', 0, 3, 1, 1, N'', N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T15:05:44.9650406+05:30' AS DateTimeOffset), CAST(N'2023-11-05T15:05:44.9650444+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'246b9829-f875-44b4-871d-63e800dc2cbd', N'logichubss+12@gmail.com', N'$2a$11$9fytp4vazQELoIBfjzUdPu6GRAD6aRRqy06tKd8/4qTLo9i30miwO', N'$2a$11$9fytp4vazQELoIBfjzUdPu', N'logichubss+12@gmail.com', N'898908098098', N'', 0, 3, 1, 1, N'', N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T15:03:15.4413391+05:30' AS DateTimeOffset), CAST(N'2023-11-05T15:03:15.4413426+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'df802fad-21fa-439b-b44d-8bc10ffbdf5e', N'logichubss+33@gmail.com', N'$2a$11$7LWpJSAv5EOy0TMYa8W7t.vvQrGWVZPdAFW1vO2RQt1dKTqXVn2n2', N'$2a$11$7LWpJSAv5EOy0TMYa8W7t.', N'logichubss+33@gmail.com', N'1112544577', N'', 0, 3, 1, 1, N'', N'36794c37-8e79-4119-b8d9-b172da6e27bb', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T18:28:02.8008847+05:30' AS DateTimeOffset), CAST(N'2023-12-03T18:28:02.8008865+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'06f045c3-3e40-4bf8-bb88-99f5177f1b7b', N'logichubss+15@gmail.com', N'$2a$11$gVTEQfE0JKJ7rkgreRol1OjJ7g81bYUz/lujmIsPmATScGbO2Y4LC', N'$2a$11$gVTEQfE0JKJ7rkgreRol1O', N'logichubss+15@gmail.com', N'8825080422', N'', 0, 3, 1, 1, N'', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T14:01:09.0034604+05:30' AS DateTimeOffset), CAST(N'2023-12-03T14:01:09.0034623+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'b68f5df4-e4ca-4405-98e2-a7c00f1bb5d2', N'logichubss+44@gmail.com', N'$2a$11$2sgMjneJrc5jiAsZFr3jOucx4Tvro.b/IXtuOVBudUgZQHgdwNSm2', N'$2a$11$2sgMjneJrc5jiAsZFr3jOu', N'logichubss+44@gmail.com', N'121545454`', N'', 0, 3, 1, 1, N'', N'36794c37-8e79-4119-b8d9-b172da6e27bb', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T18:39:00.9358781+05:30' AS DateTimeOffset), CAST(N'2023-12-03T18:39:00.9358795+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'36794c37-8e79-4119-b8d9-b172da6e27bb', N'logichubss+11@gmail.com', N'$2a$11$7dU7OqCX.WwM1UXcNMwwOOxLCDYvYPSckHWRUX9yGeFQFMMWVm7g6', N'$2a$11$7dU7OqCX.WwM1UXcNMwwOO', N'logichubss+11@gmail.com', N'8825080450', N'', 0, 3, 1, 1, N'', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T13:58:07.2850718+05:30' AS DateTimeOffset), CAST(N'2023-12-03T13:58:07.2850760+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'a0d8158e-b8d9-48f7-9aff-b3518e72989c', N'logichubss+14@gmail.com', N'$2a$11$mTPNHtARc2Tc.ymorQ75N.SuoEZoNNDth9DS11bQEBFVOG83g0B7W', N'$2a$11$mTPNHtARc2Tc.ymorQ75N.', N'logichubss+14@gmail.com', N'8825080411', N'', 0, 3, 1, 1, N'', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T13:59:47.4409315+05:30' AS DateTimeOffset), CAST(N'2023-12-03T13:59:47.4409363+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt], [Email], [ContactNo], [ResetCode], [Gender], [UserRole], [UserStatus], [IsEmailVerified], [ConfirmationCode], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'54488c3d-4ce9-452d-966e-e22732734251', N'adnan', N'$2a$11$txk9xb2hqF57vC8926el7uDWnXtGpFBk0XmyFzL6pnz/X6zJKVD.a', N'$2a$11$txk9xb2hqF57vC8926el7u', N'logichubss+77@gmail.com', N'0978987777', N'', 1, 2, 3, 1, N'', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-12-03T15:49:48.2444146+05:30' AS DateTimeOffset), CAST(N'2023-12-03T15:49:48.2444202+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[Venues] ([Id], [Name], [TotalSeats], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'12dc12a1-7e21-4f61-bf6b-1ae9ed1f4be8', N'Lagichub', 20, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T14:50:41.6928266+05:30' AS DateTimeOffset), CAST(N'2023-11-05T14:50:41.6928277+05:30' AS DateTimeOffset))
INSERT [dbo].[Venues] ([Id], [Name], [TotalSeats], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'974917a1-78dd-4cd3-8fb5-7192ffbcbe26', N'Santoor', 50, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-11-05T14:40:21.9264102+05:30' AS DateTimeOffset), CAST(N'2023-11-05T14:40:21.9264138+05:30' AS DateTimeOffset))
GO
ALTER TABLE [dbo].[Convocations] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [VenueId]
GO
ALTER TABLE [dbo].[SeatAllocations] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [ConvocationId]
GO
ALTER TABLE [dbo].[AppPayments]  WITH CHECK ADD  CONSTRAINT [FK_AppPayments_AppOrders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[AppOrders] ([Id])
GO
ALTER TABLE [dbo].[AppPayments] CHECK CONSTRAINT [FK_AppPayments_AppOrders_OrderId]
GO
ALTER TABLE [dbo].[Convocations]  WITH CHECK ADD  CONSTRAINT [FK_Convocations_Venues_VenueId] FOREIGN KEY([VenueId])
REFERENCES [dbo].[Venues] ([Id])
GO
ALTER TABLE [dbo].[Convocations] CHECK CONSTRAINT [FK_Convocations_Venues_VenueId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments_DepartemntId] FOREIGN KEY([DepartemntId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments_DepartemntId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users_Id]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Convocations_ConvocationId] FOREIGN KEY([ConvocationId])
REFERENCES [dbo].[Convocations] ([Id])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Convocations_ConvocationId]
GO
ALTER TABLE [dbo].[Passes]  WITH CHECK ADD  CONSTRAINT [FK_Passes_Convocations_IUSTConvocationId] FOREIGN KEY([IUSTConvocationId])
REFERENCES [dbo].[Convocations] ([Id])
GO
ALTER TABLE [dbo].[Passes] CHECK CONSTRAINT [FK_Passes_Convocations_IUSTConvocationId]
GO
ALTER TABLE [dbo].[Registrations]  WITH CHECK ADD  CONSTRAINT [FK_Registrations_Convocations_ConvocationId] FOREIGN KEY([ConvocationId])
REFERENCES [dbo].[Convocations] ([Id])
GO
ALTER TABLE [dbo].[Registrations] CHECK CONSTRAINT [FK_Registrations_Convocations_ConvocationId]
GO
ALTER TABLE [dbo].[SeatAllocations]  WITH CHECK ADD  CONSTRAINT [FK_SeatAllocations_Convocations_ConvocationId] FOREIGN KEY([ConvocationId])
REFERENCES [dbo].[Convocations] ([Id])
GO
ALTER TABLE [dbo].[SeatAllocations] CHECK CONSTRAINT [FK_SeatAllocations_Convocations_ConvocationId]
GO
ALTER TABLE [dbo].[SeatAllocations]  WITH CHECK ADD  CONSTRAINT [FK_SeatAllocations_Seats_SeatId] FOREIGN KEY([SeatId])
REFERENCES [dbo].[Seats] ([Id])
GO
ALTER TABLE [dbo].[SeatAllocations] CHECK CONSTRAINT [FK_SeatAllocations_Seats_SeatId]
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD  CONSTRAINT [FK_Seats_Venues_VenueId] FOREIGN KEY([VenueId])
REFERENCES [dbo].[Venues] ([Id])
GO
ALTER TABLE [dbo].[Seats] CHECK CONSTRAINT [FK_Seats_Venues_VenueId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Departments_DepartemntId] FOREIGN KEY([DepartemntId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Departments_DepartemntId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Users_Id]
GO

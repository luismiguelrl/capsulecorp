IF DB_ID('Capsulecorp') IS NULL
BEGIN
    CREATE DATABASE [Capsulecorp]
END
GO

USE [Capsulecorp]
GO
/****** Object:  Table [dbo].[City]    Script Date: 26/08/2021 02:54:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Latitude] [int] NULL,
	[Longitude] [int] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrafficFine]    Script Date: 26/08/2021 02:54:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrafficFine](
	[TrafficFineId] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [varchar](7) NULL,
	[Distance] [int] NULL,
	[Valid] [bit] NULL,
	[AssignedCityId] [int] NULL,
	[Image] [varchar](500) NULL,
	[FlightAltitude] [int] NULL,
	[Speed] [int] NULL,
 CONSTRAINT [PK_TrafficFine] PRIMARY KEY CLUSTERED 
(
	[TrafficFineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityId], [Name], [Latitude], [Longitude]) VALUES (1, N'Ciudad Norte', -500, -200)
INSERT [dbo].[City] ([CityId], [Name], [Latitude], [Longitude]) VALUES (2, N'Ciudad Sur', 100, -100)
INSERT [dbo].[City] ([CityId], [Name], [Latitude], [Longitude]) VALUES (3, N'Ciudad Este', 500, 100)
INSERT [dbo].[City] ([CityId], [Name], [Latitude], [Longitude]) VALUES (4, N'Ciudad Oeste', 200, 100)
SET IDENTITY_INSERT [dbo].[City] OFF
GO


USE [master]
GO
/****** Object:  Database [CustomerDatabase1]    Script Date: 11/8/2022 1:41:44 PM ******/
CREATE DATABASE [CustomerDatabase1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerDatabase1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CustomerDatabase1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CustomerDatabase1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CustomerDatabase1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CustomerDatabase1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerDatabase1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerDatabase1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerDatabase1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerDatabase1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CustomerDatabase1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerDatabase1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CustomerDatabase1] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerDatabase1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerDatabase1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerDatabase1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerDatabase1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CustomerDatabase1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CustomerDatabase1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CustomerDatabase1] SET QUERY_STORE = OFF
GO
USE [CustomerDatabase1]
GO
/****** Object:  Table [dbo].[ContactTypes]    Script Date: 11/8/2022 1:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactTypes](
	[Identifier] [int] IDENTITY(1,1) NOT NULL,
	[ContactType] [nvarchar](50) NULL,
 CONSTRAINT [PK_ContactTypes] PRIMARY KEY CLUSTERED 
(
	[Identifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/8/2022 1:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Identifier] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](255) NULL,
	[ContactFirstName] [nvarchar](255) NULL,
	[ContactLastName] [nvarchar](255) NULL,
	[ContactTypeIdentifier] [int] NULL,
	[GenderIdentifier] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Identifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 11/8/2022 1:41:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[GenderType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ContactTypes] ON 

INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (1, N'Account Manager')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (2, N'Assistant Sales Agent')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (3, N'Assistant Sales representative')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (4, N'Marketing assistant')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (5, N'Marketing Manager')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (6, N'Order Administrator')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (7, N'Owner')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (8, N'Owner/Marketing Assistant')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (9, N'Sales Agent')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (10, N'Sales Associate')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (11, N'Sales Manager')
INSERT [dbo].[ContactTypes] ([Identifier], [ContactType]) VALUES (12, N'Sales Representative')
SET IDENTITY_INSERT [dbo].[ContactTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (1, N'Fly Girls', N'Tim', N'Clark', 7, 2)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (2, N'Coffee Paradise', N'Ann', N'Adams', 12, 1)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (3, N'Garrys Coffee', N'Mary', N'Clime', 7, 2)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (4, N'Salem Boat Rentals', N'Bill', N'Willis', 9, 2)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (5, N'Knifes are us', N'Kathy', N'Williams', 7, 1)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (6, N'Karen''s fish', N'Karen', N'Payne', 7, 1)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (7, N'Best tax preparers', N'Hank', N'Smith', 7, 3)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (8, N'ABC', N'Jill', N'Payne', 7, 1)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (9, N'Waters LLC', N'Karla', N'Nicolas', 11, 1)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (12, N'Rodriguez and Sons', N'Ervin', N'Zemlak', 11, 2)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (13, N'Maggio, Maggio and Heller', N'Lorene', N'Roberts', 6, 2)
INSERT [dbo].[Customer] ([Identifier], [CompanyName], [ContactFirstName], [ContactLastName], [ContactTypeIdentifier], [GenderIdentifier]) VALUES (14, N'Ankunding, Goodwin and Mayer', N'Joe', N'Date', 7, 2)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Genders] ON 

INSERT [dbo].[Genders] ([id], [GenderType]) VALUES (1, N'Female')
INSERT [dbo].[Genders] ([id], [GenderType]) VALUES (2, N'Male')
INSERT [dbo].[Genders] ([id], [GenderType]) VALUES (3, N'Other')
SET IDENTITY_INSERT [dbo].[Genders] OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_ContactTypes] FOREIGN KEY([ContactTypeIdentifier])
REFERENCES [dbo].[ContactTypes] ([Identifier])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_ContactTypes]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Genders] FOREIGN KEY([GenderIdentifier])
REFERENCES [dbo].[Genders] ([id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Genders]
GO
USE [master]
GO
ALTER DATABASE [CustomerDatabase1] SET  READ_WRITE 
GO

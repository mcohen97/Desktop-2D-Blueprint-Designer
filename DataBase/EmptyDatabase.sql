USE [master]
GO
/****** Object:  Database [BlueBuilderDB]    Script Date: 6/20/2018 3:29:23 PM ******/
CREATE DATABASE [BlueBuilderDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlueBuilderDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER_R14\MSSQL\DATA\BlueBuilderDB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BlueBuilderDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER_R14\MSSQL\DATA\BlueBuilderDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BlueBuilderDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlueBuilderDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlueBuilderDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BlueBuilderDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlueBuilderDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlueBuilderDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BlueBuilderDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlueBuilderDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BlueBuilderDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlueBuilderDB] SET  MULTI_USER 
GO
ALTER DATABASE [BlueBuilderDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlueBuilderDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlueBuilderDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlueBuilderDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BlueBuilderDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BlueBuilderDB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/20/2018 3:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BlueprintEntities]    Script Date: 6/20/2018 3:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BlueprintEntities](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Length] [int] NOT NULL,
	[Width] [int] NOT NULL,
	[Owner_UserName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.BlueprintEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ColumnEntities]    Script Date: 6/20/2018 3:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColumnEntities](
	[Id] [uniqueidentifier] NOT NULL,
	[Width] [real] NOT NULL,
	[Length] [real] NOT NULL,
	[Height] [real] NOT NULL,
	[CoordX] [real] NOT NULL,
	[CoordY] [real] NOT NULL,
	[BearerBlueprint_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.ColumnEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CostPriceEntities]    Script Date: 6/20/2018 3:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostPriceEntities](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[Price] [real] NOT NULL,
	[Cost] [real] NOT NULL,
	[ComponentType] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CostPriceEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OpeningEntities]    Script Date: 6/20/2018 3:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpeningEntities](
	[Id] [uniqueidentifier] NOT NULL,
	[CoordX] [real] NOT NULL,
	[CoordY] [real] NOT NULL,
	[BearerBlueprint_Id] [uniqueidentifier] NOT NULL,
	[Template_Name] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.OpeningEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OpeningTemplateEntities]    Script Date: 6/20/2018 3:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpeningTemplateEntities](
	[Name] [nvarchar](128) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[Height] [real] NOT NULL,
	[Length] [real] NOT NULL,
	[HeightAboveFloor] [real] NOT NULL,
	[ComponentType] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OpeningTemplateEntities] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SignatureEntities]    Script Date: 6/20/2018 3:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SignatureEntities](
	[Id] [uniqueidentifier] NOT NULL,
	[SignerName] [nvarchar](max) NULL,
	[SignerSurname] [nvarchar](max) NULL,
	[SignerUserName] [nvarchar](max) NULL,
	[SignatureDate] [datetime2](7) NOT NULL,
	[BlueprintSigned_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.SignatureEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserEntities]    Script Date: 6/20/2018 3:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserEntities](
	[UserName] [varchar](100) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[RegistrationDate] [datetime2](7) NOT NULL,
	[LastLoginDate] [datetime2](7) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[IdCard] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.UserEntities] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WallEntities]    Script Date: 6/20/2018 3:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WallEntities](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[Height] [real] NOT NULL,
	[Width] [real] NOT NULL,
	[BeginningX] [real] NOT NULL,
	[BeginningY] [real] NOT NULL,
	[EndX] [real] NOT NULL,
	[EndY] [real] NOT NULL,
	[BearerBlueprint_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.WallEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Id]    Script Date: 6/20/2018 3:29:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Id] ON [dbo].[BlueprintEntities]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Owner_UserName]    Script Date: 6/20/2018 3:29:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Owner_UserName] ON [dbo].[BlueprintEntities]
(
	[Owner_UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BearerBlueprint_Id]    Script Date: 6/20/2018 3:29:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_BearerBlueprint_Id] ON [dbo].[ColumnEntities]
(
	[BearerBlueprint_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BearerBlueprint_Id]    Script Date: 6/20/2018 3:29:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_BearerBlueprint_Id] ON [dbo].[OpeningEntities]
(
	[BearerBlueprint_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Template_Name]    Script Date: 6/20/2018 3:29:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Template_Name] ON [dbo].[OpeningEntities]
(
	[Template_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Name]    Script Date: 6/20/2018 3:29:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name] ON [dbo].[OpeningTemplateEntities]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlueprintSigned_Id]    Script Date: 6/20/2018 3:29:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_BlueprintSigned_Id] ON [dbo].[SignatureEntities]
(
	[BlueprintSigned_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Id]    Script Date: 6/20/2018 3:29:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Id] ON [dbo].[SignatureEntities]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserName]    Script Date: 6/20/2018 3:29:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[UserEntities]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BearerBlueprint_Id]    Script Date: 6/20/2018 3:29:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_BearerBlueprint_Id] ON [dbo].[WallEntities]
(
	[BearerBlueprint_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ColumnEntities] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[OpeningEntities] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[BlueprintEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlueprintEntities_dbo.UserEntities_Owner_UserName] FOREIGN KEY([Owner_UserName])
REFERENCES [dbo].[UserEntities] ([UserName])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlueprintEntities] CHECK CONSTRAINT [FK_dbo.BlueprintEntities_dbo.UserEntities_Owner_UserName]
GO
ALTER TABLE [dbo].[ColumnEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ColumnEntities_dbo.BlueprintEntities_BearerBlueprint_Id] FOREIGN KEY([BearerBlueprint_Id])
REFERENCES [dbo].[BlueprintEntities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ColumnEntities] CHECK CONSTRAINT [FK_dbo.ColumnEntities_dbo.BlueprintEntities_BearerBlueprint_Id]
GO
ALTER TABLE [dbo].[OpeningEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OpeningEntities_dbo.BlueprintEntities_BearerBlueprint_Id] FOREIGN KEY([BearerBlueprint_Id])
REFERENCES [dbo].[BlueprintEntities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OpeningEntities] CHECK CONSTRAINT [FK_dbo.OpeningEntities_dbo.BlueprintEntities_BearerBlueprint_Id]
GO
ALTER TABLE [dbo].[OpeningEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OpeningEntities_dbo.OpeningTemplateEntities_Template_Name] FOREIGN KEY([Template_Name])
REFERENCES [dbo].[OpeningTemplateEntities] ([Name])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OpeningEntities] CHECK CONSTRAINT [FK_dbo.OpeningEntities_dbo.OpeningTemplateEntities_Template_Name]
GO
ALTER TABLE [dbo].[SignatureEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SignatureEntities_dbo.BlueprintEntities_BlueprintSigned_Id] FOREIGN KEY([BlueprintSigned_Id])
REFERENCES [dbo].[BlueprintEntities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SignatureEntities] CHECK CONSTRAINT [FK_dbo.SignatureEntities_dbo.BlueprintEntities_BlueprintSigned_Id]
GO
ALTER TABLE [dbo].[WallEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WallEntities_dbo.BlueprintEntities_BearerBlueprint_Id] FOREIGN KEY([BearerBlueprint_Id])
REFERENCES [dbo].[BlueprintEntities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WallEntities] CHECK CONSTRAINT [FK_dbo.WallEntities_dbo.BlueprintEntities_BearerBlueprint_Id]
GO
USE [master]
GO
ALTER DATABASE [BlueBuilderDB] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [na_green]    Script Date: 09-04-2015 20:08:16 ******/
CREATE DATABASE [na_green]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'na_green', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\na_green.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'na_green_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\na_green_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [na_green] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [na_green].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [na_green] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [na_green] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [na_green] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [na_green] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [na_green] SET ARITHABORT OFF 
GO
ALTER DATABASE [na_green] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [na_green] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [na_green] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [na_green] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [na_green] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [na_green] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [na_green] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [na_green] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [na_green] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [na_green] SET  DISABLE_BROKER 
GO
ALTER DATABASE [na_green] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [na_green] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [na_green] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [na_green] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [na_green] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [na_green] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [na_green] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [na_green] SET RECOVERY FULL 
GO
ALTER DATABASE [na_green] SET  MULTI_USER 
GO
ALTER DATABASE [na_green] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [na_green] SET DB_CHAINING OFF 
GO
ALTER DATABASE [na_green] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [na_green] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [na_green] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'na_green', N'ON'
GO
USE [na_green]
GO
/****** Object:  Table [dbo].[Game_Round]    Script Date: 09-04-2015 20:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game_Round](
	[RoundId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Stake] [bigint] NOT NULL,
	[Win] [bigint] NULL,
	[BalanceChange] [bigint] NULL,
	[ReferenceId] [nvarchar](50) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Game_Round] PRIMARY KEY CLUSTERED 
(
	[RoundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transaction_Types]    Script Date: 09-04-2015 20:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transaction_Types](
	[TransactionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Transaction_Types] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 09-04-2015 20:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [bigint] IDENTITY(1,1) NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[CDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[RoundId] [bigint] NOT NULL,
	[BalanceChange] [bigint] NOT NULL,
	[ReferenceId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 09-04-2015 20:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Balance] [bigint] NOT NULL,
	[Currency] [char](3) NOT NULL,
	[CDate] [datetime] NOT NULL,
	[LastLogin] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Game_Round]  WITH CHECK ADD  CONSTRAINT [FK_Game_Round_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Game_Round] CHECK CONSTRAINT [FK_Game_Round_Users]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Game_Round] FOREIGN KEY([RoundId])
REFERENCES [dbo].[Game_Round] ([RoundId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Game_Round]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Transaction_Types] FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[Transaction_Types] ([TransactionTypeId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Transaction_Types]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Users]
GO
USE [master]
GO
ALTER DATABASE [na_green] SET  READ_WRITE 
GO

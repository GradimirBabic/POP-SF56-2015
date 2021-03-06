USE [master]
GO
/****** Object:  Database [salonnamestaja]    Script Date: 10.1.2018. 22.01.07 ******/
CREATE DATABASE [salonnamestaja]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'salonnamestaja', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\salonnamestaja.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'salonnamestaja_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\salonnamestaja_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [salonnamestaja] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [salonnamestaja].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [salonnamestaja] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [salonnamestaja] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [salonnamestaja] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [salonnamestaja] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [salonnamestaja] SET ARITHABORT OFF 
GO
ALTER DATABASE [salonnamestaja] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [salonnamestaja] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [salonnamestaja] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [salonnamestaja] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [salonnamestaja] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [salonnamestaja] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [salonnamestaja] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [salonnamestaja] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [salonnamestaja] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [salonnamestaja] SET  DISABLE_BROKER 
GO
ALTER DATABASE [salonnamestaja] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [salonnamestaja] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [salonnamestaja] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [salonnamestaja] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [salonnamestaja] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [salonnamestaja] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [salonnamestaja] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [salonnamestaja] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [salonnamestaja] SET  MULTI_USER 
GO
ALTER DATABASE [salonnamestaja] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [salonnamestaja] SET DB_CHAINING OFF 
GO
ALTER DATABASE [salonnamestaja] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [salonnamestaja] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [salonnamestaja] SET DELAYED_DURABILITY = DISABLED 
GO
USE [salonnamestaja]
GO
/****** Object:  Table [dbo].[Namestaj]    Script Date: 10.1.2018. 22.01.07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Namestaj](
	[id] [int] NOT NULL,
	[naziv] [nvarchar](50) NOT NULL,
	[idTipaNamestaja] [int] NOT NULL,
	[sifra] [nvarchar](50) NULL,
	[cena] [real] NULL,
	[kolicinaUMagacinu] [int] NULL,
	[obrisan] [bit] NULL,
 CONSTRAINT [PK_Namestaj] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prodaja]    Script Date: 10.1.2018. 22.01.07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prodaja](
	[id] [int] NOT NULL,
	[idNamestaja] [int] NOT NULL,
	[kolicina] [int] NULL,
	[datumProdaje] [datetime] NULL,
	[kupac] [nvarchar](50) NULL,
	[brojRacuna] [nvarchar](50) NULL,
	[ukupnaCena] [real] NULL,
	[obrisan] [bit] NULL,
 CONSTRAINT [PK_Prodaja] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipNamestaja]    Script Date: 10.1.2018. 22.01.07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipNamestaja](
	[id] [int] NOT NULL,
	[naziv] [nvarchar](50) NULL,
	[obrisan] [bit] NULL,
 CONSTRAINT [PK_TipNamestaja] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Namestaj]  WITH CHECK ADD  CONSTRAINT [FK_Namestaj_TipNamestaja] FOREIGN KEY([idTipaNamestaja])
REFERENCES [dbo].[TipNamestaja] ([id])
GO
ALTER TABLE [dbo].[Namestaj] CHECK CONSTRAINT [FK_Namestaj_TipNamestaja]
GO
ALTER TABLE [dbo].[Prodaja]  WITH CHECK ADD  CONSTRAINT [FK_Prodaja_Namestaj] FOREIGN KEY([idNamestaja])
REFERENCES [dbo].[Namestaj] ([id])
GO
ALTER TABLE [dbo].[Prodaja] CHECK CONSTRAINT [FK_Prodaja_Namestaj]
GO
USE [master]
GO
ALTER DATABASE [salonnamestaja] SET  READ_WRITE 
GO

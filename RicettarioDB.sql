USE [master]
GO
/****** Object:  Database [Ricettario]    Script Date: 12/07/2017 22:07:13 ******/
CREATE DATABASE [Ricettario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ricettario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Ricettario.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Ricettario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Ricettario_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Ricettario] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ricettario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ricettario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ricettario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ricettario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ricettario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ricettario] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ricettario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ricettario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ricettario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ricettario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ricettario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ricettario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ricettario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ricettario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ricettario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ricettario] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ricettario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ricettario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ricettario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ricettario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ricettario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ricettario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ricettario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ricettario] SET RECOVERY FULL 
GO
ALTER DATABASE [Ricettario] SET  MULTI_USER 
GO
ALTER DATABASE [Ricettario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ricettario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ricettario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ricettario] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Ricettario] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Ricettario]
GO
/****** Object:  Table [dbo].[Alternativo]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alternativo](
	[AltIdIngrediente] [int] NOT NULL,
	[idIngrediente] [int] NOT NULL,
 CONSTRAINT [IDalternativo] PRIMARY KEY CLUSTERED 
(
	[AltIdIngrediente] ASC,
	[idIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Assemblaggio]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assemblaggio](
	[idRicetta] [int] NOT NULL,
	[idMenù] [int] NOT NULL,
 CONSTRAINT [IDassemblaggio] PRIMARY KEY CLUSTERED 
(
	[idMenù] ASC,
	[idRicetta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Caratteristica]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Caratteristica](
	[idCaratteristica] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](20) NOT NULL,
	[Descrizione] [text] NOT NULL,
 CONSTRAINT [IDSpecifica_ID] PRIMARY KEY CLUSTERED 
(
	[idCaratteristica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Caratterizzante]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caratterizzante](
	[idIngrediente] [int] NOT NULL,
	[idCaratteristica] [int] NOT NULL,
 CONSTRAINT [IDcaratterizzante] PRIMARY KEY CLUSTERED 
(
	[idCaratteristica] ASC,
	[idIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[Nome] [varchar](50) NOT NULL,
	[Descrizione] [text] NOT NULL,
 CONSTRAINT [IDCategoria] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Consumo]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Consumo](
	[idIngrediente] [int] NOT NULL,
	[NomeUDM] [varchar](20) NOT NULL,
	[idRicetta] [int] NOT NULL,
	[idRicettaStrum] [int] NOT NULL,
	[NomeStep] [varchar](100) NOT NULL,
	[Quantità] [int] NOT NULL,
 CONSTRAINT [IDconsumo] PRIMARY KEY CLUSTERED 
(
	[idRicetta] ASC,
	[idRicettaStrum] ASC,
	[NomeStep] ASC,
	[idIngrediente] ASC,
	[NomeUDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Definito]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Definito](
	[idRicetta] [int] NOT NULL,
	[idRicettaStrum] [int] NOT NULL,
	[idCaratteristica] [int] NOT NULL,
 CONSTRAINT [IDDefinito] PRIMARY KEY CLUSTERED 
(
	[idCaratteristica] ASC,
	[idRicetta] ASC,
	[idRicettaStrum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingrediente](
	[idIngrediente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[NomeCat] [varchar](50) NOT NULL,
 CONSTRAINT [IDIngrediente_ID] PRIMARY KEY CLUSTERED 
(
	[idIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IngrUDM]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IngrUDM](
	[idIngrediente] [int] NOT NULL,
	[NomeUDM] [varchar](20) NOT NULL,
	[kcalPerUnità] [real] NOT NULL,
 CONSTRAINT [IDIngrUDM] PRIMARY KEY CLUSTERED 
(
	[idIngrediente] ASC,
	[NomeUDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menù]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menù](
	[Nome] [varchar](100) NOT NULL,
	[Tipo] [varchar](100) NOT NULL,
	[idMenù] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [IDMenù_ID] PRIMARY KEY CLUSTERED 
(
	[idMenù] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Portata]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Portata](
	[Nome] [varchar](20) NOT NULL,
 CONSTRAINT [IDPortata] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Presenta]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Presenta](
	[idRicetta] [int] NOT NULL,
	[idRicettaStrum] [int] NOT NULL,
	[idIngrediente] [int] NOT NULL,
	[NomeUDM] [varchar](20) NOT NULL,
	[Quantità] [int] NOT NULL,
 CONSTRAINT [PK_Presenta] PRIMARY KEY CLUSTERED 
(
	[idRicetta] ASC,
	[idRicettaStrum] ASC,
	[idIngrediente] ASC,
	[NomeUDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ricetta]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ricetta](
	[idRicetta] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descrizione] [text] NOT NULL,
	[Immagine] [varchar](400) NOT NULL,
	[TCottura] [int] NOT NULL,
	[TPreparazione] [int] NOT NULL,
	[Difficoltà] [int] NOT NULL,
	[Persone] [int] NOT NULL,
	[portata] [varchar](20) NOT NULL,
 CONSTRAINT [IDRicetta_ID] PRIMARY KEY CLUSTERED 
(
	[idRicetta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RicettaStrumento]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RicettaStrumento](
	[idRicetta] [int] NOT NULL,
	[Kcal] [int] NOT NULL,
	[idRicettaStrum] [int] NOT NULL,
 CONSTRAINT [IDRicettaStrumento_ID] PRIMARY KEY CLUSTERED 
(
	[idRicetta] ASC,
	[idRicettaStrum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Step]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Step](
	[idRicetta] [int] NOT NULL,
	[idRicettaStrum] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descrizione] [text] NOT NULL,
	[Immagine] [varchar](400) NOT NULL,
	[NumOrdine] [int] NOT NULL,
 CONSTRAINT [IDStep_ID] PRIMARY KEY CLUSTERED 
(
	[idRicetta] ASC,
	[idRicettaStrum] ASC,
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Strumento]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Strumento](
	[Immagine] [varchar](200) NOT NULL,
	[Nome] [varchar](20) NOT NULL,
	[Descrizione] [text] NOT NULL,
	[TipoElettrodom] [varchar](20) NULL,
	[Tipo] [varchar](20) NOT NULL,
	[Potenza] [int] NULL,
	[Prezzo] [int] NOT NULL,
	[idStrumento] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [IDStrumento] PRIMARY KEY CLUSTERED 
(
	[idStrumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UnitàDiMisura]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UnitàDiMisura](
	[Nome] [varchar](20) NOT NULL,
 CONSTRAINT [IDUnitàDiMisura] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Uso]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Uso](
	[idStrumento] [int] NOT NULL,
	[idRicetta] [int] NOT NULL,
	[idRicettaStrum] [int] NOT NULL,
	[NomeStep] [varchar](100) NOT NULL,
 CONSTRAINT [IDuso] PRIMARY KEY CLUSTERED 
(
	[idRicetta] ASC,
	[idRicettaStrum] ASC,
	[NomeStep] ASC,
	[idStrumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Utilizzo]    Script Date: 12/07/2017 22:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizzo](
	[idRicetta] [int] NOT NULL,
	[idRicettaStrum] [int] NOT NULL,
	[idStrumento] [int] NOT NULL,
 CONSTRAINT [IDutilizzo] PRIMARY KEY CLUSTERED 
(
	[idStrumento] ASC,
	[idRicetta] ASC,
	[idRicettaStrum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Alternativo] ([AltIdIngrediente], [idIngrediente]) VALUES (67, 68)
INSERT [dbo].[Alternativo] ([AltIdIngrediente], [idIngrediente]) VALUES (68, 67)
INSERT [dbo].[Alternativo] ([AltIdIngrediente], [idIngrediente]) VALUES (75, 76)
INSERT [dbo].[Alternativo] ([AltIdIngrediente], [idIngrediente]) VALUES (76, 75)
INSERT [dbo].[Alternativo] ([AltIdIngrediente], [idIngrediente]) VALUES (91, 92)
INSERT [dbo].[Alternativo] ([AltIdIngrediente], [idIngrediente]) VALUES (92, 91)
INSERT [dbo].[Alternativo] ([AltIdIngrediente], [idIngrediente]) VALUES (93, 94)
INSERT [dbo].[Alternativo] ([AltIdIngrediente], [idIngrediente]) VALUES (94, 93)
INSERT [dbo].[Alternativo] ([AltIdIngrediente], [idIngrediente]) VALUES (100, 101)
INSERT [dbo].[Alternativo] ([AltIdIngrediente], [idIngrediente]) VALUES (101, 100)
SET IDENTITY_INSERT [dbo].[Caratteristica] ON 

INSERT [dbo].[Caratteristica] ([idCaratteristica], [Nome], [Descrizione]) VALUES (1, N'Vegano', N'Alimenti e ricette senza prodotti animali o derivati')
INSERT [dbo].[Caratteristica] ([idCaratteristica], [Nome], [Descrizione]) VALUES (2, N'Vegetariano', N'Alimenti e ricette senza carne o pesce')
INSERT [dbo].[Caratteristica] ([idCaratteristica], [Nome], [Descrizione]) VALUES (3, N'Gluten Free', N'Alimenti senza glutine')
INSERT [dbo].[Caratteristica] ([idCaratteristica], [Nome], [Descrizione]) VALUES (4, N'Senza lattosio', N'Alimento che non ha il lattosio')
INSERT [dbo].[Caratteristica] ([idCaratteristica], [Nome], [Descrizione]) VALUES (5, N'Senza frutta secca', N'Alimento che non è una frutta secca (arachidi ecc ecc)')
INSERT [dbo].[Caratteristica] ([idCaratteristica], [Nome], [Descrizione]) VALUES (6, N'Nichel free', N'Alimento senza nichele')
INSERT [dbo].[Caratteristica] ([idCaratteristica], [Nome], [Descrizione]) VALUES (8, N'No fava e simili', N'Alimento che non appartiane alla fava o ad elementi simili')
INSERT [dbo].[Caratteristica] ([idCaratteristica], [Nome], [Descrizione]) VALUES (9, N'Fruttariano', N'Alimento che deriva da frutta e derivati')
SET IDENTITY_INSERT [dbo].[Caratteristica] OFF
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (67, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (68, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (71, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (72, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (73, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (74, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (77, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (88, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (90, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (93, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (94, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (95, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (96, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (97, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (98, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (99, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (102, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (103, 1)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (67, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (68, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (71, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (72, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (73, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (74, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (75, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (76, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (77, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (88, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (90, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (91, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (92, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (93, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (94, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (95, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (96, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (97, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (98, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (99, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (102, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (103, 2)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (67, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (68, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (69, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (70, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (73, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (74, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (77, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (78, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (79, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (85, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (86, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (87, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (88, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (89, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (90, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (91, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (92, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (93, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (94, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (95, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (96, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (97, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (98, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (99, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (101, 3)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (67, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (68, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (69, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (70, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (71, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (72, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (73, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (77, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (78, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (79, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (82, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (86, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (87, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (88, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (89, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (90, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (93, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (94, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (95, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (96, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (97, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (98, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (99, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (100, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (101, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (102, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (103, 4)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (67, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (68, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (69, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (70, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (71, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (72, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (73, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (74, 5)
GO
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (75, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (76, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (77, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (78, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (79, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (80, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (81, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (82, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (85, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (86, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (87, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (88, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (89, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (90, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (91, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (92, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (93, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (94, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (95, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (96, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (97, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (98, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (99, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (100, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (101, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (102, 5)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (88, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (89, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (90, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (91, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (92, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (93, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (94, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (95, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (96, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (97, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (98, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (99, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (101, 6)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (67, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (68, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (69, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (70, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (71, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (72, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (73, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (74, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (75, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (76, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (77, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (78, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (79, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (80, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (81, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (83, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (85, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (86, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (87, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (88, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (89, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (90, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (91, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (92, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (93, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (94, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (95, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (96, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (97, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (98, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (99, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (100, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (101, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (102, 8)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (67, 9)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (68, 9)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (73, 9)
INSERT [dbo].[Caratterizzante] ([idIngrediente], [idCaratteristica]) VALUES (98, 9)
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Aceto', N'Prodotto derivato dal vino')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Bevande', N'Prodotto liquido utilizzato per diversi scopi')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Carne', N'Alimenti derivati da carni animali')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Cereali', N'Prodotto derivato dai vari cereali')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Farine', N'Alimenti derivati da frumento')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Frutta', N'Alimenti ad alto conenuto di zuccheri')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Latte e derivati', N'Prodotto derivato dal  latte')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Legumi', N'Prodotto vegetale ricco di proteine')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Lieviti', N'Utilizzati per effettuare la lievitazione')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Olio', N'Prodotto grasso  derivato da origine vegetali')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Pane', N'Prodotto derivato dalla farina')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Pasta', N'Prodotto derivato dalle farine')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Pesce', N'Alimenti derivati da pesce')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Sale', N'Prodotto utilizzato per dare sapore ad altri ingredienti')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Salsa', N'Prodotti derivati da altri prodotti')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Salume', N'Prodotto di origine animale insaccato ')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Spezie', N'Prodotto utilizzato per insaporire varie prodotti')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Uova', N' Prodotto di origine animale ricco di proteine')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Verdura', N'Prodotto essenziale in una dieta equilibrata')
INSERT [dbo].[Categoria] ([Nome], [Descrizione]) VALUES (N'Zucchero', N'Prodotto utilizzato per dolcificare altri prodotti')
SET IDENTITY_INSERT [dbo].[Ingrediente] ON 

INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (67, N'Aceto di vino bianco', N'Aceto')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (68, N'Aceto di mela', N'Aceto')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (69, N'Fettina di bovino', N'Carne')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (70, N'Petto di pollo', N'Carne')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (71, N'Farina di frumento 00', N'Farine')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (72, N'Farina di frumento 0', N'Farine')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (73, N'Orzo', N'Cereali')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (74, N'Mais', N'Cereali')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (75, N'Pasta di semola di grano duro', N'Pasta')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (76, N'Pasta all''uovo', N'Pasta')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (77, N'Riso', N'Cereali')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (78, N'Costina di maiale', N'Carne')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (79, N'Filetto di manzo', N'Carne')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (80, N'Bresaola', N'Salume')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (81, N'Mortadella', N'Salume')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (82, N'Prosciutto crudo magro', N'Salume')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (83, N'Prosciutto cotto', N'Salume')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (84, N'Salame', N'Salume')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (85, N'Acciuga fresca', N'Pesce')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (86, N'Cavedano', N'Pesce')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (87, N'Salmone', N'Pesce')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (88, N'Origano', N'Spezie')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (89, N'Uova di gallina', N'Uova')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (90, N'Lievito di birra', N'Lieviti')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (91, N'Ricotta', N'Latte e derivati')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (92, N'Burro', N'Latte e derivati')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (93, N'Olio di girasole', N'Olio')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (94, N'Olio d''oliva', N'Olio')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (95, N'Vino bianco', N'Bevande')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (96, N'Sale bianco', N'Sale')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (97, N'Pepe nero', N'Spezie')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (98, N'Mela ', N'Frutta')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (99, N'Patata', N'Verdura')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (100, N'Gaunciale', N'Salume')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (101, N'Pancetta', N'Salume')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (102, N'Salsa di pomodoro', N'Salsa')
INSERT [dbo].[Ingrediente] ([idIngrediente], [Nome], [NomeCat]) VALUES (103, N'Fava', N'Legumi')
SET IDENTITY_INSERT [dbo].[Ingrediente] OFF
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (67, N'grammi', 0.04)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (67, N'millilitri', 0.04)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (68, N'grammi', 0.04)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (68, N'millilitri', 0.04)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (69, N'grammi', 2.5)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (70, N'grammi', 1.1)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (71, N'grammi', 3.45)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (72, N'grammi', 3.25)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (73, N'grammi', 3.25)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (74, N'grammi', 3.55)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (75, N'grammi', 3.5)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (76, N'grammi', 3.68)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (77, N'grammi', 3.34)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (78, N'grammi', 2.74)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (79, N'grammi', 1.16)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (80, N'grammi', 2.46)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (81, N'grammi', 4.16)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (82, N'grammi', 1.53)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (83, N'grammi', 4.15)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (84, N'grammi', 4.6)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (85, N'grammi', 0.96)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (86, N'grammi', 0.79)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (87, N'grammi', 1.8)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (88, N'grammi', 3)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (88, N'q.b.', 5)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (89, N'pezzi', 1.28)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (90, N'grammi', 0.56)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (91, N'grammi', 1.46)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (92, N'grammi', 7.58)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (93, N'grammi', 8.99)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (93, N'litri', 920)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (94, N'grammi', 9.01)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (94, N'millilitri', 9.9)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (95, N'litri', 789)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (95, N'millilitri', 7.89)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (96, N'grammi', 0)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (96, N'q.b.', 0)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (97, N'grammi', 2.51)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (97, N'q.b.', 3)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (98, N'grammi', 0.52)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (98, N'pezzi', 9)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (99, N'grammi', 82)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (99, N'pezzi', 1.5)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (100, N'grammi', 6.55)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (101, N'grammi', 4.58)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (102, N'grammi', 0.029)
INSERT [dbo].[IngrUDM] ([idIngrediente], [NomeUDM], [kcalPerUnità]) VALUES (103, N'grammi', 0.88)
INSERT [dbo].[Portata] ([Nome]) VALUES (N'Antipasto')
INSERT [dbo].[Portata] ([Nome]) VALUES (N'Contorno')
INSERT [dbo].[Portata] ([Nome]) VALUES (N'Dessert')
INSERT [dbo].[Portata] ([Nome]) VALUES (N'Primo')
INSERT [dbo].[Portata] ([Nome]) VALUES (N'Secondo')
SET IDENTITY_INSERT [dbo].[Strumento] ON 

INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Padella', N'Padella', N'Utilizzata per cottura nei fornelli', NULL, N'Recipiente', NULL, 2000, 1)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Bimby', N'Bimby', N'Uno dei migliori robot da cucina', N'Robot da Cucina', N'Elettrodomestico', 400, 100000, 3)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Forno', N'Forno elettrico', N'uno dei qualsiasi forni in commerci', N'Forno', N'Elettrodomestico', 1500, 50000, 8)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Crepiera', N'Piastra', N'utilizzata per cuocere carne e pesce', NULL, N'Recipiente', NULL, 4000, 10)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Frullatore', N'Frullatore ', N'Utilizzato per sbattere le uova', N'Frullatore', N'Elettrodomestico', 400, 10000, 12)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Impastatrice', N'Impastatrice', N'E'' un elettrodomestico utilizzato per impastare vari composti', N'Robot da Cucina', N'Elettrodomestico', 1000, 50000, 13)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Bilancia', N'Bilancia', N'Strumento utilizzato per pesare gli ingredienti', N'Bilancia', N'Utensile', NULL, 500, 15)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Colino', N'Colino', N'Strumento utilizzato per filtrare composti e fluidi', NULL, N'Utensile', NULL, 100, 16)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Coltello', N'Coltello', N'Strumento generico per il taglio di ingredienti', NULL, N'Utensile', NULL, 50, 17)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Cucchiaio', N'Cucchiaio', N'Strumento generico per prendere porzioni di ingredienti', NULL, N'Utensile', NULL, 50, 22)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'cucchiaioDiLegno', N'Cucchiaio di legno', N'Strumento atto al mescolamento di fluidi e composti', NULL, N'Utensile', NULL, 200, 23)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'FornettoPizza', N'Forno per pizza', N'Utilizzato per la cottura di pizze e anche torte', N'Forno', N'Elettrodomestico', 1200, 9000, 24)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'FornoAMicroonde', N'Forno a microonde', N'Utilizzato per la cottura e lo scongelamento di cibi', N'Forno', N'Elettrodomestico', 1000, 20000, 25)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'FrustaDaCucina', N'Frusta', N'Utilizzato per sbattere le uova e amalgamare composti', NULL, N'Utensile', NULL, 500, 26)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Mestolo', N'Mestolo', N'Strumento utilizzato per mescolare e raccogliere comosti semi liquidi', NULL, N'Utensile', NULL, 200, 27)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'PadellaCaldarroste', N'Padella per castagne', N'Recipiente utilizzato per la cottura di castagne', NULL, N'Recipiente', NULL, 1500, 28)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Pelapatate', N'Pelapatate', N'Strumento utilizzato per sbucciare le patate', NULL, N'Utensile', NULL, 200, 29)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Pentola', N'Pentola', N'Recipiente utilizzato per la cottura in acqua dei cibi', NULL, N'Recipiente', NULL, 2500, 30)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'PentolaAPressione', N'Pentola a pressione', N'Recipiente ideale per la cottura rapida e salutare dei cibi', NULL, N'Recipiente', NULL, 3500, 31)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'PinzaDaCucina', N'Pinza', N'Strumento utilizzato per prendere vari tipi di cibi', NULL, N'Utensile', NULL, 500, 32)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Schiaccianoci', N'Schiaccianoci', N'Strumento utilizzato per frantumare noci e simili', NULL, N'Utensile', NULL, 200, 33)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Schiacciapatate', N'Schiacciapatate', N'Strumento utilizzato per frantumare le patate', NULL, N'Utensile', NULL, 800, 34)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Schiumarola', N'Schiumarola', N'Strumento utilizzato in genere per raccogliere e scolare cibi cotti in acqua', NULL, N'Utensile', NULL, 200, 38)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Scodella', N'Scodella', N'Recipiente usato per contenere diversi tipi di cibi e composti', NULL, N'Recipiente', NULL, 200, 39)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Spatola', N'Spatola', N'Strumento utilizzato per girare cibi in padella ', NULL, N'Utensile', NULL, 500, 40)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'TegliaRettangolare', N'Teglia rettangolare', N'Recipiente utilizzato per la cottura in forno', NULL, N'Recipiente', NULL, 1500, 41)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'TegliaTonda', N'Teglia tonda', N'Recipiente utilizzato per la cottura di cibi in forno', NULL, N'Recipiente', NULL, 1500, 42)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Tortiera', N'Tortiera', N'Recipiente utilizzato per la cottura di torte e altre preparazioni', NULL, N'Recipiente', NULL, 1500, 43)
INSERT [dbo].[Strumento] ([Immagine], [Nome], [Descrizione], [TipoElettrodom], [Tipo], [Potenza], [Prezzo], [idStrumento]) VALUES (N'Tritatutto', N'Tritatutto', N'Elettrodomestico utilizzato per triturare e sminuzzare cibi', N'Robot da Cucina', N'Elettrodomestico', 1500, 3000, 45)
SET IDENTITY_INSERT [dbo].[Strumento] OFF
INSERT [dbo].[UnitàDiMisura] ([Nome]) VALUES (N'grammi')
INSERT [dbo].[UnitàDiMisura] ([Nome]) VALUES (N'litri')
INSERT [dbo].[UnitàDiMisura] ([Nome]) VALUES (N'millilitri')
INSERT [dbo].[UnitàDiMisura] ([Nome]) VALUES (N'pezzi')
INSERT [dbo].[UnitàDiMisura] ([Nome]) VALUES (N'q.b.')
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDRicetta_1]    Script Date: 12/07/2017 22:07:13 ******/
ALTER TABLE [dbo].[Ricetta] ADD  CONSTRAINT [IDRicetta_1] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alternativo]  WITH CHECK ADD  CONSTRAINT [FKalt_Ing] FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[Ingrediente] ([idIngrediente])
GO
ALTER TABLE [dbo].[Alternativo] CHECK CONSTRAINT [FKalt_Ing]
GO
ALTER TABLE [dbo].[Alternativo]  WITH CHECK ADD  CONSTRAINT [FKalternativa] FOREIGN KEY([AltIdIngrediente])
REFERENCES [dbo].[Ingrediente] ([idIngrediente])
GO
ALTER TABLE [dbo].[Alternativo] CHECK CONSTRAINT [FKalternativa]
GO
ALTER TABLE [dbo].[Assemblaggio]  WITH CHECK ADD  CONSTRAINT [FKass_Men] FOREIGN KEY([idMenù])
REFERENCES [dbo].[Menù] ([idMenù])
GO
ALTER TABLE [dbo].[Assemblaggio] CHECK CONSTRAINT [FKass_Men]
GO
ALTER TABLE [dbo].[Assemblaggio]  WITH CHECK ADD  CONSTRAINT [FKass_Ric] FOREIGN KEY([idRicetta])
REFERENCES [dbo].[Ricetta] ([idRicetta])
GO
ALTER TABLE [dbo].[Assemblaggio] CHECK CONSTRAINT [FKass_Ric]
GO
ALTER TABLE [dbo].[Caratterizzante]  WITH CHECK ADD  CONSTRAINT [FKcar_Car] FOREIGN KEY([idCaratteristica])
REFERENCES [dbo].[Caratteristica] ([idCaratteristica])
GO
ALTER TABLE [dbo].[Caratterizzante] CHECK CONSTRAINT [FKcar_Car]
GO
ALTER TABLE [dbo].[Caratterizzante]  WITH CHECK ADD  CONSTRAINT [FKcar_Ing] FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[Ingrediente] ([idIngrediente])
GO
ALTER TABLE [dbo].[Caratterizzante] CHECK CONSTRAINT [FKcar_Ing]
GO
ALTER TABLE [dbo].[Consumo]  WITH CHECK ADD  CONSTRAINT [FKcon_Ing] FOREIGN KEY([idIngrediente], [NomeUDM])
REFERENCES [dbo].[IngrUDM] ([idIngrediente], [NomeUDM])
GO
ALTER TABLE [dbo].[Consumo] CHECK CONSTRAINT [FKcon_Ing]
GO
ALTER TABLE [dbo].[Consumo]  WITH CHECK ADD  CONSTRAINT [FKcon_Ste] FOREIGN KEY([idRicetta], [idRicettaStrum], [NomeStep])
REFERENCES [dbo].[Step] ([idRicetta], [idRicettaStrum], [Nome])
GO
ALTER TABLE [dbo].[Consumo] CHECK CONSTRAINT [FKcon_Ste]
GO
ALTER TABLE [dbo].[Definito]  WITH CHECK ADD  CONSTRAINT [FKDef_Car] FOREIGN KEY([idCaratteristica])
REFERENCES [dbo].[Caratteristica] ([idCaratteristica])
GO
ALTER TABLE [dbo].[Definito] CHECK CONSTRAINT [FKDef_Car]
GO
ALTER TABLE [dbo].[Definito]  WITH CHECK ADD  CONSTRAINT [FKDef_Ric] FOREIGN KEY([idRicetta], [idRicettaStrum])
REFERENCES [dbo].[RicettaStrumento] ([idRicetta], [idRicettaStrum])
GO
ALTER TABLE [dbo].[Definito] CHECK CONSTRAINT [FKDef_Ric]
GO
ALTER TABLE [dbo].[Ingrediente]  WITH CHECK ADD  CONSTRAINT [FKappartenenza] FOREIGN KEY([NomeCat])
REFERENCES [dbo].[Categoria] ([Nome])
GO
ALTER TABLE [dbo].[Ingrediente] CHECK CONSTRAINT [FKappartenenza]
GO
ALTER TABLE [dbo].[IngrUDM]  WITH CHECK ADD  CONSTRAINT [FKquantificazione] FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[Ingrediente] ([idIngrediente])
GO
ALTER TABLE [dbo].[IngrUDM] CHECK CONSTRAINT [FKquantificazione]
GO
ALTER TABLE [dbo].[IngrUDM]  WITH CHECK ADD  CONSTRAINT [FKspecificante] FOREIGN KEY([NomeUDM])
REFERENCES [dbo].[UnitàDiMisura] ([Nome])
GO
ALTER TABLE [dbo].[IngrUDM] CHECK CONSTRAINT [FKspecificante]
GO
ALTER TABLE [dbo].[Presenta]  WITH CHECK ADD  CONSTRAINT [FKPre_Ing] FOREIGN KEY([idIngrediente], [NomeUDM])
REFERENCES [dbo].[IngrUDM] ([idIngrediente], [NomeUDM])
GO
ALTER TABLE [dbo].[Presenta] CHECK CONSTRAINT [FKPre_Ing]
GO
ALTER TABLE [dbo].[Presenta]  WITH CHECK ADD  CONSTRAINT [FKPre_Ric] FOREIGN KEY([idRicetta], [idRicettaStrum])
REFERENCES [dbo].[RicettaStrumento] ([idRicetta], [idRicettaStrum])
GO
ALTER TABLE [dbo].[Presenta] CHECK CONSTRAINT [FKPre_Ric]
GO
ALTER TABLE [dbo].[Ricetta]  WITH CHECK ADD  CONSTRAINT [FKè] FOREIGN KEY([portata])
REFERENCES [dbo].[Portata] ([Nome])
GO
ALTER TABLE [dbo].[Ricetta] CHECK CONSTRAINT [FKè]
GO
ALTER TABLE [dbo].[RicettaStrumento]  WITH CHECK ADD  CONSTRAINT [FKcomposizione] FOREIGN KEY([idRicetta])
REFERENCES [dbo].[Ricetta] ([idRicetta])
GO
ALTER TABLE [dbo].[RicettaStrumento] CHECK CONSTRAINT [FKcomposizione]
GO
ALTER TABLE [dbo].[Step]  WITH CHECK ADD  CONSTRAINT [FKinerenza] FOREIGN KEY([idRicetta], [idRicettaStrum])
REFERENCES [dbo].[RicettaStrumento] ([idRicetta], [idRicettaStrum])
GO
ALTER TABLE [dbo].[Step] CHECK CONSTRAINT [FKinerenza]
GO
ALTER TABLE [dbo].[Uso]  WITH CHECK ADD  CONSTRAINT [FKuso_Ste] FOREIGN KEY([idRicetta], [idRicettaStrum], [NomeStep])
REFERENCES [dbo].[Step] ([idRicetta], [idRicettaStrum], [Nome])
GO
ALTER TABLE [dbo].[Uso] CHECK CONSTRAINT [FKuso_Ste]
GO
ALTER TABLE [dbo].[Uso]  WITH CHECK ADD  CONSTRAINT [FKuso_Str] FOREIGN KEY([idStrumento])
REFERENCES [dbo].[Strumento] ([idStrumento])
GO
ALTER TABLE [dbo].[Uso] CHECK CONSTRAINT [FKuso_Str]
GO
ALTER TABLE [dbo].[Utilizzo]  WITH CHECK ADD  CONSTRAINT [FKuti_Ric] FOREIGN KEY([idRicetta], [idRicettaStrum])
REFERENCES [dbo].[RicettaStrumento] ([idRicetta], [idRicettaStrum])
GO
ALTER TABLE [dbo].[Utilizzo] CHECK CONSTRAINT [FKuti_Ric]
GO
ALTER TABLE [dbo].[Utilizzo]  WITH CHECK ADD  CONSTRAINT [FKuti_Str] FOREIGN KEY([idStrumento])
REFERENCES [dbo].[Strumento] ([idStrumento])
GO
ALTER TABLE [dbo].[Utilizzo] CHECK CONSTRAINT [FKuti_Str]
GO
USE [master]
GO
ALTER DATABASE [Ricettario] SET  READ_WRITE 
GO

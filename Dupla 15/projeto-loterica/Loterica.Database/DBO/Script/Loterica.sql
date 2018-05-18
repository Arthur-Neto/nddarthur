USE [LotericaDB]
GO
/****** Object:  Table [dbo].[Aposta]    Script Date: 11/05/2018 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aposta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Data] [datetime] NOT NULL,
	[IdConcurso] [int] NOT NULL,
	[Validade] [datetime] NOT NULL,
	[Valor] [float] NOT NULL,
	[IdBolao] [int] NULL,
	[Tipo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bolao]    Script Date: 11/05/2018 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Concurso]    Script Date: 11/05/2018 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Resultado] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Premio]    Script Date: 11/05/2018 16:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Premio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdConcurso] [int] NOT NULL,
	[PremioQuadra] [float] NULL,
	[PremioQuina] [float] NULL,
	[PremioSena] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aposta]  WITH CHECK ADD  CONSTRAINT [FK_Aposta_Bolao] FOREIGN KEY([IdBolao])
REFERENCES [dbo].[Bolao] ([Id])
GO
ALTER TABLE [dbo].[Aposta] CHECK CONSTRAINT [FK_Aposta_Bolao]
GO
ALTER TABLE [dbo].[Aposta]  WITH CHECK ADD  CONSTRAINT [FK_Aposta_Concurso] FOREIGN KEY([IdConcurso])
REFERENCES [dbo].[Concurso] ([Id])
GO
ALTER TABLE [dbo].[Aposta] CHECK CONSTRAINT [FK_Aposta_Concurso]
GO
ALTER TABLE [dbo].[Premio]  WITH CHECK ADD  CONSTRAINT [FK_Premio_Concurso] FOREIGN KEY([IdConcurso])
REFERENCES [dbo].[Concurso] ([Id])
GO
ALTER TABLE [dbo].[Premio] CHECK CONSTRAINT [FK_Premio_Concurso]
GO

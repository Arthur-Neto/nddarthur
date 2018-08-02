USE [ProvaTDDArthur]
GO
/****** Object:  Table [dbo].[TBAluno]    Script Date: 19/06/2018 19:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBAluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Media] [float] NOT NULL,
	[Idade] [int] NOT NULL,
 CONSTRAINT [PK_TBAluno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBAvaliacao]    Script Date: 19/06/2018 19:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBAvaliacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Assunto] [varchar](50) NOT NULL,
	[Data] [datetime] NOT NULL,
 CONSTRAINT [PK_TBAvaliacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBResultado]    Script Date: 19/06/2018 19:13:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBResultado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nota] [nchar](10) NOT NULL,
	[IdAluno] [int] NOT NULL,
 CONSTRAINT [PK_TBResultado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBResultado_Avaliacao]    Script Date: 19/06/2018 19:13:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBResultado_Avaliacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdResultado] [int] NOT NULL,
	[IdAvaliacao] [int] NOT NULL,
 CONSTRAINT [PK_TBResultado_Avaliacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TBResultado]  WITH CHECK ADD  CONSTRAINT [FK_TBResultado_TBAluno] FOREIGN KEY([IdAluno])
REFERENCES [dbo].[TBResultado] ([Id])
GO
ALTER TABLE [dbo].[TBResultado] CHECK CONSTRAINT [FK_TBResultado_TBAluno]
GO
ALTER TABLE [dbo].[TBResultado_Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_TBResultado_Avaliacao_Avaliacao] FOREIGN KEY([IdAvaliacao])
REFERENCES [dbo].[TBAvaliacao] ([Id])
GO
ALTER TABLE [dbo].[TBResultado_Avaliacao] CHECK CONSTRAINT [FK_TBResultado_Avaliacao_Avaliacao]
GO
ALTER TABLE [dbo].[TBResultado_Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_TBResultado_Avaliacao_Resultado] FOREIGN KEY([IdResultado])
REFERENCES [dbo].[TBResultado] ([Id])
GO
ALTER TABLE [dbo].[TBResultado_Avaliacao] CHECK CONSTRAINT [FK_TBResultado_Avaliacao_Resultado]
GO

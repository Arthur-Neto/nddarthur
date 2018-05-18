CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Titulo] VARCHAR(50) NULL, 
    [Tema] VARCHAR(50) NULL, 
    [Autor] VARCHAR(50) NULL, 
    [Volume] INT NULL, 
    [DataPublicacao] DATE NULL, 
    [Disponibilidade] BIT NULL
)

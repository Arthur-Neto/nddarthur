CREATE TABLE [dbo].[Contato]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Departamento] VARCHAR(50) NOT NULL, 
    [Endereco] VARCHAR(50) NOT NULL, 
    [Telefone] INT NOT NULL
)

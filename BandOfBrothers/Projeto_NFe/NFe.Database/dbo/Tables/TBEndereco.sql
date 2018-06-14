CREATE TABLE [dbo].[TBEndereco]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Bairro] VARCHAR(50) NOT NULL, 
    [Logradouro] VARCHAR(50) NOT NULL, 
    [Municipio] VARCHAR(50) NOT NULL, 
    [Pais] VARCHAR(50) NOT NULL, 
    [Numero] VARCHAR(50) NOT NULL, 
    [Estado] VARCHAR(50) NOT NULL
)

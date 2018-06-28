CREATE TABLE [dbo].[TBMaterias]
(
	[ID] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Nome] NVARCHAR(50) NOT NULL, 
    [SerieID] INT NOT NULL, 
    [DisciplinaID] INT NOT NULL, 
    CONSTRAINT [FK_SerieID] FOREIGN KEY (SerieID) REFERENCES [TBSeries]([ID]), 
    CONSTRAINT [FK_DisciplinaID_materias] FOREIGN KEY ([DisciplinaID]) REFERENCES [TBDisciplinas]([ID])
)

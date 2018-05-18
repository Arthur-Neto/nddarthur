USE DBMariana

INSERT INTO TBSerie (Numero) 
VALUES
(1),(2),(3),(4),(5),(6);

INSERT INTO TBDisciplina (nome) 
VALUES
('Matemática'),('Português'),('Ciências'), ('Geografia'),('História'),('Educação Física'),('Artes');

INSERT INTO TBMateria (IdDisciplina, IdSerie, Nome) 
VALUES
(1,1,'Operações numéricas'),
(2,2,'Categorização gráfica das letras'),
(4,3,'Corpo humano'),(6,4,'O Sistema solar'),
(1,5,'Vestígios do passado'),(1,6,'Futebol');

INSERt INTO TBQuestao (Bimestre,Enunciado,IdDisciplina,IdMateria) 
VALUES 
(1,'Quanto é 2+8-3-5+15=?',1,1),
(1,'Quanto é 2+8=?',1,1),
(1,'Quanto é 5+15=?',1,1),
(1,'Quanto é 15-5=?',1,1),
(1,'Quanto é 2+8-15=?',1,1),
(1,'Quanto é 2+15=?',1,1),
(1,'Quanto é 2+8-3=?',1,1),
(1,'Quanto é 3-15=?',1,1),
(1,'Quanto é 3-10=?',1,1),
(1,'Quanto é 7-5=?',1,1),
(1,'Quanto é 150-45=?',1,1);

INSERT INTO TBResposta (CorpoResposta,Correta,IdQuestao) 
VALUES 
('10',0,1),('16',0,1),('6',0,1),('1',0,1),('17',1,1),
('10',1,2),('16',0,2),('6',0,2),('1',0,2),('0',0,2),
('3',0,3),('20',1,3),('6',0,3),('7',0,3),('3',0,3),
('4',0,4),('10',1,4),('2',0,4),('0',0,4),('0',0,4),
('3',0,5),('16',0,5),('-5',1,5),('17',0,5),('30',0,5),
('3',0,6),('16',0,6),('26',0,6),('17',1,6),('30',0,6),
('3',0,7),('7',1,7),('26',0,7),('17',0,7),('30',0,7),
('12',1,8),('16',0,8),('26',0,8),('17',0,8),('30',0,8),
('3',0,9),('16',0,9),('26',0,9),('7',1,9),('30',0,9),
('3',1,10),('16',0,10),('26',0,10),('17',0,10),('15',0,10),
('3',0,11),('16',0,11),('26',0,11),('17',1,11),('105',1,11);
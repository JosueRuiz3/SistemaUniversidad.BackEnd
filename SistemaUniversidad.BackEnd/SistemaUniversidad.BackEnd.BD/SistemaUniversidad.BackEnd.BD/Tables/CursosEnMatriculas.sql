CREATE TABLE CursosEnMatriculas(
	NumeroMatricula INT,
	CodigoCurso VARCHAR(10) NOT NULL,
	NumeroCiclo INT NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_CursosEnMatriculas PRIMARY KEY(NumeroCiclo, CodigoCurso, NumeroMatricula),
	CONSTRAINT FK_CursosEnMatriculas_NumeroMatriculas FOREIGN KEY(NumeroMatricula) REFERENCES Matriculas(NumeroMatricula),
	CONSTRAINT FK_CursosEnMatriculas_NumeroCiclos FOREIGN KEY(NumeroCiclo) REFERENCES CicloLectivos(NumeroCiclo),
	CONSTRAINT FK_CursosEnMatriculas_CodigoCursos FOREIGN KEY(CodigoCurso) REFERENCES Cursos(CodigoCurso)
)
GO
--Documentación de tabla
EXEC sp_addextendedproperty
	@name = N'MS_Description',	@value = 'Cursos en matrícula que se han registrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
  	@level1type = N'Table',		@level1name = 'CursosEnMatriculas'
GO
----Documentación a campos 
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Número de matrícula que se ha hecho',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnMatriculas', 
   	@level2type = N'Column',	@level2name = 'NumeroMatricula'
GO
----Documentación a campos 
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Código del curso',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnMatriculas', 
   	@level2type = N'Column',	@level2name = 'CodigoCurso'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Número del ciclo lectivo que se va a impartir',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnMatriculas', 
   	@level2type = N'Column',	@level2name = 'NumeroCiclo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnMatriculas', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnMatriculas', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnMatriculas', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnMatriculas', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnMatriculas', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'
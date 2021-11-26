CREATE TABLE CursosConProfesores(  
	CodigoCurso VARCHAR(10) NOT NULL,
	CedulaProfesor VARCHAR(15) NOT NULL,
	NumeroCiclo INT NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_CursosConProfesores PRIMARY KEY(CodigoCurso,CedulaProfesor, NumeroCiclo),
	CONSTRAINT FK_CursosConProfesores_NumeroCiclo FOREIGN KEY(NumeroCiclo) REFERENCES CicloLectivos(NumeroCiclo),
	CONSTRAINT FK_CursosConProfesores_CedulaProfesor FOREIGN KEY(CedulaProfesor) REFERENCES Profesores(CedulaProfesor),
	CONSTRAINT FK_CursosConProfesores_CodigoCurso FOREIGN KEY(CodigoCurso) REFERENCES Cursos(CodigoCurso)
)
GO
--Documentación de tabla
EXEC sp_addextendedproperty
	@name = N'MS_Description',	@value = 'Cursos que se asocian a un profesor para ser inpartido en un aula y en un ciclo lectivo',
   	@level0type = N'Schema',	@level0name = 'dbo',
  	@level1type = N'Table',		@level1name = 'CursosConProfesores'
GO
----Documentación a campos
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Código del curso que se imparte en un aula en un ciclo lectivo',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosConProfesores', 
   	@level2type = N'Column',	@level2name = 'CodigoCurso'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Cédula del profesor que imparte un curso en un ciclo lectivo',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosConProfesores', 
   	@level2type = N'Column',	@level2name = 'CedulaProfesor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Número del ciclo lectivo en el que se imparte un curso en un aula',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosConProfesores', 
   	@level2type = N'Column',	@level2name = 'NumeroCiclo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosConProfesores', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosConProfesores', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosConProfesores', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosConProfesores', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosConProfesores', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'
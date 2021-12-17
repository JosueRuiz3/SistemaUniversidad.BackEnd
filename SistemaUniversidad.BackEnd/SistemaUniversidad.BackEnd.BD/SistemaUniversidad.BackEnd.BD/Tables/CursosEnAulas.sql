CREATE TABLE CursosEnAulas( 
    CodigoCurso VARCHAR(10) NOT NULL,
    NumeroAula VARCHAR(10) NOT NULL,
    NumeroCiclo VARCHAR(10) NOT NULL,
	HorarioInicio VARCHAR (30),
	HorarioFin VARCHAR (30),
	DiaDeLaSemana VARCHAR (30),
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),	
	CONSTRAINT PK_CursosEnAulas PRIMARY KEY(CodigoCurso,NumeroAula,NumeroCiclo,HorarioInicio,HorarioFin,DiaDeLaSemana),
	CONSTRAINT FK_CursosEnAulas_CodigoCursos FOREIGN KEY(CodigoCurso) REFERENCES Cursos(CodigoCurso),
	CONSTRAINT FK_CursosEnAulas_NumeroAulas FOREIGN KEY(NumeroAula) REFERENCES Aulas(NumeroAula),
	CONSTRAINT FK_CurososEnAula_NumeroCiclos FOREIGN KEY(NumeroCiclo) REFERENCES CicloLectivos(NumeroCiclo),
)
GO
--Documentación de tabla
EXEC sp_addextendedproperty
	@name = N'MS_Description',	@value = 'Cursos que se asocian con aulas en un ciclo en específico y un aula en específico',
   	@level0type = N'Schema',	@level0name = 'dbo',
  	@level1type = N'Table',		@level1name = 'CursosEnAulas'
GO
----Documentación a campos
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Código de un curso',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'CodigoCurso'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Número de un aula',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'NumeroAula'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Número del ciclo lectivo',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'NumeroCiclo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Horario de inicio del curso en un aula',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'HorarioInicio'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Horario de fin del curso en un aula',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'HorarioFin'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Día de la semana en que se imparte un curso en un aula',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'DiaDeLaSemana'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'CursosEnAulas', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'
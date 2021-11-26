CREATE TABLE Matriculas( 
	NumeroMatricula INT IDENTITY(1,1),
    NumeroCiclo INT NOT NULL,
	CedulaEstudiante VARCHAR(15) NOT NULL,
	MontoMatricula DECIMAL(18,3) NOT NULL,
	MontoCursos DECIMAL(18,3), --TODO: Por cada curso que se matricule se debe actualizar este campo, para que sume el costo de cada curso
	MontoTotal AS MontoMatricula + MontoCursos, 
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),	
	CONSTRAINT PK_Matriculas PRIMARY KEY(NumeroMatricula),
	CONSTRAINT FK_Matriculas_NumeroCiclos FOREIGN KEY(NumeroCiclo) REFERENCES CicloLectivos(NumeroCiclo),
	CONSTRAINT FK_Matriculas_CedulaEstudiantes FOREIGN KEY(CedulaEstudiante) REFERENCES Estudiantes(CedulaEstudiante)
)
GO
--Documentación de tabla
EXEC sp_addextendedproperty
	@name = N'MS_Description',	@value = 'Matriculas que el sistema de universidad gestiona',
   	@level0type = N'Schema',	@level0name = 'dbo',
  	@level1type = N'Table',		@level1name = 'Matriculas'
GO
----Documentación a campos
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Número de matrícula',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'NumeroMatricula'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Número de ciclo que impartir la universidad',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'NumeroCiclo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Cédula del estudiate que esta matriculando',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'CedulaEstudiante'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Costo de la matrícula',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'MontoMatricula'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Costo de los cursos matriculados',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'MontoCursos'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Campo Calculado: Costo total de la matrícula, incluye costo de matrícula más costo de los cursos matriculados en un ciclo lectivo',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'MontoTotal'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Matriculas', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'
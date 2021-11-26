CREATE TABLE Cursos( 
	CodigoCurso VARCHAR(10) NOT NULL,
	NombreCurso VARCHAR(30) NOT NULL,
	Precio DECIMAL(18,3),
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_Cursos PRIMARY KEY(CodigoCurso)
)
GO
--DOCUMENTACIÓN A TABLA
EXEC sp_addextendedproperty
	@name = N'MS_Description',	@value = 'Cursos que el sistema de la universidad gestiona',
   	@level0type = N'Schema',	@level0name = 'dbo',
  	@level1type = N'Table',		@level1name = 'Cursos'
GO
----DOCUMENTACIÓN A CAMPOS
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Código del curso',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Cursos', 
   	@level2type = N'Column',	@level2name = 'CodigoCurso'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del curso',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Cursos', 
   	@level2type = N'Column',	@level2name = 'NombreCurso'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Precio del curso',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Cursos',
   	@level2type = N'Column',	@level2name = 'Precio'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Cursos', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Cursos', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Cursos', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Cursos', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Cursos', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'
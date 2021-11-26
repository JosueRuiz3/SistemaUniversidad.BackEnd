CREATE TABLE Estudiantes (
	CedulaEstudiante VARCHAR(15) NOT NULL,
	Nombre VARCHAR(30) NOT NULL,
	Apellidos VARCHAR(50) NOT NULL,
	Telefono VARCHAR(12),
	Direccion VARCHAR(50) NOT NULL,
	CorreoElectronico VARCHAR(50) NOT NULL,
	Edad INT NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_Estudiantes PRIMARY KEY(CedulaEstudiante)
)
GO
--Documentación de tabla
EXEC sp_addextendedproperty
	@name = N'MS_Description',	@value = 'Estudiantes que el sistema de universidad gestiona',
   	@level0type = N'Schema',	@level0name = 'dbo',
  	@level1type = N'Table',		@level1name = 'Estudiantes'
GO
----Documentación a campos
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Cédula del estudiante',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'CedulaEstudiante'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del estudiante',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'Nombre'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Apellidos del estudiante',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'Apellidos'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Número de teléfono del estudiante',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'Telefono'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Dirección del estudiante',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'Direccion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Correo electrónico del estudiante',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'CorreoElectronico'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Edad del estudiante',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'Edad'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Estudiantes', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'
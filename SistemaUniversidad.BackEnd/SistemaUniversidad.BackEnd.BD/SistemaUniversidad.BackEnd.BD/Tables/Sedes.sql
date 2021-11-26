CREATE TABLE Sedes(
	CodigoSede INT,
	NombreSede VARCHAR(30) NOT NULL,
	Telefono VARCHAR(12) NOT NULL,
	CorreoElectronico VARCHAR(50) NOT NULL,
	Direccion VARCHAR(50) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_Sedes PRIMARY KEY(CodigoSede)
)
GO
--Documentación de tabla
EXEC sp_addextendedproperty
	@name = N'MS_Description',	@value = 'Sedes que el sistema gestiona',
   	@level0type = N'Schema',	@level0name = 'dbo',
  	@level1type = N'Table',		@level1name = 'Sedes'
GO
----Documentación a campos 
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Código de la sede',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Sedes', 
   	@level2type = N'Column',	@level2name = 'CodigoSede'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre de la sede',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Sedes', 
   	@level2type = N'Column',	@level2name = 'NombreSede'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Teléfono de la sede',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Sedes', 
   	@level2type = N'Column',	@level2name = 'Telefono'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Correo electrónico de la sede',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Sedes', 
   	@level2type = N'Column',	@level2name = 'CorreoElectronico'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Dirección de la sede',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Sedes', 
   	@level2type = N'Column',	@level2name = 'Direccion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Sedes', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Sedes', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Sedes', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Sedes', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Sedes', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'
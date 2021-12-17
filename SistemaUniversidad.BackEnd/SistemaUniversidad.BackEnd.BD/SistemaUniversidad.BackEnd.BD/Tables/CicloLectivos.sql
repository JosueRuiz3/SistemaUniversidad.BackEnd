CREATE TABLE CicloLectivos(
    NumeroCiclo VARCHAR(10) NOT NULL,
    NombreCiclo VARCHAR(30) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
    FechaModificacion DATETIME,
    CreadoPor VARCHAR(60),
    ModificadoPor VARCHAR(60),
    CONSTRAINT PK_CicloLectivos PRIMARY KEY (NumeroCiclo)
)
GO
--Documentación de tabla
EXEC sp_addextendedproperty
    @name = N'MS_Description',    @value = 'Ciclos lectivos que tendrá la universidad',
    @level0type = N'Schema',    @level0name = 'dbo',
    @level1type = N'Table',        @level1name = 'CicloLectivos'
GO
----Documentación a campos
EXEC sp_addextendedproperty 
    @name = N'MS_Description',    @value = 'Número del ciclo lectivo que se imparte en la universidad',
       @level0type = N'Schema',    @level0name = 'dbo',
       @level1type = N'Table',        @level1name = 'CicloLectivos', 
       @level2type = N'Column',    @level2name = 'NumeroCiclo'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',    @value = 'Nombre del ciclo lectivo que imparte la universidad',
       @level0type = N'Schema',    @level0name = 'dbo',
       @level1type = N'Table',        @level1name = 'CicloLectivos', 
       @level2type = N'Column',    @level2name = 'NombreCiclo'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',    @value = 'Fecha en que inicia el ciclo lectivo que imparte la universidad',
       @level0type = N'Schema',    @level0name = 'dbo',
       @level1type = N'Table',        @level1name = 'CicloLectivos', 
       @level2type = N'Column',    @level2name = 'FechaInicio'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',    @value = 'Fecha en que termina el ciclo lectivo que impartre la universidad',
       @level0type = N'Schema',    @level0name = 'dbo',
       @level1type = N'Table',        @level1name = 'CicloLectivos', 
       @level2type = N'Column',    @level2name = 'FechaFin'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',    @value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado',
       @level0type = N'Schema',    @level0name = 'dbo',
       @level1type = N'Table',        @level1name = 'CicloLectivos', 
       @level2type = N'Column',    @level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',    @value = 'Fecha de creación del registro',
       @level0type = N'Schema',    @level0name = 'dbo',
       @level1type = N'Table',        @level1name = 'CicloLectivos', 
       @level2type = N'Column',    @level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',    @value = 'Fecha de modificación del registro',
       @level0type = N'Schema',    @level0name = 'dbo',
       @level1type = N'Table',        @level1name = 'CicloLectivos', 
       @level2type = N'Column',    @level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',    @value = 'Nombre del usuario que crea el registro',
       @level0type = N'Schema',    @level0name = 'dbo',
       @level1type = N'Table',        @level1name = 'CicloLectivos', 
       @level2type = N'Column',    @level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',    @value = 'Nombre del usuario que modifica el registro',
       @level0type = N'Schema',    @level0name = 'dbo',
       @level1type = N'Table',        @level1name = 'CicloLectivos', 
       @level2type = N'Column',    @level2name = 'ModificadoPor'
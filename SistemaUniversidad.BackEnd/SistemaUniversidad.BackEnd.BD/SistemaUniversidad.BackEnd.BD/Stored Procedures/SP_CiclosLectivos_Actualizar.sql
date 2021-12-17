--PROCEDIMIENTO ALMACENADO ACTUALIZAR CICLO LECTIVO
CREATE PROCEDURE SP_CiclosLectivos_Actualizar
    @NumeroCiclo VARCHAR(10),
    @NombreCiclo VARCHAR(30),
    @FechaInicio DATE,
    @FechaFin DATE,
    @Activo BIT,
    @ModificadoPor VARCHAR(60)
    AS
BEGIN

    DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

    UPDATE CicloLectivos 
    SET
        NumeroCiclo = @NumeroCiclo,
        NombreCiclo = @NombreCiclo,
        FechaInicio = @FechaInicio,
        FechaFin = @FechaFin,
        Activo = @Activo,
        FechaModificacion = @FechaModificacion,
        ModificadoPor = @ModificadoPor
    WHERE    
        NumeroCiclo = @NumeroCiclo
END
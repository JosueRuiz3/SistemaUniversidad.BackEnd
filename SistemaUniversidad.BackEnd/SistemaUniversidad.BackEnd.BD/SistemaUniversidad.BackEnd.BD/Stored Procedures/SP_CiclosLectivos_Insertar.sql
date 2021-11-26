--PROCEDIMIENTO ALMACENADO INSERTAR CICLO LECTIVO
CREATE PROCEDURE SP_CiclosLectivos_Insertar
    @NumeroCiclo INT,
    @NombreCiclo VARCHAR(30),
    @FechaInicio DATE,
    @FechaFin DATE,
    @CreadoPor VARCHAR(60)
    AS
BEGIN

    INSERT INTO CicloLectivos(NumeroCiclo, NombreCiclo, FechaInicio,FechaFin, CreadoPor)
    VALUES(@NumeroCiclo, @NombreCiclo, @FechaInicio, @FechaFin, @CreadoPor)
END
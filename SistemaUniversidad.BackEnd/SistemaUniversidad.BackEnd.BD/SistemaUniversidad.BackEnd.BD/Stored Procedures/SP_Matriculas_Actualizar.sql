--PROCEDIMIENTO ALMACENADO ACTUALIZAR MATRICULA
CREATE PROCEDURE SP_Matriculas_Actualizar
	@NumeroMatricula INT,
	@NumeroCiclo INT,
	@MontoMatricula DECIMAL(18,3),
	@CedulaEstudiante VARCHAR(15),
    @CreadoPor VARCHAR(50),
	@ModificadoPor VARCHAR(60)
	AS
BEGIN 

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE Matriculas
	SET
		NumeroCiclo = @NumeroCiclo,
		MontoMatricula = @MontoMatricula, 
		CedulaEstudiante = @CedulaEstudiante,
		CreadoPor = @CreadoPor,
		ModificadoPor = @ModificadoPor
	WHERE
		NumeroMatricula = @NumeroMatricula
END
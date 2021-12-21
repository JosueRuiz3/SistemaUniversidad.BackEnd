--PROCEDIMIENTO ALMACENADO ACTUALIZAR MATRICULA
CREATE PROCEDURE SP_Matriculas_Actualizar
	@NumeroMatricula INT,
	@NumeroCiclo VARCHAR(10),
	@MontoMatricula DECIMAL(18,3),
	@CedulaEstudiante VARCHAR(15),
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
		ModificadoPor = @ModificadoPor
	WHERE
		NumeroMatricula = @NumeroMatricula
END
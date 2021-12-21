--PROCEDIMIENTO ALMACENADO INSERTAR MATRICULA
CREATE PROCEDURE SP_Matriculas_Insertar
	@NumeroCiclo VARCHAR(10),
	@MontoMatricula DECIMAL(18,3), 
	@CedulaEstudiante VARCHAR(20),
    @CreadoPor VARCHAR(50)
	AS
BEGIN

	INSERT INTO Matriculas(NumeroCiclo, MontoMatricula, CedulaEstudiante, CreadoPor )
	VALUES(@NumeroCiclo, @MontoMatricula, @CedulaEstudiante, @CreadoPor)
END
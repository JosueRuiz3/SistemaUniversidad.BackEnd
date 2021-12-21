--PROCEDIMIENTO ALMACENADO INSERTAR CURSOS EN MATRICULAS
CREATE PROCEDURE SP_CursosEnMatriculas_Insertar
	@NumeroMatricula INT,
	@CodigoCurso VARCHAR(10),
	@NumeroCiclo VARCHAR(10),
	@CreadoPor VARCHAR(50)
	AS
BEGIN

	INSERT INTO CursosEnMatriculas(NumeroMatricula, CodigoCurso, NumeroCiclo, CreadoPor )
	VALUES (@NumeroMatricula, @CodigoCurso, @NumeroCiclo, @CreadoPor)
END
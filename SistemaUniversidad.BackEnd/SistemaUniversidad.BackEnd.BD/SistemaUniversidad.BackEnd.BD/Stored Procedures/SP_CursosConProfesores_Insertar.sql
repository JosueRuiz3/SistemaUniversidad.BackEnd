--PROCEDIMIENTO ALMACENADO INSERTAR CURSOS CON PROFESOR
CREATE PROCEDURE SP_CursosConProfesores_Insertar
	@CodigoCurso VARCHAR(10),
	@CedulaProfesor VARCHAR(15),
	@NumeroCiclo INT,
	@CreadoPor VARCHAR(50)
	AS
BEGIN

	INSERT INTO CursosConProfesores(CodigoCurso, CedulaProfesor, NumeroCiclo, CreadoPor)
	VALUES (@CodigoCurso, @CedulaProfesor, @NumeroCiclo, @CreadoPor)
END
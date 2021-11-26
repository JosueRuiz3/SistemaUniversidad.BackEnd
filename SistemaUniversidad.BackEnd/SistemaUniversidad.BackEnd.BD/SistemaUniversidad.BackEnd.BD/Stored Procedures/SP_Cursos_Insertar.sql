--PROCEDIMIENTO ALMACENADO INSERTAR CURSOS
CREATE PROCEDURE SP_Cursos_Insertar
	@CodigoCurso VARCHAR(10),
	@NombreCurso VARCHAR(30),
	@Precio DECIMAL(18,3),
	@CreadoPor VARCHAR(50)
	AS
BEGIN

	INSERT INTO Cursos(CodigoCurso, NombreCurso, Precio, CreadoPor)
	VALUES (@CodigoCurso, @NombreCurso, @Precio, @CreadoPor)
END
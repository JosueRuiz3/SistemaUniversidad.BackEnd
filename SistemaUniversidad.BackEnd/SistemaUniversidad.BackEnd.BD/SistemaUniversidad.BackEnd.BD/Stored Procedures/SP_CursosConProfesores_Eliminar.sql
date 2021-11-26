--PROCEDIMIENTO ALMACENADO ELIMINAR CURSOS CON PROFESOR
CREATE PROCEDURE SP_CursosConProfesores_Eliminar
	@CodigoCurso VARCHAR(15)
	AS
	
	UPDATE CursosConProfesores
	SET
		Activo = 0
	WHERE
		@CodigoCurso = @CodigoCurso
--PROCEDIMIENTO ALMACENADO ELIMINAR CURSOS EN AULAS
CREATE PROCEDURE SP_CursosEnAulas_Eliminar
	@CodigoCurso INT
	AS 
	
	UPDATE CursosEnAulas
	SET
		Activo = 0
	WHERE
		CodigoCurso = @CodigoCurso
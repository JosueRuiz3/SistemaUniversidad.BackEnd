--PROCEDIMIENTO ALMACENADO ELIMINAR CURSOS
CREATE PROCEDURE SP_Cursos_Eliminar
	@CodigoCurso VARCHAR(10)
    AS 
	
	UPDATE Cursos 
	SET
		Activo = 0
	WHERE 
		CodigoCurso = @CodigoCurso
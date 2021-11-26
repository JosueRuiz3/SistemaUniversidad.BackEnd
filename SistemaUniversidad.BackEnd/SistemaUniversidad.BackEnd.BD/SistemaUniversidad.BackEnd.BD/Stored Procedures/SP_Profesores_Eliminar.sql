--PROCEDIMIENTO ALMACENADO ELIMINAR PROFESOR
CREATE PROCEDURE SP_Profesores_Eliminar
	@CedulaProfesor VARCHAR(15) 
	AS 
	
	UPDATE Profesores
	SET
		Activo = 0
	WHERE 
		CedulaProfesor = @CedulaProfesor
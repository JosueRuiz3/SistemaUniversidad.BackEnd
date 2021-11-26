--PROCEDIMIENTO ALMACENADO ELIMINAR ESTUDIANTE
CREATE PROCEDURE SP_Estudiantes_Eliminar
	@CedulaEstudiante VARCHAR(15)
	AS 
	
	UPDATE Estudiantes 
	SET
		Activo = 0
	WHERE
		CedulaEstudiante = @CedulaEstudiante
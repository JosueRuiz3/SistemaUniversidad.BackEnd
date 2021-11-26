--PROCEDIMIENTO ALMACENADO ELIMINAR CURSOS EN MATRICULAS
CREATE PROCEDURE SP_CursosEnMatriculas_Eliminar
	@NumeroMatricula INT 
	AS 
	
	UPDATE CursosEnMatriculas
	SET
		Activo = 0
	WHERE 
		NumeroMatricula = @NumeroMatricula
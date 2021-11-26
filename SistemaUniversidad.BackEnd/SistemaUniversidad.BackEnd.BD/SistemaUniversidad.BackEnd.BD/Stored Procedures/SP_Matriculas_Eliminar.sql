--PROCEDIMIENTO ALMACENADO ELIMINAR MATRICULA
CREATE PROCEDURE SP_Matriculas_Eliminar
	@NumeroMatricula INT
	AS UPDATE Matriculas SET
	Activo = 0
	WHERE NumeroMatricula = @NumeroMatricula
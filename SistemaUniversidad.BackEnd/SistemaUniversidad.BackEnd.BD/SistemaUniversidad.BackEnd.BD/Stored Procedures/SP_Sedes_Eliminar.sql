--PROCEDIMIENTO ALMACENADO ELIMINAR SEDES
CREATE PROCEDURE SP_Sedes_Eliminar
	@CodigoSede INT 
	AS 
	
	UPDATE Sedes 
	SET
		Activo = 0
	WHERE 
		CodigoSede = @CodigoSede
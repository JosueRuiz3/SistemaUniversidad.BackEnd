--PROCEDIMIENTO ALMACENADO ELIMINAR CARRERAS
CREATE PROCEDURE SP_Carreras_Eliminar
	@CodigoCarrera INT 
	AS
	
	UPDATE Carreras 
	SET
		Activo = 0
	WHERE 
		CodigoCarrera = @CodigoCarrera
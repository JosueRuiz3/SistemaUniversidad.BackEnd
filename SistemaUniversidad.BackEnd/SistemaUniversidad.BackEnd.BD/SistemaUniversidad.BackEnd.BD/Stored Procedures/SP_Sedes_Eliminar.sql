﻿--PROCEDIMIENTO ALMACENADO ELIMINAR SEDES
CREATE PROCEDURE SP_Sedes_Eliminar
	@CodigoSede  VARCHAR(10) 
	AS 
	
	UPDATE Sedes 
	SET
		Activo = 0
	WHERE 
		CodigoSede = @CodigoSede
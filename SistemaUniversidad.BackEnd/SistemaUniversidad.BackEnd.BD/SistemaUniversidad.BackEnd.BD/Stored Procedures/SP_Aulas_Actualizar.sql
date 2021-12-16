﻿--PROCEDIMIENTO ALMACENADO ACTUALIZAR AULAS
CREATE PROCEDURE SP_Aulas_Actualizar
	@NumeroAula VARCHAR(10),
	@NombreAula VARCHAR(30),
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
	AS
BEGIN 

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE Aulas
	SET
		NumeroAula = @NumeroAula, 
		NombreAula = @NombreAula,
		Activo = @Activo,
		FechaModificacion = @FechaModificacion,
		ModificadoPor = @ModificadoPor
	WHERE 
		NumeroAula = @NumeroAula
END
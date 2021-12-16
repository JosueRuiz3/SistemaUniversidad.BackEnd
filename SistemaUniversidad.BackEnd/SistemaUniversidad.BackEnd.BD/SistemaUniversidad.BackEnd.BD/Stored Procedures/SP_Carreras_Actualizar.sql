﻿--PROCEDIMIENTO ALMACENADO ACTUALIZAR CARRERAS
CREATE PROCEDURE SP_Carreras_Actualizar
	@CodigoCarrera VARCHAR(10),
	@NombreCarrera VARCHAR(100),
	@Acreditada BIT,
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
	AS
BEGIN 

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE Carreras
	SET
		CodigoCarrera = @CodigoCarrera,
		NombreCarrera = @NombreCarrera,
		Acreditada = @Acreditada,
		Activo = @Activo,
		FechaModificacion = @FechaModificacion,
		ModificadoPor = @ModificadoPor
	WHERE
		CodigoCarrera = @CodigoCarrera
END
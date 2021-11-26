--PROCEDIMIENTO ALMACENADO ACTUALIZAR CARRERAS
CREATE PROCEDURE SP_Carreras_Actualizar
	@CodigoCarrera INT,
	@NombreCarrera VARCHAR(100),
	@Activo BIT,
	@CreadoPor VARCHAR(60),
	@ModificadoPor VARCHAR(60)
	AS
BEGIN 

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE Carreras
	SET
		CodigoCarrera = @CodigoCarrera,
		NombreCarrera = @NombreCarrera,
		Activo = @Activo,
		FechaModificacion = @FechaModificacion,
		CreadoPor  = @CreadoPor ,
		ModificadoPor = @ModificadoPor
	WHERE
		CodigoCarrera = @CodigoCarrera
END
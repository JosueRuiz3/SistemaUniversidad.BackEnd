--PROCEDIMIENTO ALMACENADO ACTUALIZAR SEDE
CREATE PROCEDURE SP_Sedes_Actualizar
	@CodigoSede  VARCHAR(10),
	@NombreSede VARCHAR(30),
	@Telefono VARCHAR(12),
	@CorreoElectronico VARCHAR(50),
	@Direccion VARCHAR(50),
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
	AS
BEGIN 

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE()) 
	
	UPDATE Sedes 
	SET
		CodigoSede = @CodigoSede,
		NombreSede = @NombreSede,
		Telefono = @Telefono,
		CorreoElectronico = @CorreoElectronico,
		Direccion = @Direccion,
		Activo = @Activo,
		FechaModificacion = @FechaModificacion,
		ModificadoPor = @ModificadoPor
	WHERE
		CodigoSede = @CodigoSede
END
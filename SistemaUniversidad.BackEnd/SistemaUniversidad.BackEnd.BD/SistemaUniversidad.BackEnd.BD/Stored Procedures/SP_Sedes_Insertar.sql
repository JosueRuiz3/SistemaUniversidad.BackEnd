--PROCEDIMIENTO ALMACENADO INSERTAR SEDES
CREATE PROCEDURE SP_Sedes_Insertar
	@CodigoSede VARCHAR(10),
	@NombreSede VARCHAR(30),
	@Telefono VARCHAR(12),
	@CorreoElectronico VARCHAR(50),
	@Direccion VARCHAR(50),
	@CreadoPor VARCHAR(50)
	AS
BEGIN

	INSERT INTO Sedes(CodigoSede, NombreSede, Telefono, CorreoElectronico, Direccion, CreadoPor )
	VALUES (@CodigoSede, @NombreSede, @Telefono, @CorreoElectronico, @Direccion, @CreadoPor)
END
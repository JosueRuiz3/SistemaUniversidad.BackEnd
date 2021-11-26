---PROCEDIMIENTO ALMACENADO ACTUALIZAR ESTUDIANTES
CREATE PROCEDURE SP_Estudiantes_Actualizar
    @CedulaEstudiante VARCHAR(15),
	@Nombre VARCHAR(30),
	@Apellidos VARCHAR(50),
	@Telefono VARCHAR (12),
	@Direccion VARCHAR(50),
	@CorreoElectronico VARCHAR(50),
	@Edad INT,
	@CreadoPor VARCHAR(50),
	@ModificadoPor VARCHAR(60)
	AS
BEGIN

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE Estudiantes 
	SET
		Nombre = @Nombre,
		Apellidos=@Apellidos,
		Telefono=@Telefono,
		Direccion=@Direccion,
		CorreoElectronico=@CorreoElectronico,
		Edad=@Edad,
		FechaModificacion = @FechaModificacion,
		CreadoPor = @CreadoPor,
		ModificadoPor = @ModificadoPor
	WHERE 
		CedulaEstudiante = @CedulaEstudiante
END
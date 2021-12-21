---PROCEDIMIENTO ALMACENADO ACTUALIZAR ESTUDIANTES
CREATE PROCEDURE SP_Estudiantes_Actualizar
    @CedulaEstudiante VARCHAR(20),
	@Nombre VARCHAR(30),
	@Apellidos VARCHAR(50),
	@Telefono VARCHAR (15),
	@Direccion VARCHAR(100),
	@CorreoElectronico VARCHAR(50),
	@Edad INT,
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
	AS
BEGIN

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE Estudiantes 
	SET
		CedulaEstudiante = @CedulaEstudiante,
		Nombre = @Nombre,
		Apellidos=@Apellidos,
		Telefono=@Telefono,
		Direccion=@Direccion,
		CorreoElectronico=@CorreoElectronico,
		Edad=@Edad,
		Activo = @Activo,
		FechaModificacion = @FechaModificacion,
		ModificadoPor = @ModificadoPor
	WHERE 
		CedulaEstudiante = @CedulaEstudiante
END
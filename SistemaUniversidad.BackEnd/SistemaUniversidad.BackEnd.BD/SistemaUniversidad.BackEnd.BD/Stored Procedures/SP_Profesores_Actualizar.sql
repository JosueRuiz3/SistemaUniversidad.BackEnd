--PROCEDIMIENTO ALMACENADO ACTUALIZAR PROFESOR 
CREATE PROCEDURE SP_Profesores_Actualizar
    @CedulaProfesor VARCHAR(15),
	@NombreProfesor VARCHAR(30),
	@Apellidos VARCHAR(25),
	@Telefono VARCHAR (12),
	@Profesion VARCHAR(30),
	@CorreoElectronico VARCHAR(50),
	@Edad INT,
	@CreadoPor VARCHAR(50),
	@ModificadoPor VARCHAR(60)
	AS
BEGIN 

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE Profesores
	SET
		NombreProfesor = @NombreProfesor,
		Apellidos=@Apellidos,
		Telefono=@Telefono,
		Profesion=@Profesion,
		CorreoElectronico=@CorreoElectronico,
		Edad=@Edad,
		FechaModificacion = @FechaModificacion,
		CreadoPor = @CreadoPor, 
		ModificadoPor = @ModificadoPor
	WHERE 
		CedulaProfesor = @CedulaProfesor
END
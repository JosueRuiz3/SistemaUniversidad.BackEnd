--PROCEDIMIENTO ALMACENADO INSERTAR PROFESOR
CREATE PROCEDURE SP_Profesores_Insertar
	@CedulaProfesor VARCHAR(15),
	@NombreProfesor VARCHAR(30),
	@Apellidos VARCHAR(25),
	@Telefono VARCHAR (12),
	@Profesion VARCHAR(30),
	@CorreoElectronico VARCHAR(50),
	@Edad INT,
	@CreadoPor VARCHAR(50)
	AS
BEGIN

	INSERT INTO Profesores(CedulaProfesor, NombreProfesor, Apellidos, Telefono, Profesion, CorreoElectronico, Edad, CreadoPor)
	VALUES (@CedulaProfesor, @NombreProfesor, @Apellidos, @Telefono, @Profesion, @CorreoElectronico, @Edad, @CreadoPor)
END
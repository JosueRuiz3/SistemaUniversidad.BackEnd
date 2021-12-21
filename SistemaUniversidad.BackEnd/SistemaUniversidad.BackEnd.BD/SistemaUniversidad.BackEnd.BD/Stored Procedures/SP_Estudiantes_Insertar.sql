--PROCEDIMIENTO ALMACENADO INSERTAR ESTUDIANTE
CREATE PROCEDURE SP_Estudiantes_Insertar
	@CedulaEstudiante VARCHAR(20),
	@Nombre VARCHAR(30),
	@Apellidos VARCHAR(50),
	@Telefono VARCHAR (15),
	@Direccion VARCHAR(100),
	@CorreoElectronico VARCHAR(50),
	@Edad INT,
	@CreadoPor VARCHAR(50)
	AS
BEGIN

	INSERT INTO Estudiantes(CedulaEstudiante, Nombre, Apellidos, Telefono, Direccion, CorreoElectronico, Edad, CreadoPor)
	VALUES (@CedulaEstudiante, @Nombre, @Apellidos, @Telefono, @Direccion, @CorreoElectronico, @Edad, @CreadoPor)
END
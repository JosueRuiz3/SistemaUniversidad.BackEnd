--PROCEDIMIENTO ALMACENADO INSERTAR AULAS
CREATE PROCEDURE SP_Aulas_Insertar
	@NumeroAula VARCHAR(10),
	@NombreAula VARCHAR(30),
	@CreadoPor VARCHAR(50)
	AS
BEGIN

	INSERT INTO Aulas(NumeroAula, NombreAula, CreadoPor)
	VALUES(@NumeroAula, @NombreAula, @CreadoPor)
END
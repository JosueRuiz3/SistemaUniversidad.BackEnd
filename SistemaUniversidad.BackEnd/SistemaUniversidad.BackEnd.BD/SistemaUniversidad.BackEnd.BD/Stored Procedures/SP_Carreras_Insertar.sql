--PROCEDIMIENTO ALMACENADO INSERTAR CARRERAS
CREATE PROCEDURE SP_Carreras_Insertar
	@CodigoCarrera VARCHAR(10),
	@NombreCarrera VARCHAR(100),
	@CreadoPor VARCHAR(50)
	AS
BEGIN

	INSERT INTO Carreras(CodigoCarrera, NombreCarrera, CreadoPor)
	VALUES (@CodigoCarrera, @NombreCarrera, @CreadoPor)
END
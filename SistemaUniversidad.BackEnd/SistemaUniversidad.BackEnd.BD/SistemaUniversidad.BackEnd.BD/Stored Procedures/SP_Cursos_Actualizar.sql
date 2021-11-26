--PROCEDIMIENTO ALMACENADO ACTUALIZAR CURSOS
CREATE PROCEDURE SP_Cursos_Actualizar
	@CodigoCurso VARCHAR(10),
	@NombreCurso VARCHAR(30),
	@Precio DECIMAL(18,3),
	@CreadoPor VARCHAR(50),
	@ModificadoPor VARCHAR(60)
	AS
BEGIN

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE Cursos 
	SET
		NombreCurso = @NombreCurso,
		FechaModificacion = @FechaModificacion,
		Precio  = @Precio,
		CreadoPor = @CreadoPor,
		ModificadoPor = @ModificadoPor
	WHERE 
		CodigoCurso = @CodigoCurso
END
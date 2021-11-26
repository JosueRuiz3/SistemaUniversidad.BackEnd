---PROCEDIMIENTO ALMACENADO ACTUALIZAR CURSOS CON PROFESOR
CREATE PROCEDURE SP_CursosConProfesores_Actualizar
    @CodigoCurso VARCHAR(10),
	@CedulaProfesor VARCHAR(15),
	@NumeroCiclo INT,
	@CreadoPor VARCHAR(50),
	@ModificadoPor VARCHAR(60)
	AS
BEGIN

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE CursosConProfesores 
	SET
		CodigoCurso = @CodigoCurso,
		CedulaProfesor = @CedulaProfesor,
		FechaModificacion = @FechaModificacion,
		NumeroCiclo = @NumeroCiclo,
		CreadoPor = @CreadoPor,
		ModificadoPor = @ModificadoPor
	WHERE 
		CodigoCurso = @CodigoCurso
END
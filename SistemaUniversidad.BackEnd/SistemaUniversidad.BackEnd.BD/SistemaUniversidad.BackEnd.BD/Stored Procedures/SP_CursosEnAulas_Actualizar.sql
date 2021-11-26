--PROCEDIMIENTO ALMACENADO ACTUALIZAR CURSOS EN AULAS
CREATE PROCEDURE SP_CursosEnAulas_Actualizar
	@CodigoCurso VARCHAR(10),
    @NumeroAula VARCHAR(10),
    @NumeroCiclo INT,
	@HorarioInicio VARCHAR (30),
	@HorarioFin VARCHAR (30),
	@DiaDeLaSemana VARCHAR (30),
    @CreadoPor VARCHAR(50),
	@ModificadoPor VARCHAR(60)
	AS
	IF EXISTS (SELECT *FROM CursosEnAulas WHERE NumeroCiclo = @NumeroCiclo and HorarioInicio= @HorarioInicio and HorarioFin=@HorarioFin AND DiaDeLaSemana= @DiaDeLaSemana)
BEGIN 
	PRINT ('Ya existe ese Horario En esa Aula')
	RETURN
	END
BEGIN

	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE CursosEnAulas 
	SET
		CodigoCurso = @CodigoCurso,
		NumeroAula =  @NumeroAula,
		NumeroCiclo = @NumeroCiclo,
		HorarioInicio = @HorarioInicio,
		HorarioFin = @HorarioFin,
		DiaDeLaSemana = @DiaDeLaSemana,
		CreadoPor = @CreadoPor,
		ModificadoPor = @ModificadoPor
	WHERE
		CodigoCurso = @CodigoCurso
    END
BEGIN 
	SELECT *FROM CursosEnAulas WHERE NumeroCiclo = @NumeroCiclo and HorarioInicio= @HorarioInicio AND HorarioFin=@HorarioFin
	END
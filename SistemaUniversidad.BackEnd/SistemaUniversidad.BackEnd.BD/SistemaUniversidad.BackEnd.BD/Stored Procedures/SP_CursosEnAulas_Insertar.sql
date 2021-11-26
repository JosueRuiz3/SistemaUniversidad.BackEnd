--PROCEDIMIENTO ALMACENADO INSERTAR CURSOS EN AULAS
CREATE PROCEDURE SP_CursosEnAulas_Insertar
    @CodigoCurso  VARCHAR(10),
    @NumeroAula VARCHAR(10),
    @NumeroCiclo INT,
	@HorarioInicio VARCHAR (30),
	@HorarioFin VARCHAR (30),
	@DiaDeLaSemana VARCHAR (30),
    @CreadoPor VARCHAR(60) 
	AS
	IF exists (SELECT *FROM CursosEnAulas WHERE NumeroCiclo = @NumeroCiclo AND HorarioInicio= @HorarioInicio and HorarioFin=@HorarioFin and DiaDeLaSemana= @DiaDeLaSemana)
BEGIN 
	PRINT ('Ya existe ese Horario En esa Aula')
	RETURN
	END

BEGIN

	INSERT INTO CursosEnAulas(CodigoCurso, NumeroAula, NumeroCiclo, HorarioInicio, HorarioFin, DiaDeLaSemana, CreadoPor )
	VALUES(@CodigoCurso, @NumeroAula, @NumeroCiclo, @HorarioInicio, @HorarioFin, @DiaDeLaSemana,  @CreadoPor)
END

    BEGIN 
	SELECT *FROM CursosEnAulas WHERE NumeroCiclo = @NumeroCiclo and HorarioInicio= @HorarioInicio and HorarioFin=@HorarioFin
	END
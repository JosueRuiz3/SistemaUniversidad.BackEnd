﻿--PROCEDIMIENTO ALMACENADO ACTUALIZAR CURSOS EN MATRICULAS
CREATE PROCEDURE SP_CursosEnMatriculas_Actualizar
	@NumeroMatricula INT,
	@CodigoCurso VARCHAR(10),
	@NumeroCiclo INT,
	@Activo BIT,
	@CreadoPor VARCHAR(60),
	@ModificadoPor VARCHAR(60)
	AS
BEGIN 
	
	DECLARE @FechaModificacion DATETIME;
    SET @FechaModificacion = (SELECT GETDATE())

	UPDATE CursosEnMatriculas 
	SET
		NumeroMatricula = @NumeroMatricula,
		CodigoCurso = @CodigoCurso,
		NumeroCiclo = @NumeroCiclo,
		Activo = @Activo,
		FechaModificacion = @FechaModificacion,
		CreadoPor  = @CreadoPor ,
		ModificadoPor = @ModificadoPor
	WHERE 
		NumeroMatricula = @NumeroMatricula
END
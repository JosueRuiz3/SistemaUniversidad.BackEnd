﻿--PROCEDIMIENTO ALMACENADO INSERTAR MATRICULA
CREATE PROCEDURE SP_Matriculas_Insertar
	@NumeroCiclo INT,
	@MontoMatricula DECIMAL(18,3), 
	@CedulaEstudiante VARCHAR(15),
    @CreadoPor VARCHAR(50)
	AS
BEGIN

	INSERT INTO Matriculas(NumeroCiclo, MontoMatricula, CedulaEstudiante, CreadoPor )
	VALUES(@NumeroCiclo, @MontoMatricula, @CedulaEstudiante, @CreadoPor)
END
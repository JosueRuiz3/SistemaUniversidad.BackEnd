--FUNCION PARA MOSTRAR REGISTRO POR ID Y MOSTRAR SOLO LOS ACTIVOS
CREATE FUNCTION fn_Matriculas_SeleccionarPorId
(
	@NumeroMatricula INT
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM Matriculas
	WHERE NumeroMatricula = @NumeroMatricula
	AND Activo = 1
--FUNCION PARA MOSTRAR REGISTRO POR ID Y MOSTRAR SOLO LOS ACTIVOS
CREATE FUNCTION fn_CursosEnMatriculas_SeleccionarPorId
(
		@NumeroMatricula INT
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM CursosEnMatriculas
	WHERE NumeroMatricula = @NumeroMatricula
	AND Activo = 1
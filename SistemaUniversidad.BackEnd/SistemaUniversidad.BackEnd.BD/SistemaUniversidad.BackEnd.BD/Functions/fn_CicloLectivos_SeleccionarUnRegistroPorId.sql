--FUNCION PARA MOSTRAR REGISTRO POR ID Y MOSTRAR SOLO LOS ACTIVOS
CREATE FUNCTION fn_CicloLectivos_SeleccionarUnRegistroPorId
(
    @NumeroCiclo INT
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM CicloLectivos
	WHERE NumeroCiclo = @NumeroCiclo
	AND Activo = 1
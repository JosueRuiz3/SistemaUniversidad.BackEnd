--FUNCION PARA MOSTRAR REGISTRO POR ID Y MOSTRAR SOLO LOS ACTIVOS
CREATE FUNCTION fn_Estudiantes_SeleccionarPorId
(
	@CedulaEstudiante VARCHAR(15)
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM Estudiantes
	WHERE CedulaEstudiante = @CedulaEstudiante
	AND Activo = 1
--PROCEDIMIENTO ALMACENADO ELIMINAR CICLO LECTIVO
CREATE PROCEDURE SP_CiclosLectivos_Eliminar
    @NumeroCiclo INT 
    AS UPDATE CicloLectivos SET
    Activo = 0
    WHERE NumeroCiclo = @NumeroCiclo
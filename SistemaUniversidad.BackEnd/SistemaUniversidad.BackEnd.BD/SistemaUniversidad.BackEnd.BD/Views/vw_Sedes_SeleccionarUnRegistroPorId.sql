﻿--VISTA EN DONDE SE MUESTRAN SOLO LOS REGISTROS LLAMADOS POR EL ID QUE SE ENCUENTRAN ACTIVOS EN LA TABLA "SEDES"
CREATE VIEW vw_Sedes_SeleccionarUnRegistroPorId AS SELECT * FROM Sedes WHERE CodigoSede = '27'
and activo =1
--VISTA EN DONDE SE MUESTRA UNA MATRICULA COMPLETA
CREATE  VIEW vw_Matriculas_SeleccionarTodos AS
	SELECT Matri.NumeroMatricula, 
	Matri.NumeroCiclo  AS 'Ciclo',
	Ciclo.NombreCiclo AS 'Ciclo Lectivo',
	Ciclo.FechaInicio AS 'Inico Del Ciclo',
	Ciclo.FechaFin AS 'Fin Del Ciclo',
	Matri.MontoMatricula AS 'Monto Total Matricula',
	Matri.CedulaEstudiante AS 'Cedula Del Estudiante',
	Es.Nombre,
	Es.Apellidos,
	Matri.FechaCreacion AS 'Fecha De Matr�cula'
	FROM Matriculas AS Matri 

	INNER JOIN Estudiantes AS Es ON Matri.CedulaEstudiante  = Es.CedulaEstudiante
	INNER JOIN CicloLectivos AS Ciclo ON Matri.NumeroCiclo  = Ciclo.NumeroCiclo
	INNER JOIN Estudiantes AS Est ON Matri.CedulaEstudiante = Est.CedulaEstudiante
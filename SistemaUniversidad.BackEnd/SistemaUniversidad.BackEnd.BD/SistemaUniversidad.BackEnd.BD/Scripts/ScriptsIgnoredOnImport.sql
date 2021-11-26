
CREATE DATABASE Universidad;
GO

USE Universidad
GO

EXEC SP_Sedes_Insertar
	@CodigoSede = 58, 
	@NombreSede = 'Ca�as',
	@Telefono = '2435-6436', 
	@CorreoElectronico = 'ca�as@una.cr', 
	@Direccion = 'Contiguo al banco',
	@CreadoPor = NULL;
GO

EXEC SP_Sedes_Insertar
	@CodigoSede = 27, 
	@NombreSede = 'Santa Cruz',
	@Telefono = '2685-6321', 
	@CorreoElectronico = 'stacruz@una.cr', 
	@Direccion = 'Contiguo al parque',
	@CreadoPor = NULL;
GO

EXEC SP_Sedes_Actualizar
	@CodigoSede = 58, 
	@NombreSede = 'Cañas',
	@Telefono = '2435-6436', 
	@CorreoElectronico = 'cañas@ulatina.net', 
	@Direccion = 'Contiguo al banco',
	@Activo = 1,
	@CreadoPor = NULL,
	@ModificadoPor = NULL;
GO

EXEC SP_Sedes_Eliminar
	@CodigoSede = 27;
GO

--SELECT PARA VER LA TABLA "SEDES" CON LOS DATOS INGRESADOS
SELECT * FROM Sedes
GO

SELECT * FROM vw_Sedes_SeleccionarActivos
GO

SELECT * FROM vw_Sedes_SeleccionarUnregistroPorId
GO

SELECT * FROM fn_Sedes_SeleccionarPorId(58)
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_Sedes_SeleccionarTodos]()
RETURNS TABLE
AS
RETURN
	SELECT * FROM Sedes A WHERE A.Activo = 1
GO

SELECT * FROM [fn_Sedes_SeleccionarTodos]()
GO

EXEC SP_Carreras_Insertar
	@CodigoCarrera = 111,
	@NombreCarrera = 'Ingeniera en Sistemas',
	@CreadoPor = NULL;
GO

--SELECT PARA VER LA TABLA "CARRERAS" CON LOS DATOS INGRESADOS
SELECT * FROM Carreras
GO

SELECT * FROM vw_Carreras_SeleccionarActivos
GO

SELECT * FROM vw_Carreras_SeleccionarUnregistroPorId
GO

SELECT * FROM fn_Carreras_SeleccionarPorId(255)
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_Carreras_SeleccionarTodos]()
RETURNS TABLE
AS
RETURN
	SELECT * FROM Carreras A WHERE A.Activo = 1
GO

SELECT * FROM [fn_Carreras_SeleccionarTodos]()
GO

EXEC SP_Cursos_Insertar
	@CodigoCurso = 'A4352',	
	@NombreCurso = 'Bases de datos', 
	@Precio = 125000.0,
	@CreadoPor = NULL;
GO

EXEC SP_Cursos_Insertar
	@CodigoCurso = 'B6138',	
	@NombreCurso = 'Programacion III', 
	@Precio = 155000.0,
	@CreadoPor = NULL;
GO

--SELECT PARA VER LA TABLA "CURSOS" CON LOS DATOS INGRESADOS
SELECT * FROM Cursos
GO

SELECT * FROM vw_Cursos_SeleccionarActivos
GO

SELECT * FROM vw_Cursos_SeleccionarUnregistroPorId
GO

SELECT * FROM fn_Cursos_SeleccionarPorId('A4352')
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_Cursos_SeleccionarTodos]()
RETURNS TABLE
AS
RETURN 
	SELECT * FROM Cursos A WHERE A.Activo = 1
GO

SELECT * FROM [fn_Cursos_SeleccionarTodos]()
GO

EXEC SP_Aulas_Insertar
	@NumeroAula = '4_2', 
	@NombreAula = 'Laboratorio',
	@CreadoPor = NULL;
GO

EXEC SP_Aulas_Insertar
	@NumeroAula = '3_2', 
	@NombreAula= 'Laboraotrio 2',
	@CreadoPor = NULL;
GO

--SELECT PARA VER LA TABLA "AULA" CON LOS DATOS INGRESADOS
SELECT * FROM Aulas;
GO

SELECT * FROM vw_Aulas_SeleccionarActivos
GO

SELECT * FROM vw_Aulas_SeleccionarUnregistroPorId
GO

SELECT * FROM fn_Aulas_SeleccionarPorId('3_2')
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_Aulas_SeleccionarTodos]()
RETURNS TABLE
AS
RETURN
	SELECT * FROM Aulas A WHERE A.Activo = 1
GO

SELECT * FROM [fn_Aulas_SeleccionarTodos]()
GO

EXEC SP_Profesores_Insertar
	@CedulaProfesor = '1-0625-0789',
	@NombreProfesor = 'Jirafales',
	@Apellidos = 'Perez Jimenez',
	@Telefono = '5667-8789',
	@Profesion = 'Docente',
	@CorreoElectronico = 'jirafales@gmail.com',
	@Edad = 31, 
	@CreadoPor = NULL;
GO

EXEC SP_Profesores_Insertar
	@CedulaProfesor = '5-8932-5634',
	@NombreProfesor = 'Elba',
	@Apellidos = 'Surero',
	@Telefono = '9812-5409',
	@Profesion = 'Docente',
	@CorreoElectronico = 'surero@gmail.com',
	@Edad = 45, 
	@CreadoPor = NULL;
GO

--SELECT PARA VER LA TABLA "PROFESOR" CON LOS DATOS INGRESADOS
SELECT * FROM Profesores
GO

SELECT * FROM vw_Profesores_SeleccionarActivos
GO

SELECT * FROM vw_Profesores_SeleccionarUnregistroPorId
GO

SELECT * FROM fn_Profesores_SeleccionarPorId('5-8932-5634')
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_Profesores_SeleccionarTodos]()
RETURNS TABLE
AS
RETURN 
	SELECT * FROM Profesores A WHERE A.Activo = 1
GO

SELECT * FROM [fn_Profesores_SeleccionarTodos]()
GO

EXEC SP_Estudiantes_Insertar
	@CedulaEstudiante = '5-09480567', 
	@Nombre = 'Luis',
	@Apellidos = 'Rosales Espinoza',
	@Telefono = '8372-5362', 
	@Direccion = 'Santorini', 
	@CorreoElectronico = 'luis@gmail.com', 
	@Edad = 19, 
	@CreadoPor = NULL;
GO

EXEC SP_Estudiantes_Insertar
	@CedulaEstudiante = '5-0432-0608', 
	@Nombre = 'Josue',
	@Apellidos = 'Ruiz',
	@Telefono = '6406-0470', 
	@Direccion = 'Samara', 
	@CorreoElectronico = 'andyjosue123.jr@gmail.com', 
	@Edad = 21, 
	@CreadoPor = NULL;
GO

--SELECT PARA VER LA TABLA "ESTUDIANTES" CON LOS DATOS INGRESADOS
SELECT * FROM Estudiantes;
GO

SELECT * FROM vw_Estudiantes_SeleccionarActivos
GO

SELECT * FROM vw_Estudiantes_SeleccionarUnregistroPorId
GO

SELECT * FROM fn_Estudiantes_SeleccionarPorId('5-09480567')
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_Estudiantes_SeleccionarPorId]()
RETURNS TABLE
AS
RETURN 
	SELECT * FROM Estudiantes A WHERE A.Activo = 1
GO

SELECT * FROM [fn_Estudiantes_SeleccionarPorId]()
GO

EXEC SP_CiclosLectivos_Insertar
    @NumeroCiclo = 1,
    @NombreCiclo = 'C1A2022',
    @FechaInicio = '2022/1/23',
    @FechaFin = '2022/5/19',
    @CreadoPor = NULL;
GO

EXEC SP_CiclosLectivos_Insertar
    @NumeroCiclo = 2,
    @NombreCiclo = 'BID2023',
    @FechaInicio = '2023/1/23',
    @FechaFin = '2023/5/19',
    @CreadoPor = NULL;
GO

--SELECT PARA VER LA TABLA "CICLO LECTIVO" CON LOS DATOS INGRESADOS
SELECT * FROM CicloLectivos;
GO

SELECT * FROM vw_CicloLectivos_SeleccionarActivos
GO

SELECT * FROM vw_CicloLectivos_SeleccionarUnRegistroPorId
GO

--SE BUSCA UNO POR UNO LOS ID
SELECT * FROM fn_CicloLectivos_SeleccionarUnRegistroPorId(1)
GO

SELECT * FROM fn_CicloLectivos_SeleccionarUnRegistroPorId(2)
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_CicloLectivos_SeleccionarTodos]()
RETURNS TABLE
AS
RETURN
	SELECT * FROM CicloLectivos A WHERE A.Activo = 1
GO

SELECT * FROM [fn_CicloLectivos_SeleccionarTodos]()
GO

EXEC SP_Matriculas_Insertar
	@NumeroCiclo = 1,
	@MontoMatricula = 102000, 
	@CedulaEstudiante = '5-0432-0608',
    @CreadoPor = NULL;
GO

--SELECT PARA VER LA TABLA "MATRICULA" CON LOS DATOS INGRESADOS
SELECT * FROM Matriculas;
GO

SELECT * FROM vw_Matriculas_SeleccionarActivos
GO

SELECT * FROM vw_Matriculas_SeleccionarUnRegistroPorId
GO

SELECT * FROM fn_Matriculas_SeleccionarPorId(1)
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_Matriculas_SeleccionarTodos]()
RETURNS TABLE
AS
RETURN
	SELECT * FROM Matriculas A WHERE A.Activo = 1
GO

SELECT * FROM [fn_Matriculas_SeleccionarTodos]()
GO

SELECT * FROM vw_Matriculas_SeleccionarTodos
GO

--SE PUEDE HACER UN "SELECT" DEL PROCESO ALMACENADO
EXEC ObtenerDatosMatriculaPorId1 1
GO

EXEC SP_CursosEnMatriculas_Insertar
	@NumeroMatricula = 1,
	@NumeroCiclo = 1,
	@CodigoCurso = 'A4352',	
	@CreadoPor = NULL;
GO

--SELECT PARA VER LA TABLA "CURSOS EN MATRICULAS" CON LOS DATOS INGRESADOS
SELECT * FROM CursosEnMatriculas;
GO

SELECT * FROM vw_CursosEnMatriculas_SeleccionarActivos
GO

SELECT * FROM vw_CursosEnMatriculas_SeleccionarUnRegistroPorId
GO

SELECT * FROM fn_CursosEnMatriculas_SeleccionarPorId(1)
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_CursosEnMatriculas_SeleccionarTodos]()
RETURNS TABLE
AS
RETURN 
	SELECT * FROM CursosEnMatriculas A WHERE A.Activo = 1
GO

SELECT * FROM [fn_CursosEnMatriculas_SeleccionarTodos]()
GO

EXEC SP_CursosEnAulas_Insertar
    @CodigoCurso = A4352,
	@NumeroAula = '3_2',
	@NumeroCiclo = 1,
	@HorarioInicio = '10:30am',
	@HorarioFin = '1:20pm',
	@DiaDeLaSemana = Sabado,
    @CreadoPor = NULL;
GO

EXEC SP_CursosEnAulas_Insertar
    @CodigoCurso = A4352,
	@NumeroAula = '3_2',
	@NumeroCiclo = 2,
	@HorarioInicio = '10:30am',
	@HorarioFin = '1:20pm',
	@DiaDeLaSemana = Sabado,
    @CreadoPor = NULL;
GO

--SELECT PARA VER LA TABLA "CURSOS EN AULAS" CON LOS DATOS INGRESADOS
SELECT * FROM CursosEnAulas;
GO

SELECT * FROM vw_CursosEnAulas_SeleccionarActivos
GO

SELECT * FROM vw_CursosEnAulas_SeleccionarUnregistroPorId
GO

SELECT * FROM fn_CursosEnAulas_SeleccionarPorId(1)
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_CursosEnAulas_SeleccionarTodos]()
RETURNS TABLE
AS
RETURN
	SELECT * FROM CursosEnAulas A WHERE A.Activo = 1
GO

SELECT * FROM [fn_CursosEnAulas_SeleccionarTodos]()
GO

EXEC SP_CursosConProfesores_Insertar
	@CodigoCurso = 'B6138',
	@CedulaProfesor = '5-8932-5634',
	@NumeroCiclo = 1,
	@CreadoPor = NULL;
GO

--SELECT PARA VER LA TABLA "CURSOS CON PROFESORES" CON LOS DATOS INGRESADOS
SELECT * FROM CursosConProfesores;
GO

SELECT * FROM vw_CursosConProfesores_SeleccionarActivos
GO

SELECT * FROM vw_CursosConProfesores_SeleccionarUnRegistroPorId
GO

SELECT * FROM fn_CursosConProfesores_SeleccionarPorId('B6138')
GO

--FUNCION PARA MOSTRAR DE LA TABLA TODOS LOS REGISTROS ACTIVOS
CREATE OR ALTER FUNCTION[fn_CursosConProfesores_SeleccionarTodos]()
RETURNS TABLE
AS
RETURN 
	SELECT * FROM CursosConProfesores A WHERE A.Activo = 1
GO

SELECT * FROM [fn_CursosConProfesores_SeleccionarTodos]()
GO

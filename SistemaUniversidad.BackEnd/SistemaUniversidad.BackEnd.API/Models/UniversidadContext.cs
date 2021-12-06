﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SistemaUniversidad.BackEnd.API.Models
{
    public partial class UniversidadContext : DbContext
    {
        public UniversidadContext()
        {
        }

        public UniversidadContext(DbContextOptions<UniversidadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aula> Aulas { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<CicloLectivo> CicloLectivos { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<CursosConProfesore> CursosConProfesores { get; set; }
        public virtual DbSet<CursosEnAula> CursosEnAulas { get; set; }
        public virtual DbSet<CursosEnMatricula> CursosEnMatriculas { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Profesore> Profesores { get; set; }
        public virtual DbSet<Sede> Sedes { get; set; }
        public virtual DbSet<VwAulasSeleccionarActivo> VwAulasSeleccionarActivos { get; set; }
        public virtual DbSet<VwAulasSeleccionarUnRegistroPorId> VwAulasSeleccionarUnRegistroPorIds { get; set; }
        public virtual DbSet<VwCarrerasSeleccionarActivo> VwCarrerasSeleccionarActivos { get; set; }
        public virtual DbSet<VwCarrerasSeleccionarUnRegistroPorId> VwCarrerasSeleccionarUnRegistroPorIds { get; set; }
        public virtual DbSet<VwCicloLectivosSeleccionarActivo> VwCicloLectivosSeleccionarActivos { get; set; }
        public virtual DbSet<VwCicloLectivosSeleccionarUnRegistroPorId> VwCicloLectivosSeleccionarUnRegistroPorIds { get; set; }
        public virtual DbSet<VwCursosConProfesoresSeleccionarActivo> VwCursosConProfesoresSeleccionarActivos { get; set; }
        public virtual DbSet<VwCursosConProfesoresSeleccionarUnRegistroPorId> VwCursosConProfesoresSeleccionarUnRegistroPorIds { get; set; }
        public virtual DbSet<VwCursosEnAulasSeleccionarActivo> VwCursosEnAulasSeleccionarActivos { get; set; }
        public virtual DbSet<VwCursosEnAulasSeleccionarUnRegistroPorId> VwCursosEnAulasSeleccionarUnRegistroPorIds { get; set; }
        public virtual DbSet<VwCursosEnMatriculasSeleccionarActivo> VwCursosEnMatriculasSeleccionarActivos { get; set; }
        public virtual DbSet<VwCursosEnMatriculasSeleccionarUnRegistroPorId> VwCursosEnMatriculasSeleccionarUnRegistroPorIds { get; set; }
        public virtual DbSet<VwCursosSeleccionarActivo> VwCursosSeleccionarActivos { get; set; }
        public virtual DbSet<VwCursosSeleccionarUnRegistroPorId> VwCursosSeleccionarUnRegistroPorIds { get; set; }
        public virtual DbSet<VwEstudiantesSeleccionarActivo> VwEstudiantesSeleccionarActivos { get; set; }
        public virtual DbSet<VwEstudiantesSeleccionarUnRegistroPorId> VwEstudiantesSeleccionarUnRegistroPorIds { get; set; }
        public virtual DbSet<VwMatriculasSeleccionarActivo> VwMatriculasSeleccionarActivos { get; set; }
        public virtual DbSet<VwMatriculasSeleccionarTodo> VwMatriculasSeleccionarTodos { get; set; }
        public virtual DbSet<VwMatriculasSeleccionarUnRegistroPorId> VwMatriculasSeleccionarUnRegistroPorIds { get; set; }
        public virtual DbSet<VwProfesoresSeleccionarActivo> VwProfesoresSeleccionarActivos { get; set; }
        public virtual DbSet<VwProfesoresSeleccionarUnRegistroPorId> VwProfesoresSeleccionarUnRegistroPorIds { get; set; }
        public virtual DbSet<VwSedesSeleccionarActivo> VwSedesSeleccionarActivos { get; set; }
        public virtual DbSet<VwSedesSeleccionarUnRegistroPorId> VwSedesSeleccionarUnRegistroPorIds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.NumeroAula);

                entity.HasComment("Aulas que el sistema de la universidad gestiona");

                entity.Property(e => e.NumeroAula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Número del aula");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.Property(e => e.NombreAula)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Nombre del Aula");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.CodigoCarrera);

                entity.HasComment("Carreras que el sistema de universidad gestiona");

                entity.Property(e => e.CodigoCarrera)
                    .ValueGeneratedNever()
                    .HasComment("Código de la carrera");

                entity.Property(e => e.Acreditada)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra una carrera: 1 = Acreditada; 0 = No Acreditada");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.Property(e => e.NombreCarrera)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nombre de la carrera");
            });

            modelBuilder.Entity<CicloLectivo>(entity =>
            {
                entity.HasKey(e => e.NumeroCiclo);

                entity.HasComment("Ciclos lectivos que tendrá la universidad");

                entity.Property(e => e.NumeroCiclo)
                    .ValueGeneratedNever()
                    .HasComment("Número del ciclo lectivo que se imparte en la universidad");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasComment("Fecha en que termina el ciclo lectivo que impartre la universidad");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasComment("Fecha en que inicia el ciclo lectivo que imparte la universidad");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.Property(e => e.NombreCiclo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Nombre del ciclo lectivo que imparte la universidad");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.CodigoCurso);

                entity.HasComment("Cursos que el sistema de la universidad gestiona");

                entity.Property(e => e.CodigoCurso)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código del curso");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.Property(e => e.NombreCurso)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Nombre del curso");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("Precio del curso");
            });

            modelBuilder.Entity<CursosConProfesore>(entity =>
            {
                entity.HasKey(e => new { e.CodigoCurso, e.CedulaProfesor, e.NumeroCiclo });

                entity.HasComment("Cursos que se asocian a un profesor para ser inpartido en un aula y en un ciclo lectivo");

                entity.Property(e => e.CodigoCurso)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código del curso que se imparte en un aula en un ciclo lectivo");

                entity.Property(e => e.CedulaProfesor)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Cédula del profesor que imparte un curso en un ciclo lectivo");

                entity.Property(e => e.NumeroCiclo).HasComment("Número del ciclo lectivo en el que se imparte un curso en un aula");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.HasOne(d => d.CedulaProfesorNavigation)
                    .WithMany(p => p.CursosConProfesores)
                    .HasForeignKey(d => d.CedulaProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursosConProfesores_CedulaProfesor");

                entity.HasOne(d => d.CodigoCursoNavigation)
                    .WithMany(p => p.CursosConProfesores)
                    .HasForeignKey(d => d.CodigoCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursosConProfesores_CodigoCurso");

                entity.HasOne(d => d.NumeroCicloNavigation)
                    .WithMany(p => p.CursosConProfesores)
                    .HasForeignKey(d => d.NumeroCiclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursosConProfesores_NumeroCiclo");
            });

            modelBuilder.Entity<CursosEnAula>(entity =>
            {
                entity.HasKey(e => new { e.CodigoCurso, e.NumeroAula, e.NumeroCiclo, e.HorarioInicio, e.HorarioFin, e.DiaDeLaSemana });

                entity.HasComment("Cursos que se asocian con aulas en un ciclo en específico y un aula en específico");

                entity.Property(e => e.CodigoCurso)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código de un curso");

                entity.Property(e => e.NumeroAula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Número de un aula");

                entity.Property(e => e.NumeroCiclo).HasComment("Número del ciclo lectivo");

                entity.Property(e => e.HorarioInicio)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Horario de inicio del curso en un aula");

                entity.Property(e => e.HorarioFin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Horario de fin del curso en un aula");

                entity.Property(e => e.DiaDeLaSemana)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Día de la semana en que se imparte un curso en un aula");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.HasOne(d => d.CodigoCursoNavigation)
                    .WithMany(p => p.CursosEnAulas)
                    .HasForeignKey(d => d.CodigoCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursosEnAulas_CodigoCursos");

                entity.HasOne(d => d.NumeroAulaNavigation)
                    .WithMany(p => p.CursosEnAulas)
                    .HasForeignKey(d => d.NumeroAula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursosEnAulas_NumeroAulas");

                entity.HasOne(d => d.NumeroCicloNavigation)
                    .WithMany(p => p.CursosEnAulas)
                    .HasForeignKey(d => d.NumeroCiclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurososEnAula_NumeroCiclos");
            });

            modelBuilder.Entity<CursosEnMatricula>(entity =>
            {
                entity.HasKey(e => new { e.NumeroCiclo, e.CodigoCurso, e.NumeroMatricula });

                entity.HasComment("Cursos en matrícula que se han registrado");

                entity.Property(e => e.NumeroCiclo).HasComment("Número del ciclo lectivo que se va a impartir");

                entity.Property(e => e.CodigoCurso)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Código del curso");

                entity.Property(e => e.NumeroMatricula).HasComment("Número de matrícula que se ha hecho");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.HasOne(d => d.CodigoCursoNavigation)
                    .WithMany(p => p.CursosEnMatriculas)
                    .HasForeignKey(d => d.CodigoCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursosEnMatriculas_CodigoCursos");

                entity.HasOne(d => d.NumeroCicloNavigation)
                    .WithMany(p => p.CursosEnMatriculas)
                    .HasForeignKey(d => d.NumeroCiclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursosEnMatriculas_NumeroCiclos");

                entity.HasOne(d => d.NumeroMatriculaNavigation)
                    .WithMany(p => p.CursosEnMatriculas)
                    .HasForeignKey(d => d.NumeroMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursosEnMatriculas_NumeroMatriculas");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.CedulaEstudiante);

                entity.HasComment("Estudiantes que el sistema de universidad gestiona");

                entity.Property(e => e.CedulaEstudiante)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Cédula del estudiante");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Apellidos del estudiante");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Correo electrónico del estudiante");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Dirección del estudiante");

                entity.Property(e => e.Edad).HasComment("Edad del estudiante");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Nombre del estudiante");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("Número de teléfono del estudiante");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.NumeroMatricula);

                entity.HasComment("Matriculas que el sistema de universidad gestiona");

                entity.Property(e => e.NumeroMatricula).HasComment("Número de matrícula");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.CedulaEstudiante)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Cédula del estudiate que esta matriculando");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.Property(e => e.MontoCursos)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("Costo de los cursos matriculados");

                entity.Property(e => e.MontoMatricula)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("Costo de la matrícula");

                entity.Property(e => e.MontoTotal)
                    .HasColumnType("decimal(19, 3)")
                    .HasComputedColumnSql("([MontoMatricula]+[MontoCursos])", false)
                    .HasComment("Campo Calculado: Costo total de la matrícula, incluye costo de matrícula más costo de los cursos matriculados en un ciclo lectivo");

                entity.Property(e => e.NumeroCiclo).HasComment("Número de ciclo que impartir la universidad");

                entity.HasOne(d => d.CedulaEstudianteNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.CedulaEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matriculas_CedulaEstudiantes");

                entity.HasOne(d => d.NumeroCicloNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.NumeroCiclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matriculas_NumeroCiclos");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.CedulaProfesor)
                    .HasName("PK_Profesor");

                entity.HasComment("Profesores que el sistema de universidad gestiona");

                entity.Property(e => e.CedulaProfesor)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Cédula del profesor");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Apellidos del profesor");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Correo electrónico del profesor");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.Edad).HasComment("Edad");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.Property(e => e.NombreProfesor)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Nombre del profesor");

                entity.Property(e => e.Profesion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Profesión");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("Número de teléfono del profesor");
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.HasKey(e => e.CodigoSede);

                entity.HasComment("Sedes que el sistema gestiona");

                entity.Property(e => e.CodigoSede)
                    .ValueGeneratedNever()
                    .HasComment("Código de la sede");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Condición en la que se encuentra el registro: 1 = Activo; 0 = Inactivo o Borrado");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Correo electrónico de la sede");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que crea el registro");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Dirección de la sede");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Fecha de creación del registro");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de modificación del registro");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario que modifica el registro");

                entity.Property(e => e.NombreSede)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Nombre de la sede");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("Teléfono de la sede");
            });

            modelBuilder.Entity<VwAulasSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Aulas_SeleccionarActivos");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAula)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroAula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwAulasSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Aulas_SeleccionarUnRegistroPorId");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAula)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroAula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCarrerasSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Carreras_SeleccionarActivos");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCarrera)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCarrerasSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Carreras_SeleccionarUnRegistroPorId");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCarrera)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCicloLectivosSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CicloLectivos_SeleccionarActivos");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCiclo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCicloLectivosSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CicloLectivos_SeleccionarUnRegistroPorId");

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCiclo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCursosConProfesoresSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CursosConProfesores_SeleccionarActivos");

                entity.Property(e => e.CedulaProfesor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoCurso)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCursosConProfesoresSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CursosConProfesores_SeleccionarUnRegistroPorId");

                entity.Property(e => e.CedulaProfesor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoCurso)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCursosEnAulasSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CursosEnAulas_SeleccionarActivos");

                entity.Property(e => e.CodigoCurso)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DiaDeLaSemana)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.HorarioFin)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioInicio)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroAula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCursosEnAulasSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CursosEnAulas_SeleccionarUnRegistroPorId");

                entity.Property(e => e.CodigoCurso)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DiaDeLaSemana)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.HorarioFin)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioInicio)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroAula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCursosEnMatriculasSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CursosEnMatriculas_SeleccionarActivos");

                entity.Property(e => e.CodigoCurso)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCursosEnMatriculasSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CursosEnMatriculas_SeleccionarUnRegistroPorId");

                entity.Property(e => e.CodigoCurso)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCursosSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Cursos_SeleccionarActivos");

                entity.Property(e => e.CodigoCurso)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCurso)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<VwCursosSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Cursos_SeleccionarUnRegistroPorId");

                entity.Property(e => e.CodigoCurso)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCurso)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<VwEstudiantesSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Estudiantes_SeleccionarActivos");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaEstudiante)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwEstudiantesSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Estudiantes_SeleccionarUnRegistroPorId");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaEstudiante)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwMatriculasSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Matriculas_SeleccionarActivos");

                entity.Property(e => e.CedulaEstudiante)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.MontoCursos).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.MontoMatricula).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.MontoTotal).HasColumnType("decimal(19, 3)");

                entity.Property(e => e.NumeroMatricula).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwMatriculasSeleccionarTodo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Matriculas_SeleccionarTodos");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaDelEstudiante)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Cedula Del Estudiante");

                entity.Property(e => e.CicloLectivo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Ciclo Lectivo");

                entity.Property(e => e.FechaDeMatrCula)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha De Matr�cula");

                entity.Property(e => e.FinDelCiclo)
                    .HasColumnType("date")
                    .HasColumnName("Fin Del Ciclo");

                entity.Property(e => e.InicoDelCiclo)
                    .HasColumnType("date")
                    .HasColumnName("Inico Del Ciclo");

                entity.Property(e => e.MontoTotalMatricula)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Monto Total Matricula");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwMatriculasSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Matriculas_SeleccionarUnRegistroPorId");

                entity.Property(e => e.CedulaEstudiante)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.MontoCursos).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.MontoMatricula).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.MontoTotal).HasColumnType("decimal(19, 3)");

                entity.Property(e => e.NumeroMatricula).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwProfesoresSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Profesores_SeleccionarActivos");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaProfesor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProfesor)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Profesion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwProfesoresSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Profesores_SeleccionarUnRegistroPorId");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaProfesor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProfesor)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Profesion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwSedesSeleccionarActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Sedes_SeleccionarActivos");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSede)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwSedesSeleccionarUnRegistroPorId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Sedes_SeleccionarUnRegistroPorId");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSede)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.Services;
using SistemaUniversidad.BackEnd.API.UnitOfWork.Interfaces;
using SistemaUniversidad.BackEnd.API.UnitOfWork.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaUniversidad.BackEnd.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaUniversidad.BackEnd.API", Version = "v1" });
            });

            services.AddCors(c =>
            {

                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
                c.AddPolicy("AllowHeaders", options => options.AllowAnyHeader());
                c.AddPolicy("AllowHeaders", options => options.AllowAnyMethod());
            }
            );

            services.AddTransient<IUnitOfWork, UnitOfWorkSqlServer>();
            services.AddTransient<IAulasService, AulaService>();
            services.AddTransient<ISedeService, SedeService>();
            services.AddTransient<ICarreraService, CarreraService>();
            services.AddTransient<ICicloLectivoService, CicloLectivoService>();
            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<ICursosConProfesoreService, CursosConProfesoreService>();
            services.AddTransient<ICursosEnAulaService, CursosEnAulaService>();
            services.AddTransient<ICursosEnMatriculaService, CursosEnMatriculaService>();
            services.AddTransient<IMatriculaService, MatriculaService>();
            services.AddTransient<IEstudianteService, EstudianteService>();
            services.AddTransient<IProfesoresService, ProfesoresService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaUniversidad.BackEnd.API v1"));
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

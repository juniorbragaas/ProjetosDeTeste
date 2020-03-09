
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;
using TGCTE.Entities;
using TGCTE.Repository.Implementation;
using TGCTE.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using TGUsuarios.Repository.Implementation;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using TGTCE.Repository.Implementation;

namespace TGCTE
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<BaseContext>(op => op.UseSqlServer(Configuration["ConnectionString:TGDB"]));

            /*Registrando Repositorios do sistema*/

            services.AddScoped<ICteRepository, CteRepository>();
            services.AddScoped<IHistoricoRepository, HistoricoRepository>();
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IFaturaRepository, FaturaRepository>();
            services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info 
                { 
                    Title = "TG-Envios API", 
                    Version = "V1",
                    Description = "Actions do sistemas de Envios",
                    TermsOfService = "Nenhum",
                    Contact =  new Contact{  Name= "Teste", Email="Teste@email.com", Url="wwww.teste.com" }
                });
                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
                c.InjectStylesheet("../assets/swagger-styles.css");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

using App.Data;
using App.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			Configuration = configuration;
			Env = env;
		}

		public IConfiguration Configuration { get; }
		public IWebHostEnvironment Env { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			if (Env.IsDevelopment())
			{
				// Add InMemoryDataBase for developer
				services.AddDbContext<AppContext>(options =>
				options.UseInMemoryDatabase("Memory"));
			}


			if (Env.IsProduction())
			{
				services.AddDbContext<AppContext>(options =>
				options.UseOracle(Configuration.GetConnectionString("DefaultConnection")));
			}


			services.AddControllersWithViews();

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
				configuration.RootPath = "ClientApp/dist");

			// Register the Swagger services
			//services.AddSwaggerDocument();
			services.AddOpenApiDocument(config =>
				config.Title = "AppServicer");

			services.AddAutoMapperSetup();

			services.ConfigureMediatR();

			// .NET Native DI Abstraction
			services.RegisterServices();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseExceptionHandler("/Error");

			app.UseStaticFiles();

			if (!env.IsDevelopment())
				app.UseSpaStaticFiles();

			// Register the Swagger generator and the Swagger UI middlewares
			app.UseOpenApi();
			app.UseSwaggerUi3();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});


			// To Use Angular FrontEnd
			//app.UseSpa(spa =>
			//{
			//	spa.Options.SourcePath = "ClientApp";

			//	//if (env.IsDevelopment())
			//	//	spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
			//});
		}
	}
}

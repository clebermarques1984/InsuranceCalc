using App.Application.SeguradoCommands;
using App.Application.ApoliceCommands;
using App.Application.Notifications;
using App.Application.Pipelines;
using App.Data.Repository;
using App.Data.UoW;
using App.Domain.Entities;
using App.Domain.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.Web.Extensions
{
	public static class ConfigExtensions
	{
		public static void AddAutoMapperSetup(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(Startup));

			// Registering Mappings automatically only works if the 
			// Automapper Profile classes are in ASP.NET project
			// AutoMapperConfig.RegisterMappings();
		}

		public static void ConfigureMediatR(this IServiceCollection services)
		{
			// Adding MediatR for Domain Commands, Events and Notifications
			services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

			// Domain - Pipelines
			// services.AddScoped<IMediatorHandler, InMemoryBus>();
			services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MeasureTime<,>));
			services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateCommand<,>));

			// Domain - Commands
			// => Clients
			services.AddScoped<IRequestHandler<SeguradoRegisterRequest, Domain.Result>, SeguradoHandler>();
			services.AddScoped<IRequestHandler<SeguradoDeleteRequest, Domain.Result>, SeguradoHandler>();
			services.AddScoped<IRequestHandler<SeguradoUpdateRequest, Domain.Result>, SeguradoHandler>();
			// => Insurance
			services.AddScoped<IRequestHandler<ApoliceRegisterRequest, Domain.Result>, ApoliceHandler>();

			// Domain - Events
			services.AddScoped<INotificationHandler<SeguradoNotification>, SeguradoEventHandler>();
			services.AddScoped<INotificationHandler<ApoliceNotification>, ApoliceEventHandler>();
		}

		public static void RegisterServices(this IServiceCollection services)
		{
			// ASP.NET HttpContext dependency
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			// Application - Services

			// Infra - Data
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<ISeguradoRead, SeguradoRepository>();
			services.AddScoped<IRepository<Segurado>, SeguradoRepository>();
			services.AddScoped<IApoliceRead, ApoliceRepository>();
			services.AddScoped<IRepository<Apolice>, ApoliceRepository>();
		}
	}
}

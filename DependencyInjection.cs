using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurveyBasket.Contracts.Requests;
using SurveyBasket.Data;
using SurveyBasket.Services;
using SurveyBasket.ValidationAttributeFolder;
using System.Reflection;

namespace SurveyBasket
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddControllers();
            service.RegisterServices();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //service.AddOpenApi();
            service.AddSwaggerGen();
            string? ConnectionString =configuration["ConnectionStrings:ConnectionString"];//cs8801
            service.AddDbContext<DatabaseContext>(option => option.UseSqlServer(ConnectionString));
            service.AddScoped<IPollService, PollService>();
            service.RegisterServicies();
            service.AddCors();
            service.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 
            //service.AddScoped<IValidator<PollRequest>, PollCustomValidator>();//validation
            var mapConfig = TypeAdapterConfig.GlobalSettings;

            mapConfig.Scan(Assembly.GetExecutingAssembly());
            service.AddSingleton<IMapper>(new Mapper(mapConfig)); // maping 
           // service.AddIdentity();
            return service;
        }

        static IServiceCollection AddIdentity(this IServiceCollection service)
        {
            service.AddIdentity<ApplicationUser,IdentityRole>().
                AddDefaultTokenProviders().
                AddEntityFrameworkStores<DatabaseContext>();
            return service;
        }
        static IServiceCollection AddCors(this IServiceCollection service)
        {
            service.AddCors(setUpActions => setUpActions.AddPolicy(
                "myPolicy",
                policy => policy.WithOrigins(
                    "https://localhost:7073", "http://localhost:5264"
                    ).AllowAnyHeader().AllowAnyMethod()));
            return service;
        }
        static IServiceCollection RegisterServicies(this IServiceCollection service)
        {
            service.AddMapster();
            return service;
        }
        static IServiceCollection RegisterServices(this IServiceCollection service)
        {
            service.AddScoped<IPollService, PollService>();
            return service;
        }

    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.AppService;
using WebMotors.AppService.Interface;
using WebMotors.AppService.ViewModel;
using WebMotors.Domain;
using WebMotors.Domain.Repository;
using WebMotors.Infra.DataAccess;
using WebMotors.Services;
using System.Net.Http;

namespace WebMotors.Infra.CrossCutting.Middleware
{
    public static class ServiceExtension
    {

        public static void AddAutoMapperMiddleware(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnuncioWebMotorsViewModel, AnuncioWebMotors>();
                cfg.CreateMap<AnuncioWebMotors, AnuncioWebMotorsViewModel> ();

            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
        

        public static void AddIoCMiddleware(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAnuncioWebMotorsAppService, AnuncioWebMotorsAppService>();
            services.AddScoped<IWebMotorsAppService, WebMotorsAppService>();

            services.AddScoped<IAnuncioWebMotorsRepository, AnuncioWebMotorsRepository>();

            services.AddSingleton(new ConnectionConfig(configuration["Endpoint"]));


        }


        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Conexao>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

    }
}

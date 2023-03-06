using Serilog;

namespace Simple.Api.Middlewares
{
    public static class AppBuilder
    {
        /*
         * AppBuilder - Classe responsável por construir a aplicação
         */
        public static WebApplication GetApp(string[] args)
        {
            /*
            * GetApp - Método responsável por retornar a aplicação
            *          com as configurações necessárias
            @param args - Argumentos passados na execução da aplicação
            return WebApplication - Aplicação com as configurações necessárias
            */
            var builder = WebApplication.CreateBuilder(args);

            // Controllers
            builder.Services.AddControllers();
            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new() { Title = "Simple.Api", Version = "v1" });
                }
            );

            // Serilog - Load configuration from appsettings.json
            builder.Host.UseSerilog(
            (hostingContext, loggerConfiguration) =>
                loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

            // Build Infra
            Simple.Infra.InfraStartup.Start(
                services: builder.Services,
                connectionString: builder.Configuration.GetConnectionString("SqlConnectionString") ?? string.Empty
            );

            // Build
            var app = builder.Build();

            return app;
        }
    }
}
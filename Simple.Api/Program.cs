using Serilog;
using Simple.Api.Middlewares;


try
{
    // Criando a instância da aplicação
    var app = AppBuilder.GetApp(args);

    // Configurando a aplicação
    PipelineBuilder.Configure(app);

    // Executando a aplicação
    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.Information("Application is shutting down");
    Log.CloseAndFlush();
}




using Simple.Api.Middlewares;

// Criando a instância da aplicação
var app = AppBuilder.GetApp(args);

// Configurando a aplicação
PipelineBuilder.Configure(app);

// Executando a aplicação
app.Run();

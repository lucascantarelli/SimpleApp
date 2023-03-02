
using SimpleApi.Middlewares;

// Criando a instância da aplicação
var app = AppBuilder.GetApp(args);

// Configurando a aplicação
RequestPipelineBuilder.Configure(app);

// Executando a aplicação
app.Run();

using Emtelco.Api;

var builder = WebApplication.CreateBuilder(args);

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();

var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

app.Run();

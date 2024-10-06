using Application;
using Domain;
using InterfaceAdapters_Data;
using InterfaceAdapters_Mappers;
using InterfaceAdapters_Mappers.Dtos.Requests;
using InterfaceAdapters_Repository;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

// ******** Dependencies ********
// Cosmos singleton
//builder.Services.AddSingleton(provider =>
//{
//    var endpointUri = configuration["CosmosDbSettings.EndpointUri"];
//    var primaryKey = configuration["CosmosDbSettings.PrimaryKey"];
//    var databaseName = configuration["CosmosDbSettings.DatabaseName"];

//    var cosmosClientOptions = new CosmosClientOptions 
//    {
//        ApplicationName = databaseName
//    };

//    var loggerFactory = LoggerFactory.Create(builder =>
//    {
//        builder.AddConsole();
//    });

//    var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);

//    return cosmosClient;
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Interface Implementation
builder.Services.AddScoped<IRepository<LogEntity>, LogRepository>();
builder.Services.AddScoped<IMapper<LogRequestDTO, LogEntity>, LogMapper>();

// Use Cases
builder.Services.AddScoped<GetLogsUseCase<LogEntity>>();
builder.Services.AddScoped<CreateLogUseCase<LogRequestDTO>>();

// ******** App ********
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Get all the logs from cosmosDB
app.MapGet("/get-logs", async (GetLogsUseCase<LogEntity> logUseCase) =>
{
    return await logUseCase.ExecuteAsync();
})
.WithName("getLogs")
.WithOpenApi();

// Add new log to cosmosDB
app.MapPost("/add-log", async (LogRequestDTO logRequest,
    CreateLogUseCase<LogRequestDTO> logUseCase) =>
{
    await logUseCase.ExecuteAsync(logRequest);
    return Results.Created();
})
.WithName("addLog")
.WithOpenApi();

app.Run();

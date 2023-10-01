using Microsoft.AspNetCore.HttpLogging;
using MovieStore.API.Configs;
using MovieStore.Application;
using MovieStore.Persistence;
using MyVdsFactory.API.Configs;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddAuthenticationConfig(builder.Configuration);
builder.Services.AddSwaggerConfig();
builder.Services.AddSettingsConfig(builder.Configuration);

var logger = new LoggerConfiguration()
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("SqlServer_Dev"),
        tableName: "Logs",
        autoCreateSqlTable: true)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(logger);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());


app.MapControllers();

app.Run();
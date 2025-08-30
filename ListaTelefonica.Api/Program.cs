using ListaTelefonica.Api.Infrastructure;
using ListaTelefonica.Api.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings")
);
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddScoped<IContatoRepository, ContatoRepository>();


builder.Services.AddMediatR(typeof(Program).Assembly);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors("AllowLocalhost3000");

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();


public class MongoDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
}
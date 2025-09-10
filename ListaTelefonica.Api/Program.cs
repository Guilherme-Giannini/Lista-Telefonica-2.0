using ListaTelefonica.CrossCutting.IoC;    // Dependências (IoC)
using MediatR;
using ListaTelefonica.Application.Application.Commands;

var builder = WebApplication.CreateBuilder(args);

// Configuração das dependências (IoC)
builder.Services.AddInfrastructure(builder.Configuration);

// Registro do MediatR apontando para o assembly da Application
builder.Services.AddMediatR(typeof(CreateContatoCommand).Assembly);

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middlewares
app.UseCors("AllowLocalhost3000");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
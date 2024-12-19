using IOC;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAppServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Api teste de melhor rota",
            Description = "Calcula a melhor rota em termos de valor baseado no algoritimo de dijkstrar" +
            "              Adicionado teste unitarios nunit, padrao repository, camadas, solid, poo, " +
            "             Orm entityFramework in memory etc"
        }); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());


app.UseAuthorization();

app.MapControllers();

app.Run();

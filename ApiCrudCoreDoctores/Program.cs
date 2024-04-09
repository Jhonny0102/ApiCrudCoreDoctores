using ApiCrudCoreDoctores.Data;
using ApiCrudCoreDoctores.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryDoctor>();
builder.Services.AddDbContext<DoctorContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Permite habilitar el Swagger de forma Publica
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hoy tenemos Champions",
        Description = "Api crud de champions"
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api crud champions v1");
    options.RoutePrefix = "";
});

//***

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using DAL.DataContext;
using System.Text.Json.Serialization;
//ANADIR ESTO
using DAL.Repository;
using ENTITY;
using LN.Service;
using DAL.Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//CONEXION GLOBAL SQL
builder.Services.AddDbContext<WebApiContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSql")));

//inyeccion de dependencias -AGREGAR EXAMEN
builder.Services.AddScoped<IGenericRepository<Person>, PersonRepository>();//cualquier controlador trabaje con esto
builder.Services.AddScoped<IPersonService,PersonService>();//utilizar en cualquier parte
builder.Services.AddScoped<IGenericLogin<Person>, PersonLogin>();//utilizar en cualquier parte


builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

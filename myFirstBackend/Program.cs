//0. Usings para trabajar con EntityFramework
using Microsoft.EntityFrameworkCore;
using myFirstBackend.DataAcces;

var builder = WebApplication.CreateBuilder(args);

/*1. Conexion con la Base de Datos
 *2.Dependencias:
 *  -Microsoft.EntityFrameworkCore.SqlServer
 *  -Microsoft.EntityFrameworkCore.Tools, ejecutar desde terminal
 *  -Microsoft.VisualStudio.Web.CodeGeneration.Design, trae plantillas crud
 *  -Microsoft.VisualStudio.Web.CodeGeneration.Core,
 *  --Extension EF Core Power Tools, permite hacer un diagrama del DBContext
 * */
//3.Conexxion con SQL Server
const string name = "DefaultConnection";

var connectionString=builder.Configuration.GetConnectionString(name);

//4. A�adir contexto-Usind Dta acces
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

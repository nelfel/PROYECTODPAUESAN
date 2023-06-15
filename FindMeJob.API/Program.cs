using FindMeJob.DOMAIN.Core.Interfaces;
using FindMeJob.DOMAIN.Infrastructure.Data;
using FindMeJob.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _confg = builder.Configuration;
var _cnx = _confg.GetConnectionString("CnFindMeJob");

builder.Services.AddDbContext<FindMeJobContext>(options =>
{
    options.UseSqlServer(_cnx);
});

builder.Services
    .AddTransient<IUsuarioRepository, UsuarioRepository>();

builder.Services
    .AddTransient<IEmpresaRepository, EmpresaRepository>();

builder.Services
    .AddTransient<IOfertaTrabajoRepository, OfertaTrabajoRepository>();

builder.Services
    .AddTransient<IPostulacionRepository, PostulacionRepository>();

builder.Services
    .AddTransient<IPerfilProfesionalRepository, PerfilProfesionalRepository>();


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

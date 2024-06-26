using Aplication.Contracts;
using Aplication.Services;
using infraestrocture.Context;
using infraestrocture.Interfaces;
using infraestrocture.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("\"Server=LAPTOP-QCIUVPFJ;Database=SimpleApi;User ID=sa;Password=Alejandro23@#; TrustServerCertificate=true;\"")));

//Repositoris
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IClienteRepository, ClientesRepository>();

//Services
builder.Services.AddTransient<IUsuarioServise, UsuarioService>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddCors(options =>
{

    options.AddPolicy("app", policyBuilder =>
    {
        policyBuilder.WithOrigins("https://localhost:7226");
       
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
    });

    options.AddPolicy("jsApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://127.0.0.1:5500");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
    });
});

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

app.UseCors("jsApp");


app.Run();

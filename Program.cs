using SiteLeiloes.Data.Interfaces;
using SiteLeiloes.Data.Components;
using SiteLeiloes.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<CarenseDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DemoMyItConnection")));
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICoworkerRepository, CoworkerRepository>();
builder.Services.AddScoped<IAdministradorRepository, AdministradorRepository>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<ILeilaoRepository, LeilaoRepository>();
builder.Services.AddScoped<ILeilaoFavoritoRepository, LeilaoFavoritoRepository>();
builder.Services.AddScoped<IUtilizadorRepository, UtilizadorRepository>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.Run();

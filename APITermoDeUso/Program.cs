using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APITermoDeUso.Data;
using Microsoft.Extensions.Options;
using APITermoDeUso.Utils;
using APITermoDeUso.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APITermoDeUsoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APITermoDeUsoContext") ?? throw new InvalidOperationException("Connection string 'APITermoDeUsoContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurações para receber os dados do arquivo de configuração 
builder.Services.Configure<TermoUsoSettings>(
    builder.Configuration.GetSection(nameof(TermoUsoSettings)));

builder.Services.AddSingleton<ITermoUsoSettings>(sp =>
    sp.GetRequiredService<IOptions<TermoUsoSettings>>().Value);

builder.Services.AddSingleton<TermoUsoService>();

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

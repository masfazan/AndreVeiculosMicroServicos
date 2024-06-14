using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIBanco.Data;
using Microsoft.Extensions.Options;
using APIBanco.Utils;
using APIBanco.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APIBancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIBancoContext") ?? throw new InvalidOperationException("Connection string 'APIBancoContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Utilizar o Arquivo de configuração#####################################################

builder.Services.Configure<BancoSettings>(
               builder.Configuration.GetSection(nameof(BancoSettings)));

builder.Services.AddSingleton<IBancoSettings>(sp =>
    sp.GetRequiredService<IOptions<BancoSettings>>().Value);

builder.Services.AddSingleton<BancoService>();


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

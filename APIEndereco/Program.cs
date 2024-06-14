using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIEndereco.Data;
using Microsoft.Extensions.Options;
using APIEndereco.Utils;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APIEnderecoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIEnderecoContext") ?? throw new InvalidOperationException("Connection string 'APIEnderecoContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurações para receber os dados do arquivo de configuração 
builder.Services.Configure<EnderecoSettings>(
    builder.Configuration.GetSection(nameof(EnderecoSettings)));

builder.Services.AddSingleton<IEnderecoSettings>(sp =>
    sp.GetRequiredService<IOptions<EnderecoSettings>>().Value);

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

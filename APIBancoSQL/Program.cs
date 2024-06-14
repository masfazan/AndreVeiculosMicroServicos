using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIBancoSQL.Data;
using Microsoft.Extensions.Options;
using APIBancoSQL.Utils;
using Consumer.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APIBancoSQLContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIBancoSQLContext") ?? throw new InvalidOperationException("Connection string 'APIBancoSQLContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configurações para receber os dados do arquivo de configuração 
builder.Services.Configure<BancoSQLSettings>(
    builder.Configuration.GetSection(nameof(BancoSQLSettings)));

builder.Services.AddSingleton<IBancoSQLSettings>(
        sp => sp.GetRequiredService<IOptions<BancoSQLSettings>>().Value);

builder.Services.AddSingleton<MessageService>();

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

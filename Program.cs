using Microsoft.EntityFrameworkCore;
using RepositoryPattern_MySQL_Youtube.Models;
using RepositoryPattern_MYSQL_Youtube.Data.MusicRepo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add connection string
var connectionString = builder.Configuration.GetConnectionString("DbConnection");

// Set the connectionString to AddDbContext
builder.Services.AddDbContext<AppDbContext>(options=>options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

// Reguster service
builder.Services.AddScoped<IMusicService,MusicService>();

// Register Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

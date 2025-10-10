using Microsoft.EntityFrameworkCore;
using UsuariosApi.Configuration;
using UsuariosApi.DBContext;
using UsuariosApi.Features.Usuarios.Queries;
using UsuariosApi.Middlewares;
using UsuariosApi.Profiles;
using UsuariosApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(cfg => { }, typeof(UsuarioProfile).Assembly);
builder.Services.AddSingleton<SettingsProvider>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ObtenerTodosUsuariosQuery).Assembly));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var settingsProvider = new SettingsProvider(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(settingsProvider.DefaultConnectionString));

builder.Services.AddControllers();

var app = builder.Build();
app.UseMiddleware<TiempoRespuestaMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Urls.Add("http://*:80");

app.Run();

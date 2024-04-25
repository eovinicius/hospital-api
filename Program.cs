using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Web;
using SistemaHospitalar.Application.Services;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Domain.Repositories;
using SistemaHospitalar.Infrastructure.Database;
using SistemaHospitalar.Infrastructure.Database.EntityFramework.Repositories;
using SistemaHospitalar.Infrastructure.Database.Seeds;
using SistemaHospitalar.Infrastructure.filter;
using SistemaHospitalar.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<CadastrarMedicoUseCase>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<AutenticarUsuarioUseCase>();
builder.Services.AddScoped<CadastrarPacienteUseCase>();
builder.Services.AddScoped<IConvenioRepository, ConvenioRepository>();
builder.Services.AddScoped<ListarConsultasDeMedicoUseCase>();
builder.Services.AddScoped<MarcarConsultaUseCase>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<DetalhesPacienteUseCase>();
builder.Services.AddScoped<ListarConveniosUseCase>();
builder.Services.AddScoped<CadastrarConvenioUseCase>();
builder.Services.AddScoped<ListarPacientesUseCase>();
builder.Services.AddScoped<ListarMedicosUseCase>();
builder.Services.AddScoped<MarcarExameUseCase>();
builder.Services.AddScoped<IExameRepository, ExameRepository>();
builder.Services.AddScoped<DetalhesMedicoUseCase>();
builder.Services.AddScoped<DesativarMedicoUseCase>();
builder.Services.AddScoped<DesativarConvenioUseCase>();
builder.Services.AddScoped<DetalhesConvenioUseCase>();
builder.Services.AddScoped<DetalhesConsultaUseCase>();
builder.Services.AddScoped<HashService>();
builder.Services.AddScoped<DesativarPacienteUseCase>();
builder.Services.AddScoped<ListarExamesUseCase>();

builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {

        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("e82ae3da0cf299afd549f0b90e2cf0fc64d4a1b36fcec113f71637f082fcb9fb")),
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wedding Planner API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedManeger.Seed(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.Run();
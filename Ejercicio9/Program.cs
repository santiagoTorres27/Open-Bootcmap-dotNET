using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using UniversityApiBackend;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// 12. SERILOG: Config serilog
builder.Host.UseSerilog((hostBuilderCtx, loggerConf) =>
{
    loggerConf.WriteTo.Console().WriteTo.Debug().ReadFrom.Configuration(hostBuilderCtx.Configuration);
});

// 2. Connection with SQL Database
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. Add Context to Services of builder
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

// 7. Add Service of JWT Authorization
// TODO:
builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.
// 4. Add Custom Services (folder Services)
builder.Services.AddScoped<IStudentsService, StudentsService>();

// 8. Add Authorization
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// 9. Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// TODO: Add the remaining services
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 9. OTOD: Config Swagger to take care of Authorization of JWT
builder.Services.AddSwaggerGen(options =>
{
    // We define the Security for authorization
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header using Bearer Scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer",
            }
        },
        new string[]{}
        }
    });
});

//5. CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

// 10. Supported cultures
var supportedCultures = new[] { "en-US", "es-ES", "fr-FR", "de-DE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

// 11. Add Localization to App
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 13. SERILOG: Tell app to use serilog
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//6. Tell app to use CORS
app.UseCors("Cors Policy");

app.Run();

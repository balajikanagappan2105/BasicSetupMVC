using AutoMapper;
using EffortEntry.AutoMapper;
using EffortEntry.Repository.DBContexts;
using EffortEntry.Repository.Interfaces;
using EffortEntry.Repository.Interfaces.Base;
using EffortEntry.Repository.Repositories;
using EffortEntry.Repository.Repositories.Base;
using EffortEntry.Services;
using EffortEntry.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using NLog.Web;


string CorsPolicyName = "MMHCorsPolicy";

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var isDevelopmentEnvironment = environmentName == Environments.Development;
var logger = NLog.LogManager.Setup(options =>
{
	options.LoadConfigurationFromAppSettings(environment: environmentName, reloadOnChange: true);
}).GetCurrentClassLogger();

logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Add services to the container.

//AutoMapper
var autoMapperConfig = new MapperConfiguration(options =>
{
	options.AddProfile<EntityToModelMappingProfile>();
});
var autoMapper = autoMapperConfig.CreateMapper();
builder.Services.AddSingleton(autoMapper);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<DBContext>(options =>
{
	options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("EffortEntryConnection"));
	options.EnableSensitiveDataLogging(true);
	options.EnableDetailedErrors(true);
	//options.EnableThreadSafetyChecks
});

//Core Mapping
builder.Services.AddScoped<DbContext, DBContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


if (!isDevelopmentEnvironment)
{
	builder.Services.AddHttpsRedirection(options =>
	{
		options.HttpsPort = 443;
	});
}

var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = appSettings["ValidIssuer"],
		ValidAudience = appSettings["ValidAudience"],
		IssuerSigningKey = new SymmetricSecurityKey(WebEncoders.Base64UrlDecode(appSettings["IssuerSigningKey"]))
	};
});

builder.Services.AddCors(options =>
{
	options.AddPolicy(CorsPolicyName, builder =>
	{
		builder
		.WithOrigins(appSettings["CORSAllowedOrigins"].Split([',']))
		.SetIsOriginAllowedToAllowWildcardSubdomains()
		.WithHeaders(appSettings["CORSAllowedHeaders"].Split([',']))
		.WithExposedHeaders(appSettings["CORSExposedHeaders"].Split([',']))
		.WithMethods(appSettings["CORSAllowedMethods"].Split([',']))
		.AllowCredentials();
	});
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
	app.UseDeveloperExceptionPage();
else
	app.UseHsts();

app.UseCors(CorsPolicyName);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseStaticFiles();
app.UseDefaultFiles(new DefaultFilesOptions() { DefaultFileNames = ["index.html"] });
app.UseRouting();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
	name: "DefaultApi",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

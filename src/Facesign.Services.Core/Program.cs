using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Text;
using Facesign.Services.Domain.Security;
using Facesign.Services.Infra.Ioc;
using Facesign.Services.Entities.Configuration;
using Facesign.Services.Infra.Data.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conf = builder.Services.BuildServiceProvider().GetService<IConfiguration>();


var environment = conf.GetValue<string>("AppSettings:EnvironmentName");


builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);


BuildConfigurationModel.ConnectionString = new Base64Crypt().Decrypt(conf.GetValue<string>("AppSettings:ConnectionString"));
BuildConfigurationModel.EndpointFrontEnd =  conf.GetValue<string>("AppSettings:EndpointFrontEnd");
BuildConfigurationModel.MongoConnectionString = new Base64Crypt().Decrypt(conf.GetValue<string>("AppSettings:MongoDbConnectionString"));
BuildConfigurationModel.EndpointSDK = conf.GetValue<string>("AppSettings:EndpointSDK");


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret.GetSecret())),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


NativeInjectorBootStrapper.RegisterServices(builder.Services);

builder.Services.AddCors();

builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Facesign Services Core", Version = "v1" });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseSwagger();

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

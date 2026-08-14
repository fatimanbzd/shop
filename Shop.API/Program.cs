
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shop.Application;
using Shop.Application.Features.Identity.Register;
using Shop.Application.Shared.Interfaces;
using Shop.Infrastructure;
using Shop.Infrastructure.Authentication;
using Shop.Infrastructure.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDataProtection();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ShopDomain", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(RegisterCommandHandler).Assembly));

<<<<<<< HEAD

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
=======
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
>>>>>>> main
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.MigrateDatabase();
}

await IdentitySeeder.SeedRolesAsync(app.Services);

app.UseHttpsRedirection();

app.UseCors("ShopDomain");


app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();


//var appSettings = new ConfigurationBuilder()
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
//    .Build();

//builder.Services.ConfigureApplication();
//builder.Services.ConfigureInfrastructure();

//builder.Services.AddSwaggerGen(option =>
//{
//option.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop API", Version = "v1" });
//option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//{
//    In = ParameterLocation.Header,
//    Description = "Please enter a valid token",
//    Name = "Authorization",
//    Type = SecuritySchemeType.Http,
//    BearerFormat = "JWT",
//    Scheme = "Bearer"
//});

//    option.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                }
//            },
//            new string[]{}
//        }
//    });
//});



//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("ShopDomain",
//    policy => policy.WithOrigins("*")
//    .AllowAnyHeader()
//    .AllowAnyMethod());
//});
//builder.Services.AddHttpContextAccessor();
//var app = builder.Build();

//app.UseDeveloperExceptionPage();


//app.UseHttpsRedirection();

//app.UseCors("ShopDomain");


app.Run();


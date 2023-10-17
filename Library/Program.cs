using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Authentications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(options =>{
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;

}); ;


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add ConfigureSwaggerOptions
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


//Add JwT Token
builder.Services.AddAuthenticationJWTToken(builder.Configuration);

builder.Services.AddAuthorization();

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

//connection sqlserver
builder.Services.AddApplicationMySqlCon(builder.Configuration);

// Add Validation for validation
builder.Services.AddAppValidationMySql();

//jsonSerializer
builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//add Authentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

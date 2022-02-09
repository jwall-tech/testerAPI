using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Okta.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOktaMvc(new OktaMvcOptions
{
        OktaDomain = "https://middlesbro-ac.okta.com",
        ClientId = "0oadksw3u29HdwSGT696",
        ClientSecret = "8y4MaAchS32CLcGEiUdhLzDqwyd2o8PAgulcBoRh",
        AuthorizationServerId = "default",
})
.AddJwtBearer(options =>
{
    options.Audience = "0oadksw3u29HdwSGT696";
    options.TokenValidationParameters = new() { NameClaimType = ClaimTypes.NameIdentifier };
});

builder.Services.AddAuthorization(options =>
     {
         options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
     });

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

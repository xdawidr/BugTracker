using BugTracker.Application;
using BugTracker.Persistance;
using BugTracker.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BugTracker.Application.Common.Interfaces;
using BugTracker.Service;
using Microsoft.OpenApi.Models;
using BugTracker;

var builder = WebApplication.CreateBuilder(args);

//optional line to resolve problem with identity
builder.Services.AddControllersWithViews()
    .ConfigureApplicationPartManager(apm => {
        apm.ApplicationParts
        .Remove(apm.ApplicationParts.Single(ap => ap.Name == "Microsoft.AspNetCore.ApiAuthorization.IdentityServer"));
    });
// Add services to the container.
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                TokenUrl = new Uri("https://localhost:5001/connect/token"),
                Scopes = new Dictionary<string, string>
                {
                    {"api1", "Full access"},
                    {"user", "User infos" }
                }
            }
        }
    });
    c.OperationFilter<AuthorizeCheckOperationFilter>();
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin());
});


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters() 
        {
            ValidateAudience = false
        };
    });

builder.Services.AddHealthChecks();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope, api1");
    });
});

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BugTracker v1");
        c.OAuthClientId("swagger");
        c.OAuth2RedirectUrl("https://localhost:7069/swagger/oauth-redirect.html");
        c.OAuthUsePkce();
    });
}
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

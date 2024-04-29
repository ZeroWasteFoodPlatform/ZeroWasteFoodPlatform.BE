using Business.DependencyResolvers;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utils.DI.Abstact;
using DataAccess.DependencyResolvers;
using Domain.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
const string corsPolicyName = "AllowOrigin";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyResolvers(
    new IDependencyInjectionModule[]
    {
        new CoreModule(),
        new DomainModule(),
        new BusinessModule(),
        new DataAccessModule()
    });

<<<<<<< HEAD

=======
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});
>>>>>>> 14167465d7572e6139ab4762421ae83e71b629e6

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
    .AddUserSecrets<Program>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSeeder();
}

app.UseCors(corsPolicyName);

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
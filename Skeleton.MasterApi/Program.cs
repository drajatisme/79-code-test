using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Skeleton.Application;
using Skeleton.Application.Common;
using Skeleton.Application.Extensions;
using Skeleton.Application.Services.Country;
using Skeleton.Application.Services.Health;
using Skeleton.Application.Services.Token;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

var configuration = new ConfigurationWrapper();
builder.Configuration.Bind(configuration);
builder.Services.AddSingleton(configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddBearerSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddHealthChecks();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    // options.UseInMemoryDatabase("MyAppDb"));
    options.UseSqlServer(configuration.ConnectionStrings.DefaultConnection));

builder.Services.AddIdentityCore<UserEntity>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<RoleEntity>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddJwtAuthorization(configuration);

builder.Services.AddAuthorization();

#region Custom Services

builder.Services.AddCountryServices();
builder.Services.AddTokenServices();
builder.Services.AddHealthServices();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    #region Seeder

    using var scope = app.Services.CreateScope();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
    var adminUser = new UserEntity
        { UserName = "technicaltest@test.com", Email = "technicaltest@test.com", EmailConfirmed = true };
    await userManager.CreateAsync(adminUser, "P@ssw0rd789");

    #endregion
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
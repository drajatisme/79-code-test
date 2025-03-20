using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Skeleton.Application.Services.Item;
using Skeleton.Application.Services.ItemCategory;
using Skeleton.Application.Services.Lov;
using Skeleton.Application.Services.UserNotification;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Data;
using Skeleton.WebApp.Components;
using Skeleton.WebApp.Components.Account;
using Skeleton.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
//                        throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("MyAppDb"));
// options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<UserEntity>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<RoleEntity>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<UserEntity>, IdentityNoOpEmailSender>();

builder.Services.AddScoped<ILifecycleLogger, LifecycleLogger>();

builder.Services.AddLovServices();

builder.Services.AddItemCategoryServices();
builder.Services.AddItemServices();
builder.Services.AddUserNotificationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    #region Seeder

    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<RoleEntity>>();
    var adminRole = new RoleEntity
    {
        Name = "Administrator"
    };
    await roleManager.CreateAsync(adminRole);

    var userRole = new RoleEntity
    {
        Name = "Role 1"
    };
    await roleManager.CreateAsync(userRole);

    var userRole2 = new RoleEntity
    {
        Name = "Role 2"
    };
    await roleManager.CreateAsync(userRole2);

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
    var adminUser = new UserEntity
        { UserName = "admin@example.com", Email = "admin@example.com", EmailConfirmed = true };
    await userManager.CreateAsync(adminUser, "qweQWE123!@#");
    await userManager.AddToRoleAsync(adminUser, adminRole.Name);

    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    context.ItemCategories.AddRange([
        new()
        {
            Name = "Item 1",
            Description = "Item 1 description"
        },
        new()
        {
            Name = "Item 2",
            Description = "Item 2 description"
        }
    ]);

    context.Items.AddRange([
        new()
        {
            Name = "Item 1-1",
            Description = "Item 1-1 description",
            ItemCategoryId = 1
        },
        new()
        {
            Name = "Item 1-2",
            Description = "Item 1-2 description",
            ItemCategoryId = 1
        },
        new()
        {
            Name = "Item 2-1",
            Description = "Item 2-1 description",
            ItemCategoryId = 2
        },
        new()
        {
            Name = "Item 2-2",
            Description = "Item 2-2 description",
            ItemCategoryId = 2
        }
    ]);

    context.UserNotifications.AddRange(
    [
        new ()
        {
            Subject = "Subject 1",
            Body = "<h1>Body 1</h1>",
            Read = false,
            UserId = adminRole.Id
        },
        new ()
        {
            Subject = "Subject 2",
            Body = "<h1>Body 2</h1>",
            Read = false,
            UserId = userRole.Id
        }
    ]);

    context.SaveChanges();

    #endregion
}
else
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
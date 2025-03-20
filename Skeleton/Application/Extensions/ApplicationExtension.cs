using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Skeleton.Application.Common;

namespace Skeleton.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddBearerSwaggerGen(this IServiceCollection services)
    {
        const string BEARER = "Bearer";
    
        return services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition(BEARER, new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. \n\nEnter 'Bearer' [space] and then your token in the text input below. \n\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = BEARER
            });
    
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = BEARER
                        },
                        Scheme = "oauth2",
                        Name = BEARER,
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
    }

    public static IServiceCollection AddJwtAuthorization(this IServiceCollection services, ConfigurationWrapper configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,

                    ValidIssuer = configuration.Jwt.Issuer,
                    ValidAudience = configuration.Jwt.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Jwt.Secret))
                };
        
                options.MapInboundClaims = false;
            });

        return services;
    }
}
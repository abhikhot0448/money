﻿using Dhanman.Infrastructure.Authentication.Abstractions;
using Dhanman.Infrastructure.Authentication.Constants;
using Dhanman.Infrastructure.Authentication.Cryptography;
using Dhanman.Infrastructure.Authentication.Options;
using Dhanman.Infrastructure.Authentication.Permissions;
using Dhanman.Infrastructure.Authentication.Providers;
using dhanman.money.Application.Abstractions.Authentication;
using dhanman.money.Application.Abstractions.Cryptography;
using dhanman.money.Domain.Entities.Users.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dhanman.Infrastructure.Authentication;

public static class DependencyInjection
{
    public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        #region Methodes
        services.AddAuthentication(DhanmanJwtDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration[DhanmanJwtDefaults.IssuerSettingsKey],
                    ValidAudience = configuration[DhanmanJwtDefaults.AudienceSettingsKey],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration[DhanmanJwtDefaults.SecurityKeySettingsKey]))
                };
            });

        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SettingsKey));

        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

        services.AddTransient<IPasswordHasher, PasswordHasher>();

        services.AddTransient<IPasswordHashChecker, PasswordHasher>();

        services.AddScoped<IClaimsProvider, ClaimsProvider>();

        services.AddScoped<IJwtProvider, JwtProvider>();

        services.AddScoped<IUserIdentifierProvider, UserIdentifierProvider>();
        #endregion
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OrderOut.DtosOU;
using System.Text;

namespace jwt
{
    public static class JWTStartup
    {
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration Configuration)
        {
            var authSettingsSection = Configuration.GetSection(nameof(AuthSettings));
            services.Configure<AuthSettings>(authSettingsSection);

            var authSettings = authSettingsSection.Get<AuthSettings>();
            var key = Encoding.ASCII.GetBytes(authSettings.SecretKey);
           
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "http://localhost:5001/",
                    ValidAudience = "http://localhost:5001/",
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/hub")))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Usuario", builder => builder.RequireRole("Usuario"));
                options.AddPolicy("Cajero", builder => builder.RequireRole("2"));
                options.AddPolicy("Cocinero", builder => builder.RequireRole("3"));
            });
                

            return services;
        }

    }


}
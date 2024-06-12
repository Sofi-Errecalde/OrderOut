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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

    }
}
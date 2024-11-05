using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace POS.Extensions
{
    public static class ServiceExtensions
    {
        //public static void configureSqlContext(this IServiceCollection service, IConfiguration configuration)
        //{
        //    service.add(
        //options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        //}


        //public static void ConfigureIdentity(this IServiceCollection services)
        //{
        //    var builder = services.AddIdentityCore<WebClients>(o =>
        //    {
        //        o.Password.RequireDigit = true;
        //        o.Password.RequireLowercase = false;
        //        o.Password.RequireUppercase = false;
        //        o.Password.RequireNonAlphanumeric = false;
        //        o.Password.RequiredLength = 6;
        //        o.User.RequireUniqueEmail = true;
        //    });
        //    builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
        //    builder.AddEntityFrameworkStores<PosContext>().AddDefaultTokenProviders();
        //}

        //public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var jwtSettings = configuration.GetSection("JwtSettings");
        //    var secretKey = jwtSettings.GetSection("SECRET").Value;
        //    services.AddAuthentication(opt =>
        //    {
        //        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    })
        //    .AddJwtBearer(options =>
        //    {
        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
        //            ValidAudience = jwtSettings.GetSection("validAudience").Value,
        //            IssuerSigningKey = new
        //                  SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        //        };
        //    });
        //}

    }
}

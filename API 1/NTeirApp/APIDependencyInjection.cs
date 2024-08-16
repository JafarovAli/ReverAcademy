using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace NTeirApp.Api
{
    public static class APIDependencyInjection
    {
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration) 
        {
            var secretKey = configuration.GetValue<string>("JwtConfiguration:SecretKey");
            var issuer = configuration.GetValue<string>("JwtConfiguration:Issuer");
            var audience = configuration.GetValue<string>("JwtConfiguration:Audience");

            var key = Encoding.ASCII.GetBytes(secretKey);

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("Dev", builder =>
            //    {
            //        // Allow multiple methods
            //        builder
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials()
            //        .SetIsOriginAllowed(origin =>
            //        {
            //            if (string.IsNullOrWhiteSpace(origin)) return false;
            //            if (origin.ToLower().StartsWith("http://localhost")) return true;
            //            if (origin.ToLower().Contains("192")) return true;
            //            if (origin.ToLower().Contains("test")) return true;
            //            return false;
            //        });
            //    });
            //});

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            //});

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                //opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //opt.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Token failed to authenticate: " + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token validated: " + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JwtConfiguration:Issuer"],
                    ValidAudience = configuration["JwtConfiguration:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtConfiguration:SecretKey"])),
                    LifetimeValidator = (notBefore, expires, tokenToValidate, tokenValidationParameters) =>
                    {
                        return expires != null && expires > DateTime.UtcNow;
                    }
                };
            });

            services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "AppTech.API", Version = "v1" });
            });
        }
    }
}

//.AddCookie(options =>
//{
//    options.Cookie.Name = "google-cookie";
//})
//.AddGoogle(options =>
//{
//    options.ClientId = configuration["Authentication:Google:ClientId"];
//    options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
//    options.CallbackPath = new PathString(configuration["Authentication:Google:PathString"]);
//    options.Scope.Add("profile");
//    options.Events.OnCreatingTicket = (context) =>
//    {
//        var picture = context.User.GetProperty("picture").GetString();

//        context.Identity.AddClaim(new Claim("picture", picture));

//        return Task.CompletedTask;
//    };
//})
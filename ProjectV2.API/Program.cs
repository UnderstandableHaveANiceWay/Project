using ProjectV2.Bll.Services;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Dal.Repositories;
using ProjectV2.Dal.DataBaseContext;
using Microsoft.EntityFrameworkCore;

using ProjectV2.Bll;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProjectV2.API.TokenOptions;
using ProjectV2.API.Infrustructure.Middlewares;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ProjectDbContext>(optionBuilder =>
        {
            optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("ProjectDb"));
        });

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
        builder.Services.AddScoped<ICityService, CityService>();
        builder.Services.AddScoped<ICountryService, CountryService>();
        builder.Services.AddScoped<IReviewService, ReviewService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<ISightService, SightService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ISightImageService, SightImageService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<DbContext, ProjectDbContext>();
        builder.Services.AddAutoMapper(typeof(BllAssemblyMarker));

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.ISSUER,

                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,

                    ValidateLifetime = true,

                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

                    ValidateIssuerSigningKey = true
                };
            });

        builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<TransactionMiddleware>();

        app.MapControllers();

        app.Run();
    }
}
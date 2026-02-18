using DotnetWebApi.Application.Common.Interfaces;
using DotnetWebApi.WebApi.Common;
using DotnetWebApi.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetWebApi.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy("AppClients", policy =>
                {
                    if (allowedOrigins != null && allowedOrigins.Length > 0)
                    {
                        policy.WithOrigins(allowedOrigins)
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    }
                });
            });

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = actionContext =>
                    {
                        var errors = actionContext.ModelState
                            .Where(e => e.Value?.Errors.Count > 0)
                            .SelectMany(x => x.Value!.Errors)
                            .Select(x => x.ErrorMessage)
                            .ToList();

                        var response = ApiResponse<object>.Failure(errors, "Validation failed.");

                        return new BadRequestObjectResult(response);
                    };
                });

            //services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddOpenApi();

            return services;
        }
    }
}

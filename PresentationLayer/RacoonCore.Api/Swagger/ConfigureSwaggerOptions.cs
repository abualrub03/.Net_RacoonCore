﻿using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RacoonCore.Api.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer",new Microsoft.OpenApi.Models.OpenApiSecurityScheme 
            {
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "Please Enter Your Token >^_^< ",
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme="Bearer"
            });
            options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });






        }
    }
}

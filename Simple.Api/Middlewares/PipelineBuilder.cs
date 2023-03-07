using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Api.Middlewares
{
    public static class PipelineBuilder
    {
        public static void Configure(WebApplication app)
        {
            // Environment
            if (app.Environment.IsDevelopment())
            {
                // Developer Exception Page
                app.UseDeveloperExceptionPage();
                // Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple.Api v1");
                });
            }

            // Security
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthorization();

            // Controllers
            app.UseRouting();
            app.MapControllers();
        }
    }
}
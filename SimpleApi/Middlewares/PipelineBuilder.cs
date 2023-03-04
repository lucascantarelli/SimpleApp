using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi.Middlewares
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleApi v1");
                });
            }

            // Security
            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Controllers
            app.UseRouting();
            app.MapControllers();
        }
    }
}
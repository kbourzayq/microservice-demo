using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlateformService.Data;
using PlateformService.Models;

namespace PlateformService.DataSeed
{
    public static class DataSeeder
    {
        public static void DataSeed(this IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
               var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
               Seed(context);
            }
        }

        private static void Seed(AppDbContext context)
        {
            if(context.Platforms.Any()) return;
            System.Console.WriteLine("Data seeding...");
            context.Platforms.AddRange(
                new Platform{
                    Id = System.Guid.NewGuid(),
                    Name = "Dotnet",
                    Publisher = "Mirosoft",
                    Cost = "Free"
                },
                new Platform{
                    Id = System.Guid.NewGuid(),
                    Name = "Sql server express",
                    Publisher = "Mirosoft",
                    Cost = "Free"
                },
                new Platform{
                    Id = System.Guid.NewGuid(),
                    Name = "Kubernetes",
                    Publisher = "Cloud native",
                    Cost = "Free"
                }
            );
            context.SaveChanges();
            System.Console.WriteLine("Seeding done...");
        }
    }
}
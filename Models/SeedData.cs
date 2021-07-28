using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using csi_media_test.Data;

namespace csi_media_test.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new csiDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<csiDBContext>>()))
            {

                if (context.SortedNumModel.Any())
                {
                    return;
                }

                context.SortedNumModel.AddRange(
                    new DBO_SortedNumModel
                    {
                        Id = 1,
                        Number = "1,2,3,4,5",
                        SortType = "Ascending"
                    },
                    new DBO_SortedNumModel
                    {
                        Id = 2,
                        Number = "5,4,3,2,1",
                        SortType = "Descending"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
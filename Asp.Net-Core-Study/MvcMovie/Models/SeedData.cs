using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context=new MvcMovieContext(serviceProvider.GetRequiredService < DbContextOptions<MvcMovieContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie() { Title = "When Harry Met Sally", ReleaseDate = new DateTime(1989, 1, 11), Genre = "Romantic Comedy", Price = 7.99M },
                    new Movie() { Title = "Ghostbusters", ReleaseDate = new DateTime(1984, 3, 13), Genre = "Comedy", Price = 8.99M }
                    );
                context.SaveChanges();
            }
        }
    }
}

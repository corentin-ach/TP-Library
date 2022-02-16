using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre SF, Classic, Romance, Thriller;
            bookDbContext.Genre.AddRange(
                SF = new Genre() { Type = "SF" },
                Classic = new Genre() { Type = "Classic" },
                Romance = new Genre() { Type = "Romance" },
                Thriller = new Genre() { Type = "Thriller" }
            ); ;
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book(){ titre = "yyy", contenu = "teshs", prix = 200, Genres = new List<Genre>() { SF } }, 
                new Book(){ titre = "xxx", contenu = "teshs", prix = 400, Genres = new List<Genre>() { SF } },
                new Book(){ titre = "www", contenu = "teshs", prix = 15, Genres = new List<Genre>() { SF } },
                new Book(){ titre = "zzz", contenu = "teshs" }
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}
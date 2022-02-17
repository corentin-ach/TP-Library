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
                new Book(){ titre = "Book 1", contenu = "teshs", prix = 200, auteur = "Tessir" , Genres = new List<Genre>() { SF, Romance} }, 
                new Book(){ titre = " Book 2", contenu = "teshs", prix = 400, auteur =  "Corentin" , Genres = new List<Genre>() { SF, Thriller } },
                new Book(){ titre = "Book 3", contenu = "teshs", prix = 15, auteur = "Nisserine", Genres = new List<Genre>() { Romance } },
                new Book(){ titre = " Book 4", contenu = "teshs", prix = 15, auteur = "Florent", Genres = new List<Genre>() { SF, Thriller } }
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}
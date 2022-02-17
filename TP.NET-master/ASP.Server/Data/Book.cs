using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ASP.Server.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public String titre { get; set; }
        public String contenu { get; set; }
        public double prix { get; set; }

        public String auteur { get; set; }

        public List<Genre> Genres { get; set; }




        // Mettez ici les propriété de votre livre: Nom, Autheur, Prix, Contenu et Genres associés
        // N'oublier pas qu'un livre peut avoir plusieur genres
    }
    public class BookModel
    {
        [JsonIgnore]
        public Book Book { init; private get; }
        public int Id { get { return Book.Id; } }
        public String titre { get { return Book.titre; } }
        public double Prices { get { return Book.prix; } }
        public string auteur { get { return Book.auteur; } }
        public List<Genre> Genres { get { return Book.Genres; } }

        public static List<BookModel> ToBookmodel(IEnumerable<Book> bookslist)
        {
            var bookmodel = bookslist.Select(x => new BookModel() { Book = x }).ToList();
            return bookmodel;
        }


    }
}

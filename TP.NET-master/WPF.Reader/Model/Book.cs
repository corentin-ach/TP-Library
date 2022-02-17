using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Reader.Model
{
    // A vous de completer ce qu'est un Livre !!
    public class Book
    {
        public int Id { get; set; }
        public String titre { get; set; }
        public String contenu { get; set; }
        public double prix { get; set; }

        public String auteur { get; set; }

        public List<Genre> Genres { get; set; }

        /*public List<Genre> Genres { get; set; }*/
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

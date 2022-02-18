using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using WPF.Reader.Model;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouer et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public LibraryService()
        {
            var SF = new Genre() { Type = "SF" };
            var Classic = new Genre() { Type = "Classic" };
            var Romance = new Genre() { Type = "Romance" };
            var Thriller = new Genre() { Type = "Thriller" };

            Genres = new ObservableCollection<Genre>()
            {
                SF,
                Classic,
                Romance,
                Thriller
            };

            Books = new ObservableCollection<Book>() {
                new Book { titre = "yyy", contenu = "teshs", prix = 200, auteur="auteur1", Genres = new List<Genre>() { SF } },
                new Book { titre = "xxx", contenu = "teshs", prix = 400, auteur="auteur2", Genres = new List<Genre>() { SF } },
                new Book { titre = "www", contenu = "teshs", prix = 15, auteur="auteur3", Genres = new List<Genre>() { SF } },
            };

            UpdateBookList();
            UpdateGenreList();
        }

        public ObservableCollection<Book> Books { get; set; }

        public ObservableCollection<Genre> Genres { get; set; }

        public async void UpdateBookList()
        {

            var httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:5001") };

            var books = await new ASP.Server.Client(httpClient).ApiBookGetBooksAsync( new List<int>(),0,10);
            Books.Clear();
           
            foreach (var book in books.Select(x => new Book() { Id = x.Id, titre = x.Titre,  prix = x.Prices, Genres = x.Genres.Select(x => new Genre { Type = x.Type }).ToList() }))
            {
                Books.Add(book);
            }

        }
        public async void UpdateGenreList()
        {

            var httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:5001") };

            var genres = await new ASP.Server.Client(httpClient).ApiBookGetGenreAsync();
            Genres.Clear();
            foreach (var genre in genres.Select(x => new Genre { Type = x.Type }))
            {
                Genres.Add(genre);
            }
        }

        public Book GetBook(int id)
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:5001") };
            var book = new ASP.Server.Client(httpClient).ApiBookGetBookAsync(id).Result;

            Book fullbook = new Book() { titre = book.Titre, contenu = book.Contenu, prix = book.Prix, auteur = book.Auteur  };

            return fullbook;
        }



        // C'est aussi ici que vous ajouterez les requète réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
    }
}

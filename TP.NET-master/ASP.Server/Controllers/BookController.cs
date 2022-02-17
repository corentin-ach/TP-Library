using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ASP.Server.Controllers
{
    public class CreateBookModel
    {
        [Required]
        [Display(Name = "Nom")]
        public String Name { get; set; }

        // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre
        [Required]
        [Display(Name = "Contenu")]
        public String Contenu { get; set; }
        [Required]
        [Display(Name = "Prix")]
        public double Prix { get; set; }
        [Required]
        [Display(Name = "Auteur")]
        public String Auteur { get; set; }
        [Required]
        [Display(Name = "Genres")]
        // Liste des genres séléctionné par l'utilisateur
        public List<int> Genres { get; set; }
        
        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; init;  }
    }

    public class DeleteBookModel
    {
       [Required]
        [Display(Name = "Nom")]
        public String Name { get; set; }

        // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre
        [Required]
        [Display(Name = "Contenu")]
        public String Contenu { get; set; }
        [Required]
        [Display(Name = "Prix")]
        public double Prix { get; set; }
        [Required]
        [Display(Name = "Auteur")]
        public String Auteur { get; set; }
        [Required]
        [Display(Name = "Genres")]
        // Liste des genres séléctionné par l'utilisateur
        public List<int> Genres { get; set; }
        
        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; init;  }
    }

    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public ActionResult<IEnumerable<Book>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            List<Book> ListBooks = libraryDbContext.Books.Include(x => x.Genres).ToList();
            return View(ListBooks);
        }

        public ActionResult<CreateBookModel> Create(CreateBookModel book)
        {
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Il faut intéroger la base pour récupérer l'ensemble des objets genre qui correspond aux id dans CreateBookModel.Genres
                var genres = libraryDbContext.Genre.Where(genres => book.Genres.Contains(genres.Id)).ToList();
                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                //requete recup list genre et obetenir le bon genre

                libraryDbContext.Add(new Book() { titre = book.Name, contenu = book.Contenu, prix = book.Prix, Genres=genres});
                libraryDbContext.SaveChanges();
            }

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new CreateBookModel() { AllGenres = libraryDbContext.Genre.ToList() } );
        }

        public ActionResult<DeleteBookModel> Delete(int id)
        {
            var books = libraryDbContext.Books.Single(element => element.Id == id);
            libraryDbContext.Remove(books);
            libraryDbContext.SaveChanges();
            List<Book> ListBooks = libraryDbContext.Books.ToList();
            return View(new DeleteBookModel() { });
        }
    }
}

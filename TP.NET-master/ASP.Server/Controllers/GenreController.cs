using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Controllers
{
    public class CreateGenreModel
    {
        [Required]
        [Display(Name = "Type")]
        public String Type { get; set; }
    }

    public class GenreController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public GenreController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }
        public ActionResult<IEnumerable<Genre>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            List<Genre> ListGenre = libraryDbContext.Genre.ToList();
            return View(ListGenre);
        }

        public ActionResult<CreateGenreModel> Create(CreateGenreModel genre) 
        {
            if (ModelState.IsValid) 
            {
                libraryDbContext.Add(new Genre() { Type = genre.Type });
                libraryDbContext.SaveChanges();
            }
            return View(new CreateGenreModel() { });
        }

        // A vous de faire comme BookController.List mais pour les genres !
    }
}

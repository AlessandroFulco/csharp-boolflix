using csharp_boolflix.Data;
using csharp_boolflix.Data.Form;
using csharp_boolflix.Data.Repositories;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        IDbMovieRepositories movieRepositories;
        BoolflixDbContext db;

        public MovieController(IDbMovieRepositories _movieRepositories, BoolflixDbContext _db) : base()
        {
            movieRepositories = _movieRepositories;
            db = _db;
        }
        public IActionResult Index()
        {
            List<Movie> movies = movieRepositories.All();
            return View(movies);
        }
        public IActionResult Create()
        {
            ViewData["title"] = "Create";

            MovieForm formData = new MovieForm();
            formData.Movie = new Movie();
            formData.Actors = db.Actors.ToList();
            formData.Categories = db.Categories.ToList();
            formData.AreCheckedActors = new List<int>();
            formData.AreCheckedCategories = new List<int>();

            return View(formData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieForm formData)
        {
            List<Actor> actors = db.Actors.ToList();
            List<Category> categories = db.Categories.ToList();

            movieRepositories.Create(formData.Movie, actors, categories);

            return RedirectToAction("Index");
        }
    }
}

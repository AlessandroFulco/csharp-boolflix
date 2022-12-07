using csharp_boolflix.Data;
using csharp_boolflix.Data.Form;
using csharp_boolflix.Data.Repositories.MyInterface;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    //[Authorize]
    public class MovieController : Controller
    {
        IDbMovieRepositories movieRepositories;
        IDbActorRepositories actorRepositories;
        IDbCategoryRepositories categoryRepositories;
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
        public IActionResult Details(int id)
        {
            Movie movie = movieRepositories.GetById(id);
            return View(movie);
        }
        public IActionResult Create()
        {
            ViewData["title"] = "Create";

            MovieForm formData = new MovieForm();
            formData.Movie = new Movie();
            formData.Actors = actorRepositories.All();
            formData.Categories = categoryRepositories.All();
            formData.AreCheckedActors = new List<int>();
            formData.AreCheckedCategories = new List<int>();

            return View(formData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieForm formData)
        {
            List<Actor> actors = new List<Actor>();
            List<Category> categories = new List<Category>();

            movieRepositories.Create(formData.Movie, actors, categories, formData.AreCheckedActors, formData.AreCheckedCategories);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            MovieForm formData = new MovieForm();
            formData.AreCheckedActors = new List<int>();
            formData.AreCheckedCategories = new List<int>();

            Movie movie = movieRepositories.GetById(id);
            if (movie == null)
                return NotFound();

            formData.Movie = movie;

            List<Actor> actors = db.Actors.ToList();
            
            foreach(Actor actor in movie.Actors)
            {
                formData.AreCheckedActors.Add(actor.Id);
            }
            formData.Actors = actors;

            List<Category> categories = db.Categories.ToList();
            
            foreach(Category category in movie.Categories)
            {
                formData.AreCheckedCategories.Add(category.Id);
            }
            formData.Categories = categories;


            return View(formData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, MovieForm formData)
        {

            Movie movie = movieRepositories.GetById(id);

            movieRepositories.Update(movie, formData.Movie, formData.AreCheckedActors, formData.AreCheckedCategories);

            return RedirectToAction("Index");
        }
    }
}

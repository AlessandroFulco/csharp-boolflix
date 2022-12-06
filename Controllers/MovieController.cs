using csharp_boolflix.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class MovieController : Controller
    {
        DbMovieRepositories movieRepositories;
        public MovieController(DbMovieRepositories _movieRepositories)
        {
            movieRepositories = _movieRepositories;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

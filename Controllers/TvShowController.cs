using csharp_boolflix.Data.Form;
using csharp_boolflix.Data.Repositories.MyInterface;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class TvShowController : Controller
    {
        private IDbTvShowRepositories tvShowRepositories;
        public TvShowController(IDbTvShowRepositories _tvShowRepositories)
        {
            tvShowRepositories = _tvShowRepositories;
        }
        public IActionResult Index()
        {
            List<TvShow> tvShows = tvShowRepositories.All();
            return View(tvShows);
        }

        //Details


        public IActionResult Create()
        {
            ViewData["title"] = "Create";
            TvShowForm formData = new TvShowForm();
            formData.TvShow = new TvShow();

            tvShowRepositories.ViewCreate(formData);

            return View(formData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TvShowForm formData)
        {
            tvShowRepositories.Create(formData.TvShow, formData.AreCheckedActors, formData.AreCheckedCategories);

            return RedirectToAction("index");
        }
        
    }
}

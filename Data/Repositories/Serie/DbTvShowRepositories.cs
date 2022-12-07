using csharp_boolflix.Data.Form;
using csharp_boolflix.Data.Repositories.MyInterface;
using csharp_boolflix.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Data.Repositories.Serie
{
    public class DbTvShowRepositories : IDbTvShowRepositories
    {
        private BoolflixDbContext db;
        IDbActorRepositories actorRepositories;
        IDbCategoryRepositories categoryRepositories;
        public DbTvShowRepositories(BoolflixDbContext _db, IDbActorRepositories _actorRepositories, IDbCategoryRepositories _categoryRepositories)
        {
            actorRepositories = _actorRepositories;
            categoryRepositories = _categoryRepositories;
            db = _db;
        }

        public List<TvShow> All()
        {
            return db.TvShows.ToList();
        }
        public TvShow GetById(int id)
        {
            return db.TvShows.Where(t => t.Id == id).Include("Seasons").Include("Episode").FirstOrDefault();
        }
        public void ViewCreate(TvShowForm formData)
        {
            formData.Actors = actorRepositories.All();
            formData.Categories = categoryRepositories.All();
            formData.AreCheckedActors = new List<int>();
            formData.AreCheckedCategories = new List<int>();
        }
        public void Create(TvShow tvShow, List<int> areCheckedActors, List<int> areCheckedCategories)
        {
            List<Actor> actors = new List<Actor>();
            List<Category> categories = new List<Category>();

            foreach (int id in areCheckedActors)
            {
                Actor actor = db.Actors.Where(a => a.Id == id).FirstOrDefault();
                actors.Add(actor);
            }


            foreach (int id in areCheckedCategories)
            {
                Category category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
                categories.Add(category);
            }

            tvShow.Actors = actors;
            tvShow.Categories = categories;

            db.TvShows.Add(tvShow);
            db.SaveChanges();
        }
    }
}

using csharp_boolflix.Data.Form;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Data.Repositories
{
    public class DbMovieRepositories : IDbMovieRepositories
    {
        private BoolflixDbContext db;

        public DbMovieRepositories(BoolflixDbContext _db)
        {
            db = _db;
        }

        public List<Movie> All()
        {
            return db.Movies.ToList();
        }
        public Movie GetById(int id)
        {
            return db.Movies.Where(m => m.Id == id).Include("Actors").Include("Categories").FirstOrDefault();
        }

        public void Create(Movie movie, List<Actor> actors, List<Category> categories)
        {
            movie.Actors = actors;
            movie.Categories = categories;

            db.Movies.Add(movie);
            db.SaveChanges();
        }

    }
}

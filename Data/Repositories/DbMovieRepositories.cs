using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories
{
    public class DbMovieRepositories
    {
        BoolflixDbContext db;

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
            return db.Movies.Where(m => m.Id == id).FirstOrDefault();
        }
    }
}

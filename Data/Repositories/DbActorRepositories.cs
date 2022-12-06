using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories
{
    public class DbActorRepositories : IDbActorRepositories
    {
        private BoolflixDbContext db;
        public DbActorRepositories(BoolflixDbContext _db)
        {
            db = _db;
        }
        public List<Actor> All()
        {
            return db.Actors.ToList();
        }
        public Actor GetById(int id)
        {
            return db.Actors.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}

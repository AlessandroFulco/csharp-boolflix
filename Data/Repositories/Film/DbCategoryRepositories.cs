using csharp_boolflix.Data.Repositories.MyInterface;
using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories.Film
{
    public class DbCategoryRepositories : IDbCategoryRepositories
    {
        private BoolflixDbContext db;
        public DbCategoryRepositories(BoolflixDbContext _db)
        {
            db = _db;
        }

        public List<Category> All()
        {
            return db.Categories.ToList();
        }
        public Category GetById(int id)
        {
            return db.Categories.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}

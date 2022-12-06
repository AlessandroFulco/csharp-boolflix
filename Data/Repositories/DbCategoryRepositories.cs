using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories
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

using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories
{
    public interface IDbCategoryRepositories
    {
        List<Category> All();
        Category GetById(int id);
    }
}
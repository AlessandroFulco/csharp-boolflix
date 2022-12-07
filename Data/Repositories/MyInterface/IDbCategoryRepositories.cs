using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories.MyInterface
{
    public interface IDbCategoryRepositories
    {
        List<Category> All();
        Category GetById(int id);
    }
}
using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories
{
    public interface IDbCategoryRepositories
    {
        Category GetById(int id);
    }
}
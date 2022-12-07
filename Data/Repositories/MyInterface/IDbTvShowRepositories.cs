using csharp_boolflix.Data.Form;
using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories.MyInterface
{
    public interface IDbTvShowRepositories
    {
        List<TvShow> All();
        TvShow GetById(int id);
        void ViewCreate(TvShowForm formData);
        void Create(TvShow tvShow, List<int> areCheckedActors, List<int> areCheckedCategories);
    }
}
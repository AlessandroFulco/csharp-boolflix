using csharp_boolflix.Data.Form;
using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories
{
    public interface IDbMovieRepositories
    {
        List<Movie> All();
        Movie GetById(int id);
        void Create(Movie movie, List<Actor> actors, List<Category> categories, List<int> areCheckedActors, List<int> areCheckedCategories);
        void Update(Movie movie, Movie formData, List<int> areCheckedActors, List<int> areCheckedCategories);
    }
}
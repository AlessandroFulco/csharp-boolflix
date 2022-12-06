using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories
{
    public interface IDbActorRepositories
    {
        List<Actor> All();
        Actor GetById(int id);
    }
}
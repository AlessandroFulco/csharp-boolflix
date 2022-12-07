using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories.MyInterface
{
    public interface IDbActorRepositories
    {
        List<Actor> All();
        Actor GetById(int id);
    }
}
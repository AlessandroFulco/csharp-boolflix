using csharp_boolflix.Models;

namespace csharp_boolflix.Data.Repositories
{
    public interface IDbActorRepositories
    {
        Actor GetById(int id);
    }
}
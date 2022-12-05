using Microsoft.Identity.Client;

namespace csharp_boolflix.Models
{
    public abstract class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Director { get; set; }
        
        public DateTime Year { get; set; }


        //relazione con actors
        public List<Actor> Actors { get; set; }

        //aggiungere la relazione con la categoria
        public List<Category> Categories { get; set; }

        //relazione con season
        public List<Season> Seasons { get; set; }
    }
}

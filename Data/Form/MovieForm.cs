using csharp_boolflix.Models;


namespace csharp_boolflix.Data.Form
{
    public class MovieForm
    {
        public Movie Movie { get; set; }
        public List<Category>? Categories { get; set; }
        public List<int>? AreCheckedCategories { get; set; }
        public List<Actor>? Actors { get; set; }
        public List<int>? AreCheckedActors{ get; set; }
    }
}

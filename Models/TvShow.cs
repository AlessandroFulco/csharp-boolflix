namespace csharp_boolflix.Models
{
    public class TvShow : Content
    {


        public TvShow() { }

        //relazione con season
        public List<Season>? Seasons { get; set; }
    }
}

namespace csharp_boolflix.Models
{
    public class Season
    {
        public int Id { get; set; }
        public int Number { get; set; }

        //relazione con content
        public int TvShowId { get; set; }
        public TvShow TvShow { get; set; }

        //relazione con episodi
        public List<Episode> Episodes { get; set; }

        public Season() { } 
    }
}

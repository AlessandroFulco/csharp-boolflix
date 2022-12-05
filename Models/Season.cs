namespace csharp_boolflix.Models
{
    public class Season
    {
        public int Id { get; set; }
        public int Number { get; set; }

        //relazione con content
        public List<Content> Contents { get; set; } 

        //relazione con episodi
        public List<Episode> Episodes { get; set;}

    }
}

namespace csharp_boolflix.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //ralazione con content 1 a N
        public int SeasonId { get; set; }
        public Season? Season { get; set; }
    }
}

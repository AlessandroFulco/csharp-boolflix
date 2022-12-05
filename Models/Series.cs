namespace csharp_boolflix.Models
{
    public class Series : Content
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        //da inserire la relazione con episode
    }
}

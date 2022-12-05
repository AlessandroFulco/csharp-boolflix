namespace csharp_boolflix.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //aggiungere la relazione con il content
        public List<Content> Contents { get; set; }
    }
}

namespace csharp_boolflix.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //aggiungere la relazione con il content
        public List<Content>? Contents { get; set; }

        public Actor() { }
        
    }
}

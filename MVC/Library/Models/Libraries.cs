namespace Library.Models
{
    public class Libraries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Books> Books { get; set; }
    }
}

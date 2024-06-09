namespace Library.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Products> Product { get; set; }
    }
}

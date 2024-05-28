namespace Library.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public int AuthorId { get; set; }
        public int LibraryId { get; set; }

    }
}

namespace MovieMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string Diretor { get; set; }
        public string? Description { get; set; }

        public Movie()
        {

        }

        public Movie(int id, string? title, string? genre, string diretor, string? description)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Diretor = diretor;
            Description = description;
        }
    }
}

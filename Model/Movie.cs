using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }
    }
}
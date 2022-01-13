using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Book
    {
        public int Id { get; set; }


        [Required]
        public string? Title { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public int Edition { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public BookCategory BookCategory { get; set; }
    }
}
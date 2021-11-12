namespace WebApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime IssueDate { get; set; }

        public string? Author { get; set; }

        public int Edition { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
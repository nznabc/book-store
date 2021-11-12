using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBook")]
        public IEnumerable<Book> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Book
            {
                Author = "Hasan",
                Edition = 5,
                IssueDate = DateTime.Now,
                Summary = "summary",
                Title = "book title"
            })
            .ToArray();
        }

        //[HttpPost]
        //public IActionResult Create(Book book)
        //{

        //}

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{

        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Book book)
        //{

        //}


    }
}
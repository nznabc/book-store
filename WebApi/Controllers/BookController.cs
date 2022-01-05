using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            this.bookService = bookService;
        }

        //[HttpGet(Name = "GetBook")]
        //public IEnumerable<Book> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new Book
        //    {
        //        Author = "Hasan",
        //        Edition = 5,
        //        IssueDate = DateTime.Now,
        //        Summary = "summary",
        //        Title = "book title"
        //    })
        //    .ToArray();
        //}

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Book>> Get()
        {
            var res = await bookService.GetAll();
            return res;
        }

        [HttpGet("GetBookById/{id}")]
        public Book GetBookById(int id)
        {
            var res = bookService.GetBookById(id);
            return res;
        }

        [HttpPost]
        public async Task<bool> Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await bookService.SaveBook(book);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("createFailed", "Unable to save changes.");
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> Update(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await bookService.UpdateBook(book);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("createFailed", "Unable to save changes.");
            }
            return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                return bookService.DeleteBook(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to delete book");
            }
            return false;
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Book book)
        //{

        //}


    }
}
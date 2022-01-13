using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
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


        public async Task<IActionResult> Index()
        {
            var res = await bookService.GetAll();

            if (!ModelState.IsValid)
            {
                return null;
            }

            return View(res.ToList());
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Update(int id)
        {
            var book = bookService.GetBookById(id);
            return View(book);
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save([FromForm] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookService.SaveBook(book);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("createFailed", "Unable to save changes.");
                _logger.LogError(ex.Message);
                return View(ex);
            }
            return View(book);
        }

        

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bookService.DeleteBook(id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(ex);
            }            
        }

        //[HttpGet("GetBookById/{id}")]
        //public Book GetBookById(int id)
        //{
        //    var res = bookService.GetBookById(id);
        //    return res;
        //}

        //[HttpPost]
        //public async Task<bool> Create(Book book)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            return await bookService.SaveBook(book);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError("createFailed", "Unable to save changes.");
        //    }
        //    return false;
        //}

        //[HttpPost]
        //public async Task<bool> Update(Book book)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            return await bookService.UpdateBook(book);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError("createFailed", "Unable to save changes.");
        //    }
        //    return false;
        //}

        //[HttpDelete]
        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        return bookService.DeleteBook(id);
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError("", "Unable to delete book");
        //    }
        //    return false;
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Book book)
        //{

        //}


    }
}
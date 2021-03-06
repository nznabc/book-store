using Models;


namespace Services
{
    public class BookService : IBookService
    {
        private readonly DataContext dataContext;

        public BookService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Task<List<Book>> GetAll()
        {
            var data = dataContext.Books.ToList();
            return Task.FromResult(data);
        }

        public Book GetBook(string name)
        {
            var data = dataContext.Books.FirstOrDefault<Book>(x => x.Title == name);
            return data;
        }

        public Book GetBookById(int id)
        {
            var data = dataContext.Books.FirstOrDefault<Book>(x => x.Id == id);
            return data;
        }

        public void SaveBook(Book book)
        {
            var result = dataContext.Books.FirstOrDefault(x => x.Id == book.Id);
            if (result == null)
            {
                dataContext.Add<Book>(book);
            }
            else
            {
                result.Title = book.Title;
                result.Summary= book.Summary;
                result.Author = book.Author;
                result.IssueDate = book.IssueDate;
                result.Edition = book.Edition;
                result.BookCategory = book.BookCategory;
                dataContext.Update<Book>(result);                
            }            
            dataContext.SaveChanges();
        }

        public bool DeleteBook(int id)
        {
            var book = dataContext.Books.FirstOrDefault<Book>(x => x.Id == id);
            if (book != null)
            {
                dataContext.Remove<Book>(book);
                dataContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var res = await dataContext.Books.FindAsync(book.Id);
            if (res != null)
            {
                book.Title = res.Title;
                book.IssueDate = res.IssueDate;
                book.Author = res.Author;
                book.Summary = res.Summary;
                dataContext.Update<Book>(res);
                await dataContext.SaveChangesAsync();
            }

            return false;
        }
    }
}

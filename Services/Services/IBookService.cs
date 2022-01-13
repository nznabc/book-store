using Models;

namespace Services
{
    public interface IBookService
    {
        Book GetBook(string name);

        Book GetBookById(int id);
        
        Task<List<Book>> GetAll();

        bool DeleteBook(int id);
        
        void SaveBook(Book book);
        Task<bool> UpdateBook(Book book);
    }
}

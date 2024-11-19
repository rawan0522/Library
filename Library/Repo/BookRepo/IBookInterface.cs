using Library.DTOs.BookDTO;
using Library.Models;

namespace Library.Repo.BookRepo
{
    public interface IBookInterface
    {
        IEnumerable<BookDTO> GetAllBooks();
        void Add(BookDTO bookDTO);
        void Update(BookDTO bookDTO , int id);
        void Delete(int id);
        void AddBookOnly(BookOnly bookOnly);
        BookDTO GetById(int id);
    }
}

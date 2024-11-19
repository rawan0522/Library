using Library.DTOs.BookDTO;
using Library.Models;
using Library.Repo.BookRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface _repo;
        public BookController(IBookInterface bookInterface)
        {
            _repo = bookInterface;
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
          var book= _repo.GetById(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
           var book= _repo.GetAllBooks();
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(BookDTO book)
        {
            _repo.Add(book);
            return Created();
        }

        [HttpPost("Book_Only")]
        public IActionResult AddBookOnly(BookOnly bookOnly)
        {
            _repo.AddBookOnly(bookOnly);
            return Created();
        }

        [HttpPut]
        public IActionResult UpdateBook(BookDTO book,int id)
        {
            _repo.Update(book, id);
                return Accepted();
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            _repo.Delete(id);
            return Accepted();
        }

    }
}

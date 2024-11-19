using Library.DTOs;
using Library.DTOs.AutherDTO;
using Library.DTOs.BookDTO;
using Library.DTOs.GenerDTO;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repo.BookRepo
{
    public class BookRepo : IBookInterface
    {
        private readonly AppDbContext _context;
        public BookRepo(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Add(BookDTO bookDTO)
        {
            var book = new Book
            {
                Title = bookDTO.Title,
                PublishedYear = bookDTO.publishedyear,

                Generes = bookDTO.Generers.Select(x => new Genere
                {
                    Name =x.Name,
                }).ToList(),
                Author=bookDTO.Authers.Select(x=> new Author
                {
                     Name=x.Name,
                     Email=x.Email,
                     PhoneNumber=x.PhoneNumber
                }).ToList(),
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void AddBookOnly(BookOnly bookOnly)
        {
            var book = new Book
            {
                Title = bookOnly.Title,
                PublishedYear = bookOnly.publishedyear,

                Author = _context.Authors.Where(x => bookOnly.AuthorID.Contains(x.Id)).ToList(),
                Generes = _context.Generes.Where(x => bookOnly.GenerID.Contains(x.Id)).ToList(),
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
               _context.Books.Remove(book);
                _context.SaveChanges();
            }
            return;
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var book = _context.Books.Include(x => x.Author).Include(x => x.Generes).Select(x => new BookDTO
            {
                Title = x.Title,
                publishedyear = x.PublishedYear,

                Authers = x.Author.Select(x => new AutherDTO
                {
                    Name = x.Name,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                }).ToList(),

                Generers = x.Generes.Select(x => new GenerDTO {
                    Name = x.Name,
                }).ToList()

            }).ToList();
            return book;
        }

        public BookDTO GetById(int id)
        {
            var book = _context.Books.Include(x => x.Generes).Include(x => x.Author).FirstOrDefault(x=>x.Id==id);
            return new BookDTO
            {
                Title = book.Title,
                publishedyear=book.PublishedYear,
                Authers=book.Author.Select(x=> new AutherDTO
                {
                    Name = x.Name,
                    Email = x.Email,
                    PhoneNumber=x.PhoneNumber,
                }).ToList(),
                Generers=book.Generes.Select(x=> new GenerDTO
                {
                    Name=x.Name,
                }).ToList(),
            };
        }

        public void Update(BookDTO bookDTO, int id)
        {
            var book = _context.Books.Include(x => x.Generes).Include(x => x.Author).FirstOrDefault(x => x.Id == id);

            book.Title= bookDTO.Title;
            book.PublishedYear = bookDTO.publishedyear;

            book.Author=bookDTO.Authers.Select(x=>new Author
            {
                Name=x.Name,
                Email=x.Email,
                PhoneNumber = x.PhoneNumber,
            }).ToList();

            book.Generes=bookDTO.Generers.Select(x=> new Genere
            {
                Name= x.Name,
            }).ToList();
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}

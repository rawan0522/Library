using Library.DTOs.AutherDTO;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repo.AutherRepo
{
    public class AutherRepo : IAutherInterface
    {
        private readonly AppDbContext _context;
        public AutherRepo(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Add(AutherOnlyDto dto)
        {
            var auther = new Author
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
            };
            if(dto.BookID != null && dto.BookID.Any())
            {
                var validBooks = _context.Books.Where(x => dto.BookID.Contains(x.Id)).ToList();
                if(validBooks != null && validBooks.Any())
                {
                    auther.Books = validBooks;
                }
            }
            _context.Authors.Add(auther);
            _context.SaveChanges();
        }

        public void AddAutherOnly(AutherOnlyDto autherOnly)
        {
            var auther = new Author
            {
                Name = autherOnly.Name,
                Email = autherOnly.Email,
                PhoneNumber = autherOnly.PhoneNumber,
                Books = _context.Books.Where(x => autherOnly.BookID.Contains(x.Id)).ToList(),
            };
            _context.Authors.Add(auther);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var auther = _context.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            if(auther != null)
            {
                _context.Remove(auther);
                _context.SaveChanges();
            }
            return;
        }

        public IEnumerable<AutherDTO> GetAllBooks()
        {
            var auther = _context.Authors.Include(x => x.Books).Select(x => new AutherDTO
            {
                Name=x.Name,
                Email=x.Email,
                PhoneNumber=x.PhoneNumber,
                Books = x.Books.Select(x=> new Book
                {
                    Title=x.Title,
                    PublishedYear=x.PublishedYear
                }).ToList(),
            }).ToList();
            return auther;
        }

        public AutherDTO GetById(int id)
        {
            var auther = _context.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            return new AutherDTO
            {
                Name = auther.Name,
                Email = auther.Email,
                PhoneNumber = auther.PhoneNumber,
                Books = auther.Books.Select(x => new Book
                {
                    Title = x.Title,
                    PublishedYear = x.PublishedYear,
                }).ToList(),
            };
        }

        public void Update(AutherOnlyDto dto, int id)
        {
            var auther = _context.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            auther.Name = dto.Name;
            auther.Email = dto.Email;
            auther.PhoneNumber = dto.PhoneNumber;
           if(dto.BookID != null && dto.BookID.Any())
           {
              var validBooks = _context.Books.Where(x => dto.BookID.Contains(x.Id)).ToList();
              if(validBooks != null && validBooks.Any())
              {
                    auther.Books = validBooks;
              }
           }
            _context.Authors.Update(auther);
            _context.SaveChanges();
        }
    }
}

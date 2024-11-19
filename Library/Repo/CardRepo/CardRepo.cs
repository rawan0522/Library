using Library.DTOs.CardDTO;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repo.CardRepo
{
    public class CardRepo : ICardInterface
    {
        private readonly AppDbContext _context;
        public CardRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(CardDTO cardDTO)
        {
            var card = new Card
            {
                Name = cardDTO.Name,
                creditnum = cardDTO.credidnum,
            };
            _context.Add(card);
            _context.SaveChanges();
        }

        public void AddCardWithAuther(AutherCard cardDto)
        {
            var card = new Card
            {
                Name = cardDto.Name,
                creditnum = cardDto.credetCard,
                Author = new Author
                {
                    Name = cardDto.Author.Name,
                    PhoneNumber = cardDto.Author.PhoneNumber,
                    Email = cardDto.Author.Email
                }
            };
            _context.Add(card);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var card = _context.Authors.Include(x => x.card).FirstOrDefault(x => x.Id == id);
            if (card != null)
            {
                _context.Remove(card);
                _context.SaveChanges();
            }
        }

        public IEnumerable<CardDTO> GetAllCard()
        {
            var card = _context.Authors.Include(x => x.card).Select(x => new CardDTO
            {
                Name =x.Name,
                credidnum=x.card.creditnum
            }).ToList();
            return card;
        }

        public CardDTO GetById(int id)
        {
            var card = _context.Authors.Include(x => x.card).FirstOrDefault(x => x.Id == id);
            return new CardDTO
            {
                Name = card.Name,
                credidnum = card.card.creditnum
            };

        }

        public void Update(CardDTO cardDTO, int id)
        {
            var card = _context.Authors.Include(x => x.card).FirstOrDefault(x => x.Id == id);
            card.Name = cardDTO.Name;
            card.card.creditnum = card.card.creditnum;
            _context.Update(card);
            _context.SaveChanges();
        }
    }
}

using Library.DTOs.BookDTO;
using Library.DTOs.CardDTO;

namespace Library.Repo.CardRepo
{
    public interface ICardInterface
    {
        IEnumerable<CardDTO> GetAllCard();
        void Add(CardDTO cardDTO);
        void Update(CardDTO cardDTO, int id);
        void Delete(int id);
        void AddCardWithAuther(AutherCard card);
        CardDTO GetById(int id);
    }
}

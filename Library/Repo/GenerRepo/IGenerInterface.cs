using Library.DTOs.GenerDTO;

namespace Library.Repo.GenerRepo
{
    public interface IGenerInterface
    {
        GenerDTO GetById(int id);
        void Update(GenerDTO dto, int id);
        void ADD(GenerDTO dto);
        void Delete(int id);
        IEnumerable<GenerDTO> GetAll();

        // Book GetByName(string name);
    }
}

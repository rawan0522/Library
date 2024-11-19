using Library.DTOs.AutherDTO;

namespace Library.Repo.AutherRepo
{
    public interface IAutherInterface
    {
        IEnumerable<AutherDTO> GetAllBooks();
        void Add(AutherOnlyDto dto);
        void Update(AutherOnlyDto dto, int id);
        void Delete(int id);
        void AddAutherOnly(AutherOnlyDto autherOnly);
        AutherDTO GetById(int id);
    }
}

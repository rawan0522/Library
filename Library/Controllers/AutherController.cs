using Library.DTOs.AutherDTO;
using Library.Migrations;
using Library.Repo.AutherRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutherController : ControllerBase
    {
        private readonly IAutherInterface _repo;

        public AutherController(IAutherInterface autherInterface)
        {
            _repo = autherInterface;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var auther = _repo.GetById(id);
            if (auther == null)
            {
                return NotFound();
            }
            return Ok(auther);
        }
        [HttpGet]
        public IActionResult GetAllAuthers()
        {
            var a = _repo.GetAllBooks();
            if (a == null)
            {
                return NotFound();
            }
            return Ok(a);
        }

        [HttpPost]
        public IActionResult Post(AutherOnlyDto dto)
        {
             _repo.Add(dto);
            return Created();
        }
        [HttpPost("Auther_Only")]
        public IActionResult AddAuther(AutherOnlyDto dto)
        {
            _repo.AddAutherOnly(dto);
            return Created();
        }

        [HttpPut]
        public IActionResult Put(AutherOnlyDto dto , int id)
        {
            _repo.Update(dto, id);
            return Accepted();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Accepted();
        }
    }
}

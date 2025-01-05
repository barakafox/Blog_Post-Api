using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trier_3.Dtos;
using Trier_3.Repositorys.RepoUser;

namespace Trier_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repo.GetAllUsers();
            return Ok(result);
        }
        [HttpGet ("GetById")]
        public IActionResult GetByID(int id)
        {
            var result = _repo.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddAll(AddAllUser dto)
        {
            _repo.AddAllUsers(dto);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _repo.DeleteAllUsers(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateAll(AddAllUser dto,int id)
        {
            _repo.UpdateAll(dto,id);
            return Created();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trier_3.Dtos;
using Trier_3.Repositorys.RepoReaction;

namespace Trier_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly IReactionRepo _repo;

        public ReactionController(IReactionRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Post(PostAllReaction dto)
        {
            _repo.PostAllReaction(dto);
            return Accepted();
        }
    }
}

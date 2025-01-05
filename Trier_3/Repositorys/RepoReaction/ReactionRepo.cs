using Trier_3.AppDbContext;
using Trier_3.Dtos;
using Trier_3.Models;

namespace Trier_3.Repositorys.RepoReaction
{
    public class ReactionRepo : IReactionRepo
    {
        private readonly dbcontext _context;

        public ReactionRepo(dbcontext context)
        {
            _context = context;
        }

        public void PostAllReaction(PostAllReaction dto)
        {
            var result = new Reaction
            {
                ReactionName = dto.ReactionName,
                User = dto.UserDto.Select(x => new User
                {
                    UserName = x.UserName,
                    UserPhone = x.UserPhone,
                    UserEmail = x.UserEmail,
                    BlogPost = x.BlogPostDto.Select(t => new BlogPost
                    {
                        BlogPostTitle = t.BlogPostTitle,
                        DateTime = DateTime.UtcNow,
                        nameofsubscribe = t.nameofsubscribe,
                        numberofsubscribe = t.numberofsubscribe,
                    }).ToList(),
                    Role = new Role
                    {
                        RoleName = x.RoleDto.RoleName,
                    }
                }).ToList(),
            };
            _context.Reactions.Add(result);
            _context.SaveChanges();
        }
    }
}

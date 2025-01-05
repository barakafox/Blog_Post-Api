using Microsoft.EntityFrameworkCore;
using Trier_3.AppDbContext;
using Trier_3.Dtos;
using Trier_3.Models;

namespace Trier_3.Repositorys.RepoUser
{
    public class UserRepo : IUserRepo
    {
        private readonly dbcontext _context;

        public UserRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddAllUsers(AddAllUser dto)
        {
            var result = new User
            {
                UserName = dto.UserName,
                UserEmail = dto.UserEmail,
                UserPhone = dto.UserPhone,
                BlogPost = dto.BlogPostDto.Select(t => new BlogPost
                {
                    BlogPostTitle = t.BlogPostTitle,
                    DateTime = DateTime.UtcNow,
                    nameofsubscribe = t.nameofsubscribe,
                    numberofsubscribe = t.numberofsubscribe,
                }).ToList(),
                Role = new Role
                {
                    RoleName = dto.RoleDto.RoleName
                },
                Reaction = dto.ReactionDto.Select(x=> new Reaction
                {
                    ReactionName = x.ReactionName,
                }).ToList(),
            };
            _context.Users.Add(result);
            _context.SaveChanges();
        }

        public void DeleteAllUsers(int id)
        {

            var result = _context.Users.
                Include(x=>x.Role).
                Include(x=>x.Reaction).
                Include(x=>x.BlogPost).
                FirstOrDefault(x=>x.UserId == id);
            
            if (result != null)
            {
                _context.Users.Remove(result);
                _context.Roles.Remove(result.Role);
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.SaveChanges();
        }

        public List<AddAllUser> GetAllUsers()
        {
            var result = _context.Users.
                Include(x => x.BlogPost).
                Include(x => x.Role).
                Include(x => x.Reaction).
                Select(t => new AddAllUser
                {
                    UserEmail = t.UserEmail,
                    UserName = t.UserName,
                    UserPhone = t.UserPhone,
                    BlogPostDto = t.BlogPost.Select(i => new BlogPostDto
                    {
                        DateTime = DateTime.UtcNow,
                        numberofsubscribe = i.numberofsubscribe,
                        BlogPostTitle = i.BlogPostTitle,
                        nameofsubscribe = i.nameofsubscribe
                    }).ToList(),
                    RoleDto = new RoleDto
                    {
                        RoleName = t.Role.RoleName,
                    },
                    ReactionDto = t.Reaction.Select(m => new ReactionDto
                    {
                        ReactionName = m.ReactionName,
                    }).ToList(),
                }).ToList();
            return result;
        }

        public AddAllUser GetById(int id)
        {
            var result = _context.Users.
                Include(x => x.BlogPost).
                Include(x => x.Role).
                Include(x => x.Reaction).
                FirstOrDefault(x => x.UserId == id);
            return new AddAllUser
            {
                UserEmail = result.UserEmail,
                UserName = result.UserName,
                UserPhone = result.UserPhone,
                BlogPostDto = result.BlogPost.Select(i=> new BlogPostDto
                {
                    BlogPostTitle= i.BlogPostTitle,
                    DateTime = DateTime.UtcNow,
                    numberofsubscribe = i.numberofsubscribe,
                    nameofsubscribe= i.nameofsubscribe
                }).ToList(),
                ReactionDto = result.Reaction.Select(m => new ReactionDto
                {
                    ReactionName = m.ReactionName,
                }).ToList(),
                RoleDto = new RoleDto
                {
                    RoleName = result.Role.RoleName,
                }
            };
        }

        public void UpdateAll(AddAllUser dto, int id)
        {
            var result = _context.Users.
                Include(x => x.BlogPost).
                Include(x => x.Role).
                Include(x => x.Reaction).
                FirstOrDefault(x => x.UserId == id);
            if (result != null)
            {
                result.UserEmail = dto.UserEmail;
                result.UserName = dto.UserName;
                result.UserPhone = dto.UserPhone;
                result.BlogPost = dto.BlogPostDto.Select(i => new BlogPost
                {
                    BlogPostTitle = i.BlogPostTitle,
                    DateTime = DateTime.UtcNow,
                    nameofsubscribe=i.nameofsubscribe,
                    numberofsubscribe=i.numberofsubscribe,
                }).ToList();
                result.Role = new Role
                {
                    RoleName = dto.RoleDto.RoleName,
                };
                result.Reaction = dto.ReactionDto.Select(i => new Reaction
                {
                    ReactionName = i.ReactionName,
                }).ToList();
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.Users.Update(result);
            _context.SaveChanges();
        }
    }
}

using Trier_3.Dtos;

namespace Trier_3.Repositorys.RepoUser
{
    public interface IUserRepo
    {
        public void AddAllUsers(AddAllUser dto);
        public void UpdateAll(AddAllUser dto, int id);
        public void DeleteAllUsers(int id);
        public List<AddAllUser> GetAllUsers();
        public AddAllUser GetById(int id);
    }
}

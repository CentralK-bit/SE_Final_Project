using MyProject.DAL;
using MyProject.DTO;

namespace MyProject.BLL
{
    public class UserService
    {
        private readonly UserRepository _repo = new();
        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            var user = _repo.Login(username, password);
            return user != null;
        }
    }
}
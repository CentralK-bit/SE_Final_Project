using MyProject.DAL;

namespace MyProject.BLL
{
    public class UserService
    {
        private readonly UserRepository _repo = new();

        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            if (string.IsNullOrWhiteSpace(password))
                return false;

            return _repo.CheckLogin(username, password);
        }
    }
}
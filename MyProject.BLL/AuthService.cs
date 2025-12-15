using MyProject.DAL;

namespace MyProject.BLL
{
    public class AuthService
    {
        private readonly UserRepository _repo;

        // Constructor cho production
        public AuthService()
        {
            _repo = new UserRepository();
        }

        // Constructor cho Unit Test (FAKE)
        public AuthService(UserRepository repo)
        {
            _repo = repo;
        }

        public virtual bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            if (string.IsNullOrWhiteSpace(password)) return false;

            return _repo.CheckLogin(username, password);
        }
    }
}
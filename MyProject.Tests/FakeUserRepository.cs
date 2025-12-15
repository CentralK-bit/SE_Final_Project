using MyProject.DAL;

namespace MyProject.Tests
{
    public class FakeUserRepository : UserRepository
    {
        public bool ResultToReturn { get; set; } = true;

        public override bool CheckLogin(string username, string password)
        {
            return ResultToReturn;
        }
    }
}
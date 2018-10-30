using MusicCollectionModel.Interfaces;

namespace MusicCollectionServices
{
    public class LogInService : ILogInService
    {
        private class UserInfo : IUserInfo
        {
            public string UserName { get; set; }

            public string LibraryName { get; set; }
        }
        public IUserInfo LogIn(string userName, string password)
        {
            if (userName.Equals("test") && password.Equals("test"))
            {
                return new UserInfo { UserName = userName, LibraryName = "TEST_LIBRARY" };
            }

            return null;
        }
    }
}
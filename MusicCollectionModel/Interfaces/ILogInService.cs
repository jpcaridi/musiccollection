using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionModel.Interfaces
{
    public interface ILogInService
    {
        IUserInfo LogIn(string userName, string password);

        bool ChangePassword(IUserInfo userInfo, string currentPassword, string newPassword);
    }
}

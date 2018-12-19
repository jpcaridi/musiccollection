using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionModel.Interfaces
{
    public interface IUserInfo
    {
        int UserId { get; }
        string UserName { get; }
    }
}

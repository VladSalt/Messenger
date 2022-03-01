using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    interface IUserRepository
    {
        UserDataModel GetUserById(int useId);
        UserDataModel GetUserByName(string username);
        IQueryable<UserDataModel> SearchUserByName(string query);
        int AddUser(UserDataModel userDataModel);
        bool UpdateUser(UserDataModel updateUserDataModel);
        bool UpdateUserState(int userId, bool userState);
    }
}

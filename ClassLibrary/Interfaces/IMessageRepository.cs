using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    interface IMessageRepository
    {
        IQueryable<MessageDataModel> GetUserMessages(int userId);
        MessageDataModel SearchUserMessages(int userId, int contactId, string query);
        bool AddMessage(MessageDataModel messageDataModel);
    }
}

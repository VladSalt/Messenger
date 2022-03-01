using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    interface IContactRepository
    {
        ContactDataModel GetUserContact(int userId, int contactId);
        IQueryable<ContactDataModel> GetUserContacts(int userId);
        ContactDataModel SearchUserContacts(int userId, string name);
        bool AddContact(ContactDataModel contactDataModel);
        bool UpdateContact(ContactDataModel updateContactDataModel);
        bool DeleteContact(int userId, int contactId);
    }
}

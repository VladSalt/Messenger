using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClassLibrary.Models;

namespace ClassLibrary
{
    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=NameDb")
        {
        }

        public virtual DbSet<ContactDataModel> ContactDataModel { get; set; }
        public virtual DbSet<MessageDataModel> MessageDataModel { get; set; }
        public virtual DbSet<UserDataModel> UserDataModel { get; set; }
    }
}

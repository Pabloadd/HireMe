using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.Models
{
    using SQLite;
    using SQLiteNetExtensions.Attributes;

    public class PostUsers
    {
        [PrimaryKey,AutoIncrement]
        public int IdPost { get; set; }
        public string UserName { get; set; }
        public string PostText { get; set; }
        public string fechaPost { get; set; }
        public string profesionPost { get; set; }
        
        [ForeignKey(typeof(UsersHm))]
        public int IdId_userhm { get; set; }
        [OneToMany]
        public UsersHm usershmpost { get; set; }
    }
}

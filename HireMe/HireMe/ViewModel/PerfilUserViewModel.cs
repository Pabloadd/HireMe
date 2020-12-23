using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.ViewModel
{
    using Models;
    class PerfilUserViewModel : BaseViewModel
    {
        public PerfilUserViewModel(UsersWorkerModel usersWorker)
        {
            this.Perfiluser = usersWorker;
        }

        

        #region Properties
        public UsersWorkerModel Perfiluser { get; set; }
       /* public string NameComplete 
        {
            get { return namecomplete; }
            set { SetValue(ref namecomplete, value); } 
        }
        public string Mail 
        {
            get { return mail; }
            set { SetValue(ref mail, value); }
        }
        public int Phone 
        { 
            get { return phone; }
            set { SetValue(ref phone, value); } 
        }
        public string Location
        {
            get { return location; }
            set { SetValue(ref location, value); }
        }
        public string Profession
        {
            get { return profession; }
            set { SetValue(ref profession, value); }
        }*/
        #endregion
    }
}

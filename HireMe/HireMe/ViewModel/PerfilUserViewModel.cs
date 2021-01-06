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
       
        #endregion
    }
}

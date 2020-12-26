using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.ViewModel
{
    using Models;
    class SearchViewModel : BaseViewModel
    {

        public SearchViewModel(UsersHm user)
        {
            LoadListUsers();
        }

        #region Attribitues
        private List<SearchItemViewModel> listUsers;
        private bool isRefreshing;
        #endregion

        #region Properties
        public List<SearchItemViewModel> ListUser
        {
            get { return listUsers;  } 
            set { SetValue(ref listUsers, value);  }
        }

        public bool IsRefreshing 
        { 
            get { return isRefreshing; } 
            set { SetValue(ref isRefreshing, value); } 
        }
        #endregion

        #region Methods
        public void LoadListUsers()
        {
            IsRefreshing = true;
            ListUser = App.Database.GetUsersWorkers();
            IsRefreshing = false;
        }
        #endregion
    }
}

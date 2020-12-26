
namespace HireMe.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;
    using View;

    class SearchViewModel : BaseViewModel
    {

        public SearchViewModel(UsersHm user)
        {
            this.user = user;
            LoadListUsers();
            
        }

        public SearchViewModel()
        {

        }

        #region Attribitues
        public UsersHm user;
        
        private List<SearchItemViewModel> listUsers;
        private bool isRefreshing;
        #endregion

        #region Commands
        
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

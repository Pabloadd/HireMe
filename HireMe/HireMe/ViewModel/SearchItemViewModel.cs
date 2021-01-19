using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using View;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class SearchItemViewModel : UsersWorkerModel
    {
        public SearchItemViewModel()
        {
            
        }

        #region attributes
        
        #endregion

        #region Property
        public ICommand SelectUserCommand
        {
            get 
            {
                return new RelayCommand(SelectUser);
            }
        }
        #endregion

        #region Methods
        private async void SelectUser()
        {
            MainViewModel.GetInstance().Perfiluser = new PerfilUserViewModel(this);
            await App.Navigator.PushAsync( new PerfilUserPage());
        }
        #endregion

    }
}

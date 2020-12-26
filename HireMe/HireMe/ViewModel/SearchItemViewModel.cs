using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using View;
    using ViewModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class SearchItemViewModel : UsersWorkerModel
    {
        public SearchItemViewModel()
        {
            
        }

        #region attributes
        UsersHm userHm;
        #endregion

        #region Property
        public ICommand SelectUserCommand
        {
            get 
            {
                return new RelayCommand(SelectUser);
            }
        }

        public ICommand SearchsPostsBtn()
        {
            return new RelayCommand(SearchsPostsMethod);
        }

        #endregion

        #region Methods
        private async void SelectUser()
        {
            MainViewModel.GetInstance().Perfiluser = new PerfilUserViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync( new PerfilUserPage());
        }

        public async void SearchsPostsMethod()
        {
            SearchViewModel Svm = new SearchViewModel();
            userHm = Svm.user;
            MainViewModel.GetInstance().SearchPostvm = new SearchPostViewModel(this.userHm);
            await Application.Current.MainPage.Navigation.PushAsync(new SearchPostPage());
        }
        #endregion

    }
}

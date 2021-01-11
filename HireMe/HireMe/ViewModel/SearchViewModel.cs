
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

        #region Constructors
        public SearchViewModel(UsersHm user)
        {
            this.user = user;
            LoadListUsers();
        }

        public SearchViewModel()
        {

        } 
        #endregion

        #region Attribitues
        public UsersHm user;

        private string filter;
        private List<SearchItemViewModel> listUsers;
        private bool isRefreshing;
        #endregion

        #region Properties
        public List<SearchItemViewModel> ListUser
        {
            get { return listUsers; }
            set { SetValue(ref listUsers, value); }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }

        public string Filter
        {
            get { return filter; }
            set 
            { 
                SetValue(ref filter, value);
                SearchProf();
            }
        }
        #endregion

        #region Commands
        public ICommand SearchsPostsBtn
        {
            get
            {
                return new RelayCommand(SearchsPostsMethod);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(SearchProf);
            }
        }
        #endregion

        #region Methods
        public void LoadListUsers()
        {
            IsRefreshing = true;
            ListUser = App.Database.GetUsersWorkers();
            IsRefreshing = false;
        }
        public async void SearchsPostsMethod()
        {
            SearchViewModel Svm = new SearchViewModel();
            MainViewModel.GetInstance().SearchPostvm = new SearchPostViewModel(this.user);
            await Application.Current.MainPage.Navigation.PushAsync(new SearchPostPage());
        }

        public async void SearchProf()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                LoadListUsers();
            }
            else
            {
                try
                {
                    IsRefreshing = true;
                    this.ListUser = App.Database.GetUsersWorkersFilter(Filter);
                    IsRefreshing = false;
                }
                catch (System.Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Mensaje",
                        e.Message,
                        "Aceptar");
                    return;
                }
            }
        }
        #endregion
    }
}

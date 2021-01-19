
namespace HireMe.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;
    using View;

    public class SearchViewModel : BaseViewModel
    {

        #region Constructors
        public SearchViewModel(UsersHm login_user)
        {
            this.login_user = login_user;
            LoadListUsers();
        }

        public SearchViewModel(string login_user_mail)
        {
            ConsultUser(login_user_mail);
            LoadListUsers();
        } 
        #endregion

        #region Attribitues
        public UsersHm login_user;

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
            MainViewModel.GetInstance().SearchPostvm = new SearchPostViewModel(this.login_user);
            await App.Navigator.PushAsync(new SearchPostPage());
            
        }
        public async void SearchProf()
        {
            /* 
             * This method is for list users through the filter, 
             * using the SearchCommand where the people write a profession
             */
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
        public void ConsultUser(string login_user_mail)
        {
            this.login_user = App.Database.getUserHm(login_user_mail).Result;
        }
        #endregion
    }
}

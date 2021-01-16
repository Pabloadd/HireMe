
namespace HireMe.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using View;
    using Models;
    using ViewModel;

    public class MenuItemViewModel
    {
        #region constructor
        public MenuItemViewModel()
        {
        }
        #endregion

        #region vars
        private UsersHm login_user;
        
        #endregion

        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }
        #endregion

        #region Methods
        private async void Navigate()
        {
            if (this.PageName == "LoginPage")
            {
                Application.Current.MainPage = new LoginPage();
            }
            if (this.PageName == "MyProfilePage")
            {
                SearchViewModel search = new SearchViewModel();
                login_user = search.getLoginUser();
                if (this.login_user == null)
                {
                    await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "Login user null",
                            "Aceptar");
                    return;
                }
                MainViewModel.GetInstance().MyProfile = new MyProfileViewModel(this.login_user);
                await Application.Current.MainPage.Navigation.PushAsync(new MyProfilePage());
            }
        }
        #endregion
    }
}

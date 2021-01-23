
namespace HireMe.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using View;
    using Helpers;

    public class MenuItemViewModel
    {
        #region constructor
        public MenuItemViewModel()
        {
        }
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
                //Settings.Login_User_ID = string.Empty;
                Settings.Login_User_Mail = string.Empty;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            if (this.PageName == "MyProfilePage")
            {
                if (string.IsNullOrEmpty(Settings.Login_User_Mail))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Alerta",
                        "Login user null 😢",
                        "ok");
                    return;
                }
                MainViewModel.GetInstance().MyProfile = new MyProfileViewModel(Settings.Login_User_Mail);
                await App.Navigator.PushAsync(new MyProfilePage());
            }
        }
        #endregion
    }
}

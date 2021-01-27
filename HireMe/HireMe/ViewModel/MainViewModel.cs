
namespace HireMe.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Themes;
    using Xamarin.Forms;

    class MainViewModel
    {
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            LoadMenu();
            //ThemeApp();
        }
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        #endregion

        #region ViewModels
        public LoginViewModel Login { get; set; }
        public RegisterViewModel Register { get; set; }

        public SearchViewModel Searchvm { get; set; }

        public SearchPostViewModel SearchPostvm { get; set; }

        public PerfilUserViewModel Perfiluser { get; set; }
        public MyProfileViewModel MyProfile { get; set; }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                instance = new MainViewModel();
            }
            return instance;
        }

        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_account",
                PageName = "MyProfilePage",
                Title = "Mi Perfil"
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                PageName = "MyProfile",
                Title = "Configurar"
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_logout",
                PageName = "LoginPage",
                Title = "Cerrar Sesion"
            });
        }
        /*private void ThemeApp()
        {
            ICollection<ResourceDictionary> dictionaries = Application.Current.Resources.MergedDictionaries;

            if (dictionaries != null)
            {
                dictionaries.Clear();
                OSAppTheme currentTheme = Application.Current.RequestedTheme;
                if (currentTheme == OSAppTheme.Dark)
                {
                    dictionaries.Add(new DarkTheme());
                }
                else if (currentTheme == OSAppTheme.Light)
                {
                    dictionaries.Add(new LightTheme());
                }
                else if(currentTheme == OSAppTheme.Unspecified)
                {
                    dictionaries.Add(new LightTheme());
                }
            }
        }*/
        #endregion

    }
}

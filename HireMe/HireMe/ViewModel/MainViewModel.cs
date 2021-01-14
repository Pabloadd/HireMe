
namespace HireMe.ViewModel
{
    using System.Collections.ObjectModel;
    class MainViewModel
    {
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            LoadMenu();
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
        #endregion

    }
}

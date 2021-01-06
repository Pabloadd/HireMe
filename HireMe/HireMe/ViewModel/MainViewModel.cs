
namespace HireMe.ViewModel
{
    class MainViewModel
    {
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            
        }
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

        
    }
}

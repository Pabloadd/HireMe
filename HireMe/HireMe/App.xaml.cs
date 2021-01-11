
namespace HireMe
{
    using View;
    using Data;
    using System.IO;
    using System;
    using Xamarin.Forms;

    public partial class App : Application
    {
        static HmDatabase database;

        public static HmDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new HmDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "hmdbproject.db3"));
                }
                return database;
            }
        }

        #region Properties
        public static NavigationPage Navigator { get; internal set; }
        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        } 
        #endregion
    }
}

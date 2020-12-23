using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HireMe
{
    using View;
    using Data;
    using System.IO;

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

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

           // MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

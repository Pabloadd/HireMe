
namespace HireMe
{
    using View;
    using Data;
    using System.IO;
    using System;
    using Xamarin.Forms;
    using Helpers;
    using ViewModel;
    using System.Collections.Generic;
    using HireMe.Themes;

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
            ThemeApp();
            if (string.IsNullOrEmpty(Settings.Login_User_Mail))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainViewModel.GetInstance().Searchvm = new SearchViewModel(Settings.Login_User_Mail);
                MainPage = new MasterPage();
            }
            //MainPage = new NavigationPage(new LoginPage());
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
        private void ThemeApp()
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
                else if (currentTheme == OSAppTheme.Unspecified)
                {
                    dictionaries.Add(new LightTheme());
                }
            }
        }
        #endregion
    }
}

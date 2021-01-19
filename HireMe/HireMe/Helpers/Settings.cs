
namespace HireMe.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    using Models;
    
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string login_user_mail = "";
        private const string login_user_id = "";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string Login_User_Mail
        {
            get
            {
                return AppSettings.GetValueOrDefault(login_user_mail, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(login_user_mail, value);
            }
        }

        public static string Login_User_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(login_user_id, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(login_user_id, value);
            }
        }
    }
}

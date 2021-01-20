
namespace HireMe.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using HireMe.Models;
    using System.Windows.Input;
    public class MyProfileViewModel : BaseViewModel
    {
        #region Constructor
        public MyProfileViewModel(string login_user_mail)
        {
            IsEnabled = false;
            IsVisible = false;
            ConsultUser(login_user_mail);
            SetUserDataForm();
            
        }
        #endregion

        #region Atributes
        private string name;
        private string lastname;
        private string password;
        private string location;
        private string profesion;
        private int phone;
        private bool isEnabled;
        private bool isVisible;

        private UsersHm login_user;
        #endregion

        #region Properties
        public string Name 
        {
            get { return name; }
            set { SetValue(ref name, value); } 
        }
        public string LastName
        {
            get { return lastname; }
            set { SetValue(ref lastname, value); }
        }
        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }
        public string Location
        {
            get { return location; }
            set { SetValue(ref location, value); }
        }
        public int Phone
        {
            get { return phone; }
            set { SetValue(ref phone, value); }
        }
        public string Profesion
        {
            get { return profesion; }
            set { SetValue(ref profesion, value); }
        }
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetValue(ref isVisible, value); }
        }
        public bool IsEnabled 
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); } 
        }
        #endregion

        #region Commands
        public ICommand EditCommand 
        { 
            get { return new RelayCommand(EditProfile);  }  
        }
        #endregion

        #region Methods
        private void EditProfile()
        {

        }
        private void SetUserDataForm()
        {
            this.Name = this.login_user.Nombre_c;
            this.LastName = this.login_user.Apellido_user;
            this.Password = this.login_user.Password_user;
            this.Location = this.login_user.Ubicacion;
            this.Phone = this.login_user.Celular;

        }
        public void ConsultUser(string login_user_mail)
        {
            this.login_user = App.Database.getUserHm(login_user_mail).Result;
        }
        #endregion
    }
}

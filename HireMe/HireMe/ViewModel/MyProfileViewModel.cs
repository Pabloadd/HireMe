
namespace HireMe.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using HireMe.Models;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MyProfileViewModel : BaseViewModel
    {
        #region Constructor
        public MyProfileViewModel(string login_user_mail)
        {
            IsEnabled = false;
            IsVisible = false;
            IsRunning = false;
            ConsultUser(login_user_mail);
            SetUserDataForm();
            
        }
        #endregion

        #region Atributes
        private string name;
        private string lastname;
        private string mail;
        private string password;
        private string location;
        private string profesion;
        private int phone;
        private bool isEnabled;
        private bool isVisible;
        private bool isRunning;

        private UsersHm login_user;
        private UsersWorkers login_user_worker;
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
        public string Mail
        {
            get { return mail; }
            set { SetValue(ref mail,value); }
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
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        #endregion

        #region Commands
        public ICommand EditCommand 
        { 
            get { return new RelayCommand(EditProfile);  }  
        }
        public ICommand SendBtn
        {
            get { return new RelayCommand(SendData); }
        }
        #endregion

        #region Methods
        private void EditProfile()
        {
            this.IsEnabled = true;
        }
        private async void SendData()
        {
            this.IsEnabled = false;
            this.IsRunning = true;
            this.login_user.Nombre_c = this.Name;
            this.login_user.Apellido_user = this.LastName;
            this.login_user.Password_user = this.Password;
            this.login_user.Mail_user = this.Mail;
            this.login_user.Ubicacion = this.Location;
            this.login_user.Celular = this.Phone;
            
            int result = await App.Database.SaveUser(login_user);
            try
            {
                if (!string.IsNullOrEmpty(this.login_user_worker.profesion))
                {
                    this.login_user_worker.Id_userhm = login_user.Id_userhm;
                    this.login_user_worker.profesion = this.Profesion;
                    int r = await App.Database.SaveUserWorker(login_user_worker);
                }
            }
            catch (System.Exception)
            {
                this.IsRunning = false;
            }
            if (result > 0)
            {

                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Mensaje",
                    "La informacion ha sido actualizada",
                    "Aceptar");
                return;
            }
            else
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Algo salio mal, intentalo más tarde",
                    "Aceptar");
                return;
            }
        }
        private void SetUserDataForm()
        {
            this.Name = this.login_user.Nombre_c;
            this.LastName = this.login_user.Apellido_user;
            this.Mail = this.login_user.Mail_user;
            this.Password = this.login_user.Password_user;
            this.Location = this.login_user.Ubicacion;
            this.Phone = this.login_user.Celular;
            try
            {
                if (!string.IsNullOrEmpty(this.login_user_worker.profesion))
                {
                    IsVisible = true;
                    this.Profesion = this.login_user_worker.profesion;
                }
            }
            catch (System.Exception)
            {
                this.IsRunning = false;
            }
            this.IsRunning = false;
        }
        public void ConsultUser(string login_user_mail)
        {
            IsRunning = true;
            this.login_user = App.Database.getUserHm(login_user_mail).Result;
            login_user_worker = App.Database.GetUserWorker(login_user.Id_userhm).Result;

        }
        #endregion
    }
}

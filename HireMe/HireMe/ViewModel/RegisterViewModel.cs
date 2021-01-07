
namespace HireMe.ViewModel
{
    using System.Windows.Input;
    using Xamarin.Forms;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using System;

    public class RegisterViewModel : BaseViewModel
    {


        #region Constructor
        public RegisterViewModel()
        {
            this.apiService = new ApiService();
            IsEnabled = true;
            IsVisibleProf = false;
        }
        #endregion


        #region Atributes
        private string profileuser;
        private string name;
        private string lastName;
        private string mail;
        private string password;
        private string location;
        private int phone;
        private string profession;
        private bool isRuning;
        private bool isEnabled;
        private bool isVisibleProf;

        private string findAddress;
        private ApiService apiService;
        private Address objAddress;
        private int flagMessageValidation = 0;
        #endregion

        #region Properties

        public string FindAddress
        {
            get { return findAddress; }
            set
            {
                SetValue(ref findAddress, value);
                // este metodo refresca el campo, pero suele reventar
                //this.Search();
            }
        }

        public string ProfileUser
        {
            get { return profileuser; }
            set
            {
                SetValue(ref profileuser, value);
                CheckUserProfile();
            }
        }
        public string Name
        {
            get { return name; }
            set { SetValue(ref name, value); }
        }

        public string LastName
        {
            get { return lastName; }
            set { SetValue(ref lastName, value); }
        }

        public string Mail
        {
            get { return mail; }
            set { SetValue(ref mail, value); }
        }

        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }

        public int Phone
        {
            get { return phone; }
            set { SetValue(ref phone, value); }
        }

        public string Location
        {
            get { return location; }
            set { SetValue(ref location, value); }
        }

        public string Profession
        {
            get { return profession; }
            set { SetValue(ref profession, value); }
        }

        public bool IsRuning
        {
            get { return isRuning; }
            set { SetValue(ref isRuning, value); }
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }

        public bool IsVisibleProf
        {
            get { return isVisibleProf; }
            set { SetValue(ref isVisibleProf, value); }
        }
        #endregion

        #region Methods
        public async void Send()
        {
            IsEnabled = false;
            IsRuning = true;
            //this region are some lines to validate the form 
            #region ValidationsLines
            if (string.IsNullOrEmpty(this.ProfileUser) || string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.LastName) ||
                string.IsNullOrEmpty(this.Mail) || string.IsNullOrEmpty(this.Password) || string.IsNullOrEmpty(this.Location))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Falta algunos datos, revise por favor",
                    "Aceptar");
                IsRuning = false;
                IsEnabled = true;
                return;
            }
            if (this.Phone <= 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Falta ingresar su numero de celular",
                    "Aceptar");
                IsRuning = false;
                IsEnabled = true;
                return;
            }
            if (this.ProfileUser.Equals("Trabajador"))
            {
                if (string.IsNullOrEmpty(this.Profession))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Debe establecer sus profesiones",
                        "Aceptar");
                    IsRuning = false;
                    IsEnabled = true;
                    return;
                }
            }
            #endregion

            if (ProfileUser.Equals("Cliente"))
            {
                try
                {
                    UsersHm userhm = new UsersHm();
                    userhm.Nombre_c = Name;
                    userhm.Apellido_user = LastName;
                    userhm.Mail_user = Mail;
                    userhm.Password_user = Password;
                    userhm.Ubicacion = Location;
                    userhm.Celular = Phone;
                    int suscces = await App.Database.SaveUser(userhm);
                    await Application.Current.MainPage.Navigation.PopAsync();
                    if (suscces > 0)
                    {
                        IsRuning = false;
                        await Application.Current.MainPage.DisplayAlert(
                        "Alerta",
                        "Lets Goo!!!",
                        "ok");
                    }
                }
                catch (Exception e)
                {
                    IsRuning = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "Alerta",
                        e.Message,
                        "ok");
                }

            }
            if (ProfileUser.Equals("Trabajador"))
            {
                try
                {
                    var userWhm = new UsersHm();
                    var userworker = new UsersWorkers();
                    userWhm.Nombre_c = Name;
                    userWhm.Apellido_user = LastName;
                    userWhm.Mail_user = Mail;
                    userWhm.Password_user = Password;
                    userWhm.Ubicacion = Location;
                    userWhm.Celular = Phone;
                    await App.Database.SaveUser(userWhm);

                    //Este metedod para obtener el ID del usurio que se ha registrado Si funciona.

                    userworker.Id_userhm = App.Database.getUserId(Mail);
                    userworker.profesion = Profession;
                    int success = await App.Database.SaveUserWorker(userworker);
                    await Application.Current.MainPage.Navigation.PopAsync();
                    if (success > 0)
                    {
                        IsRuning = false;
                        await Application.Current.MainPage.DisplayAlert(
                        "Alerta",
                        "Lets Goo!!!2",
                        "ok");
                    }
                }
                catch (Exception r)
                {
                    IsRuning = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "Alerta",
                        r.Message,
                        "ok");
                }
            }
            IsRuning = false;
            IsEnabled = true;
        }

        public async void Search()
        {
            IsRuning = true;
            if (!string.IsNullOrEmpty(FindAddress))
            {
                var response = await this.apiService.GetList<Address>(
                    "https://maps.googleapis.com",
                    "/maps",
                    "/api/place/findplacefromtext/json",
                    "input=" + FindAddress,
                    "inputtype=textquery",
                    "fields=formatted_address,name",
                    "key=AIzaSyAEXb4E0LnAFJdjuegTVp3DMvrQU2ecy-E");

                if (!response.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Mensaje",
                        response.Message,
                        "Aceptar");
                    IsRuning = false;
                    return;
                }
                // se establece un try cath aqui porque aveces suele salir un error en la
                // que forza el cierre de la app
                try
                {
                    objAddress = (Address)response.Result;
                    this.Location = objAddress.Candidates[0].Name;
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Mensaje",
                        e.Message,
                        "Aceptar");
                    IsRuning = false;
                    return;
                }

                IsRuning = false;
                //this.Address = new List<Address>(this.addressList);

            }

        }
        
        public void CheckUserProfile()
        {
            
            if (!string.IsNullOrEmpty(this.ProfileUser))
            {
                if (this.ProfileUser.Equals("Trabajador"))
                {
                    IsVisibleProf = true;
                }
                if (this.ProfileUser.Equals("Cliente"))
                {
                    IsVisibleProf = false;
                }
            }
        }
        #endregion
        
        #region Command

        public ICommand SendCommand
        {
            get
            {
                return new RelayCommand(Send);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }
        #endregion
    }

    
}

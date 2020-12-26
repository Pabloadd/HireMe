﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using View;
    using Models;
    using Xamarin.Forms;
    /*
     * USUARIOS REGISTRADOS
     * pablo@gmail.com 123 Cliente  
     * mario@gmail.com 123 Trabajador
     */
    public class LoginViewModel : BaseViewModel
    {
        
        #region Constructor
        public LoginViewModel()
        {
            this.IsSesion = true;
            this.IsEnable = true;
            //this.Mail = "pablo@gmail.com";
            //operacionDeleteTables();
        }
        #endregion

        #region Attributes
        private bool isRuning;
        private string password;
        private bool isEnable;
        private string mail;

        
        #endregion

        #region Properties
        public string Mail 
        {
            get
            {
                return mail;
            }
            set
            {
                SetValue(ref mail, value);
            }
        }
        public string Password 
        {
            get
            {
                return password;
            }
            set
            {
                SetValue(ref password, value);
            } 
        }
        public bool IsRuning 
        {
            get
            {
                return isRuning;
            }
            set
            {
                SetValue(ref isRuning, value);
            }
        }
        public bool IsSesion { get; set; }
        public bool IsEnable 
        {
            get
            {
                return isEnable;
            }
            set
            {
                SetValue(ref isEnable, value);
            }
        }

        #endregion

        #region Commands
        public ICommand LoginCommand 
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }

        

        #endregion

        #region Metodos
        private async void Login()
        {
            IsRuning = true;
            IsEnable = false;
            
            if (string.IsNullOrEmpty(this.Mail) )
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar correo electronico",
                    "Aceptar");
                IsRuning = false;
                IsEnable = true;
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar contrasena",
                    "Aceptar");
                IsRuning = false;
                IsEnable = true;
                return;
            }
            /*if(this.Mail != "pablo@gmail.com" || this.Password != "123")
            {
                
            }*/
            var validUser = App.Database.ConsultaLogin(this.Mail, this.Password);
            if (validUser <= 0 )
            {
                await Application.Current.MainPage.DisplayAlert(
                                    "Error",
                                    "El correo o contrasena incorrectos, por favor intente nuevamente",
                                    "Aceptar");
                this.Password = string.Empty;
                IsRuning = false;
                IsEnable = true;
                return;
            }
            IsRuning = false;
            IsEnable = true;
            this.Mail = string.Empty; this.Password = string.Empty;
            await Application.Current.MainPage.DisplayAlert(
                    "Mensaje",
                    "Bienvenido",
                    "Aceptar");
            //linea para obtener los datos del usuario que inicio sesion
            UsersHm user = App.Database.getUserHm(this.Mail).Result;
            //lineas para pasar a la siguiente interfaz, enlanzando la viewModel con la View
            MainViewModel.GetInstance().Searchvm = new SearchViewModel(user);
            await Application.Current.MainPage.Navigation.PushAsync(new SearchPage());
            
        }

        private async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        public void operacionDeleteTables()
        {
            App.Database.BorrarDataDB();
        }
        #endregion
    }
}


namespace HireMe.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class SearchPostViewModel : BaseViewModel
    {
        // EN EL CONSTRUCTOR SE DEBE RECIBIR EL USUARIO QUE INICO SESION
        #region constructor
        public SearchPostViewModel(UsersHm user)
        {
            sessionUser = user;
            this.LoadListPosts();
        }
        #endregion

        #region Properties
        public String EntryPostUser 
        {
            get { return entryPostUser; } 
            set { SetValue(ref entryPostUser, value); } 
        }

        public List<PostUsers> ListPosts 
        {
            get { return listPosts; } 
            set { SetValue(ref listPosts, value); } 
        }

        public bool IsRefreshingPosts
        {
            get { return isRefreshingPosts; }
            set { SetValue(ref isRefreshingPosts, value); }
        }

        
        #endregion

        #region Attributies
        private string entryPostUser;
        private List<PostUsers> listPosts;
        private bool isRefreshingPosts;

        private UsersHm sessionUser;
        #endregion

        #region Commands
        public ICommand SendPostUser
        {
            get
            {
                return new RelayCommand(SendPostMethod);
            } 
        }
        #endregion

        #region Methods
        public async void SendPostMethod()
        {
            //codigo para enviar los datos del post a la BD
            if (string.IsNullOrEmpty(this.EntryPostUser))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "La descripcion de la publicacion esta vacia!",
                        "Aceptar");
                return;
            }
            PostUsers post = new PostUsers();
            var usernamepost = sessionUser.Nombre_c +" "+ sessionUser.Apellido_user;
            post.UserName = usernamepost;
            post.PostText = this.EntryPostUser;
            post.fechaPost = DateTime.Now.ToString();
            post.IdId_userhm = sessionUser.Id_userhm;
            try
            {
                var result = await App.Database.SavePostUser(post);
                if (result > 0)
                {
                    this.EntryPostUser = string.Empty;
                    await Application.Current.MainPage.DisplayAlert(
                        "Notificacion",
                        "Su publicacion ha sido enviada.",
                        "Aceptar");
                    this.LoadListPosts();
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Algio salio Mal en la publicacion. " + e.Message,
                        "Aceptar");
            }
            
        }

        public async void LoadListPosts()
        {
            
            try
            {
                IsRefreshingPosts = true;
                this.ListPosts = App.Database.GetPosts().Result;
                IsRefreshingPosts = false;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Algio salio mal al cargar la lista. " + e.Message,
                    "Aceptar");
            }
            
        }
        #endregion
    }
}

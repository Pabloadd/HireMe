
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

        public string NameUserPost
        {
            get { return nameUserPost; }
            set { SetValue(ref nameUserPost, value); }
        }

        public string DatePost
        {
            get { return datePost; }
            set { SetValue(ref datePost, value); }
        }

        public string DescriptionPost 
        {
            get { return descriptionPost; } 
            set { SetValue(ref descriptionPost, value); } 
        }
        #endregion

        #region Attributies
        private string entryPostUser;
        private List<PostUsers> listPosts;
        private bool isRefreshingPosts;
        private string nameUserPost;
        private string datePost;
        private string descriptionPost;

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
            if (string.IsNullOrEmpty(this.DescriptionPost))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "La descripcion de la publicacion esta vacia!",
                        "Aceptar");
                return;
            }
            PostUsers post = new PostUsers();
            this.NameUserPost = sessionUser.Nombre_c +" "+ sessionUser.Apellido_user;
            post.UserName = this.NameUserPost;
            post.PostText = this.DescriptionPost;
            post.fechaPost = DateTime.UtcNow.ToString();
            post.IdId_userhm = sessionUser.Id_userhm;
            try
            {
                var result = await App.Database.SavePostUser(post);
                if (result > 0)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Notificacion",
                        "Su publicacion ha sido enviada.",
                        "Aceptar");
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
            IsRefreshingPosts = true;
            try
            {
                this.ListPosts = App.Database.GetPosts().Result;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Algio salio mal al cargar la lista. " + e.Message,
                    "Aceptar");
            }
            IsRefreshingPosts = false;
        }
        #endregion
    }
}

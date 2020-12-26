
using System.Text;

namespace HireMe.ViewModel
{
    using Models;
    using System;
    using System.Collections.Generic;
    public class SearchPostViewModel : BaseViewModel
    {
        // EN EL CONSTRUCTOR SE DEBE RECIBIR EL USUARIO QUE INICO SESION
        #region constructor
        public SearchPostViewModel()
        {

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
        #endregion

        #region Methods

        #endregion
    }
}

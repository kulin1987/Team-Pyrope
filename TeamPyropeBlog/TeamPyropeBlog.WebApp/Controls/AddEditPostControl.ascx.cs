namespace TeamPyropeBlog.WebApp.Controls
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using TeamPyropeBlog.Data;
    using Microsoft.AspNet.Identity;
    using System.Web.Security;

    public partial class AddEditPostControl : System.Web.UI.UserControl
    {
        PyropeBlogDbContext dbContext = new PyropeBlogDbContext();

        public string PostTitle
        {
            get
            {                
                return this.TextBoxTitle.Text;
            }

            set
            {
                this.TextBoxTitle.Text = value;
            }
        }

        public string PostMessage
        {
            get
            {
                return this.TextBoxMessage.Text;
            }

            set
            {
                this.TextBoxMessage.Text = value;
            }
        }

        public event EventHandler SubmitButtonClick
        {
            add
            {
                this.PostButton.Click += value;
            }
            remove
            {
                this.PostButton.Click -= value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //var currentUser = this.User.Identity.GetUserId();
            //var userName = dbContext.Users.Find(currentUser);

            //if (userName != null)
            //{
            //    this.TextBoxAuthor.Text = userName.UserName;
            //}
        }
    }
}
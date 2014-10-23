using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamPyropeBlog.Data;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace TeamPyropeBlog.WebApp
{
    public partial class _Default : Page
    {
        PyropeBlogDbContext dbContext = new PyropeBlogDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string SafeEval(string property)
        {
            string propertyValue = (string)Eval(property);
            string propertyValueEscaped = Server.HtmlEncode(propertyValue);
            return propertyValueEscaped;
        }

        protected string SafeEvalWithFormatting(string property)
        {
            string propertyValue = SafeEval(property);
            string formattedValue = propertyValue.Replace("\n", "<br/>");
            formattedValue = formattedValue.Replace(" ", "&nbsp;");
            return formattedValue;
        }

        protected string GetAuthor()
        {         
            var currentUser = this.User.Identity.GetUserId();
            var userName = dbContext.Users.Find(currentUser);

            if (userName == null)
            {
                return "";
            }
            return " (" + userName.UserName + ")";
        }

        protected bool IsEditAllowed()
        {
            //Post currentPost = (Post) this.Page.GetDataItem();
            var currentUser = this.User.Identity.GetUserId();
            var userName = dbContext.Users.Find(currentUser);

            if (userName != null)
            {
                //Guid? currentUserId = (Guid?)currentUser.ProviderUserKey;
                //if (currentPost.AuthorUserId == currentUserId)
                //{
                return true;
                //}
            }

            return false;
        }
    }
}
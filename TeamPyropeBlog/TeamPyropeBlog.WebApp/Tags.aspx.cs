using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamPyropeBlog.Data;
using TeamPyropeBlog.Models;
using Microsoft.AspNet.Identity;

namespace TeamPyropeBlog.WebApp
{
    public partial class Tags : System.Web.UI.Page
    {
        PyropeBlogDbContext dbContext = new PyropeBlogDbContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lvPostsByTag_Load(object sender, EventArgs e)
        {
            var lv = (ListView)sender;
            var a = Request.QueryString;
            var tag = Request.QueryString["tag"];
            var postsToShow = dbContext.Posts.Where(p => p.Tags.Any(t => t.Name.ToLower() == tag.ToLower())).ToList();
            lv.DataSource = postsToShow;
            lv.DataBind();
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
            var currentUser = this.User.Identity.GetUserId();
            var userName = dbContext.Users.Find(currentUser);

            if (currentUser != null)
            {
                return true;
            }

            return false;
        }

        protected IEnumerable<Tag> GetPostTags(object postId)
        {
            var id = int.Parse(postId.ToString());
            var tags = dbContext.Posts.Where(p => p.ID == id).Select(p => p.Tags).FirstOrDefault();

            return tags;
        }
    }
}
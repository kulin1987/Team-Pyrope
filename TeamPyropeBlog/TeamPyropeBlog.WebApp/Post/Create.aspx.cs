using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamPyropeBlog.WebApp.Post
{
    using System.Web.Security;

    using Microsoft.AspNet.Identity;

    using TeamPyropeBlog.Data;

    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbAuthor.Text = Context.User.Identity.Name;
        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            var context = new PyropeBlogDbContext();

            string title = this.lbTitle.Text;
            string content = this.CKEditor.Text;

            if (title.Length < 6)
            {
                FailureText.Text = "Title length must be at least 6 chars!";
                ErrorMessage.Visible = true;

            }
            else if (content.Length < 10)
            {
                FailureText.Text = "Content length must be at least 10 chars!";
                ErrorMessage.Visible = true;
            }
            else
            {
                ErrorMessage.Visible = false;
                try
                {
                    var authorId = Page.User.Identity.GetUserId();

                    var newPost = new TeamPyropeBlog.Models.PostMessage()
                    {
                        Title = title,
                        PostContent = content,
                        PostDate = DateTime.Now,
                        UserID = authorId.ToString()
                    };

                    context.Posts.Add(newPost);
                    context.SaveChanges();
                    Response.Redirect("~", false);
                }
                catch (Exception ex)
                {
                    FailureText.Text = "Server Error: " + ex.Message;
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}
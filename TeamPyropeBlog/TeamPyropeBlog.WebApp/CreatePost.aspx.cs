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
    public partial class CreatePost : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            PyropeBlogDbContext dbContext = new PyropeBlogDbContext();
            PostMessage newPost = new PostMessage();
            newPost.Title = this.TextBoxTitle.Text;
            newPost.PostContent = this.TextBoxMessage.Text;
            newPost.UserID = this.User.Identity.GetUserId();
            newPost.PostDate = DateTime.Now;


            dbContext.Posts.Add(newPost);
            dbContext.SaveChanges();
            Response.Redirect("~/Default.aspx");
        }

    }
}
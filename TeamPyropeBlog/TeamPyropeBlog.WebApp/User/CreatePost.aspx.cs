using System;
using System.Linq;
using System.Web.UI;
using TeamPyropeBlog.Data;
using TeamPyropeBlog.Models;
using Microsoft.AspNet.Identity;

namespace TeamPyropeBlog.WebApp.User
{
    public partial class CreatePost : Page
    {
        PyropeBlogDbContext dbContext = new PyropeBlogDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AddEditPostControl_SubmitButtonClick(object sender, EventArgs e)
        {
            PyropeBlogDbContext dbContext = new PyropeBlogDbContext();
            PostMessage newPost = new PostMessage();
            newPost.Title = this.AddEditPostControl.PostTitle;
            newPost.PostContent = this.AddEditPostControl.PostMessage;
            newPost.UserID = this.User.Identity.GetUserId();
            newPost.PostDate = DateTime.Now;


            dbContext.Posts.Add(newPost);
            dbContext.SaveChanges();
            Response.Redirect("~/Default.aspx");
        }

    }
}
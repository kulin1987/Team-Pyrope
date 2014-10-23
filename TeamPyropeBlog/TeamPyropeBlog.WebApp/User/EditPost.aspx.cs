using System;
using System.Linq;
using System.Web.UI;
using TeamPyropeBlog.Data;
using TeamPyropeBlog.Models;
using Microsoft.AspNet.Identity;

namespace TeamPyropeBlog.WebApp.User
{
    public partial class EditPost : Page
    {
        PyropeBlogDbContext dbContext = new PyropeBlogDbContext();
        private int postId;

        protected void Page_Load(object sender, EventArgs e)
        {
            string postIdParam = Request.Params["id"];
            this.postId = Int32.Parse(postIdParam);

            if (!IsPostBack && postIdParam != null)
            {
                PostMessage newPost = dbContext.Posts.SingleOrDefault(p => p.ID == postId);

                if (newPost != null)
                {
                    var currentUser = this.User.Identity.GetUserId();
                    var userName = dbContext.Users.Find(currentUser);

                    this.AddEditPostControl.PostTitle = newPost.Title;
                    this.AddEditPostControl.PostMessage = newPost.PostContent;

                    if (userName != null)
                    {
                        this.AddEditPostControl.PostAuthor = userName.UserName;
                    }
                }
            }
        }

        protected void AddEditPostControl_SubmitButtonClick(object sender, EventArgs e)
        {
            string title = this.AddEditPostControl.PostTitle;
            string message = this.AddEditPostControl.PostMessage;

            PostMessage post = dbContext.Posts.SingleOrDefault(p => p.ID == postId);
            post.Title = title;
            post.PostContent = message;
            post.PostDate = DateTime.Now;

            dbContext.SaveChanges();
            Response.Redirect("~/Default.aspx");
        }

    }
}
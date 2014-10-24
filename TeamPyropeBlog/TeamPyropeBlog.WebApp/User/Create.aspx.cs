using System;
using System.Linq;
using System.Web.UI;
using TeamPyropeBlog.Data;
using TeamPyropeBlog.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace TeamPyropeBlog.WebApp.User
{
    public partial class Create : Page
    {
        PyropeBlogDbContext dbContext = new PyropeBlogDbContext();
        private const int MinTagLenght = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = this.User.Identity.GetUserId();
            var userName = dbContext.Users.Find(currentUser);

            this.AddEditPostControl.PostAuthor = userName.UserName;
        }

        protected void AddEditPostControl_SubmitButtonClick(object sender, EventArgs e)
        {

            PostMessage newPost = new PostMessage();
            newPost.Title = this.AddEditPostControl.PostTitle;
            newPost.PostContent = this.AddEditPostControl.PostMessage;
            newPost.UserID = this.User.Identity.GetUserId();
            newPost.PostDate = DateTime.Now;

            var splitedTitle = this.AddEditPostControl.PostTitle.Split(new char[] { '.', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var tags = new List<Tag>();
            for (int i = 0; i < splitedTitle.Length; i++)
            {
                if (splitedTitle[i].Length >= MinTagLenght)
                {
                    var tagToLower = splitedTitle[i].ToLower();
                    var exsistingTag = dbContext.Tags.FirstOrDefault(t => t.Name.ToLower() == tagToLower);
                    if (exsistingTag != null)
                    {
                        tags.Add(exsistingTag);
                    }
                    else
                    {
                        tags.Add(new Tag { Name = splitedTitle[i] });
                    }
                }
            }

            newPost.Tags = tags;

            dbContext.Posts.Add(newPost);
            dbContext.SaveChanges();
            Response.Redirect("~/Default.aspx");
        }
    }
}
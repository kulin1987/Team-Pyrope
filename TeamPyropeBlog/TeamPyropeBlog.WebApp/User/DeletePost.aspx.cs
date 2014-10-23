namespace TeamPyropeBlog.WebApp.User
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using TeamPyropeBlog.Data;

    public partial class DeletePost : Page
    {
        private readonly PyropeBlogDbContext dbContext = new PyropeBlogDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            string postIdParam = Request.Params["id"];
            var postId = Int32.Parse(postIdParam);
            var post = this.dbContext.Posts.SingleOrDefault(p => p.ID == postId);
            this.dbContext.Posts.Remove(post);
            this.dbContext.SaveChanges();
            this.Response.Redirect("~/Default.aspx");
        }
    }
}
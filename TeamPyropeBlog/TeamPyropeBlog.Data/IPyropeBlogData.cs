namespace TeamPyropeBlog.Data
{
    using TeamPyropeBlog.Data.Repositories;
    using TeamPyropeBlog.Models;

    interface IPyropeBlogData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<PostMessage> Posts { get; }

        IRepository<Comment> Comments { get; } 

        int SaveChanges();
    }
}

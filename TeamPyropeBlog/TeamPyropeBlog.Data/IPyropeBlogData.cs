namespace TeamPyropeBlog.Data
{
    using TeamPyropeBlog.Data.Repositories;
    using TeamPyropeBlog.Models;

    interface IPyropeBlogData
    {
        IRepository<ApplicationUser> Users { get; } 

        int SaveChanges();
    }
}

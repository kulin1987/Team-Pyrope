namespace TeamPyropeBlog.Data
{
    using System;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using TeamPyropeBlog.Models;
    using TeamPyropeBlog.Data.Migrations;

    public class PyropeBlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public PyropeBlogDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PyropeBlogDbContext, Configuration>());
        }

        public virtual IDbSet<PostMessage> Posts { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public static PyropeBlogDbContext Create()
        {
            return new PyropeBlogDbContext();
        }
        
    }
}

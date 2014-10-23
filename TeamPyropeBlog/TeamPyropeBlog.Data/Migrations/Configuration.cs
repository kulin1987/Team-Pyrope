namespace TeamPyropeBlog.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TeamPyropeBlog.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TeamPyropeBlog.Data.PyropeBlogDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PyropeBlogDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Owner"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Owner" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@blog.bg"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@blog.bg" };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Administrator");
            }

            if (!context.Users.Any(u => u.UserName == "boss@blog.bg"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "boss@blog.bg" };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Owner");
            }

            if (!context.Users.Any(u => u.UserName == "venci@abv.bg"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "venci@abv.bg" };

                manager.Create(user, "123456");
            }
        }
    }
}

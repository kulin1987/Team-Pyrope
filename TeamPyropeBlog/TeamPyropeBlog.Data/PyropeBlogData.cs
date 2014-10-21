namespace TeamPyropeBlog.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using TeamPyropeBlog.Data.Repositories;
    using TeamPyropeBlog.Models;

    class PyropeBlogData : IPyropeBlogData
    {
        
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public PyropeBlogData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
    
}

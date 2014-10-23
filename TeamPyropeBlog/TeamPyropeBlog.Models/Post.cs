namespace TeamPyropeBlog.Models
{
    using System;
    using System.Collections.Generic;

    public class PostMessage
    {
        private ICollection<Comment> comments;

        public PostMessage()
        {
            this.comments = new HashSet<Comment>();
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime PostDate { get; set; }

        public string PostContent { get; set; }

        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}

namespace TeamPyropeBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tag
    {
        private ICollection<PostMessage> postMessages;

        public Tag()
        {
            this.postMessages = new HashSet<PostMessage>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PostMessage> PostMessages 
        {
            get
            {
                return this.postMessages;
            }

            set
            {
                this.postMessages = value;
            }
        }
    }
}
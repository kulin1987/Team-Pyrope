namespace TeamPyropeBlog.Models
{
    public class Comment
    {
        public Comment()
        {
            
        }

        public int ID { get; set; }

        public string Author { get; set; }

        public string CommentText { get; set; }

        public int PostID { get; set; }

        public virtual PostMessage Post { get; set; }
    }
}

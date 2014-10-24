using System;
using System.Linq;
using System.Web.UI.WebControls;
using TeamPyropeBlog.Data;

namespace TeamPyropeBlog.WebApp.Administration
{
    public partial class List : System.Web.UI.Page
    {
        PyropeBlogDbContext dbContext = new PyropeBlogDbContext();
        PyropeBlogData data;

        protected void Page_Init(object sender, EventArgs e)
        {
            data = new PyropeBlogData(dbContext);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ItemsList.DataSource = data.Users.All().ToList();
                this.DataBind();
            }
        }

        public void Delete_Item(object sender, CommandEventArgs e)
        {
            var item = data.Users.Find(e.CommandArgument.ToString());
            data.Users.Delete(item);
            dbContext.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }
    }
}
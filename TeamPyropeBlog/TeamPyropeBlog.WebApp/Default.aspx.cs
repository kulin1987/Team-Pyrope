﻿using System;
using System.Linq;
using System.Web.UI;
using TeamPyropeBlog.Data;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using TeamPyropeBlog.Models;
using System.Web.UI.WebControls;

namespace TeamPyropeBlog.WebApp
{
    public partial class _Default : Page
    {
        PyropeBlogDbContext dbContext = new PyropeBlogDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string SafeEval(string property)
        {
            string propertyValue = (string)Eval(property);
            string propertyValueEscaped = Server.HtmlEncode(propertyValue);
            return propertyValueEscaped;
        }

        protected string SafeEvalWithFormatting(string property)
        {
            string propertyValue = SafeEval(property);
            string formattedValue = propertyValue.Replace("\n", "<br/>");
            formattedValue = formattedValue.Replace(" ", "&nbsp;");
            return formattedValue;
        }

        protected string GetAuthor()
        {
            var currentUser = this.User.Identity.GetUserId();
            var userName = dbContext.Users.Find(currentUser);

            if (userName == null)
            {
                return "";
            }
            return " (" + userName.UserName + ")";
        }

        protected bool IsEditAllowed()
        {
            var currentUser = this.User.Identity.GetUserId();
            var userName = dbContext.Users.Find(currentUser);

            if (currentUser != null)
            {
                return true;
            }

            return false;
        }

        protected IEnumerable<Tag> GetPostTags(object postId)
        {
            var id = int.Parse(postId.ToString());
            var tags = dbContext.Posts.Where(p => p.ID == id).Select(p => p.Tags).FirstOrDefault();

           // return new List<Tag>();
            return tags;
        }
    }
}
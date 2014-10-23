<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeamPyropeBlog.WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Team Pyrope Blog</h1>
        <p>
            <asp:ListView ID="ListViewPosts" runat="server"
                DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <div class="post">
                        <h3 class="postTitle"><%# SafeEval("Title") + GetAuthor() %></h3>
                        <div class="postContent">
                            <%# SafeEvalWithFormatting("PostContent")%>
                            <div class="postDate" style="text-align: right"><%# Eval("PostDate") %></div>
                        <asp:Panel runat="server" style="text-align: right">
                            <a href="Administration/EditPost.aspx?id=<%# Eval("ID")%>">[Edit]</a>
                            <a href="Administration/DeletePost.aspx?id=<%# Eval("ID")%>">[Delete]</a>
                        </asp:Panel>
                        </div>

<%--                        <div class="postComments">
                            <asp:MultiView ID="MultiViewComments" runat="server"
                                ActiveViewIndex="<%# GetPostCommentsMultiViewIndex() %>">
                                <asp:View runat="server">
                                    <h4>No Comments</h4>
                                </asp:View>
                                <asp:View runat="server">
                                    <h4>Comments</h4>
                                    <asp:ListView ID="ListViewComments" runat="server"
                                        DataSource='<%# Eval("Comments") %>'>
                                        <ItemTemplate>
                                            <div class="postComment">
                                                Author: <%# SafeEval("Author") %>
                                                <br />
                                                Message: <%# SafeEval("CommentText") %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </asp:View>
                            </asp:MultiView>
                            <asp:MultiView ID="MultiViewCommentsForm" runat="server"
                                ActiveViewIndex="0">
                                <asp:View ID="ViewHiddenForm" runat="server">
                                    <asp:LinkButton ID="LinkButtonShowAddCommentForm" runat="server"
                                        OnClick="LinkButtonShowAddCommentForm_Click">
                                [Add Comment]
                                    </asp:LinkButton>
                                </asp:View>
                                <asp:View ID="ViewVisibleForm" runat="server">
                                    <h4>Add Comment</h4>
                                    <uc:addeditcommentcontrol id="AddEditCommentControl" runat="server"
                                        postid='<%# Eval("PostID") %>' validationgroup='<%# Eval("PostID") %>'
                                        onsubmitbuttonclick="AddEditCommentControl_SubmitButtonClick" />
                                </asp:View>
                            </asp:MultiView>
                        </div>--%>

                        <div class="postSeparator"></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PyropeBlogConnectionString %>" SelectCommand="SELECT [ID], [Title], [PostDate], [PostContent], [UserID] FROM [PostMessages] ORDER BY [PostDate] DESC"></asp:SqlDataSource>
        </p>
        <%--<p>
            <asp:DataPager ID="DataPagerPosts" runat="server" PagedControlID="ListViewPosts">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                </Fields>
            </asp:DataPager>
        </p>--%>
    </div>



</asp:Content>

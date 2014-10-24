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
                            <%# Eval("PostContent")%>
                            <div class="postDate" style="text-align: right"><%# Eval("PostDate") %></div>
                            <asp:Panel runat="server" Style="text-align: right" Visible="<%# IsEditAllowed()%>">
                                <a href="User/EditPost.aspx?id=<%# Eval("ID")%>">[Edit]</a>
                                <a href="User/DeletePost.aspx?id=<%# Eval("ID")%>">[Delete]</a>
                            </asp:Panel>
                            <asp:Repeater runat="server" DataSource='<%# GetPostTags(Eval("ID")) %>' ID="TagsRepeater">
                                <HeaderTemplate>
                                    <div id="tags">
                                        <em>Tags: </em>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" CssClass="btn btn-sm" NavigateUrl='<%# "Tags?tag=" + Eval("Name") %>' Text='<%# Eval("Name") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>

                        <div class="postComments">
                            <h4>Comments</h4>
                            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource2">
                                 <ItemTemplate>
                                    <div class="postComments">
                                        <h5 class="postTitle"><%# SafeEval("CommentText") %></h5>
                                        <h5 class="postTitle"><%# SafeEval("Author") %></h5>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>

                        <div class="postSeparator"></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PyropeBlogConnectionString %>" SelectCommand="SELECT [ID], [Title], [PostDate], [PostContent], [UserID] FROM [PostMessages] ORDER BY [PostDate] DESC"></asp:SqlDataSource>
        </p>
        <p>
            <asp:DataPager ID="DataPagerPosts" runat="server" PagedControlID="ListViewPosts">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                </Fields>
            </asp:DataPager>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PyropeBlogConnectionString %>" SelectCommand="SELECT * FROM [Comments]"></asp:SqlDataSource>
        </p>
    </div>



</asp:Content>

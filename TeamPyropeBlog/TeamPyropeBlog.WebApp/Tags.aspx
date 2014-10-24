<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="TeamPyropeBlog.WebApp.Tags" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>Team Pyrope Blog</h1>
        <p>
            <asp:ListView ID="ListViewPostsByTag" runat="server" OnLoad="lvPostsByTag_Load">
                <ItemTemplate>
                    <div class="post">
                        <h3 class="postTitle"><%# SafeEval("Title") + GetAuthor() %></h3>
                        <div class="postContent">
                            <%# Eval("PostContent")%>
                            <div class="postDate" style="text-align: right"><%# Eval("PostDate") %></div>
                        <asp:Panel runat="server" style="text-align: right" Visible="<%# IsEditAllowed()%>">
                            <a href="User/EditPost.aspx?id=<%# Eval("ID")%>">[Edit]</a>
                            <a href="User/DeletePost.aspx?id=<%# Eval("ID")%>">[Delete]</a>
                        </asp:Panel>
                            <asp:Repeater runat="server" DataSource='<%# GetPostTags(Eval("ID")) %>' ID="TagsRepeater">
                                <HeaderTemplate>
                                    <div id="tags"> Tags: 
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" NavigateUrl='<%# "Tags?tag=" + Eval("Name") %>' Text='<%# Eval("Name") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>

                        <div class="postSeparator"></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </p>
    </div>



</asp:Content>

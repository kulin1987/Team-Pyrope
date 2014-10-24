<%@ Page Title="CreatePost" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="TeamPyropeBlog.WebApp.User.CreatePost" %>

<%@ Register src="~/Controls/AddEditPostControl.ascx" tagname="AddEditPostControl" tagprefix="uc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>NEW POST</h2>

    <uc1:AddEditPostControl ID="AddEditPostControl" runat="server" OnSubmitButtonClick="AddEditPostControl_SubmitButtonClick" />
    

</asp:Content>

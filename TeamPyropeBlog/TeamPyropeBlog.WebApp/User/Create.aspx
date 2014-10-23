<%@ Page Language="C#" Title="NEW POST" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TeamPyropeBlog.WebApp.User.Create" %>

<%@ Register src="../Controls/AddEditPostControl.ascx" tagname="AddEditPostControl" tagprefix="uc1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
    <uc1:AddEditPostControl ID="AddEditPostControl" runat="server" OnSubmitButtonClick="AddEditPostControl_SubmitButtonClick"/>
</asp:Content>


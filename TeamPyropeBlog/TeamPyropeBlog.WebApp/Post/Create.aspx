<%@ Page Language="C#" Title="Create post" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TeamPyropeBlog.WebApp.Post.Create" %>

<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagPrefix="CKEditor" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    
    <div class="row">
        <CKEditor:CKEditorControl ID="CKEditor1" runat="server"></CKEditor:CKEditorControl>

    </div>
</asp:Content>


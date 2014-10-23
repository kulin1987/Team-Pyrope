<%@ Page Language="C#" Title="NEW POST" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TeamPyropeBlog.WebApp.Post.Create" %>

<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagPrefix="CKEditor" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
    <table>
        <tr class="postTable">
            <td>Author:
            </td>
            <td>
                <asp:Label ID="lbAuthor" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr class="postTable">
            <td>Title:
            </td>
            <td>
                <asp:TextBox ID="lbTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="postTable">
            <td>Message:
            </td>
            <td>
                <CKEditor:CKEditorControl ID="CKEditor" runat="server"></CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="PostButton" runat="server" Text="Post Message" OnClick="PostButton_Click" />
            </td>
        </tr>
    </table>
    <div class="row">
        
    </div>
</asp:Content>


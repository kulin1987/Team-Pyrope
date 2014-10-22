<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TeamPyropeBlog.WebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>NEW POST</h2>
    <table>
        <tr class="postTable">
            <td>Author:
            </td>
            <td>
                <asp:TextBox ID="TextBoxAuthor" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="postTable">
            <td>Title:
            </td>
            <td>
                <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="postTable">
            <td>Message:
            </td>
            <td>
                <asp:TextBox ID="TextBoxMessage" runat="server" Height="126px" TextMode="MultiLine" Width="440px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Post" runat="server" Text="Post Message" />
            </td>
        </tr>
    </table>
</asp:Content>

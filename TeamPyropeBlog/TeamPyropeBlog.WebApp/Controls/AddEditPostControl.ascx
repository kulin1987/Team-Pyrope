<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditPostControl.ascx.cs" Inherits="TeamPyropeBlog.WebApp.Controls.AddEditPostControl" %>

<div>
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
                <p>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle" ErrorMessage="Title should not be empty!" ForeColor="Red"></asp:RequiredFieldValidator>
                </p>
            </td>
        </tr>
        <tr class="postTable">
            <td>Message:
            </td>
            <td>
                <asp:TextBox ID="TextBoxMessage" runat="server" Height="126px" TextMode="MultiLine" Width="440px"></asp:TextBox>
                <p>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" ControlToValidate="TextBoxMessage" ErrorMessage="Message should not be empty!" ForeColor="Red"></asp:RequiredFieldValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="PostButton" runat="server" Text="Post Message"/>
            </td>
        </tr>
    </table>
</div>

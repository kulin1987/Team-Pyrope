<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditPostControl.ascx.cs" Inherits="TeamPyropeBlog.WebApp.Controls.AddEditPostControl" %>

<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagPrefix="CKEditor" %>

<script type="text/javascript">
    $(function () {
        CKEDITOR.replace('<%=TextBoxMessage.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
    });
</script>

<div>
    <table>
        <tr class="postTable">
            <td>Author:
            </td>
            <td>
                <asp:Label ID="TextBoxAuthor" runat="server"></asp:Label>
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
                <CKEditor:CKEditorControl ID="TextBoxMessage" runat="server"></CKEditor:CKEditorControl>
                <p>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" ControlToValidate="TextBoxMessage" ErrorMessage="Message should not be empty!" ForeColor="Red"></asp:RequiredFieldValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="PostButton" runat="server" Text="Save"/>
            </td>
        </tr>
    </table>
</div>

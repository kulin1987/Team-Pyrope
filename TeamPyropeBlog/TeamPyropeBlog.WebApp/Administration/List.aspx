<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Admin.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="TeamPyropeBlog.WebApp.Administration.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <h3>Users List</h3>
    <hr />
    <div class="bs-component">
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Username</th>
                    <th>Email</th>
                    <th>-</th>
                    <th>-</th>
                </tr>
            </thead>
            <tbody>

                <asp:Repeater 
                    ID="ItemsList" 
                    runat="server" 
                    ItemType="TeamPyropeBlog.Models.ApplicationUser">

                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.Id %></td>
                            <td><%#: Item.UserName %></td>
                            <td><%#: Item.Email %></td>
                            <td><a href="AddEdit.aspx?itemId=<%# Item.Id %>" class="btn btn-primary" role="button">Edit</a></td>
                            <td>
                                <asp:LinkButton 
                                    ID="deleteItem" 
                                    runat="server" 
                                    class="btn btn-danger"
                                    CommandName="Delete"
                                    OnCommand="Delete_Item"
                                    CommandArgument="<%# Item.Id %>"
                                    OnClientClick = "return confirm('Are you sure you want to delete this item?');"
                                    Text="Delete" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </div>
</asp:Content>

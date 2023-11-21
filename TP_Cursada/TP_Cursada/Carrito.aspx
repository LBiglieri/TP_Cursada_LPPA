<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TP_Cursada.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div>
    <h1>Carrito de Compras</h1>
    <asp:Repeater ID="CartRepeater" runat="server">
        <ItemTemplate>
            <div style="border: 1px solid #ccc; padding: 10px; margin: 10px;">
                <h2><%# Eval("RoomName") %></h2>
                <img src='<%# Eval("ImageUrl") %>' alt='<%# Eval("RoomName") %>' style="max-width: 300px; max-height: 200px;" />
                <p><strong>Descripción:</strong> <%# Eval("Description") %></p>
                <p><strong>Precio: $</strong> <%# Eval("Price") %></p>
                <p><strong>Cantidad:</strong>
                    <asp:Label ID="QuantityLabel" runat="server" Text='<%# Session[Eval("RoomID").ToString()] ?? 0 %>'></asp:Label>
                    <asp:Button ID="AddButton" runat="server" Text="+" OnClick="AddButton_Click" CommandArgument='<%# Eval("RoomID") %>' />
                    <asp:Button ID="RemoveButton" runat="server" Text="-" OnClick="RemoveButton_Click" CommandArgument='<%# Eval("RoomID") %>' />
                </p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>

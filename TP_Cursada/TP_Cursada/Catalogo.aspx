<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TP_Cursada.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Catalogo de habitaciones</h1>
        <div>
            <asp:Repeater ID="RoomRepeater" runat="server">
                <ItemTemplate>
                    <div style="border: 1px solid #ccc; padding: 10px; margin: 10px;">
                        <h2><%# Eval("RoomName") %></h2>
                        <img src='<%# Eval("ImageUrl") %>' alt='<%# Eval("RoomName") %>' style="max-width: 300px; max-height: 200px;" />
                        <p><strong>Descripción:</strong> <%# Eval("Description") %></p>
                        <p><strong>Precio: $</strong> <%# Eval("Price") %></p>
                        <asp:Button ID="ChangeValueButton" runat="server" Text="Reservar" OnClick="ChangeValueButton_Click" CommandArgument='<%# Eval("RoomID") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div>
        <h1>Descargar archivo XML del catálogo.</h1>
        <asp:Button ID="DownloadButton" runat="server" Text="Descargar XML" OnClick="DownloadButton_Click" />
    </div>
</asp:Content>

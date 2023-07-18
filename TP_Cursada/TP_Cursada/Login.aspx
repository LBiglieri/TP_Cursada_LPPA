<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Cursada.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br /><br />
<div>
    <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="loginlabel"></asp:Label><br />
    <asp:TextBox ID="tbUsuario" runat="server" cssclass="form-control" Width="190px">Webmaster</asp:TextBox>
    <br />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbUsuario" cssclass="text-danger" ErrorMessage="El campo de Usuario es obligatorio" />
</div>

<div class="form-group">
    <asp:Label ID="lblPassword" runat="server" Text="Contraseña" CssClass="loginlabel"></asp:Label><br />
    <asp:TextBox ID="tbPassword" runat="server" cssclass="form-control" Width="190px" Type="Password">contraseñawebmaster</asp:TextBox>
    <br />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPassword" CssClass="text-danger" ErrorMessage="La contraseña es obligatoria" />
</div>
<div class="form-group">
    <asp:Label ID="lblEstado" runat="server" CssClass="text-danger"></asp:Label>
    <br />
    <asp:Button ID="btnIngresar" runat="server" CssClass="btn-default" Text="Ingresar" OnClick="btnIngresar_Click" Width="106px" />
    <br />
</div>
</asp:Content>

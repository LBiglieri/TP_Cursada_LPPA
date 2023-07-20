<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="TP_Cursada.Backup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class=form-group>
        <asp:Button ID="btnBackup" runat="server" Text="Realizar backup" CssClass="btn-default" OnClick="btnBackup_Click" />
        <asp:Label ID="lblBackup" runat="server" Text="" CssClass="text-danger"/>
    </div>
</asp:Content>


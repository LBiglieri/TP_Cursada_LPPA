<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restore.aspx.cs" Inherits="TP_Cursada.Restore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="form-group">
        <asp:FileUpload ID="FileUpload1" runat="server" Width="678px" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnRestore" runat="server" Text="Realizar restore" CssClass="btn-default" OnClick="btnRestore_Click" />
        <asp:Label ID="lblRestore" runat="server" Text="" CssClass="text-danger" />
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restore.aspx.cs" Inherits="TP_Cursada.Restore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div >
        <asp:FileUpload ID="FileUploadRestore" runat="server" Width="700px"/>
    </div>
    <div >
        <br />
        <asp:Button ID="btnRestore" runat="server" Text="Realizar Restore" CssClass="btn-danger" OnClick="btnRestore_Click"/>
        <asp:Label ID="lblRestore" runat="server" Text="" CssClass="text-danger"/>
    </div>

</asp:Content>

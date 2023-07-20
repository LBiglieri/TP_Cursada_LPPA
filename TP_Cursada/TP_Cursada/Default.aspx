<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Cursada._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Proyecto de cursada</h1>
        <p class="lead">Integrantes: Ivan Yedro, María Florencia Centauro, Gianfranco Guillermo Callera, Pedro Bautista Contreras y Lautaro Biglieri. </p>
    </div>
	<div class="content">
        <asp:GridView ID="GridView1" runat="server" Height="263px" Width="791px"></asp:GridView>
        <br />
        <asp:Button ID="btnRecalcularDV" runat="server" CssClass="btn-default" Text="Recalcular DV" OnClick="btnRecalcularDV_Click" Width="150px"/>
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
</asp:Content>


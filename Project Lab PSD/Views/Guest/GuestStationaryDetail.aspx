<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/GuestNav.Master" AutoEventWireup="true" CodeBehind="GuestStationaryDetail.aspx.cs" Inherits="Project_Lab_PSD.Views.Guest.GuestStationaryDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Stationery Detail</h1>

    <div>
        <asp:Label ID="ProdName" runat="server" Text="Product Name: "></asp:Label>
        <asp:Label ID="lblStationeryName" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="ProdPrice" runat="server" Text="Product Price: "></asp:Label>
        <asp:Label ID="lblStationeryPrice" runat="server" Text=""></asp:Label>
    </div>


</asp:Content>

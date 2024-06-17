<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/CustomerNav.Master" AutoEventWireup="true" CodeBehind="CustomerUpdateStationery.aspx.cs" Inherits="Project_Lab_PSD.Views.Customer.CustomerUpdateStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Update Cart</h1>

    <div>
        <asp:Label ID="ProdName" runat="server" Text="Product Name: "></asp:Label>
        <asp:Label ID="lblStationeryName" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="ProdPrice" runat="server" Text="Product Price: "></asp:Label>
        <asp:Label ID="lblStationeryPrice" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" />
    </div>

    <div>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
    </div>


</asp:Content>

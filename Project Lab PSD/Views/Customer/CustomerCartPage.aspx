<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/CustomerNav.Master" AutoEventWireup="true" CodeBehind="CustomerCartPage.aspx.cs" Inherits="Project_Lab_PSD.Views.Customer.CustomerCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Cart</h1>

    <asp:GridView ID="cartGrid" runat="server" AutoGenerateColumns ="False" OnRowDeleting="cartGrid_RowDelete" >
        <Columns>

            <asp:BoundField DataField="StationeryName" HeaderText="Name" SortExpression="StationeryName" />
            <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="StationeryPrice" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="Update" ShowHeader="True" Text="Update" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Remove" ShowHeader="True" Text="Remove" />

        </Columns>
    </asp:GridView>

    <div>
        <asp:Button ID="Checkout" runat="server" Text="Checkout" />
    </div>

    <div>
        <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>

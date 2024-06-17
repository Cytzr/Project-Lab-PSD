<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/CustomerNav.Master" AutoEventWireup="true" CodeBehind="CustomerStationeryPage.aspx.cs" Inherits="Project_Lab_PSD.Views.Customer.CustomerStationeryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Stationery Page</h1>

    <asp:GridView ID="stationeryGrid" runat="server" AutoGenerateColumns ="False" OnSelectedIndexChanging="stationeryGrid_RowCommand">
        <Columns>

            <asp:BoundField DataField="StationeryName" HeaderText="Name" SortExpression="StationeryName" />
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Details" ShowHeader="true" Text="Detail" />

        </Columns>
    </asp:GridView>

    <div>
        <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>

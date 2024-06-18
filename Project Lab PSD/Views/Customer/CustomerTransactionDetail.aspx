<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/CustomerNav.Master" AutoEventWireup="true" CodeBehind="CustomerTransactionDetail.aspx.cs" Inherits="Project_Lab_PSD.Views.Customer.CustomerTransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
     <asp:GridView ID="detailGrid" runat="server" AutoGenerateColumns ="False">
        <Columns>

            <asp:BoundField DataField="StationeryName" HeaderText="Stationary Name" SortExpression="StationeryName" />
            <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="StationeryPrice" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />

        </Columns>
    </asp:GridView>
</asp:Content>

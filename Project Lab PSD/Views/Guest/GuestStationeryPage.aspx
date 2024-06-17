<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/GuestNav.Master" AutoEventWireup="true" CodeBehind="GuestStationeryPage.aspx.cs" Inherits="Project_Lab_PSD.Views.Guest.GuestStationeryPage" %>
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
</asp:Content>

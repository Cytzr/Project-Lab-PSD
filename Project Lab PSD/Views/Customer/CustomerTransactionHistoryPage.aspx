<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/CustomerNav.Master" AutoEventWireup="true" CodeBehind="CustomerTransactionHistoryPage.aspx.cs" Inherits="Project_Lab_PSD.Views.Customer.CustomerTransactionHistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
       <asp:Label  runat="server" Text="Transaction History"></asp:Label>
    <br />
     <asp:GridView ID="historyGrid" runat="server" AutoGenerateColumns ="False" OnSelectedIndexChanging="stationeryGrid_RowCommand">
        <Columns>

            <asp:BoundField DataField="TransactionID" HeaderText="ID" SortExpression="TransactionID" />
            <asp:BoundField DataField="UserName" HeaderText="Name" SortExpression="UserName" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
          
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Details" ShowHeader="true" Text="Detail" />

        </Columns>
    </asp:GridView>
</asp:Content>

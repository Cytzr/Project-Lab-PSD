<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/CustomerNav.Master" AutoEventWireup="true" CodeBehind="CustomerTransactionDetail.aspx.cs" Inherits="Project_Lab_PSD.Views.Customer.CustomerTransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


     <asp:GridView ID="detailGrid" runat="server" AutoGenerateColumns ="False" OnSelectedIndexChanging="stationeryGrid_RowCommand">
        <Columns>

            <asp:BoundField DataField="TransactionID" HeaderText="ID" SortExpression="TransactionID" />
            <asp:BoundField DataField="UserName" HeaderText="Name" SortExpression="UserName" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
         
        </Columns>
    </asp:GridView>


</asp:Content>

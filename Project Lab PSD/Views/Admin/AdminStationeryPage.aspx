<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/AdminNav.Master" AutoEventWireup="true" CodeBehind="AdminStationeryPage.aspx.cs" Inherits="Project_Lab_PSD.Views.Admin.AdminStationeryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <asp:Button ID="insert" runat="server" Text="Insert New Product" style="margin-top:10px" OnClick="insert_Click"/>
     <div style ="margin-top: 10px">
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
           <Columns>
               <asp:BoundField DataField="StationeryId" HeaderText="Stationary Id" SortExpression="StationaryId" />
               <asp:BoundField DataField="StationeryName" HeaderText="Stationary Name" SortExpression="StationaryName" />
               <asp:BoundField DataField="StationeryPrice" HeaderText="Stationary Price" SortExpression="StationaryName" />
               <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="Delete" />
               <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="Update" ShowHeader="True" Text="Update" />
           </Columns>
       </asp:GridView>
   </div>
</asp:Content>

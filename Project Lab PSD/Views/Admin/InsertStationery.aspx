<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/AdminNav.Master" AutoEventWireup="true" CodeBehind="InsertStationery.aspx.cs" Inherits="Project_Lab_PSD.Views.Admin.InsertStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <asp:Label ID="name" runat="server" Text="Product Name"></asp:Label>
        <asp:TextBox ID="nameVal" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="price" runat="server" Text="Prodcut Price"></asp:Label>
        <asp:TextBox ID="priceVal" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="insert" runat="server" Text="Insert New Product" OnClick="insert_Click"/>
    </div>
    <asp:Label ID="Msg" runat="server" ></asp:Label>
</asp:Content>

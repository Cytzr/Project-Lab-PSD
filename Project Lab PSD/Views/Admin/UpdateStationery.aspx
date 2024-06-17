<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/AdminNav.Master" AutoEventWireup="true" CodeBehind="UpdateStationery.aspx.cs" Inherits="Project_Lab_PSD.Views.Admin.UpdateStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Old</h1>
     <div>
         <asp:Label ID="oldName" runat="server" Text="Product Name"></asp:Label>
         <asp:TextBox ID="oldNameVal" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="oldPrice" runat="server" Text="Prodcut Price"></asp:Label>
        <asp:TextBox ID="oldPriceVal" runat="server"></asp:TextBox>
    </div>

    <h1>New</h1>
    <div>
        <asp:Label ID="newName" runat="server" Text="Product Name"></asp:Label>
        <asp:TextBox ID="newNameVal" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="newPrice" runat="server" Text="Prodcut Price"></asp:Label>
        <asp:TextBox ID="newPriceVal" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="insert" runat="server" Text="Update Product" OnClick="insert_Click"/>
    </div>
 <asp:Label ID="Msg" runat="server" ></asp:Label>
</asp:Content>

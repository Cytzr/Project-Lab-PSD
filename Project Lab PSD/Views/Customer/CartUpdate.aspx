﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/CustomerNav.Master" AutoEventWireup="true" CodeBehind="CartUpdate.aspx.cs" Inherits="Project_Lab_PSD.Views.Customer.CartUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
       <h1>Stationery Detail</h1>

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
        <asp:button id="btnupdatecart" runat="server" text="Update Stationary" onclick="btnUpdateCart_click" />
    </div>

    <div>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

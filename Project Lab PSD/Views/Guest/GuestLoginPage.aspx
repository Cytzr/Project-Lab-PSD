<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/GuestNav.Master" AutoEventWireup="true" CodeBehind="GuestLoginPage.aspx.cs" Inherits="Project_Lab_PSD.Views.Guest.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

     <asp:Label ID="lblUserName" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
           <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"/>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>


</asp:Content>

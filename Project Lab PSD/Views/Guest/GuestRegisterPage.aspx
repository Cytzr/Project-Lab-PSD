<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/GuestNav.Master" AutoEventWireup="true" CodeBehind="GuestRegisterPage.aspx.cs" Inherits="Project_Lab_PSD.Views.Guest.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <asp:Label ID="lblUserName" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
            <asp:Label ID="lblPasswordConfirm" runat="server" Text="Re-enter Password:"></asp:Label>
            <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
    <br />
     <asp:Label ID="Label1" runat="server" Text="Birth date:"></asp:Label>
            <asp:TextBox ID="dateValue" runat="server" TextMode="Date"></asp:TextBox>
                      
    <br />
     <asp:Label ID="Label4" runat="server" Text="Gender:"></asp:Label>
      <asp:RadioButtonList ID="txtGender" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Phone Number:"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Register as:"></asp:Label>
      <asp:RadioButtonList ID="txtRole" runat="server">
                <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
                <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
            </asp:RadioButtonList>
    <br />
           <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click"/>
    <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>



</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/CustomerNav.Master" AutoEventWireup="true" CodeBehind="CustomerProfilePage.aspx.cs" Inherits="Project_Lab_PSD.Views.Customer.CustomerProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <asp:Label ID="Label6" runat="server" Text="Old Username:"></asp:Label>
            <asp:TextBox ID="oldUsername" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="Label7" runat="server" Text="Old Phone:"></asp:Label>
            <asp:TextBox ID="oldPhone" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Old Address:"></asp:Label>
            <asp:TextBox ID="oldAddress" runat="server"></asp:TextBox>
    <br />


    <asp:Label ID="lblUserName" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="newUserName" runat="server"></asp:TextBox>
    <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="newPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
            <asp:Label ID="lblPasswordConfirm" runat="server" Text="Re-enter Password:"></asp:Label>
            <asp:TextBox ID="newPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
    <br />
     <asp:Label ID="Label1" runat="server" Text="Birth date:"></asp:Label>
            <asp:TextBox ID="dateValue" runat="server" TextMode="Date"></asp:TextBox>
                      
    <br />
     <asp:Label ID="Label4" runat="server" Text="Gender:"></asp:Label>
      <asp:RadioButtonList ID="newGender" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Phone Number:"></asp:Label>
            <asp:TextBox ID="newPhone" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="newAddress" runat="server"></asp:TextBox>
    <br />
           <asp:Button ID="Button1" runat="server" Text="Edit" OnClick="Button1_Click"/>
    <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
</asp:Content>

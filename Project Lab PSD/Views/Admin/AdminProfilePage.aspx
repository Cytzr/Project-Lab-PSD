<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar/AdminNav.Master" AutoEventWireup="true" CodeBehind="AdminProfilePage.aspx.cs" Inherits="Project_Lab_PSD.Views.Admin.AdminProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Old</h1>
        <asp:Label ID="oldLblUserName" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="oldTxtUserName" runat="server"></asp:TextBox>
<br />
        <asp:Label ID="Label2" runat="server" Text="Phone Number:"></asp:Label>
        <asp:TextBox ID="oldTxtPhone" runat="server"></asp:TextBox>
<br />  
        <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label>
        <asp:TextBox ID="oldTxtAddress" runat="server"></asp:TextBox>
    <h1>New</h1>
        <asp:Label ID="Label6" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="newUsername" runat="server"></asp:TextBox>
<br />
        <asp:Label ID="Label7" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="newPassword" runat="server" TextMode="Password"></asp:TextBox>
<br />
        <asp:Label ID="Label8" runat="server" Text="Re-enter Password:"></asp:Label>
        <asp:TextBox ID="newPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
<br />
        <asp:Label ID="Label9" runat="server" Text="Birth date:"></asp:Label>
        <asp:TextBox ID="newDOB" runat="server" TextMode="Date"></asp:TextBox>
<br />
        <asp:Label ID="Label10" runat="server" Text="Gender:"></asp:Label>
        <asp:RadioButtonList ID="newGender" runat="server">
            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
        </asp:RadioButtonList>
<br />
        <asp:Label ID="Label11" runat="server" Text="Phone Number:"></asp:Label>
        <asp:TextBox ID="newPhone" runat="server"></asp:TextBox>
<br />  
        <asp:Label ID="Label12" runat="server" Text="Address:"></asp:Label>
        <asp:TextBox ID="newAddress" runat="server"></asp:TextBox>
<br />
       <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click"/>
<br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
</asp:Content>

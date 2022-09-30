<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BegbyDBTemp._Default" %>

<asp:Content class="content" ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Database Oppslag</h1>
    </div>

    <div class="row">
        <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
        <asp:Button class="sbutton" ID="ButtonGeyByName" runat="server" Text="Search" OnClick="ButtonGetByName_Click"/>
        <br/>
        <br/>
        <asp:GridView class="table" ID="GridView1" runat="server"></asp:GridView>
    </div>

</asp:Content>
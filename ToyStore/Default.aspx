<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToyStore._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h1><%: Page.Title  %></h1>
            <h2>Toy store provides the beutifu toys for your kids</h2>
            <p>We are the Toy people</p>
        </div>
    </div>

</asp:Content>

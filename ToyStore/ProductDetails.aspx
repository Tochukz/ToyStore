﻿<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ToyStore.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<asp:FormView ID="productDetails" 
		          ItemType="ToyStore.Models.Product" 
		          SelectMethod="GetProduct"  
		          RenderOuterTable="false"
				  runat="server">
		<ItemTemplate>
			<div>
				<h1><%#: Item.ProductName %></h1>
			</div>
			<br />
			<table>
				<tr>
					<td>
						<img src="/Catalog/Images/<%#: Item.ImagePath %>" 
							 style="border: solid; height: 300px" 
							 alt="<%#: Item.ProductName %>" />
					</td>
					<td> &nbsp; </td>
					<td style="vertical-align: top; text-align: left;">
						<strong>Description:</strong> <br />
						<%#: Item.Description %> <br />
						<span>
							<strong>Price:</strong> &nbsp; <%#: String.Format("{0:c}", Item.UnitPrice) %> 
						</span>
						<br />
						<span>
							<strong>Product Number:</strong> &nbsp; <%#: Item.ProductID %>
						</span>
						<br />						
					</td>
				</tr>
			</table>
		</ItemTemplate>
	</asp:FormView>
</asp:Content>

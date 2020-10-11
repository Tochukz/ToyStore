<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ToyStore.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div id="CartTitle" class="ContentHead" runat="server">
		<h1>Shopping Cart</h1>
	</div>
	<asp:GridView ID="CartList" 
				runat="server"
				AutoGenerateColumns="false" 
				ShowFooter="true" 
				GridLines="Vertical" 
				CellPadding="4"
				ItemType="ToyStore.Models.CartItem"
				SelectMethod="GetCartItems"
		        CssClass="table table-stripped table-bordered">
		<Columns>
			<asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />
			<asp:BoundField DataField="Product.ProductName" HeaderText="Name" /> 
			<asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (each)" DataFormatString="{0:c}" />
			<asp:TemplateField HeaderText="Quantity">
				<ItemTemplate>
					<asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" Text="<%#: Item.Quantity %>"></asp:TextBox>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<ItemTemplate>
					<%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) * (Convert.ToDouble(Item.Product.UnitPrice)))) %>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<ItemTemplate>
					<asp:CheckBox id="Remove" runat="server"></asp:Checkbox>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<div>
		<p></p>
		<strong>
			<asp:Label ID="LabelTotalText" runat="server" Text="Order Total:"></asp:Label>
			<asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
 		</strong>
	</div>
	<br />
	<table>
		<tr>
			<td>
				<asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
			</td>
			<td>
				<!--Checkout Placeholder-->
			</td>
		</tr>
	</table>
</asp:Content>

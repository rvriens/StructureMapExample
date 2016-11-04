<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="WebApp.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblNumberOfOrders" /><br />
        <asp:Button runat="server" ID="btnAdd" Text="add" OnClick="OnAddOrder_Click" />
    </div>
    </form>
</body>
</html>

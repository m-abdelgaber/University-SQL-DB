<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addMobilePhone.aspx.cs" Inherits="GUCera.Instructor.addMobilePhone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Add MobilePhone<br />
            <asp:TextBox ID="TextBox1" runat="server" MaxLength="11"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
        </div>
    </form>
</body>
</html>

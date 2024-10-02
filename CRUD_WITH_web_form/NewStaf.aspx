<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewStaf.aspx.cs" Inherits="CRUD_WITH_web_form.NewStaf" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manage Staff</h2>
            
            <!-- Input fields -->
            <asp:Label ID="lblStafID" runat="server" Text="Staff ID: "></asp:Label>
            <asp:TextBox ID="txtStafID" runat="server"></asp:TextBox><br /><br />


            
            <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br /><br />
            
            <asp:Label ID="lblPosition" runat="server" Text="Position: "></asp:Label>
            <asp:TextBox ID="txtPosition" runat="server"></asp:TextBox><br /><br />
            
            <asp:Label ID="lblSalary" runat="server" Text="Salary: "></asp:Label>
            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox><br /><br />
            
            <!-- CRUD buttons -->
            <asp:Button ID="Insert" runat="server" Text="Insert" OnClick="Insert_Click" />
            <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
            <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" /><br /><br />
            
            <!-- GridView to display staff data -->
            <asp:GridView ID="StaffGridView" runat="server" AutoGenerateColumns="True"></asp:GridView>
        </div>
    </form>
</body>
</html>

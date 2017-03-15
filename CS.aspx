<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!--In the below HTML Markup I have placed an ASP.Net Button btnLogin to
             authenticate the user through FaceBook and get its profile 
            details like FaceBook UserId, Username, Name, Email and Profile picture.-->

<asp:Button ID="btnLogin" runat="server" Text="Login with FaceBook" OnClick="Login" />

<asp:Panel ID="pnlFaceBookUser" runat="server" Visible="false">

<hr />

<table>
    <tr>
        <td rowspan="5" valign="top">
            <asp:Image ID="ProfileImage" runat="server" Width="50" Height="50" />
        </td>
    </tr>
    <tr>
        <td>ID:<asp:Label ID="lblId" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>UserName:<asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>Name:<asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>Email:<asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>
    </tr>
</table>
</asp:Panel>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_2533_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../style/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="loginf">
            <table>
                <tr>
                    <td style="width: 30%; text-align: right">用户名：</td>
                    <td>
                        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 30%; text-align: right">密码：</td>
                    <td>
                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" /><asp:Label ID="lblMe" runat="server" Style="color: #ff0000;"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

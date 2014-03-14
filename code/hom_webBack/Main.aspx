<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="hom_webBack.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="ContentScript/css/reset.css" rel="stylesheet" />
    <link href="ContentScript/css/main.css" rel="stylesheet" />
    <script src="ContentScript/js/global.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%">
                <tr>
                    <td style="width: 350px; height: 600px; background: #eee; vertical-align: top">
                        <!--dasdfasdfsadf-->
                        <ul style="margin: 20px 10px" class="nav">
                            <li><a href="../admin/Article/articel_List.aspx" target="if_right">文章管理</a></li>
                            <li><a href="../admin/ArticleClass/articelClass_List.aspx" target="if_right">类别管理</a></li>
                        </ul>
                    </td>
                    <td style="width: auto; height: 100%; vertical-align: top">
                        <iframe id="if_right" style="width: 100%; height: 100%" src="frame/right.aspx"></iframe>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="back.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../script/jquery-1.7.2.min.js"></script>
    <link href="../style/main.css" rel="stylesheet" />
    <style type="text/css">
        body {
            background: url("../img/bkg_gradient.gif") repeat-x;
        }
    </style>
    <script src="back.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:AccessDataSource ID="AccessDataSource1" runat="server"
            SelectCommand="select * from tbl_book where isdeleted=0 order by createdate desc"
            CacheKeyDependency="ADS_Orders" EnableCaching="True"
            OnSelected="AccessDataSource1_Selected"></asp:AccessDataSource>
        <div class="listdiv">
            <table class="mTable">
                <tr class="trHead">
                    <td style="width: 30px;">序号</td>
                    <td style="width: 80px;">姓名</td>
                    <td style="width: 80px;">电话</td>
                    <td style="width: 80px;">QQ</td>
                    <td style="width: 80px;">回访时间</td>
                    <td style="width: 200px;">地址</td>
                    <td>留言内容</td>
                    <td style="width: 120px;">留言时间</td>
                    <td style="width: 80px;">操作</td>
                </tr>
                <asp:Repeater ID="reBookList" runat="server" OnItemDataBound="reBookList_ItemDataBound" OnItemCommand="reBookList_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblIndex" runat="server"></asp:Label></label></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"bookname")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"tel")%></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"qq")%></td>
                            <td>
                                <asp:Label ID="lblBackLook" runat="server"></asp:Label></label>
                            </td>
                            <td><%#DataBinder.Eval(Container.DataItem,"address")%></td>
                            <td style="text-align:left;"><%#DataBinder.Eval(Container.DataItem,"Content")%></td>
                            <td><%#((DateTime)DataBinder.Eval(Container.DataItem,"CreateDate")).ToString("yyyy-MM-dd HH:mm") %></td>
                            <td>
                                <asp:Button ID="btnDel" runat="server" OnClientClick="return confirm('确认删除？')"
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>'
                                    CommandName="del" Text="删除" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center"
                OnPageChanged="AspNetPager1_PageChanged"
                Width="100%" PageSize="15">
            </webdiyer:AspNetPager>
        </div>
    </form>
    <script type="text/javascript">
        <%=scriptString%>
    </script>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/master/ContentMaster.Master" AutoEventWireup="true" CodeBehind="articel_Add.aspx.cs" Inherits="hom_webBack.admin.Article.articel_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tbl">
        <tr>
            <td class="tdLeft">标题：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="txtg"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tdLeft">排序号：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtOrderId" runat="server" CssClass="txtg"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tdLeft">类别：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtArticelClassId" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tdLeft">图片：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtPic" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tdLeft">内容：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox></td>
        </tr>
    </table>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
    </div>
</asp:Content>

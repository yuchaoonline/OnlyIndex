<%@ Page Title="" Language="C#" MasterPageFile="~/master/ContentMaster.Master" AutoEventWireup="true" CodeBehind="articelClass_Add.aspx.cs" Inherits="hom_webBack.admin.ArticleClass.ArticelClassAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tbl">
        <tr>
            <td class="tdLeft">分类名称：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtArticelClassName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tdLeft">父Id：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtPerentId" runat="server" CssClass="txtg"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tdLeft">排序号：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtOrderId" runat="server" CssClass="txtg"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tdLeft">连接地址：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtLink" runat="server" CssClass="txtg"></asp:TextBox></td>
        </tr>
    </table>
    <div class="">
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存" />
    </div>
</asp:Content>

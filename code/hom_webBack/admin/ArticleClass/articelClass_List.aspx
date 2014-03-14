<%@ Page Title="" Language="C#" MasterPageFile="~/master/ContentMaster.Master" AutoEventWireup="true" CodeBehind="articelClass_List.aspx.cs" Inherits="hom_webBack.admin.ArticleClass.ArticelClassList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>分类列表</h1>
    <a href="articelClass_Add.aspx">新增</a>
    <asp:GridView ID="gv1" runat="server" CssClass="tbl"
        AutoGenerateColumns="false"
        HeaderStyle-CssClass="tblHeader" OnRowCommand="gv1_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="OrderId" HeaderText="OrderId" />
            <asp:BoundField DataField="PerentId" HeaderText="父Id" />
            <asp:BoundField DataField="ArticelClassName" HeaderText="分类名称" />
            <asp:BoundField DataField="Link" HeaderText="连接地址" />
            <asp:BoundField DataField="CreateDate" HeaderText="创建时间" />
            <asp:BoundField DataField="UpdateDate" HeaderText="修改时间" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href='articelClass_Add.aspx?Id=<%# Eval("Id") %>'>修改</a>

                    <asp:Button ID="btnDel" runat="server" CommandName="Del" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('确认删除？')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

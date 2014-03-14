<%@ Page Title="" Language="C#" MasterPageFile="~/master/ContentMaster.Master" AutoEventWireup="true" CodeBehind="articel_List.aspx.cs" Inherits="hom_webBack.admin.Article.articel_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>文章列表</h1>
    <a href="articel_Add.aspx">新增</a>
    <asp:GridView ID="gv1" runat="server" CssClass="tbl"
        AutoGenerateColumns="false"
        HeaderStyle-CssClass="tblHeader" OnRowCommand="gv1_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Title" HeaderText="标题" />
            <asp:BoundField DataField="ArticelClassId" HeaderText="分类" />
            <asp:BoundField DataField="CreateDate" HeaderText="创建时间" />
            <asp:BoundField DataField="UpdateDate" HeaderText="修改时间" />
            <asp:BoundField DataField="IsDeleted" HeaderText="删除" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href='articel_Add.aspx?Id=<%# Eval("Id") %>'>修改</a>

                    <asp:Button ID="btnDel" runat="server" CommandName="Del" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('确认删除？')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

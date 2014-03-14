<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/blog.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">chouhom's Blog</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Scripts/Blog.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index</h2>
    <div id="indexList"></div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FootContent" runat="server">
</asp:Content>

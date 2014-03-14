<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/blog.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Articel
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%=ViewBag.Title %></h2>
    <p><%=ViewBag.Content %></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Scripts/Articel.js"></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FootContent" runat="server">
</asp:Content>

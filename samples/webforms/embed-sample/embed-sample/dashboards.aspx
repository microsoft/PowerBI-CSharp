<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dashboards.aspx.cs" Inherits="embed_sample.dashboards" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Dashboards</h2>
    <powerbi:Token ID="pbiToken" runat="server" />
    <asp:Repeater ID="dashboardList" runat="server">
        <ItemTemplate>
            <div><asp:LinkButton ID="dashboardLink" Text='<%#Eval("DisplayName")%>' CommandArgument='<%#Eval("Id") %>' OnCommand="dashboardLink_Command" runat="server" /></div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

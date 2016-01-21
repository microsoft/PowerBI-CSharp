<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" Async="true" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="embed_sample.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Label ID="dashboardTitle" runat="server" /></h2>
    <powerbi:Token ID="pbiToken" runat="server" />
    <div class="tile-grid">
        <asp:Repeater ID="tileList" runat="server">
            <ItemTemplate>
                <div class="tile-container">
                    <h3><%#Eval("Title")%></h3>
                    <powerbi:Tile ID="pbiTile" EmbedUrl='<%#Eval("EmbedUrl") %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

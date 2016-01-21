<%@ Page Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="embed_sample.report" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h2>Reports</h2>
            <asp:Repeater ID="reportList" runat="server">
                <ItemTemplate>
                    <div><asp:LinkButton ID="reportLink" Text='<%#Eval("Name")%>' CommandArgument='<%#Eval("Id") %>' OnCommand="reportLink_Command" runat="server"></asp:LinkButton></div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-6">
            <powerbi:Token ID="pbiToken" runat="server" />
            <powerbi:Report ID="pbiReport" runat="server" />
        </div>
    </div>
</asp:Content>

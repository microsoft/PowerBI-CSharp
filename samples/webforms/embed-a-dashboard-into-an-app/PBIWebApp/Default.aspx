<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PBIWebApp._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Sign in -->
    <div><h1 style="border-bottom:solid; border-bottom-color: silver">Power BI: Integrate dashboard sample web applicaton</h1>
        <asp:Panel ID="signinPanel" runat="server" Visible="true">     
            <p><b class="step">Step 1</b>: Sign in to your Power BI account to link your account to this web application.</p>
            <p>
                <asp:Button ID="signInButton" runat="server" OnClick="signInButton_Click" Text="Sign in to Power BI" />
            </p>   

            <asp:Panel ID="signInStatus" runat="server" Visible="false">
            <table>
            <tr>
                <td><b>Signed in as:</b></td>
            </tr>
            <tr>
                <td><asp:Label ID="userLabel" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><b>Access Token:</b></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="accessTokenTextbox" runat="server" Width="586px"></asp:TextBox></td>
            </tr>

            </table>
                </asp:Panel>
        </asp:Panel>   
    </div>
    <!-- Get Dashboards -->
    <div> 
        <asp:Panel ID="PanelDashboards" runat="server" Visible="true">
            <p><b class="step">Step 2</b>: Get dashboards from your account.</p>
            <table>

            <tr>
                <td><asp:Button ID="Button2" runat="server" OnClick="getDashboardsButton_Click" Text="Get Dashboards" /></td>
            </tr>
            <tr>  
                <td><asp:TextBox ID="tb_dashboardsResult" runat="server" Height="200px" Width="1024px" TextMode="MultiLine" Wrap="False"></asp:TextBox></td>
            </tr>

        </table>
        </asp:Panel>
    </div>
        <!-- Embed Dashboard-->
    <div> 
        <asp:Panel ID="PanelEmbed" runat="server" Visible="true">
            <p><b class="step">Step 3</b>: Embed a dashboard</p>
            <table>
                <tr><td>Enter an embed url for a dashboard from Step 2 (starts with https://):<br />
                    <input type="text" id="tb_EmbedURL" style="width: 1024px;" />
            <tr>
                <td>
                    <input type="button" id="bEmbedDashboardAction" value="Embed Dashboard" />
                </td>
            </tr>
                <tr>
                    <td>
                        <iframe ID="iFrameEmbedDashboard" src="" height="768px" width="1024px" frameborder="1" seamless></iframe>
                    </td>
                </tr>
        </table>
        </asp:Panel>
    </div>
</asp:Content>

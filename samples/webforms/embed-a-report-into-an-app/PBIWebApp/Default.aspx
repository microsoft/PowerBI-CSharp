<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PBIWebApp._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Sign in -->
    <div><h1 style="border-bottom:solid; border-bottom-color: silver">Power BI: Integrate report sample web applicaton</h1>
        <asp:Panel ID="signinPanel" runat="server" Visible="true">     
            <div><b class="step">Step 1</b>: Sign in to your Power BI account to link your account to this web application.</div>
            <div>
                <asp:Button ID="signInButton" runat="server" OnClick="signInButton_Click" Text="Sign in to Power BI" />
            </div>   

            <asp:Panel ID="signInStatus" runat="server" Visible="false">
                <div>
                    Signed in as: <asp:Label ID="userLabel" runat="server"></asp:Label>
                </div>
                <div>
                    Access Token: <asp:TextBox ID="accessTokenTextbox" runat="server" Width="586px"></asp:TextBox>
                </div>
            </asp:Panel>
        </asp:Panel>   
    </div>

    <hr class="stepHr" />

    <!-- Get Reports -->
    <div>
        <asp:Panel ID="PanelReports" runat="server" Visible="true">
            <div>
                <div><b class="step">Step 2</b>: Get reports from your account.</div>
                <asp:Button ID="Button2" runat="server" OnClick="getReportsButton_Click" Text="Get Reports" />
            </div>
            
            <div class="gridWrapper">
                <asp:GridView ID="GridView1" runat="server" CssClass="grid" Width="1018px">
                </asp:GridView>
            </div>
        </asp:Panel>
    </div>

    <hr class="stepHr" />

    <!-- Embed Report-->
    <div class="embedWrapper"> 
        <asp:Panel ID="PanelEmbed" runat="server" Visible="true">
            <div><b class="step">Step 3</b>: Embed a report</div>

            <div id="embedInputs">
                Embed URL (starts with https://)
                <br />
                <input type="text" id="tb_EmbedURL"/>

                <br />

                Report Id
                <br />
                <input type="text" id="tb_ReportId"/>

                <br />
                <input type="button" id="bEmbedReportAction" value="Embed Report" />

                <div class="logViewWrap">
                    Log View
                    <br />
                    <div ID="logView" style="width: 880px;"></div>
                </div>
            </div>
            <div ID="reportContainer"></div>
        </asp:Panel>
    </div>
</asp:Content>

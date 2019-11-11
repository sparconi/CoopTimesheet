<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="TeamsView.aspx.cs" Inherits="CoopTimesheet.Admin.TeamView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewGrid" runat="server">
                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 100%; text-indent: 15px;" class="VIEWHEADER">
                                <asp:Label ID="lblLookupTitle" runat="server" CssClass="VIEWHEADERLABEL">Teams</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%" class="ACTIONBAR">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="ACTIONBUTTON" OnClick="btnAdd_Click"
                                    CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%">
                                <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                    CssClass="GRIDVIEW" DataKeyNames="teamId" ForeColor="#333333" GridLines="None" Width="100%"
                                    CaptionAlign="Left" CellSpacing="1" AllowPaging="True" DataMember="DefaultView"
                                    DataSourceID="dsTeams" PageSize="15" ShowFooter="True" OnRowDataBound="grid_RowDataBound"
                                    OnSelectedIndexChanged="grid_SelectedIndexChanged">
                                    <RowStyle BackColor="White" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="TeamName" HeaderText="Team Name" ReadOnly="True" SortExpression="TeamName" />
                                        <asp:BoundField DataField="TeamManager" HeaderText="Team Manager"
                                            ReadOnly="True" SortExpression="TeamManager" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
                                    <HeaderStyle CssClass="GRIDHEADER" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="dsTeams" runat="server"
                                    SelectCommand="GetTeams" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="detailView" runat="server">
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

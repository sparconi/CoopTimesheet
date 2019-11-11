<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="TaskView.aspx.cs" Inherits="CoopTimesheet.Admin.TaskView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server"  ActiveViewIndex="0">
                <asp:View ID="ViewGrid" runat="server">
                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 100%; text-indent: 15px;" class="VIEWHEADER">
                                <asp:Label ID="lblLookupTitle" runat="server" CssClass="VIEWHEADERLABEL">Task</asp:Label>
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
                                    CssClass="GRIDVIEW" DataKeyNames="taskId" ForeColor="#333333" GridLines="None" Width="100%"
                                    CaptionAlign="Left" CellSpacing="1" AllowPaging="True" DataMember="DefaultView"
                                    DataSourceID="dsTasks" PageSize="15" ShowFooter="True" OnRowDataBound="grid_RowDataBound"
                                    OnSelectedIndexChanged="grid_SelectedIndexChanged">
                                    <RowStyle BackColor="White" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="TaskName" HeaderText="Task Name" ReadOnly="True" SortExpression="TaskName" />
                                        <asp:BoundField DataField="CrossCharge" HeaderText="Cross charge" ReadOnly="True" SortExpression="CrossCharge" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
                                    <HeaderStyle CssClass="GRIDHEADER" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="dsTasks" runat="server"
                                    SelectCommand="GetTasks" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="Detailview" runat="server">

                </asp:View>
            </asp:MultiView>   
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

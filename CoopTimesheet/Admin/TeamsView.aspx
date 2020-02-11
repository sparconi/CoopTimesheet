<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="TeamsView.aspx.cs" Inherits="CoopTimesheet.Admin.TeamView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                    <table style="width: 100%" cellpadding="0" cellspacing="0">
						<tr>
							<td style="width: 100%; text-indent: 15px;" class="VIEWHEADER">
								<asp:Label ID="lblLookupEditTitle" runat="server" CssClass="VIEWHEADERLABEL">Resource Team</asp:Label>
							</td>
						</tr>
						<tr>
							<td style="width: 100%" class="ACTIONBAR">
								<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="ACTIONBUTTON"
									Text="Save" />
								<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="ACTIONBUTTON"
									Text="Cancel" CausesValidation="False" />
							</td>
						</tr>
						<tr>
							<td style="width: 100%">
								<table style="width: 100%">
									<tr>
										<td align="right" style="width: 15%" valign="top">
											&nbsp;
										</td>
										<td style="width: 70%">
											&nbsp;
										</td>
										<td style="width: 15%">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="width: 15%" align="right" valign="top">
											&nbsp;
										</td>
										<td style="width: 70%">
											<asp:Label ID="Label4" runat="server" CssClass="LABEL" Text="Name:"></asp:Label>
										</td>
										<td style="width: 15%">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="width: 15%">
											&nbsp;
										</td>
										<td style="width: 70%">
											<asp:TextBox ID="txtTeamName" runat="server" CssClass="TEXTBOX" MaxLength="40" Width="300px"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
												Display="None" ErrorMessage="&lt;b&gt;Name is missing&lt;/b&gt;&lt;br /&gt;A name is required..."></asp:RequiredFieldValidator>
											<cc1:ValidatorCalloutExtender PopupPosition="BottomLeft" ID="rfvName_ValidatorCalloutExtender"
												runat="server" Enabled="True" TargetControlID="rfvName">
											</cc1:ValidatorCalloutExtender>--%>
										</td>
										<td style="width: 15%">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="width: 15%">
											&nbsp;
										</td>
										<td style="width: 70%">
											<asp:Label ID="Label32" runat="server" CssClass="LABEL" Text="Authorising Manager(s):"></asp:Label>
										</td>
										<td style="width: 15%">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="width: 15%">
											&nbsp;
										</td>
										<td style="width: 70%">
											<asp:DropDownList ID="ddlAuthMgr1" runat="server" CssClass="DROPDOWNLISTEDIT" Width="200px">
											</asp:DropDownList>
										</td>
										<td style="width: 15%">
											&nbsp;
										</td>
									</tr>

									<tr>
										<td style="width: 15%">
											&nbsp;
										</td>
										<td style="width: 70%">
											<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CssClass="ACTIONLINK"
												OnClick="btnDelete_Click" Text="Delete" Visible="False" />
											<cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmOnFormSubmit="True"
												ConfirmText="Ok to Delete?" Enabled="True" TargetControlID="btnDelete">
											</cc1:ConfirmButtonExtender>
										</td>
										<td style="width: 15%">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="width: 15%">
											&nbsp;
										</td>
										<td style="width: 70%">
											&nbsp;
										</td>
										<td style="width: 15%">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="width: 15%">
											&nbsp;
										</td>
										<td style="width: 70%">
											&nbsp;
										</td>
										<td style="width: 15%">
											&nbsp;
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true"
	Inherits="CoopTimesheet.Home" CodeBehind="Home.aspx.cs" %>

<%@ MasterType VirtualPath="~/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlCanSubmit" runat="server" BackColor="White">
		<table style="width: 100%" class="VIEWHEADER">
			<tr>
				<td style="width: 50%">
					<asp:Label ID="Label25" runat="server" CssClass="VIEWHEADERLABEL" Text="Welcome"></asp:Label>
				</td>
				<td style="width: 50%" align="right">
					<asp:Label ID="lblUserName" runat="server" CssClass="VIEWHEADERLABEL" Font-Size="XX-Small"></asp:Label>&nbsp;
				</td>
			</tr>
		</table>
		<p align="center">
			<asp:Label ID="Label1" runat="server" Text="Welcome to the Infrastructure & Service Delivery Timesheet"
				CssClass="LABEL" Font-Size="Medium"></asp:Label>
		</p>
		<p align="center">
			<asp:Image ID="Image3" runat="server" Height="174px" ImageUrl="~/Images/timesheet.PNG"
				Width="275  px" />
		</p>
		<p align="center" style="margin-left: 5px; margin-right: 5px">
			<asp:Label ID="lblPurposeLine1" CssClass="LABEL" runat="server" Text="The main purpose of the Log is to enable you to submit a Project request,<br />"
				Font-Size="Medium"></asp:Label>
			<asp:Label ID="Label3" CssClass="LABEL" runat="server" Text="view and track the status of all your Projects; Live, Pending and Closed."
				Font-Size="Medium"></asp:Label>
		</p>
		<hr class="LABEL" size="1" width="70%" />
		<p align="center" style="margin-left: 5px; margin-right: 5px">
			<asp:Label ID="lblProjectRequestLine1" CssClass="LABELBOLD" runat="server" Text="If you have a new Project Request, simply complete and<br />"
				Font-Size="Medium"></asp:Label>
			<asp:Label ID="lblProjectRequestLine2" CssClass="LABELBOLD" runat="server" Text="submit the online&nbsp;"
				Font-Size="Medium"></asp:Label>
			<asp:HyperLink ID="lnkEngagementForm" runat="server" NavigateUrl="NewRequest.aspx"
				CssClass="LABELBOLD" Font-Size="Medium" ForeColor="#0000CC">Engagement Form</asp:HyperLink>
		</p>
		<hr class="LABEL" size="1" width="70%" />
		<p align="center" style="margin-left: 5px; margin-right: 5px">
			<asp:Label ID="Label5" CssClass="LABEL" runat="server" Text="If you have any queries, send your details by clicking on the&nbsp;"
				Font-Size="Medium"></asp:Label>
			<asp:HyperLink ID="lnkContactUs" runat="server" NavigateUrl="ContactUs.aspx" CssClass="LABEL"
				Font-Size="Medium" ForeColor="#0000CC">Contact Us</asp:HyperLink>
			<asp:Label ID="Label6" CssClass="LABEL" runat="server" Text="&nbsp;link" Font-Size="Medium"></asp:Label>
		</p>
		<p>
			&nbsp;</p>
	</asp:Panel>
	<asp:Panel ID="pnlCannotSubmit" runat="server" BackColor="White">
		<table style="width: 100%" class="VIEWHEADER">
			<tr>
				<td style="width: 50%">
					<asp:Label ID="Label2" runat="server" CssClass="VIEWHEADERLABEL" Text="Welcome"></asp:Label>
				</td>
				<td style="width: 50%" align="right">
					<asp:Label ID="Label4" runat="server" CssClass="VIEWHEADERLABEL" Font-Size="XX-Small"></asp:Label>&nbsp;
				</td>
			</tr>
		</table>
		<p align="center">
			<asp:Label ID="Label7" runat="server" Text="Welcome to the Shared Services Infrastructure Delivery  online"
				CssClass="LABEL" Font-Size="Medium"></asp:Label>
		</p>
		<p align="center">
			<asp:Image ID="Image1" runat="server" Height="174px" ImageUrl="~/Images/P4CMLogo.JPG"
				Width="387px" />
		</p>
		<p align="center" style="margin-left: 5px; margin-right: 5px">
			<asp:Label ID="Label8" CssClass="LABEL" runat="server" Text="The main purpose of the Log is to enable you to,<br />"
				Font-Size="Medium"></asp:Label>
			<asp:Label ID="Label9" CssClass="LABEL" runat="server" Text="view and track the status of Projects; Live, Pending and Closed."
				Font-Size="Medium"></asp:Label>
		</p>
		<hr class="LABEL" size="1" width="70%" />
		<p align="center" style="margin-left: 5px; margin-right: 5px">
			<asp:Label ID="Label10" CssClass="LABELBOLD" runat="server" Text="To view ALL Projects&lt;br /&gt;"
				Font-Size="Medium"></asp:Label>
			<asp:Label ID="Label11" CssClass="LABELBOLD" runat="server" Text="click&nbsp;"
				Font-Size="Medium"></asp:Label>
			<asp:HyperLink ID="HyperLink1" runat="server" 
				NavigateUrl="ProjectsView.aspx?Type=ALL&amp;LifeCycle=0" CssClass="LABELBOLD"
				Font-Size="Medium" ForeColor="#0000CC">here</asp:HyperLink>
		</p>
		<hr class="LABEL" size="1" width="70%" />
		<p align="center" style="margin-left: 5px; margin-right: 5px">
			<asp:Label ID="Label12" CssClass="LABEL" runat="server" Text="If you have any queries, send your details by clicking on the&nbsp;"
				Font-Size="Medium"></asp:Label>
			<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="ContactUs.aspx" CssClass="LABEL"
				Font-Size="Medium" ForeColor="#0000CC">Contact Us</asp:HyperLink>
			<asp:Label ID="Label13" CssClass="LABEL" runat="server" Text="&nbsp;link" Font-Size="Medium"></asp:Label>
		</p>
		<p>
			&nbsp;</p>
	</asp:Panel>
	<table style="width: 100%">
		<tr>
			<td style="width: 10%">
				&nbsp;
			</td>
			<td style="width: 80%">
				&nbsp;
			</td>
			<td style="width: 10%">
				&nbsp;
			</td>
		</tr>
		<tr>
			<td style="width: 10%">
				&nbsp;
			</td>
			<td style="width: 80%">
			</td>
			<td style="width: 10%">
				&nbsp;
			</td>
		</tr>
		<tr>
			<td style="width: 10%">
				&nbsp;
			</td>
			<td style="width: 80%">
				&nbsp;
			</td>
			<td style="width: 10%">
				&nbsp;
			</td>
		</tr>
		<tr>
			<td style="width: 10%">
				&nbsp;
			</td>
			<td style="width: 80%">
				&nbsp;
			</td>
			<td style="width: 10%">
				&nbsp;
			</td>
		</tr>
	</table>
</asp:Content>

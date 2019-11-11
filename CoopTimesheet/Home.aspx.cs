using System;
using System.Web.UI;
using CoopTimesheet.Common;
using Utilities;

namespace CoopTimesheet
{
	public partial class Home : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Util.LoggedIn)
				Response.Redirect("~/Default.aspx");

			UserInfo userInfo = (UserInfo) Session["UserInfo"];

            lblUserName.Text = userInfo.UserName;//(string)Session["_UserName"];// 

            if (userInfo.TeamId != 0)
            {
                pnlCanSubmit.Visible = true;
                pnlCannotSubmit.Visible = false;
            }
            else
            {
                pnlCanSubmit.Visible = false;
                pnlCannotSubmit.Visible = true;
            }
        }
	}
}
using System;
using System.Web.UI;
using CoopTimesheet.Common;
using Utilities;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
//using ProjectLog.DAL.Common;

namespace CoopTimesheet
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string applicationName = Util.ApplicationName.ToUpper();
            //if (!applicationName.Contains("TEST"))
            //{
            //    if (Util.ServerName.ToLower() == "wasp")
            //        Response.Redirect("RedirectUrl.aspx");
            //}

            if (!IsPostBack)
                LoginUser();
        }

        private void LoginUser()
        {

            //DataRow dr = DAL.Settings.GetSettingData("SiteMaintenanceMode");

            //string SiteMaintenancemode = Util.ToString(dr["DataValue"]);

            //DataRow drMessage = DAL.Settings.GetSettingData("HdrMessage");

            //string HdrMessage = Util.ToString(drMessage["DataValue"]);
            //Session["HdrMessage"] = HdrMessage;

            //string testUserName = Util.ToString(Session["ZTestUserName"]);
            
            string userLoginName = System.Web.HttpContext.Current.User.Identity.Name.ToString(); //Util.CurrentUser;

Util.LoggedIn = false;
            if (userLoginName == "")// && DataConnection.IsLocal)
            {
                userLoginName = @"LIVE\kayma";
                Session["_UserName"] = userLoginName;
                Util.LoggedIn = true;
            }

            

            //if (!String.IsNullOrEmpty(testUserName))
            //{
            //    userLoginName = testUserName;
            //    Session["_UserName"] = userLoginName;
            //}

            UserInfo userInfo = new UserInfo(userLoginName);
            Session["UserInfo"] = userInfo;
            //if (SiteMaintenancemode == "1" && !userInfo.IsAdmin)
            //{
            //    // Site in Maintenance Mode - redirect Users to Holing Page.
            //    Response.Redirect("~/Maintenance.aspx");
            //}
            //else
            //{
            //    if (userInfo.IsAdmin)
            //    {
            //        Response.Redirect("~/ProjectsView.aspx?Type=ALL&LifeCycle=0");
            //    }
            //    else
            Response.Redirect("~/Home.aspx");
            //}
        }
    }
}
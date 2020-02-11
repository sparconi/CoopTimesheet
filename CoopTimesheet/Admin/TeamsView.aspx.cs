using CoopTimesheet.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace CoopTimesheet.Admin
{
    public partial class TeamView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Util.LoggedIn)
                Response.Redirect("~/Default.aspx");

            dsTeams.ConnectionString = CoopDAL.Constant.cnstr;

            if (!IsPostBack)
            {
                GridFunctions.SetGridView(ref grid);
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            grid.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["RecordID"] = 0;
            OpenEdit();
        }

        private void OpenEdit()
        {
            LoadData();
            MultiView1.SetActiveView(detailView);
        }

        private void LoadData()
        {
            int teamId = Util.ToInt(Session["RecordId"]);
            int authMgr1ID = 0;

            LoadAuthMgrs();

            if (teamId > 0)
            {
                DataRow dr = CoopDAL.Team.GetTeam(teamId);
                if (dr != null)
                {
                    txtTeamName.Text = Util.ToString(dr["TeamName"]);
                    authMgr1ID = Util.ToInt(dr["TeamManager"]);
                }
            }
            else
            {
                txtTeamName.Text = "";
            }
            Util.SetDDLByValue(ref ddlAuthMgr1, authMgr1ID);

            btnDelete.Visible = (teamId > 0);
        }

        private void LoadAuthMgrs()
        {
            DataTable dt = CoopDAL.User.GetAuthorisingManagersDDL();
            Util.LoadDDL(dt, ref ddlAuthMgr1, "Username", "userId");
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int recordID = Util.ToInt(GridFunctions.GetRecordId(ref grid));
            if (recordID > 0)
            {
                Session["RecordId"] = recordID;
                OpenEdit();
            }
        }

        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
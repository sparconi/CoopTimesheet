using CoopTimesheet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace CoopTimesheet.Admin
{
    public partial class TaskView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Util.LoggedIn)
                Response.Redirect("~/Default.aspx");

            dsTasks.ConnectionString = CoopDAL.Constant.cnstr;

            if (!IsPostBack)
            {
                GridFunctions.SetGridView(ref grid);
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            grid.DataBind();
            // any old change
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
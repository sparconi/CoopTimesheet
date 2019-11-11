using System;
using System.Web.UI.WebControls;
//using ProjectLog.DAL.Common;
using CoopTimesheet.Common;
using System.Data;
using CoopDAL;
using Utilities;

namespace CoopTimesheet
{
    public partial class Base : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMenu();
                UserInfo userInfo = (UserInfo)Session["UserInfo"];

                //    string testUserName = Util.ToString(Session["ZTestUserName"]);
                //    btnTestLogOut.Visible = (testUserName != "");


                //lblVersion.Text = String.Format("v{0}<br />{1}",
                // System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                //  System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToShortDateString());

                lblVersion.Text = "v0.1 (14/10/2019)";
                lblUserName.Text = userInfo.UserName;
                lblUserLogin.Text = Util.CurrentUser;
                lblGroupName.Text = userInfo.UserGroupName;
                lblServerName.Text = Util.ServerName;
            }
        }


        private void LoadMenu()
        {
            TreeNode tn;
            TreeNode cn;
            bool activeUser = false;
            string username = "";
            string lanID = (string)Session["_UserName"];
            UserInfo userInfo = (UserInfo)Session["UserInfo"];

            activeUser = Util.ToBoolean(userInfo.Active);
            tvMenu.Nodes.Clear();

            if (Util.LoggedIn && activeUser)
            {
                tn = new TreeNode("Home")
                {
                    NavigateUrl = "Home.aspx",
                    ToolTip = "Go to Home Page...",
                    ImageUrl = "Images/TreeView/Home.png"
                };
                tvMenu.Nodes.Add(tn);

                tn = new TreeNode("Contact Us")
                {
                    NavigateUrl = "ContactUs.aspx",
                    ToolTip = "Go to Contact page...",
                    ImageUrl = "Images/TreeView/ContactUs.png"
                };
                tvMenu.Nodes.Add(tn);
            }

            #region dontneed
            ////==============================================================
            //// PROJECTS
            ////==============================================================
            //tn = new TreeNode("Requests");

            //if (userInfo.CanSubmitRequest || userInfo.IsAdmin)
            //{
            //    cn = new TreeNode("Engagement Form")
            //    {
            //        NavigateUrl = "NewRequest.aspx",
            //        ToolTip = "New Engagement Form request...",
            //        ImageUrl = "Images/TreeView/NewRequest.png"
            //    };
            //    tn.ChildNodes.Add(cn);


            //    cn = new TreeNode("Open Requests")
            //    {
            //        //NavigateUrl = "OpenRequests.aspx",
            //        NavigateUrl = "ProjectRequestsView.aspx?ViewId=1",
            //        ImageUrl = "Images/TreeView/OpenRequests.png",
            //        ToolTip = "View a List of Open Requests..."
            //    };
            //    tn.ChildNodes.Add(cn);
            //}

            //if (userInfo.CanViewRequest || userInfo.IsAdmin)
            //{
            //    cn = new TreeNode("Submitted Requests")
            //    {
            //        //NavigateUrl = "SubmittedRequests.aspx",
            //        NavigateUrl = "ProjectRequestsView.aspx?ViewId=2",
            //        ImageUrl = "Images/TreeView/SubmittedRequests.png",
            //        ToolTip = "View a List of submitted Requests pending Review..."
            //    };
            //    tn.ChildNodes.Add(cn);
            //}

            ////cn = new TreeNode("ALL")
            ////{
            ////    NavigateUrl = "ProjectsView.aspx?Type=ALL&LifeCycle=0&Node=ALL",
            ////    ImageUrl = "Images/TreeView/AllProjects.png",
            ////    ToolTip = "Show ALL Programmes..."
            ////};
            ////tn.ChildNodes.Add(cn);

            //tvMenu.Nodes.Add(tn);

            ////==============================================================
            //// PROJECTS
            ////==============================================================
            //tn = new TreeNode("Projects");

            //if (userInfo.ShowMyProjects)
            //{
            //    cn = new TreeNode("My Projects")
            //    {
            //        NavigateUrl = "ProjectsForUserView.aspx?&Node=PDT",
            //        ImageUrl = "Images/TreeView/MyProjects.png",
            //        ToolTip = "Show My Projects..."
            //    };
            //    tn.ChildNodes.Add(cn);
            //}

            //if (userInfo.CanViewProject || userInfo.IsAdmin)
            //{
            //    cn = new TreeNode("ALL")
            //    {
            //        NavigateUrl = "ProjectsView.aspx?Type=ALL&LifeCycle=0",
            //        ImageUrl = "Images/TreeView/AllProjects.png",
            //        ToolTip = "Show ALL Projects..."
            //    };
            //    tn.ChildNodes.Add(cn);

            //    cn = new TreeNode("Initiate")
            //    {
            //        //NavigateUrl = "TriageRequests.aspx",
            //        NavigateUrl = "ProjectRequestsView.aspx?ViewId=3",
            //        ImageUrl = "Images/TreeView/TriageRequests.png",
            //        ToolTip = "View a List of Initiate Requests..."
            //    };
            //    tn.ChildNodes.Add(cn);

            //    cn = new TreeNode("Scope")
            //    {
            //        //NavigateUrl = "DesignRequests.aspx",
            //        NavigateUrl = "ProjectRequestsView.aspx?ViewId=4",
            //        ImageUrl = "Images/TreeView/DesignRequests.png",
            //        ToolTip = "View a List of Initiate Requests waiting Scope..."
            //    };
            //    tn.ChildNodes.Add(cn);

            //    cn = new TreeNode("Design")
            //    {
            //        //NavigateUrl = "DesignRequests.aspx",
            //        NavigateUrl = "ProjectRequestsView.aspx?ViewId=5",
            //        ImageUrl = "Images/TreeView/DesignRequests.png",
            //        ToolTip = "View a List of Scope Requests waiting Design..."
            //    };
            //    tn.ChildNodes.Add(cn);

            //    cn = new TreeNode("Deliver")
            //    {
            //        NavigateUrl = "ProjectsView.aspx?Type=ALL&LifeCycle=4",
            //        ImageUrl = "Images/TreeView/LiveProjects.png",
            //        ToolTip = "Show Deliver Projects..."
            //    };
            //    tn.ChildNodes.Add(cn);

            //    cn = new TreeNode("Close/Sustain")
            //    {
            //        NavigateUrl = "ProjectsView.aspx?Type=ALL&LifeCycle=5",
            //        ImageUrl = "Images/TreeView/CompleteProjects.png",
            //        ToolTip = "Show Close/Sustain Projects..."
            //    };
            //    tn.ChildNodes.Add(cn);

            //    cn = new TreeNode("Closed")
            //    {
            //        NavigateUrl = "ProjectsView.aspx?Type=ALL&LifeCycle=6",
            //        ImageUrl = "Images/TreeView/CompleteProjects.png",
            //        ToolTip = "Show Closed Projects..."
            //    };
            //    tn.ChildNodes.Add(cn);

            //    cn = new TreeNode("On Hold")
            //    {
            //        NavigateUrl = "ProjectsView.aspx?Type=ALL&LifeCycle=7",
            //        ImageUrl = "Images/TreeView/OnHold.jpg",
            //        ToolTip = "Show On Hold Projects..."
            //    };
            //    tn.ChildNodes.Add(cn);

            //    tvMenu.Nodes.Add(tn);
            //}
            //#region Programme
            //////==============================================================
            ////// PROGRAMME
            //////==============================================================
            ////tn = new TreeNode("Programmes");

            ////if (userInfo.ShowMyProjects)
            ////{
            ////    cn = new TreeNode("My Programmes")
            ////    {
            ////        NavigateUrl = "ProjectsForUserView.aspx?Node=PRG",
            ////        ImageUrl = "Images/TreeView/MyProjects.png",
            ////        ToolTip = "Show My Programmes..."
            ////    };
            ////    tn.ChildNodes.Add(cn);
            ////}



            ////cn = new TreeNode("Design")
            ////{
            ////    //NavigateUrl = "DesignRequests.aspx",
            ////    NavigateUrl = "ProjectRequestsView.aspx?ViewId=4&Node=PDT",
            ////    ImageUrl = "Images/TreeView/DesignRequests.png",
            ////    ToolTip = "View a List of Triage Requests waiting Design..."
            ////};
            ////tn.ChildNodes.Add(cn);

            ////cn = new TreeNode("Delivery")
            ////{
            ////    NavigateUrl = "ProjectsView.aspx?Type=PRG&LifeCycle=3&Node=PDT",
            ////    ImageUrl = "Images/TreeView/LiveProjects.png",
            ////    ToolTip = "Show Live Programmes..."
            ////};
            ////tn.ChildNodes.Add(cn);

            ////cn = new TreeNode("Closed")
            ////{
            ////    NavigateUrl = "ProjectsView.aspx?Type=PRG&LifeCycle=4&Node=PDT",
            ////    ImageUrl = "Images/TreeView/CompleteProjects.png",
            ////    ToolTip = "Show Closed Programmes..."
            ////};
            ////tn.ChildNodes.Add(cn);

            ////tvMenu.Nodes.Add(tn);
            //#endregion

            ////if (DataConnection.IsTest)
            ////{
            ////if (userInfo.CanViewResourceRequests || userInfo.IsAdmin)
            ////{
            ////    tn = new TreeNode("Resource Requests")
            ////    {
            ////        NavigateUrl = "~/Resource/WorkRequestsView.aspx",
            ////        ToolTip = "View Resource Work Requests...",
            ////        ImageUrl = "Images/TreeView/ResourceTracker.png"
            ////    };
            ////    tvMenu.Nodes.Add(tn);
            ////}

            ////if (userInfo.CanViewResourceTracker || userInfo.IsAdmin)
            ////{
            ////    tn = new TreeNode("Resource Tracker")
            ////    {
            ////        NavigateUrl = "~/Tracker/TrackerView.aspx",
            ////        ToolTip = "Allocation of Resources...",
            ////        ImageUrl = "Images/TreeView/ResourceTracker.png"
            ////    };
            ////    tvMenu.Nodes.Add(tn);

            ////}
            ////}

            //tn = new TreeNode("Milestone Tracker")
            //{
            //    NavigateUrl = "MilestoneTracker.aspx",
            //    ToolTip = "Milestones...",
            //    ImageUrl = "Images/TreeView/Milestones.png"
            //};
            //tvMenu.Nodes.Add(tn);

            //if (userInfo.CanAdminFinance || userInfo.IsAdmin || userInfo.CanViewFinance || userInfo.UserGroupId == 6)  // Portfolio Leads can view
            //{
            //    tn = new TreeNode("Purchase Order Tracker")
            //    {
            //        NavigateUrl = "~/ProjectView/ProjectFinanceDetails.aspx?POTracker=1", //POTracker.aspx",
            //        ToolTip = "Purchase Order Tracker...",
            //        ImageUrl = "Images/TreeView/Tracker.png"
            //    };
            //    tvMenu.Nodes.Add(tn);
            //}

            //if (userInfo.CanAdminFinance || userInfo.IsAdmin )  // Portfolio Leads can view
            //{
            //    tn = new TreeNode("Load Transactions")
            //    {
            //        NavigateUrl = "~/DataLoad.aspx", 
            //        ToolTip = "Load Data Transactions...",
            //        ImageUrl = "Images/TreeView/Tracker.png"
            //    };
            //    tvMenu.Nodes.Add(tn);
            //}

            ////if (userInfo.CanViewDiary || userInfo.CanEditDiary || userInfo.IsAdmin)
            ////{
            ////    tn = new TreeNode("Diary")
            ////    {
            ////        NavigateUrl = "Diary.aspx",
            ////        ToolTip = "Add Diary Entry ...",
            ////        ImageUrl = "Images/TreeView/Diary.png"
            ////    };
            ////    tvMenu.Nodes.Add(tn);
            ////}

            ////if (userInfo.IsAdmin || userInfo.IsAuthManager)
            ////{
            ////    tn = new TreeNode("BAU Bulk Load")
            ////    {
            ////        NavigateUrl = "BAU.aspx",
            ////        ToolTip = "Add BAU Entry ...",
            ////        ImageUrl = "Images/TreeView/BAU.png"
            ////    };
            ////    tvMenu.Nodes.Add(tn);
            ////}
            #endregion

            ////==============================================================
            //// Reports
            ////==============================================================
            //tn = new TreeNode("Reports");

            //DataTable drReports = DAL.Reports.GetReportsByGroupId(userInfo.UserGroupId, userInfo.IsAdmin);
            //int cnt = drReports.Rows.Count;
            //for (int i = 0; i < cnt; i++)
            //{

            //    DataRow rw = drReports.Rows[i];
            //    string ReportName = rw["ReportName"].ToString();
            //    string FolderLocation = rw["FolderLocation"].ToString();

            //    cn = new TreeNode(ReportName)
            //    {
            //        NavigateUrl = "Reports.aspx?ReportId=" + rw["ReportID"].ToString(),
            //        ImageUrl = "Images/TreeView/Reports.png",
            //        ToolTip = "Show " + ReportName + "..."
            //    };
            //    tn.ChildNodes.Add(cn);
            //}

            //tvMenu.Nodes.Add(tn);


            ////==============================================================
            //// ADMIN
            ////==============================================================

            if (userInfo.IsAdmin) // ADMIN & PROJECT TEAM
            {
                tn = new TreeNode("Administration");

                cn = new TreeNode("Teams")
                {
                    NavigateUrl = "~/Admin/TeamsView.aspx",
                    ImageUrl = "Images/TreeView/Divisions.png"
                };
                tn.ChildNodes.Add(cn);
                #region
                cn = new TreeNode("Tasks")
                {
                    NavigateUrl = "~/Admin/TaskView.aspx",
                    ImageUrl = "Images/TreeView/ProjectStatusTypes.png"
                };
                tn.ChildNodes.Add(cn);

                cn = new TreeNode("Users")
                {
                    NavigateUrl = "~/Admin/UserView.aspx",
                    ImageUrl = "Images/TreeView/ProjectStatusTypes.png"
                };
                tn.ChildNodes.Add(cn);

                cn = new TreeNode("Reports")
                {
                    NavigateUrl = "~/Admin/ReportView.aspx",
                    ImageUrl = "Images/TreeView/ProjectStatusTypes.png"
                };
                tn.ChildNodes.Add(cn);

                cn = new TreeNode("Settings")
                {
                    NavigateUrl = "~/Admin/SettingsView.aspx",
                    ImageUrl = "Images/TreeView/ProjectStatusTypes.png"
                };
                tn.ChildNodes.Add(cn);
                //    cn = new TreeNode("Benefits")
                //    {
                //        NavigateUrl = "~/Admin/BenefitsView.aspx",
                //        ImageUrl = "Images/TreeView/ProjectStatusTypes.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Project Priorities")
                //    {
                //        NavigateUrl = "~/Admin/PrioritiesView.aspx",
                //        ImageUrl = "Images/TreeView/ProjectPriorities.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Project Questions")
                //    {
                //        NavigateUrl = "~/Admin/QuestionsView.aspx",
                //        ImageUrl = "Images/TreeView/ProjectQuestions.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("CSQ Questions")
                //    {
                //        NavigateUrl = "~/Admin/CSQQuestionsView.aspx",
                //        ImageUrl = "Images/TreeView/ProjectQuestions.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Email History")
                //    {
                //        NavigateUrl = "~/Admin/EmailHistoryView.aspx",
                //        ImageUrl = "Images/TreeView/Emails.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Email Templates")
                //    {
                //        NavigateUrl = "~/Admin/TemplatesView.aspx",
                //        ImageUrl = "Images/TreeView/Templates.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Allocation Types")
                //    {
                //        NavigateUrl = "~/Admin/AllocationTypesView.aspx",
                //        ImageUrl = "Images/TreeView/AllocationTypes.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("BAU Types")
                //    {
                //        NavigateUrl = "~/Admin/BAUTypesView.aspx",
                //        ImageUrl = "Images/TreeView/BAUTypes.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Teams")
                //    {
                //        NavigateUrl = "~/Admin/TeamsView.aspx",
                //        ImageUrl = "Images/TreeView/Users.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Team Users")
                //    {
                //        NavigateUrl = "Resource/TeamUsersList.aspx",
                //        ImageUrl = "Images/TreeView/Users.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Users")
                //    {
                //        NavigateUrl = "~/Admin/UsersView.aspx",
                //        ImageUrl = "Images/TreeView/Users.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("User Groups")
                //    {
                //        NavigateUrl = "~/Admin/UserGroupsView.aspx",
                //        ImageUrl = "Images/TreeView/Users.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Settings")
                //    {
                //        NavigateUrl = "~/Admin/SettingsView.aspx",
                //        ImageUrl = "Images/TreeView/Control.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Programmes")
                //    {
                //        NavigateUrl = "~/Admin/ProgrammeView.aspx",
                //        ImageUrl = "Images/TreeView/programme.jpg"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    cn = new TreeNode("Reports")
                //    {
                //        NavigateUrl = "~/Admin/ReportView.aspx",
                //        ImageUrl = "Images/TreeView/Reports.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    if (DataConnection.IsTest)
                //    {
                //        cn = new TreeNode("Test Login")
                //        {
                //            NavigateUrl = "Test.aspx",
                //            ImageUrl = "Images/TreeView/Locks.png"
                //        };
                //        tn.ChildNodes.Add(cn);
                //    }
                #endregion
                tn.ExpandAll();

                tvMenu.Nodes.Add(tn);
                //}
                //else if (userInfo.CanApproveResource || userInfo.IsAdmin)
                //{
                //    tn = new TreeNode("Administration");

                //    cn = new TreeNode("Resource Team")
                //    {
                //        NavigateUrl = "Resource/TeamUsersList.aspx",
                //        ImageUrl = "Images/TreeView/Users.png"
                //    };
                //    tn.ChildNodes.Add(cn);

                //    tvMenu.Nodes.Add(tn);
                //}
            }
        }

        public void ShowError(string message)
        {
            ShowModalMessage("Error", message, "~/Images/DlgError.png");
        }
        public void ShowExError(string message, ref Exception ex)
        {
            string errorPath = Request.Url.ToString();
            Emailer.SendEmailOnError(message, errorPath, ex.Message);
            ShowModalMessage("Error", message, "~/Images/DlgError.png");
        }
        public void ShowWarning(string message)
        {
            ShowModalMessage("Warning", message, "~/Images/DlgWarning.png");
        }
        public void ShowInformation(string message)
        {
            ShowModalMessage("Information", message, "~/Images/DlgInfo.png");
        }
        public void ShowHelp(string message)
        {
            ShowModalMessage("Help", message, "~/Images/DlgInfo.png");
        }
        public void ShowModalMessage(string headerText, string message, string imageUrl)
        {
            h_lblModalPopupHeader.Text = headerText;
            h_imgErrorSymbol.ImageUrl = imageUrl;
            if (h_lblModalPopupMessage != null)
                h_lblModalPopupMessage.Text = message;

            //ModalPopupExtender1.Show();
        }
        protected void btnTestLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Test.aspx");
        }
    }
}
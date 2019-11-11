using System.Data;
using CoopDAL;
using Utilities;

namespace CoopTimesheet.Common
{
    /// <summary>
    /// Class to control UserInfo
    /// </summary>
    public class UserInfo
    {
        // Class properties
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int DayRate { get; set; }
        public bool Active { get; set; }
        public bool IsAdmin { get; set; }

        public UserInfo(string loginName)
        {
            GetUser(loginName);
        }


        #region maynotneed 
        public int UserGroupId { get; set; }
        // public int TeamId { get; set; }
        public string UserGroupName { get; set; }

        // public bool IsAdmin { get; set; }
        public bool IsProjectAdmin { get; set; }
        public bool IsStandardUser { get; set; }
        public bool IsRequester { get; set; }
        public bool IsAuthManager { get; set; }
        public bool IsResourceTeam { get; set; }

        public bool CanViewProject { get; set; }
        public bool CanEditProject { get; set; }
        public bool CanViewRequest { get; set; }
        public bool CanEditRequest { get; set; }
        public bool CanViewResource { get; set; }
        public bool CanEditResource { get; set; }
        public bool CanEditStatusReports { get; set; }
        public bool CanEditSubmittedStatusReports { get; set; }
        public bool CanViewResourceTracker { get; set; }
        public bool CanEditResourceTracker { get; set; }
        public bool CanApproveResource { get; set; }
        public bool CanViewHiddenProjects { get; set; }
        public bool CanViewResourceRequests { get; set; }

        public bool CanSubmitRequest { get; set; }

        public bool CanCloseSuspendTask { get; set; }
        public bool CanDeleteOtherRequest { get; set; }
        public bool ShowMyProjects { get; set; }

        public bool CanViewWorkTask { get; set; }
        public bool CanEditWorkTask { get; set; }

        public bool CanViewDiary { get; set; }
        public bool CanEditDiary { get; set; }

        public bool CanViewFinance { get; set; }
        public bool CanEditFinance { get; set; }
        public bool CanAdminFinance { get; set; }
        #endregion 
        public void GetUser(string loginName)
        {
            Util.LoggedIn = false;
            DataRow dr = User.GetUserByWindowsLogin(loginName);
            if (dr != null)
            {
                UserId = Util.ToInt(dr["UserId"]);
                UserName = Util.ToString(dr["UserName"]);
                FirstName = Util.ToString(dr["FirstName"]);
                SurName = Util.ToString(dr["SurName"]);
                TeamId = Util.ToInt(dr["TeamId"]);
                TeamName = Util.ToString(dr["TeamName"]);
                DayRate = Util.ToInt(dr["DayRate"]);
                Active = Util.ToBoolean(dr["Active"]);
                IsAdmin = Util.ToBoolean(dr["IsAdmin"]);

                //    UserGroupId = Util.ToInt(dr["UserGroupId"]);
                //    UserGroupName = Util.ToString(dr["GroupName"]);
                //    TeamId = Util.ToInt(dr["TeamId"]);

                //    IsAdmin = Util.ToBoolean(dr["IsAdmin"]);
                //    IsProjectAdmin = Util.ToBoolean(dr["IsProjectAdmin"]);
                //    switch (UserGroupId)
                //    {
                //        case 3:
                //            IsResourceTeam = true;
                //            IsAuthManager = false;
                //            break;
                //        case 4:
                //            IsAuthManager = true;
                //            IsResourceTeam = false;
                //            break;
                //        default:
                //            IsAuthManager = false;
                //            IsResourceTeam = false;
                //            break;
                //    }

                //    CanViewProject = Util.ToBoolean(dr["CanViewProject"]);
                //    CanEditProject = Util.ToBoolean(dr["CanEditProject"]);
                //    CanViewRequest = Util.ToBoolean(dr["CanViewRequest"]);
                //    CanEditRequest = Util.ToBoolean(dr["CanEditRequest"]);
                //    CanViewResource = Util.ToBoolean(dr["CanViewResource"]);
                //    CanEditResource = Util.ToBoolean(dr["CanEditResource"]);
                //    CanEditStatusReports = Util.ToBoolean(dr["CanEditSavedStatus"]);
                //    CanEditSubmittedStatusReports = Util.ToBoolean(dr["CanEditSubmittedStatus"]);

                //    CanViewResourceTracker = Util.ToBoolean(dr["CanViewResourceTracker"]);
                //    CanEditResourceTracker = Util.ToBoolean(dr["CanEditResourceTracker"]);
                //    CanApproveResource = Util.ToBoolean(dr["CanApproveResource"]);
                //    CanViewHiddenProjects = Util.ToBoolean(dr["CanViewHiddenProjects"]);
                //    CanViewResourceRequests = Util.ToBoolean(dr["CanViewResourceRequests"]);
                //    CanSubmitRequest = Util.ToBoolean(dr["CanSubmitRequest"]);

                //    CanCloseSuspendTask = Util.ToBoolean(dr["CanCloseSuspendTask"]);
                //    CanDeleteOtherRequest = Util.ToBoolean(dr["CanDeleteOtherRequest"]);
                //    ShowMyProjects = Util.ToBoolean(dr["ShowMyProjects"]);

                //    CanViewWorkTask = Util.ToBoolean(dr["CanViewWorkTask"]);
                //    CanEditWorkTask = Util.ToBoolean(dr["CanEditWorkTask"]);

                //    CanViewDiary = Util.ToBoolean(dr["CanViewDiary"]);
                //    CanEditDiary = Util.ToBoolean(dr["CanEditDiary"]);

                //    CanViewFinance = Util.ToBoolean(dr["CanViewFinance"]);
                //    CanEditFinance = Util.ToBoolean(dr["CanEditFinance"]);
                //    CanAdminFinance = Util.ToBoolean(dr["CanAdminFinance"]);

                //    // NOTE: If ever the Ids should change in the table, this will break!
                //    IsStandardUser = (UserGroupId == 1);
                //    IsRequester = (UserGroupId == 5);
                Util.LoggedIn = true;
            }

            Util.UserID = UserId;
            Util.UserName = UserName;
            Util.SendLoginMailMessage();
        }
    }
}
using System.Data;
using Utilities;
using CoopDAL;

namespace CoopTimesheet.Common
{
	public static class CurrentUser
	{
        private static int _WorkRequestsView_StatusId;
        private static int _WorkRequestsView_TeamId;
        private static string _ProjectsView_Search;
        private static int _ProjectsView_Division;
        private static int _ProjectsView_BusinessArea;
        private static int _ProjectsView_ProjectType;
        private static int _ProjectsView_ProjectResource;

        public static int Id
        {
            get
            {
                int userID = 0;

                DataRow dr = User.GetUserByWindowsLogin(Util.CurrentUser);
                if (dr != null)
                {
                    userID = Util.ToInt(dr["UserID"]);
                }
                return userID;
            }
        }
        //public static int WorkRequestsView_TeamId
        //{
        //    get
        //    {
        //        return _WorkRequestsView_TeamId;
        //    }
        //    set
        //    {
        //        _WorkRequestsView_TeamId = value;

        //    }
        //}

        //public static int WorkRequestsView_StatusId
        //{
        //    get
        //    {
        //        return _WorkRequestsView_StatusId;
        //    }
        //    set
        //    {
        //        _WorkRequestsView_StatusId = value;

        //    }
        //}
        //public static string ProjectsView_Search
        //{
        //    get
        //    {
        //        return _ProjectsView_Search;
        //    }
        //    set
        //    {
        //        _ProjectsView_Search = value;

        //    }
        //}

        //public static int ProjectsView_Division
        //{
        //    get
        //    {
        //        return _ProjectsView_Division;
        //    }
        //    set
        //    {
        //        _ProjectsView_Division = value;

        //    }
        //}

        //public static int ProjectsView_BusinessArea
        //{
        //    get
        //    {
        //        return _ProjectsView_BusinessArea;
        //    }
        //    set
        //    {
        //        _ProjectsView_BusinessArea = value;

        //    }

        //}

        //public static int ProjectsView_ProjectType
        //{
        //    get
        //    {
        //        return _ProjectsView_ProjectType;
        //    }
        //    set
        //    {
        //        _ProjectsView_ProjectType = value;

        //    }

        //}

        //public static int ProjectsView_ProjectResource
        //{
        //    get
        //    {
        //        return _ProjectsView_ProjectResource;
        //    }
        //    set
        //    {
        //        _ProjectsView_ProjectResource = value;

        //    }

        //}

    }
}
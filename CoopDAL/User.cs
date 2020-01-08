using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CoopDAL
{
    // Variables and methods associated with "Users" class for the data access layer.
    public class User : Constant
    {
        #region user vairables
        public SqlConnection cn = new SqlConnection(cnstr);
        public Int32 iUserId;
        public String sFirstName;
        public String sSurName;
        public String sUserName;
        public Int16 iTeamId;
        public Int16 iDayRate;
                
        // public Int16 iRate; // which one of these?
        public Boolean bActive;

        //********************************
        // Shiny and new 
        // **********************************
        public Boolean bIsAdmin;
        public DateTime dLastLoginDate;

        // public DataTable dtUsers;

        private Int32 _iUserId;
        private SqlDataReader _drUser;
        #endregion user variables

        #region Methods

        // *************************************
        // Paul McD - Does InserUser receive the active flag, Admin status and Last Login details???
        // *************************************

        #region method InsertUser
        // The InsertUser method receives the First name, Surname, Username, Team Id, Day rate, Active flag, Admin status and LastLogin details,
        // connects to the DB and runs the stored procedure "InsertUser",
        // _iUserId is generated as output.
        public Int32 InsertUser(String sFirstName, String sSurName, String sUserName, Int32 iTeamId, Int32 iRate, Boolean bActive, Boolean bIsAdmin, DateTime dLastLoginDate)
        {
            // Open connection to the database
            cn.Open();
            SqlCommand cmd = new SqlCommand("InsertUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("firstname", SqlDbType.VarChar, 70).Value = sFirstName;
            cmd.Parameters.Add("surname", SqlDbType.VarChar, 70).Value = sSurName;
            cmd.Parameters.Add("username", SqlDbType.VarChar, 70).Value = sUserName;
            cmd.Parameters.Add("teamid", SqlDbType.Int).Value = iTeamId;
            cmd.Parameters.Add("dayrate", SqlDbType.Int).Value = iDayRate;
            cmd.Parameters.Add("active", SqlDbType.Bit).Value = bActive;
            cmd.Parameters.Add("isadmin", SqlDbType.Bit).Value = bIsAdmin;
            cmd.Parameters.Add("lastlogindate", SqlDbType.Date).Value = dLastLoginDate;
            cmd.Parameters.Add("userid", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            // _iUserId is set to the output parameter and the connection to the DB is closed.
            _iUserId = Convert.ToInt32(cmd.Parameters["userid"].Value);
            cn.Close();
            // _iUserId is passed back to application.
            return _iUserId;
        }
        #endregion method InserUser

        #region method UpdateUser
        // The UpdateUser method receives the User Id, First name, Surname, Username, Team Id, Day rate, Active flag, Admin status and LastLogin details,
        // connects to the DB and runs the stored procedure "UpdateUser",
        // The DB values for those fields are updated in the database.         
        public void UpdateUser(Int32 iUserId, String sFirstName, String sSurname, String sUsername, Int32 iTeamId, Int32 iDayRate, Boolean bActive, Boolean bIsAdmin, DateTime dLastLoginDate)
        {
            // Open connection to the database
            cn.Open();
            SqlCommand cmd = new SqlCommand("UpdateUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("userId", SqlDbType.Int).Value = iUserId;
            cmd.Parameters.Add("firstname", SqlDbType.VarChar, 70).Value = sFirstName;
            cmd.Parameters.Add("surname", SqlDbType.VarChar, 70).Value = sSurname;
            cmd.Parameters.Add("username", SqlDbType.VarChar, 70).Value = sUsername;
            cmd.Parameters.Add("teamid", SqlDbType.Int).Value = iTeamId;
            cmd.Parameters.Add("dayrate", SqlDbType.Int).Value = iDayRate;
            cmd.Parameters.Add("active", SqlDbType.Bit).Value = bActive;
            cmd.Parameters.Add("isadmin", SqlDbType.Bit).Value = bIsAdmin;
            cmd.Parameters.Add("lastlogindate", SqlDbType.Date).Value = dLastLoginDate;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        #endregion method UpdateUser

        #region method GetUser
        // The GetUser method receives the user Id value,
        // connects to the DB and runs the stored procedure "GetUserById",
        // data reader _drUser is initialised and used to read the database values for 
        // Team name, Team manager and Team Id.
        public void GetUser(Int32 iUserId)
        {
            // Open connection to the database.
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetUserById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("userId", SqlDbType.Int).Value = iUserId;

            // Set the SQL data reader.
            _drUser = cmd.ExecuteReader();

            // While loop to go through the data in the SQL reader.
            while (_drUser.Read())
            {
                iUserId = Convert.ToInt16(_drUser["userId"]);
                sFirstName = Convert.ToString(_drUser["firstname"]);
                sSurName = Convert.ToString(_drUser["surname"]);
                sUserName = Convert.ToString(_drUser["username"]);
                iTeamId = Convert.ToInt16(_drUser["teamID"]);
                iDayRate = Convert.ToInt16(_drUser["dayrate"]);
                bActive = Convert.ToBoolean(_drUser["active"]);
                bIsAdmin = Convert.ToBoolean(_drUser["isadmin"]);
                dLastLoginDate = Convert.ToDateTime(_drUser["dLastLoginDate"]);
                
            }
        }
        #endregion method GetUser

        #region method GetAllUsers
        // The GetAllUsers method retrieves all user related data,
        // A new data set object is created to return the information,
        // it connects to the DB and runs the stored procedure "GetUsers",
        // A new SQL adapter object is created to return the information.
        
        public DataSet GetAllUsers()  
        {
            // Initialise the dataset object containing rows and records from a SQL DB.
            DataSet dsUsers = new DataSet(); 
            SqlCommand cmd = new SqlCommand("GetUsers", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            // Initialise the SQL adapter, needed for a connection through to the SQL DB.
            SqlDataAdapter da = new SqlDataAdapter();
            cn.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dsUsers);
            cn.Close();
            return dsUsers;
                       
        }
        #endregion method GetAllUsers

        #region method GetUserByCriteria 
        // The GetUserByCriteria method retrieves user info based on certain criteria,
        // A new data set object is created to return the information,
        // it connects to the DB and runs the stored procedure "GetUserByCriteria",
        // A new SQL adapter object is created to return the information.                


        // The input variables look different to the other methods in this class!
        public DataSet GetUsersByCriteria(String sFirstname, String sSurname, String SUsername, Int32 iTeamId, Int32 iRate, Boolean bActive, Boolean bIsAdmin, DateTime dLastLoginDate) 
        {
            DataSet dsUsers = new DataSet();
            SqlCommand cmd = new SqlCommand("GetUsersByCriteria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@FirstName", SqlDbType.VarChar);
            param.Value = sFirstname;
            param = cmd.Parameters.Add("@Surname", SqlDbType.VarChar);
            param.Value = sSurname;
            param = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            param.Value = sUserName;
            param = cmd.Parameters.Add("@TeamID", SqlDbType.Int);
            param.Value = iTeamId;
            param = cmd.Parameters.Add("@dayrate", SqlDbType.Int);
            param.Value = iRate;
            param = cmd.Parameters.Add("@active", SqlDbType.Bit);
            param.Value = bActive;
            param = cmd.Parameters.Add("@isadmin", SqlDbType.Bit);
            param.Value = bIsAdmin;
            param = cmd.Parameters.Add("@lastlogindate", SqlDbType.DateTime);
            param.Value = dLastLoginDate;

            cn.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dsUsers);
            cn.Close();
            return dsUsers;

        }
        public static DataRow GetUserByWindowsLogin(string WindowsLogin)
        {
            SqlConnection cn = new SqlConnection
            {
                ConnectionString = cnstr
            };
            SqlCommand cmd = new SqlCommand("GetUserByWindowsLogin", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50)).Value = WindowsLogin;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataRow row = null;
            if (dr != null)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                row = dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
            cn.Close();
            return row;
        }
        #endregion method GetUserByCriteria
    }
        #endregion methods
}
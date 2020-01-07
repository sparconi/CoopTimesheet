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
    public class User : Constant
    {
        #region user vairables
        public SqlConnection cn = new SqlConnection(cnstr);
        public Int32 iUserId;
        public String sFirstname;
        public String sSurname;
        public String sUsername;
        public Int16 iTeamId;
        public Int16 idayrate; // which one of these?
        public Int16 iRate; // which one of these?
        public Boolean bActive;

        // public DataTable dtUsers;

        private Int32 _iUserId;
        private SqlDataReader _drUser;
        #endregion user variables

        #region Methods

        #region method InsertUser
        public Int32 InsertUser(String sFirstName, String sSurname, String sUsername, Int32 iTeamId, Int32 iRate, Boolean bActive)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("InsertUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("firstname", SqlDbType.VarChar, 70).Value = sFirstName;
            cmd.Parameters.Add("surname", SqlDbType.VarChar, 70).Value = sSurname;
            cmd.Parameters.Add("username", SqlDbType.VarChar, 70).Value = sUsername;
            cmd.Parameters.Add("teamId", SqlDbType.Int).Value = iTeamId;
            cmd.Parameters.Add("dayrate", SqlDbType.Int).Value = iRate;
            cmd.Parameters.Add("active", SqlDbType.Bit).Value = bActive;
            cmd.Parameters.Add("userId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //iSupplierID is set to the output parameter:
            _iUserId = Convert.ToInt32(cmd.Parameters["userId"].Value);
            cn.Close();
            //iSupplierID is passed back to user
            return _iUserId;
        }
        #endregion method InserUser

        #region method UpdateUser
        public void UpdateUser(Int32 iUserId, String sFirstName, String sSurname, String sUsername, Int32 iTeamId, Int32 iRate, Boolean bActive)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("UpdateUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("userId", SqlDbType.Int).Value = iUserId;
            cmd.Parameters.Add("firstname", SqlDbType.VarChar, 70).Value = sFirstName;
            cmd.Parameters.Add("surname", SqlDbType.VarChar, 70).Value = sSurname;
            cmd.Parameters.Add("username", SqlDbType.VarChar, 70).Value = sUsername;
            cmd.Parameters.Add("teamId", SqlDbType.Int).Value = iTeamId;
            cmd.Parameters.Add("dayrate", SqlDbType.Int).Value = iRate;
            cmd.Parameters.Add("active", SqlDbType.Bit).Value = bActive;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        #endregion method UpdateUser

        #region method GetUser
        public void GetUser(Int32 iUserId)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("userId", SqlDbType.Int).Value = iUserId;

            _drUser = cmd.ExecuteReader();

            while (_drUser.Read())
            {
                iUserId = Convert.ToInt16(_drUser["userId"]);
                sFirstname = Convert.ToString(_drUser["firstname"]);
                sSurname = Convert.ToString(_drUser["surname"]);
                sUsername = Convert.ToString(_drUser["username"]);
                iTeamId = Convert.ToInt16(_drUser["teamID"]);
                iRate = Convert.ToInt16(_drUser["dayrate"]);
                bActive = Convert.ToBoolean(_drUser["active"]);

            }
        }
        #endregion method GetUser

        #region method GetAllUsers
        public DataSet GetAllUsers()  // need to create Store Procedure
        {
            DataSet dsUsers = new DataSet(); // or dtUsers - as delared above, DataTable?
            SqlCommand cmd = new SqlCommand("GetAllUsers", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public DataSet GetUsersByCriteria(String sFirstname, String sSurname, String SUsername, Int32 iTeamId, Int32 iRate, Boolean bActive) // need to create Store Procedure
                                                                                                                                   // The input variables look different to the other methods in this class!
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
            param.Value = sUsername;
            param = cmd.Parameters.Add("@TeamID", SqlDbType.Int);
            param.Value = iTeamId;
            param = cmd.Parameters.Add("@dayrate", SqlDbType.Int);
            param.Value = iRate;
            param = cmd.Parameters.Add("@active", SqlDbType.Bit);
            param.Value = bActive;
                       
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
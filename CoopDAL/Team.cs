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
    // Variables and methods associated with "Teams" class for the data access layer.
    public class Team : Constant
    {
        #region team vairables
        public SqlConnection cn = new SqlConnection(cnstr);
        public Int16 iTeamId;
        public String sTeamName;
        public Int16 iTeamManager;

        // public DataTable dtTeam;

        private SqlDataReader _drTeam;

        private Int32 _iTeamId;
        #endregion team variables


        #region method InsertTeam
        // The InsertTeam method receives the Team name and Team manager,
        // connects to the DB and runs the stored procedure "InsertTeam",
        // _iTeamId is generated as output.
        public Int32 InsertTeam(String sTeamName, Int16 iTeamManager)
        {
            // Open connection to the database
            cn.Open();
            SqlCommand cmd = new SqlCommand("InsertTeam", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("teamname", SqlDbType.VarChar, 70).Value = sTeamName;
            cmd.Parameters.Add("teammanager", SqlDbType.Int).Value = iTeamManager;
            cmd.Parameters.Add("teamId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            // _iTeamId is set to the output parameter and the connection to the DB is closed.
            _iTeamId = Convert.ToInt16(cmd.Parameters["TeamID"].Value);
            cn.Close();
            // _iTeamId is passed back to application.
            return _iTeamId;

        }
        #endregion method InsertTeam

        #region method UpdateTeam
        // The UpdateTeam method receives the Team Id, Team name and Team manager,
        // connects to the DB and runs the stored procedure "UpdateTeam",
        // The DB values for those fields are updated in the database.
        public void UpdateTeam(Int16 iTeamId, String sTeamName, Int16 iTeamManager)
        {
            // Open connection to the database
            cn.Open();
            SqlCommand cmd = new SqlCommand("UpdateTeam", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("teamId", SqlDbType.Int).Value = iTeamId;
            cmd.Parameters.Add("teamname", SqlDbType.VarChar, 70).Value = sTeamName;
            cmd.Parameters.Add("teammanager", SqlDbType.Int).Value = iTeamManager;
            cn.Close();
        }
        #endregion method UpdateTeam

        #region method GetTeam
        // The GetTeam method receives the team Id value,
        // connects to the DB and runs the stored procedure "GetTeamById",
        // data reader _drTeam is initialised and used to read the database values for 
        // Team name, Team manager and Team Id.
        public void GetTeam(Int32 iTeamId)
        {
            // Open connection to the database.
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetTeam", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("teamId", SqlDbType.Int).Value = iTeamId;

            // Set the SQL data reader.
            _drTeam = cmd.ExecuteReader();

            // While loop to go through the data in the SQL reader.
            while (_drTeam.Read())
            {
                sTeamName = Convert.ToString(_drTeam["teamname"]);
                iTeamManager = Convert.ToInt16(_drTeam["teammanager"]);
                iTeamId = Convert.ToInt16(_drTeam["teamId"]);

            }
        }
        #endregion method GetTeam

        #region method GetAllTeams
        // The GetAllTeams method retrieves all team related data,
        // A new data set object is created to return the information,
        // it connects to the DB and runs the stored procedure "GetTeams",
        // A new SQL adapter object is created to return the information.
        public DataSet GetAllTeams()  
        {
            // Initialise the dataset object containing rows and records from a SQL DB.
            DataSet dsTeams = new DataSet();
            // **************************************************
            // Check SP name, GetTeams or GetAllTeams ??
            // **************************************************
            SqlCommand cmd = new SqlCommand("GetAllTeams", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            // Initialise the SQL adapter, needed for a connection through to the SQL DB.
            SqlDataAdapter da = new SqlDataAdapter();
            cn.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dsTeams);
            cn.Close();
            return dsTeams;
                  
        }
        #endregion method GetAllTeams

        #region method GetTeamByCriteria
        // The GetTeamByCriteria method retrieves team info based on certain criteria,
        // A new data set object is created to return the information,
        // it connects to the DB and runs the stored procedure "GetTeamByCriteria",
        // A new SQL adapter object is created to return the information.                

        // Create Store Procedure
        public DataSet GetTeamByCriteria(String sTeamName, Int32 iTeamManager) 
        {
            // Initialise the dataset object containing rows and records from a SQL DB.
            DataSet dsTeams = new DataSet();
            SqlCommand cmd = new SqlCommand("GetTeamByCriteria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            // Initialise the SQL adapter, needed for a connection through to the SQL DB.
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@TeamName", SqlDbType.VarChar);
            param.Value = sTeamName;
            param = cmd.Parameters.Add("@TeamManager", SqlDbType.Int);
            param.Value = iTeamManager;
                       
            cn.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dsTeams);
            cn.Close();
            return dsTeams;

        }
        #endregion method GetUserByCriteria

    }

}

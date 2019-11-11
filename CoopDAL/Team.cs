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
    public class Team : Constant
    {
        #region team vairables
        public SqlConnection cn = new SqlConnection(cnstr);
        public Int16 iTeamId;
        public String sTeamname;
        public Int16 iTeammanager;

        private Int32 _iTeamId;
        private SqlDataReader _drTeam;
        public DataTable dtTeam;
        #endregion team variables


        #region method InsertTeam
        public Int32 InsertTeam(String sTeamname, Int16 iTeammanager)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("InsertTeam", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("teamname", SqlDbType.VarChar, 70).Value = sTeamname;
            cmd.Parameters.Add("teammanager", SqlDbType.Int).Value = iTeammanager;
            cmd.Parameters.Add("teamId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //iSupplierID is set to the output parameter:
            _iTeamId = Convert.ToInt16(cmd.Parameters["TeamID"].Value);
            cn.Close();
            //iSupplierID is passed back to user
            return _iTeamId;    /// Not sure....

        }
        #endregion method InsertTeam

        #region method UpdateTeam
        public void UpdateTeam(Int16 iTeamId, String sTeamname, Int16 iTeammanager)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("UpdateTeam", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("teamId", SqlDbType.Int).Value = iTeamId;
            cmd.Parameters.Add("teamname", SqlDbType.VarChar, 70).Value = sTeamname;
            cmd.Parameters.Add("teammanager", SqlDbType.Int).Value = iTeammanager;
            cn.Close();
        }
        #endregion method UpdateTeam

        #region method GetTeam
        public void GetTeam(Int32 iTeamId)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetTeam", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("teamId", SqlDbType.Int).Value = iTeamId;

            _drTeam = cmd.ExecuteReader();

            while (_drTeam.Read())
            {
                sTeamname = Convert.ToString(_drTeam["teamname"]);
                iTeammanager = Convert.ToInt16(_drTeam["teammanager"]);
                iTeamId = Convert.ToInt16(_drTeam["teamId"]);

            }
        }
        #endregion method GetTeam

        #region method GetAllTeams
        public DataSet GetAllTeams()  // need to create Store Procedure
        {
            DataSet dsTeams = new DataSet();
            SqlCommand cmd = new SqlCommand("GetAllTeams", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public DataSet GetTeamByCriteria(String sTeamname, Int32 iTeammanager) // need to create Store Procedure
        {
            DataSet dsTeams = new DataSet();
            SqlCommand cmd = new SqlCommand("GetTeamByCriteria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@TeamName", SqlDbType.VarChar);
            param.Value = sTeamname;
            param = cmd.Parameters.Add("@TeamManager", SqlDbType.Int);
            param.Value = iTeammanager;
                       
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

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
    public class Task : Constant
    {
        #region user vairables
        public SqlConnection cn = new SqlConnection(cnstr);
        public Int32 iTaskId;
        public String sTaskName;
        public Boolean bCrossCharge;
        public DataTable dtTasks;
        private SqlDataReader _drTask;
        private Int32 _iTaskId; 
        public String iUserID;
       
        #endregion user variables

        #region Methods

        #region method InsertTask
        public Int32 InsertTask(String sTaskName, Boolean bCrosscharge)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("InsertTask", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskname", SqlDbType.VarChar, 70).Value = sTaskName;
            cmd.Parameters.Add("crosscharge", SqlDbType.Bit).Value = bCrosscharge;
            cmd.Parameters.Add("taskId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //iSupplierID is set to the output parameter:
            _iTaskId = Convert.ToInt32(cmd.Parameters["taskId"].Value);
            cn.Close();
            //iSupplierID is passed back to user
            return _iTaskId;    /// Not sure....

        }
        #endregion method InserTask

        #region method UpdateTask
        public void UpdateTask(Int32 iTaskId, String sTaskname, Boolean bCrosscharge)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("UpdateTask", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskId", SqlDbType.Int).Value = iTaskId;
            cmd.Parameters.Add("taskname", SqlDbType.VarChar, 70).Value = sTaskname;
            cmd.Parameters.Add("crosscharge", SqlDbType.Bit).Value = bCrosscharge;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        #endregion method UpdateTask

        #region method GetTask
        public void GetTask(Int32 iTaskId)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetTask", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskId", SqlDbType.Int).Value = iTaskId;

            _drTask = cmd.ExecuteReader();

            while (_drTask.Read())
            {
                iTaskId = Convert.ToInt32(_drTask["taskId"]);
                sTaskName = Convert.ToString(_drTask["taskname"]);
                bCrossCharge = Convert.ToBoolean(_drTask["crosscharge"]);

            }
        }
        #endregion method GetTask

        #region method GetAllTasks
        public DataSet GetAllTasks()  // need to create Store Procedure
        {
            DataSet dsTasks = new DataSet();
            SqlCommand cmd = new SqlCommand("GetAllTasks", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            cn.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dsTasks);
            cn.Close();
            return dsTasks;

        }
        #endregion method GetAllUsers

        #region method GetTasksByCriteria 
        public DataSet GetTasksByCriteria(String sTaskname, Boolean bCrosscharge) // need to create Store Procedure
                                                                                                                                             // The input variables look different to the other methods in this class!
        {
            DataSet dsTasks = new DataSet();
            SqlCommand cmd = new SqlCommand("GetTasksByCriteria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@TaskName", SqlDbType.VarChar);
            param.Value = sTaskname;
            param = cmd.Parameters.Add("@crosscharge", SqlDbType.Bit);
            param.Value = bCrosscharge;

            cn.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dsTasks);
            cn.Close();
            return dsTasks;

        }
        #endregion method GetUserByCriteria
    }
    #endregion methods

}

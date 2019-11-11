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
    public class Taskdata : Constant
    {
        #region taskdata variables
        public SqlConnection cn = new SqlConnection(cnstr);
        public Int32 iTaskdataId;
        public Int32 iUserId;
        public Int16 iTaskId;
        public DateTime dDate;
        public DateTime dTime; // Stored procedure has "decimal" not "datetime"

        public Int16 idayrate; // which one of these?
        public Int16 iRate; // which one of these?
        // public Boolean bActive;
        public DataTable dtTaskdata;
       // private Int32 _iUserId; 
        private Int32 _iTaskDataId;
       // private Int32 _iTaskId;
        private SqlDataReader _drTaskdata;
        // public Int16 iTaskdataID;  ....?
      
        #endregion taskdata variables



        #region method InsertTaskdata
        public Int32 InsertTaskdata(Int32 iUserId, Int16 iTaskId, DateTime dDate, DateTime dTime)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("InsertTaskdata", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("userid", SqlDbType.Int).Value = iUserId;
            cmd.Parameters.Add("taskid", SqlDbType.Int).Value = iTaskId;
            cmd.Parameters.Add("date", SqlDbType.DateTime).Value = dDate;
            cmd.Parameters.Add("time", SqlDbType.Time).Value = dTime;
            cmd.Parameters.Add("taskdataId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //iSupplierID is set to the output parameter:
            _iTaskDataId = Convert.ToInt32(cmd.Parameters["taskdataId"].Value);
            cn.Close();
            //iSupplierID is passed back to user
            return _iTaskDataId;    /// Not sure....

        } // Is iTaskdataID an input variable?
        #endregion method InsertTaskdata

        #region method UpdateTaskdata
        public void UpdateTaskdata(Int32 iTaskdataId, Int32 iUserId, Int32 iTaskId, DateTime dDate, DateTime dTime)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("UpdateTaskdata", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskdataId", SqlDbType.Int).Value = iTaskdataId;
            cmd.Parameters.Add("userId", SqlDbType.Int).Value = iUserId;
            cmd.Parameters.Add("taskId", SqlDbType.Int).Value = iTaskId;
            cmd.Parameters.Add("date", SqlDbType.Date).Value = dDate;
            cmd.Parameters.Add("time", SqlDbType.Time).Value = dTime;  // Is SqlDbType correct?
            cn.Close();
        } 
        #endregion method UpdateTaskdata

        #region method GetTaskdata    
        public void GetTaskdata(Int32 iTaskdataId)  
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetTaskdata", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskdataId", SqlDbType.Int).Value = iTaskdataId;

            _drTaskdata = cmd.ExecuteReader();

            while (_drTaskdata.Read())
            {
                iTaskdataId = Convert.ToInt32(_drTaskdata["taskdataId"]);
                iUserId = Convert.ToInt32(_drTaskdata["userID"]);
                iTaskId = Convert.ToInt16(_drTaskdata["taskID"]);
                dDate = Convert.ToDateTime(_drTaskdata["date"]);
                dTime = Convert.ToDateTime(_drTaskdata["time"]);

            }
        }
        #endregion method GetTaskdata

        #region method GetAllTaskdata
        public DataSet GetAllTaskdata()  // need to create Store Procedure  //  Needs editing!!!
        {
            DataSet dsTaskdata = new DataSet();
            SqlCommand cmd = new SqlCommand("GetAllTaskdata", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            cn.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dsTaskdata);
            cn.Close();
            return dsTaskdata;

        }
        #endregion method GetAllTaskdata

        #region method GetTaskdataByCriteria
        // need to create Store Procedure //  Needs editing!!!
        public DataSet GetTaskdataByCriteria(Int32 iUserId, Int16 iTaskId, DateTime dDate, DateTime dTime) 
        {
            DataSet dsTaskdata = new DataSet();
            SqlCommand cmd = new SqlCommand("GetTaskdataByCriteria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@Userid", SqlDbType.Int);
            param.Value = iUserId;
            param = cmd.Parameters.Add("@Taskid", SqlDbType.Int);
            param.Value = iTaskId;
            param = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            param.Value = dDate;
            param = cmd.Parameters.Add("@Time", SqlDbType.DateTime);
            param.Value = dTime;


            cn.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dsTaskdata);
            cn.Close();
            return dsTaskdata;

        }
        #endregion method GetTaskdataByCriteria


    }




}

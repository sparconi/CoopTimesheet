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
    // Variables and methods associated with "Taskdata" class for the data access layer.
    public class Taskdata : Constant
    {
        #region Taskdata variables
        public SqlConnection cn = new SqlConnection(cnstr);
        public Int32 iTaskDataId;
        public Int32 iUserId;
        public Int16 iTaskId;
        public DateTime dDate;
        public Decimal decTime; 

        private SqlDataReader _drTaskdata;

        private Int32 _iTaskDataId;
       
        #endregion taskdata variables



        #region method InsertTaskdata
        // The InsertTaskdata method receives the user id, task id, date and time,
        // connects to the DB and runs the stored procedure "InsertTaskdata",
        // _iTaskDataId is generated as output.
        public Int32 InsertTaskdata(Int32 iUserId, Int16 iTaskId, DateTime dDate, Decimal decTime)
        {
            // Open connection to the database
            cn.Open();
            SqlCommand cmd = new SqlCommand("InsertTaskdata", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("userid", SqlDbType.Int).Value = iUserId;
            cmd.Parameters.Add("taskid", SqlDbType.Int).Value = iTaskId;
            cmd.Parameters.Add("date", SqlDbType.DateTime).Value = dDate;
            cmd.Parameters.Add("time", SqlDbType.Decimal).Value = decTime;             
            cmd.Parameters.Add("taskdataid", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            // _iTaskDataid is set to the output parameter and the connection to the DB is closed.
            _iTaskDataId = Convert.ToInt32(cmd.Parameters["taskdataid"].Value);
            cn.Close();
            // _iTaskDataId is passed back to application.
            return _iTaskDataId;
        }
        #endregion method InsertTaskdata

        #region method UpdateTaskdata
        // The UpdateTaskdata method receives the taskdataid, user id, task id, date and time values,
        // connects to the DB and runs the stored procedure "UpdateTaskdata",
        // The DB values for those fields are updated in the database.
        public void UpdateTaskdata(Int32 iTaskDataId, Int32 iUserId, Int32 iTaskId, DateTime dDate, Decimal decTime)
        {
            // Open connection to the database
            cn.Open();
            SqlCommand cmd = new SqlCommand("UpdateTaskdata", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskdataid", SqlDbType.Int).Value = iTaskDataId;
            cmd.Parameters.Add("userid", SqlDbType.Int).Value = iUserId;
            cmd.Parameters.Add("taskid", SqlDbType.Int).Value = iTaskId;
            cmd.Parameters.Add("date", SqlDbType.Date).Value = dDate;
            cmd.Parameters.Add("time", SqlDbType.Time).Value = decTime;
            cn.Close();
        }
        #endregion method UpdateTaskdata

        #region method GetTaskdata
        // The GetTaskdata method receives the taskdata id value,
        // connects to the DB and runs the stored procedure "GetTaskDataById",
        // data reader _drTaskdata is initialised and used to read the database values for, 
        // taskdataid, user id, task id, date and time.
        public void GetTaskdata(Int32 iTaskDataId)  
        {
            // Open connection to the database
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetTaskdataById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskdataid", SqlDbType.Int).Value = iTaskDataId;

            // Set the SQL data reader.
            _drTaskdata = cmd.ExecuteReader();

            // While loop to go through the data in the SQL reader.
            while (_drTaskdata.Read())
            {
                iTaskDataId = Convert.ToInt32(_drTaskdata["taskdataid"]);
                iUserId = Convert.ToInt32(_drTaskdata["userid"]);
                iTaskId = Convert.ToInt16(_drTaskdata["taskid"]);
                dDate = Convert.ToDateTime(_drTaskdata["date"]);
                decTime = Convert.ToDecimal(_drTaskdata["time"]);

            }
        }
        #endregion method GetTaskdata


        #region method GetAllTaskdata
        // The GetAllTaskdata method retrieves all taskdata related information,
        // A new data set object is created to return the information,
        // it connects to the DB and runs the stored procedure "GetTaskdata",
        // A new SQL adapter object is created to return the information.
        public DataSet GetAllTaskdata()  
        {
            DataSet dsTaskdata = new DataSet();
            SqlCommand cmd = new SqlCommand("GetAllTaskdata", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            // Initialise the SQL adapter, needed for a connection through to the SQL DB.
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
        // The GetTasksdataByCriteria method retrieves taskdata based on certain criteria,
        // A new data set object is created to return the information,
        // it connects to the DB and runs the stored procedure "GetTasksdataByCriteria",
        // A new SQL adapter object is created to return the information.                
        public DataSet GetTaskdataByCriteria(int iUserId, int iTaskId, DateTime dDate, Decimal dTime) 
        {
            // Initialise the dataset object containing rows and records from a SQL DB.
            DataSet dsTaskdata = new DataSet();
            SqlCommand cmd = new SqlCommand("GetTaskdataByCriteria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            // Initialise the SQL adapter, needed for a connection through to the SQL DB.
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@Userid", SqlDbType.Int);
            param.Value = iUserId;
            param = cmd.Parameters.Add("@Taskid", SqlDbType.Int);
            param.Value = iTaskId;
            param = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            param.Value = dDate;
            param = cmd.Parameters.Add("@Time", SqlDbType.Decimal);
            {
                param.Precision = 18; param.Scale = 2; param.Value = dTime;
            }
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

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
    // Variables and methods associated with "Tasks" class for the data access layer
    public class Task : Constant
    {
        #region user vairables
        public SqlConnection cn = new SqlConnection(cnstr);
        public Int32 iTaskId;
        public String sTaskName;
        public Boolean bCrossCharge;
        private SqlDataReader _drTask;
        private Int32 _iTaskId; 
        
       
        #endregion user variables

        #region Methods

        #region method InsertTask
        // The InsertTask method receives the task name and crosscharge values,
        // connects to the DB and runs the stored procedure "InsertTask",
        // taskId is generated as an output.
        public Int32 InsertTask(String sTaskName, Boolean bCrosscharge)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("InsertTask", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskname", SqlDbType.VarChar, 70).Value = sTaskName;
            cmd.Parameters.Add("crosscharge", SqlDbType.Bit).Value = bCrossCharge;
            cmd.Parameters.Add("taskId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            // iTaskID is set to the output parameter and the connection to the DB is closed.
            _iTaskId = Convert.ToInt32(cmd.Parameters["taskId"].Value);
            cn.Close();
            // return iTaskID, passed back to application.
            return _iTaskId;    

        }
        #endregion method InserTask

        #region method UpdateTask
        // The UpdateTask method receives the task id, task name and crosscharge values,
        // connects to the DB and runs the stored procedure "UpdateTask",
        // The DB values for those three fields are updated in the database.
        public void UpdateTask(Int32 iTaskId, String sTaskname, Boolean bCrossCharge)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("UpdateTask", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskId", SqlDbType.Int).Value = iTaskId;
            cmd.Parameters.Add("taskname", SqlDbType.VarChar, 70).Value = sTaskname;
            cmd.Parameters.Add("crosscharge", SqlDbType.Bit).Value = bCrossCharge;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        #endregion method UpdateTask

        #region method GetTask
        // The GetTask method receives the task id value,
        // connects to the DB and runs the stored procedure "GetTask",
        // data reader _drTask is initialised and used to read the database values for task Id, taskname and crosscharge.
        public void GetTask(Int32 iTaskId)
        {
            // Open connection to the database
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetTask", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskId", SqlDbType.Int).Value = iTaskId;

            // Set the SQL data reader.
            _drTask = cmd.ExecuteReader();

            // While loop to go through the data in the SQL reader.
            while (_drTask.Read())
            {
                iTaskId = Convert.ToInt32(_drTask["taskId"]);
                sTaskName = Convert.ToString(_drTask["taskname"]);
                bCrossCharge = Convert.ToBoolean(_drTask["crosscharge"]);

            }
        }
        #endregion method GetTask

        #region method GetAllTasks
        // The GetAllTasks method retrieves task related data,
        // A new data set object is created to return the information,
        // it connects to the DB and runs the stored procedure "GetAllTasks",
        // A new SQL adapter object is created to return the information.

        public DataSet GetAllTasks()  
        {
            // Initialise the dataset object containing rows and records from a SQL DB.
            DataSet dsTasks = new DataSet();
            SqlCommand cmd = new SqlCommand("GetAllTasks", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            // Initialise the SQL adapter, needed for a connection through to the SQL DB
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
        // The GetTasksByCriteria method retrieves tasks based on certain criteria,
        // A new data set object is created to return the information,
        // it connects to the DB and runs the stored procedure "GetAllTasks",
        // A new SQL adapter object is created to return the information.

        // need to create Store Procedure ???
        
        public DataSet GetTasksByCriteria(String sTaskname, Boolean bCrosscharge) 

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
        #endregion method GetTasksByCriteria
    }
    #endregion methods

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CoopDAL
{
    // Variables and methods associated with "Task" class for the data access layer.
    public class Task : Constant
    {
        #region Task vairables
        public SqlConnection cn = new SqlConnection(cnstr);
        public Int32 iTaskId;
        public String sTaskName;
        public Boolean bCrossCharge;
        public String sProjectCode;
        public String sProjectStage;
        public Int32 iCostCentre;
        public Int32 iNominalCode;

        private SqlDataReader _drTask;

        private Int32 _iTaskId;
        #endregion Task variables


        #region Methods


        #region method InsertTask
        // The InsertTask method receives the task name, crosscharge, project code, project stage, cost centre and nominal code values
        // connects to the DB and runs the stored procedure "InsertTask",
        // iTaskId is generated as output.
        public Int32 InsertTask(String sTaskName, Boolean bCrosscharge, String sProjectCode, String sProjectStage, Int32 iCostCentre, Int32 iNominalCode)
        {
            // Open connection to the database.
            cn.Open();
            SqlCommand cmd = new SqlCommand("InsertTask", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskname", SqlDbType.VarChar, 70).Value = sTaskName;
            cmd.Parameters.Add("crosscharge", SqlDbType.Bit).Value = bCrossCharge;
            cmd.Parameters.Add("projectcode", SqlDbType.VarChar, 70).Value = sProjectCode;
            cmd.Parameters.Add("projectstage", SqlDbType.VarChar, 70).Value = sProjectStage;
            cmd.Parameters.Add("costcentre", SqlDbType.Int, 32).Value = iCostCentre;
            cmd.Parameters.Add("nominalcode", SqlDbType.Int).Value = iNominalCode;
            cmd.Parameters.Add("taskid", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            // _iTaskID is set to the output parameter and the connection to the DB is closed.
            _iTaskId = Convert.ToInt32(cmd.Parameters["taskid"].Value);
            cn.Close();
            // _iTaskId passed back to application.
            return _iTaskId;    

        }
        #endregion method InserTask

        #region method UpdateTask
        // The UpdateTask method receives the task id, task name, crosscharge, project code, project stage, cost centre and nominal code values
        // connects to the DB and runs the stored procedure "UpdateTask",
        // The DB values for those fields are updated in the database.
        public void UpdateTask(Int32 iTaskId, String sTaskName, Boolean bCrossCharge, String sProjectCode, String sProjectStage, Int32 iCostCentre, Int32 iNominalCode)
        {
            // Open connection to the database.
            cn.Open();
            SqlCommand cmd = new SqlCommand("UpdateTask", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskId", SqlDbType.Int).Value = iTaskId;
            cmd.Parameters.Add("taskname", SqlDbType.VarChar, 70).Value = sTaskName;
            cmd.Parameters.Add("crosscharge", SqlDbType.Bit).Value = bCrossCharge;
            cmd.Parameters.Add("projectcode", SqlDbType.VarChar, 70).Value = sProjectCode;
            cmd.Parameters.Add("projectstage", SqlDbType.VarChar, 70).Value = sProjectStage;
            cmd.Parameters.Add("costcentre", SqlDbType.Int, 32).Value = iCostCentre;
            cmd.Parameters.Add("nominalcode", SqlDbType.Int).Value = iNominalCode;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        #endregion method UpdateTask

        #region method GetTask
        // The GetTask method receives the task id value,
        // connects to the DB and runs the stored procedure "GetTaskbyId",
        // data reader _drTask is initialised and used to read the database values for 
        // task Id, task name, crosscharge, project code, project stage, cost centre and nominal code.
        public void GetTask(Int32 iTaskId)
        {
            // Open connection to the database.
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetTaskById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("taskid", SqlDbType.Int).Value = iTaskId;

            // Set the SQL data reader.
            _drTask = cmd.ExecuteReader();

            // While loop to go through the data in the SQL reader.
            while (_drTask.Read())
            {
                iTaskId = Convert.ToInt32(_drTask["taskid"]);
                sTaskName = Convert.ToString(_drTask["taskname"]);
                bCrossCharge = Convert.ToBoolean(_drTask["crosscharge"]);
                sProjectCode = Convert.ToString(_drTask["projectcode"]);
                sProjectStage = Convert.ToString(_drTask["projectstage"]);
                iCostCentre = Convert.ToInt32(_drTask["costcentre"]);
                iNominalCode = Convert.ToInt32(_drTask["nominalcode"]);
                
            }
        }
        #endregion method GetTasks

        #region method GetAllTasks
        // The GetAllTasks method retrieves all task related data,
        // A new data set object is created to return the information,
        // it connects to the DB and runs the stored procedure "GetTasks",
        // A new SQL adapter object is created to return the information.
        public DataSet GetAllTasks()  
        {
            // Initialise the dataset object containing rows and records from a SQL DB.
            DataSet dsTasks = new DataSet();
            SqlCommand cmd = new SqlCommand("GetTasks", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            // Initialise the SQL adapter, needed for a connection through to the SQL DB.
            SqlDataAdapter da = new SqlDataAdapter();
            cn.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dsTasks);
            cn.Close();
            return dsTasks;

        }
        #endregion method GetAllTasks

        #region method GetTasksByCriteria 
        // The GetTasksByCriteria method retrieves tasks based on certain criteria,
        // A new data set object is created to return the information,
        // it connects to the DB and runs the stored procedure "GetTasksByCriteria",
        // A new SQL adapter object is created to return the information.                
        public DataSet GetTasksByCriteria(String sTaskName, Boolean bCrossCharge, String sProjectCode, String sProjectStage, Int32 iCostCentre, Int32 iNominalCode)
        {
            // Initialise the dataset object containing rows and records from a SQL DB.
            DataSet dsTasks = new DataSet();
            SqlCommand cmd = new SqlCommand("GetTasksByCriteria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            // Initialise the SQL adapter, needed for a connection through to the SQL DB.
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@TaskName", SqlDbType.VarChar);
            param.Value = sTaskName;
            param = cmd.Parameters.Add("@crosscharge", SqlDbType.Bit);
            param.Value = bCrossCharge;
            param = cmd.Parameters.Add("@ProjectCode", SqlDbType.VarChar);
            param.Value = sProjectCode;
            param = cmd.Parameters.Add("@ProjectStage", SqlDbType.VarChar);
            param.Value = sProjectStage;
            param = cmd.Parameters.Add("@CostCentre", SqlDbType.Int);
            param.Value = iCostCentre;
            param = cmd.Parameters.Add("@NominalCode", SqlDbType.Int);
            param.Value = iNominalCode;

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

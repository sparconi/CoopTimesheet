using System.Data.SqlClient;
using Utilities;

namespace CoopDAL.Connection
{
	public class DataConnection
	{
		//public static bool IsLocal
		//{
		//	get
		//	{
		//		string serverName = Util.ServerName;

  //              return (serverName == "localhost");
		//	}
		//}
		//public static bool IsTest
		//{
		//	get
		//	{
		//		string applicationName = Util.ApplicationName.ToUpper();
		//		return IsLocal || applicationName.Contains("TEST");
  //              //return applicationName.Contains("TEST");
		//	}
		//}
		//public static string ServerToUse
		//{
		//	get
		//	{
  //              return IsLocal ? "INFGEN-SQL\\INFGENDB" : "INFGEN-SQL\\INFGENDB";
  //              //return IsLocal ? "ELVAS\\DEVELOP" : "UCDBS";
		//	}
		//}
		public static string ConnectionString
		{
			get
			{
                return Util.GetWebConfigConnectionString("LIVE");
                //		<add name="TEST" connectionString="Data Source=localhost;Initial Catalog=ProjectLog;User ID=avispa;Password=avispa" providerName="System.Data.SqlClient" />

                //SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder
                //                                                {
                //                                                    DataSource = ServerToUse,
                //                                                    InitialCatalog = (IsTest) ? "ProjectLogTEST" : "ProjectLog",
                //                                                    //InitialCatalog = (IsTest) ? "ProjectLog" : "ProjectLog",
                //                                                    //InitialCatalog = (IsTest) && !(IsLocal) ? "ProjectLogTEST" : "ProjectLog",
                //                                                    UserID = "avispa",
                //                                                    Password = "bnirn3da31"
                //                                                };

                //return connectionString.ToString();

                //if (IsTest)
                //{
                //    return Util.GetWebConfigConnectionString("TEST");
                //}
                //else
                //{
                //    if (IsLocal)
                //    {
                //        return Util.GetWebConfigConnectionString("LOCAL");
                //    }
                //    else
                //    {
                return Util.GetWebConfigConnectionString("LIVE");
                //    }
                //}
                //switch (Util.ServerName)
                //{
                //    //case "lisbon":
                //    //case "wasp":		// VIRTUAL VERSION OF WASP-SRV (BUT FASTER!)	
                //    //case "wasp-srv":	// RE-DIRECTS TO WASP (SEE IIS ON WASP-SRV)
                //    //    return Util.GetWebConfigConnectionString("WASP");

                //    case "projectlog": // NETWORK ALIAS FOR WASP (LIVE VERSION) 
                //    case "wasp-srv":
                //        return Util.GetWebConfigConnectionString("LIVE");

                //    default: // LOCALHOST
                //        return Util.GetWebConfigConnectionString("TEST");
                //}
			}
		}
	}
}
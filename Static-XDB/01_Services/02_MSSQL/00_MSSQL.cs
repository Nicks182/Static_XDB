using System.Data;
using System.Text;

using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

using LiteDB;
namespace Services
{
    public partial class Srv_MSSQL
    {
        public static bool _IsServerAndDBOnline(DB.ProjectInfo P_ProjectInfo)
        {
            if (P_ProjectInfo is not null)
            {
                SqlConnectionStringBuilder L_SqlConnectionStringBuilder = new SqlConnectionStringBuilder(_Get_Connection_String(P_ProjectInfo));
                L_SqlConnectionStringBuilder.ConnectTimeout = 5;

                using (SqlConnection L_SqlConnection = new SqlConnection(L_SqlConnectionStringBuilder.ToString()))
                {
                    try
                    {
                        ServerConnection L_ServerConnection = new ServerConnection(L_SqlConnection);

                        Server L_Server = new Server(L_ServerConnection);

                        if (L_Server.Status != ServerStatus.Online || L_Server.Databases.Contains(P_ProjectInfo.DBName) == false)
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        //public static Srv_MSSQL_DBBranchInfo _Get_CreatedWithBranch_Info(DB.ProjectInfo P_ProjectInfo)
        //{
        //    Srv_MSSQL_DBBranchInfo L_Srv_MSSQL_DBBranchInfo = new Srv_MSSQL_DBBranchInfo();
        //    if (P_ProjectInfo is not null && _IsServerAndDBOnline(P_ProjectInfo) == true)
        //    {
        //        SqlConnectionStringBuilder L_SqlConnectionStringBuilder = new SqlConnectionStringBuilder(_Get_Connection_String(P_ProjectInfo));
        //        L_SqlConnectionStringBuilder.ConnectTimeout = 5;

        //        using (SqlConnection L_SqlConnection = new SqlConnection(L_SqlConnectionStringBuilder.ToString()))
        //        {
        //            L_SqlConnection.Open();
        //            bool L_HasProc = false;
        //            using (SqlCommand L_SqlCommand = new SqlCommand("select [name] from sys.procedures where name= @procedurename", L_SqlConnection))
        //            {
        //                L_SqlCommand.Parameters.Add(new SqlParameter
        //                {
        //                    ParameterName = "@procedurename",
        //                    Value = "__Static_XDB_BranchInfo__"
        //                });

        //                using (SqlDataReader reader = L_SqlCommand.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        L_HasProc = true;
        //                        break;
        //                    }
        //                }
        //            }

        //            if (L_HasProc == true)
        //            {
        //                using (SqlCommand L_SqlCommand = new SqlCommand("__Static_XDB_BranchInfo__", L_SqlConnection))
        //                {
        //                    L_SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

        //                    using (SqlDataAdapter L_SqlDataAdapter = new SqlDataAdapter(L_SqlCommand))
        //                    {
        //                        DataTable L_DataTable = new DataTable();
        //                        L_SqlDataAdapter.Fill(L_DataTable);

        //                        L_Srv_MSSQL_DBBranchInfo.Branch         = L_DataTable.Rows[0]["Branch"].ToString();
        //                        L_Srv_MSSQL_DBBranchInfo.LastCommit     = L_DataTable.Rows[0]["LastCommit"].ToString();
        //                        L_Srv_MSSQL_DBBranchInfo.LastCommitMsg  = L_DataTable.Rows[0]["LastCommitMsg"].ToString();
        //                        L_Srv_MSSQL_DBBranchInfo.Committer      = L_DataTable.Rows[0]["Committer"].ToString();
        //                        L_Srv_MSSQL_DBBranchInfo.DatePushed     = L_DataTable.Rows[0]["DatePushed"].ToString();
        //                    }
        //                }
        //            }
        //        }
        //    }


        //    return L_Srv_MSSQL_DBBranchInfo;
        //}

        public static string _Get_Connection_String(DB.ProjectInfo P_ProjectInfo)
        {
            StringBuilder L_ConnString = new StringBuilder();
            L_ConnString.Append("Server=" + P_ProjectInfo.Server.Trim() + " ");

            if (string.IsNullOrEmpty(P_ProjectInfo.Port) == false)
            {
                L_ConnString.Append("," + P_ProjectInfo.Port.Trim() + " ");
            }
            L_ConnString.Append("; ");

            //L_ConnString.Append("Initial Catalog=" + P_ProjectInfo.DBName.Trim() + "; ");

            if (P_ProjectInfo.Integrated == false)
            {
                L_ConnString.Append("integrated security=False; ");
                L_ConnString.Append("User Id=" + P_ProjectInfo.Username + "; ");
                L_ConnString.Append("Password=" + P_ProjectInfo.Password + "; ");
            }
            else
            {
                L_ConnString.Append("integrated security=True; ");
            }

            L_ConnString.Append("TrustServerCertificate=" + P_ProjectInfo.TrustServerCertificate.ToString() + "; ");

            return L_ConnString.ToString();
        }

        public static string _GetSQLVersion_Text(string P_Version)
        {
            MSSQL_Version L_MSSQL_Version = _GetSqlVersions().Where(v => v.Version == P_Version).FirstOrDefault();
            if(L_MSSQL_Version is not null)
            {
                return L_MSSQL_Version.Description;
            }
            return "";
        }

        public static List<MSSQL_Version> _GetSqlVersions()
        {
            // Source:
            // https://learn.microsoft.com/en-us/sql/t-sql/statements/alter-database-transact-sql-compatibility-level?view=sql-server-ver16

            return new List<MSSQL_Version>
            {
                new MSSQL_Version
                {
                    Version = SqlServerVersion.Version100.ToString(),
                    Description = "SQL Server 2008 (10.0.x)"
                },

                new MSSQL_Version
                {
                    Version = SqlServerVersion.Version100.ToString(),
                    Description = "SQL Server 2008 R2 (10.50.x)"
                },

                new MSSQL_Version
                {
                    Version = SqlServerVersion.Version110.ToString(),
                    Description = "SQL Server 2012 (11.x)"
                },

                new MSSQL_Version
                {
                    Version = SqlServerVersion.Version120.ToString(),
                    Description = "SQL Server 2014 (12.x)"
                },

                new MSSQL_Version
                {
                    Version = SqlServerVersion.Version130.ToString(),
                    Description = "SQL Server 2016 (13.x)"
                },

                new MSSQL_Version
                {
                    Version = SqlServerVersion.Version140.ToString(),
                    Description = "SQL Server 2017 (14.x)"
                },

                new MSSQL_Version
                {
                    Version = SqlServerVersion.Version150.ToString(),
                    Description = "SQL Server 2019 (15.x)"
                },

                new MSSQL_Version
                {
                    Version = SqlServerVersion.Version160.ToString(),
                    Description = "SQL Server 2022 (16.x)"
                },

            };
        }

        public static SqlServerVersion _GetSqlVersion(string P_Version)
        {
            foreach (SqlServerVersion L_Version in Enum.GetValues(typeof(SqlServerVersion)))
            {
                if (L_Version.ToString() == P_Version)
                {
                    return L_Version;
                }
            }

            return SqlServerVersion.Version100;

        }
    }

    public class MSSQL_Version
    {
        public string Version { get; set; }
        public string Description { get; set; }
    }

    public class Srv_MSSQL_DBBranchInfo
    {
        public string Branch { get; set; } = "NA";
        public string LastCommit { get; set; } = "NA";
        public string LastCommitMsg { get; set; } = "NA";
        public string Committer { get; set; } = "NA";
        public string DatePushed { get; set; } = "NA";
    }
}

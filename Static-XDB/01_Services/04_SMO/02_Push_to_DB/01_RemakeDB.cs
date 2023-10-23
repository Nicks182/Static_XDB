
namespace Services
{
    public partial class Srv_SMO
    {

        private void _Remake_DB(DB.ProjectInfo P_ProjectInfo)
        {
            if (G_DoCancel == true)
            {
                return;
            }
            G_Srv_Progress._SetProgress(0, "Remake DB: " + P_ProjectInfo.DBName);
            G_ScriptBuilder.Clear();

            G_ScriptBuilder.AppendLine(Environment.NewLine);
            G_ScriptBuilder.AppendLine("USE master;");
            G_ScriptBuilder.AppendLine("GO");
            G_ScriptBuilder.AppendLine("DECLARE @DatabaseName nvarchar(500)");
            G_ScriptBuilder.AppendLine("SET @DatabaseName = N'" + P_ProjectInfo.DBName + "'");

            // Check IF DB exists...
            G_ScriptBuilder.AppendLine("IF DB_ID(@DatabaseName) IS NOT NULL");
            G_ScriptBuilder.AppendLine("BEGIN");

            // Kill all connections to DB...
            G_ScriptBuilder.AppendLine("DECLARE @SQL varchar(max)");
            G_ScriptBuilder.AppendLine("SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'");
            G_ScriptBuilder.AppendLine("FROM MASTER..SysProcesses");
            G_ScriptBuilder.AppendLine("WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId");
            G_ScriptBuilder.AppendLine("EXEC(@SQL)");
            
            // Drop the DB...
            G_ScriptBuilder.AppendLine("DROP DATABASE " + P_ProjectInfo.DBName + ";");

            G_ScriptBuilder.AppendLine("END");

            // Create DB from scratch.
            // Much easier than deleing and recreating objects one at a time.
            G_ScriptBuilder.AppendLine("CREATE DATABASE " + P_ProjectInfo.DBName + ";");
            G_ScriptBuilder.AppendLine("GO");

            G_ScriptBuilder.AppendLine("USE " + P_ProjectInfo.DBName + ";");
            G_ScriptBuilder.AppendLine("GO");


            _ExeScript(G_ScriptBuilder);

        }

    }

  
}

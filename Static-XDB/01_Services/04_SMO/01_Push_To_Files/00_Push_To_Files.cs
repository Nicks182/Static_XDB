using System.Text;

using Microsoft.SqlServer.Management.Smo;

namespace Services
{
    public partial class Srv_SMO
    {
        public Task _Push_To_Files()
        {
            G_DoCancel = false;
            G_Srv_Progress = new Srv_Progress(G_Srv_MessageBus, 10);
            G_Srv_Progress._ShowProgress();

            Task L_Task = Task.Run(() =>
            {
                if (G_IsServerUp == true)
                {
                    if (_Missing_PrimaryKeys() == false)
                    {

                        _Push_To_Files_Schema();
                        _Push_To_Files_Users();
                        _Push_To_Files_Tables();
                        _Push_To_Files_Views();
                        _Push_To_Files_Procedures();
                        _Push_To_Files_Functions();
                        _Push_To_Files_Synonyms();
                        _Push_To_Files_Triggers();
                        _Push_To_Files_TableData();
                        _Push_To_Files_Order();

                        G_Server.ConnectionContext.Disconnect();
                        //G_Server.KillAllProcesses(G_Database.Name);
                        G_SqlConnection.Close();
                        G_SqlConnection.Dispose();

                        G_Srv_Progress._SetProgress(10, "Push to Files completed!");

                    }
                }
            });
            return L_Task;
        }

        private string _CleanObjectName(string P_Name)
        {
            return P_Name.Replace("\\", "_")
                .Replace("/", "_")
                .Replace(":", "_")
                .Replace("*", "_")
                .Replace("?", "_")
                .Replace("\"", "_")
                .Replace("<", "_")
                .Replace(">", "_")
                .Replace("|", "_");
        }

        private void _Check_And_Clear_Directory(string P_Path)
        {
            if (Directory.Exists(P_Path) == true)
            {
                Directory.Delete(P_Path, true);
            }

            _Check_Directory(P_Path);
        }

        private void _Check_Directory(string P_Path)
        {
            if (Directory.Exists(P_Path) == false)
            {
                Directory.CreateDirectory(P_Path);
            }


        }


        private void _Write_To_File(string P_ObjectName, Srv_SMO_Type P_Type, StringBuilder P_Script)
        {
            
            
            File.WriteAllText(_Get_File_Path(P_ObjectName, P_Type), P_Script.ToString());
        }

        private string _Get_File_Path(string P_ObjectName, Srv_SMO_Type P_Type)
        {
            return Path.Combine(_Get_File_Folder(P_Type), P_ObjectName + ".sql");
        }

        public string _Get_File_Folder(Srv_SMO_Type P_Type)
        {
            switch(P_Type)
            {
                case Srv_SMO_Type.Schema:
                    return "00_Schema";

                case Srv_SMO_Type.User:
                    return "01_Users";

                case Srv_SMO_Type.Table:
                    return "02_Tables";

                case Srv_SMO_Type.View:
                    return "03_Views";

                case Srv_SMO_Type.Proc:
                    return "04_Procedures";

                case Srv_SMO_Type.Func:
                    return "05_Functions";

                case Srv_SMO_Type.Syn:
                    return "06_Synonyms";

                case Srv_SMO_Type.Trig:
                    return "07_Triggers";

                case Srv_SMO_Type.Data:
                    return "08_TableData";

                case Srv_SMO_Type.Contraints:
                    return "99_Contraints";
            }

            return "";
        }

        private string _CleanScript(string P_Script)
        {
            return P_Script.TrimEnd('\r', '\n');
        }

        

        public SqlServerVersion _Get_Target_Version(DB.ProjectInfo P_ProjectInfo)
        {
            return Srv_MSSQL._GetSqlVersion(P_ProjectInfo.SQLVersion);
        }

    }

  
}

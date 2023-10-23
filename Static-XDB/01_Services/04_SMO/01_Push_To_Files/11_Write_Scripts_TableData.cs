using System.Data;
using System.Text;

using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;

namespace Services
{
    public partial class Srv_SMO
    {
        const string G_IdentityFileName = "HasIdentity.txt";
        private void _Push_To_Files_TableData()
        {
            if (G_DoCancel == true)
            {
                return;
            }
            Srv_SMO_Type L_Type = Srv_SMO_Type.Data;
            _Check_And_Clear_Directory(_Get_File_Folder(L_Type));
            
            var L_List = _Get_Table_Data();

            G_Scripter.Options.ScriptSchema = false;
            G_Scripter.Options.ScriptData = true;
            G_Scripter.Options.NoIdentities = true;
            G_Scripter.Options.ExtendedProperties = true;

            StringBuilder L_TableFolder = new StringBuilder();

            bool L_HasIdentity = false;
            DataTable L_PrimaryKeyValues = null;
            List<string> L_Scripts;
            foreach (var L_Object in L_List)
            {
                if (G_DoCancel == true)
                {
                    return;
                }
                G_Srv_Progress._SetProgress(8, "Pushing Table Data: " + L_Object.Name);

                

                L_TableFolder.Clear();
                L_TableFolder.Append(System.IO.Path.Combine(_Get_File_Folder(Srv_SMO_Type.Data), L_Object.Name)); // folder path using table name

                _Check_And_Clear_Directory(L_TableFolder.ToString());

                L_HasIdentity = L_Object.Columns.Cast<Column>().Where(c => c.Identity == true).Count() > 0;
                File.WriteAllText(_Push_To_Files_TableData_Path(L_Object.Name, G_IdentityFileName), Convert.ToInt32(L_HasIdentity).ToString());

                L_PrimaryKeyValues = _Make_Script_Get_Data_For_FileName(L_Object);
                L_Scripts = G_Scripter.EnumScript(new[] { L_Object.Urn }).ToList();

                for (int i = 0; i < L_Scripts.Count; i++)
                {
                    if (G_DoCancel == true)
                    {
                        return;
                    }
                    G_ScriptBuilder.Clear();
                    G_ScriptBuilder.AppendLine(_CleanScript(L_Scripts[i]));
                    _White_Scripts_AppendGo(L_Type);

                    File.WriteAllText(
                        _FileNameFromRow(L_TableFolder, L_PrimaryKeyValues.Rows[i]), 
                        G_ScriptBuilder.ToString()
                    );
                }

            }
        }

        private string _Push_To_Files_TableData_Path(string P_ObjectName, string P_FileName)
        {
            return Path.Combine(_Get_File_Folder(Srv_SMO_Type.Data), P_ObjectName, P_FileName);
        }


        private string _FileNameFromRow(StringBuilder P_TableFolder, DataRow P_DataRow)
        {
            StringBuilder L_FileName = new StringBuilder();

            for (int i = 0; i < P_DataRow.ItemArray.Length; i++)
            {
                if (i > 0)
                {
                    L_FileName.Append("_");
                }
                L_FileName.Append(P_DataRow.ItemArray[i].ToString());
            }

            L_FileName
                .Replace("\\", "_")
                .Replace("/", "_")
                .Replace(":", "_")
                .Replace("*", "_")
                .Replace("?", "_")
                .Replace("\"", "_")
                .Replace("<", "_")
                .Replace(">", "_")
                .Replace("|", "_");

            return System.IO.Path.Combine(P_TableFolder.ToString(), L_FileName.ToString() + ".sql");
        }

        private DataTable _Make_Script_Get_Data_For_FileName(Table P_Table)
        {
            StringBuilder L_SelectString = new StringBuilder();

            List<Column> L_KeyColumns = _Make_Script_Data_GetKeyColumns(P_Table);
            if (L_KeyColumns.Count > 1)
            {
                string bla = "";
            }
            L_SelectString.Append("SELECT ");
            for (int i = 0; i < L_KeyColumns.Count; i++)
            {
                if (i > 0)
                {
                    L_SelectString.Append(", ");
                }
                L_SelectString.AppendLine(L_KeyColumns[i].Name + " ");
            }

            L_SelectString.AppendLine("FROM ");
            L_SelectString.AppendLine(P_Table.Schema + "." + P_Table.Name + " ");
            L_SelectString.AppendLine("ORDER BY ");

            for (int i = 0; i < L_KeyColumns.Count; i++)
            {
                if (i > 0)
                {
                    L_SelectString.Append(", ");
                }
                L_SelectString.AppendLine(L_KeyColumns[i].Name);
            }

            DataTable L_Data = new DataTable();
            SqlDataAdapter L_SqlDataAdapter = new SqlDataAdapter(L_SelectString.ToString(), G_SqlConnection);
            L_SqlDataAdapter.Fill(L_Data);

            return L_Data;
        }

        // Get all columns marked as Key column.
        private List<Column> _Make_Script_Data_GetKeyColumns(Table P_Table)
        {
            List<Column> L_KeyColumns = new List<Column>();
            foreach (Column L_Col in P_Table.Columns)
            {
                if (L_Col.InPrimaryKey == true)
                {
                    L_KeyColumns.Add(L_Col);
                }
            }

            return L_KeyColumns;
        }

    }

  
}

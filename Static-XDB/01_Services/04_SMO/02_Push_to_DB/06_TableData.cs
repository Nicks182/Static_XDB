using System.Text;

namespace Services
{
    public partial class Srv_SMO
    {

        private void _Remake_TableData(DB.ProjectInfo P_ProjectInfo)
        {
            if (G_DoCancel == true)
            {
                return;
            }
            G_Srv_Progress._SetProgress(5, "Remake Table Data... ");
            G_ScriptBuilder.Clear();
            Srv_SMO_Type L_Srv_SMO_Type = Srv_SMO_Type.Data;

            _Check_Directory(_Get_File_Folder(L_Srv_SMO_Type));

            List<string> L_TableFolders = Directory.GetDirectories(_Get_File_Folder(L_Srv_SMO_Type)).ToList();

            StringBuilder L_TableName = new StringBuilder();

            List<string> L_Files = new List<string>();


            bool L_HasIdentity = false;
            for (int d = 0; d < L_TableFolders.Count; d++)
            {
                if (G_DoCancel == true)
                {
                    return;
                }
                G_ScriptBuilder.Clear();
                L_TableName.Clear();
                L_HasIdentity = _CheckForIdentity(L_TableFolders[d]);
                L_TableName.Append(L_TableFolders[d].Split('\\').Last());

                G_Srv_Progress._SetProgress(6, "Remake Table Data: " + L_TableName.ToString());

                _AppendScript_Start(G_ScriptBuilder);
                _GetIdentity_ON_OFF(L_TableName, L_HasIdentity, false); // Turn Identity Insert ON

                L_Files = Directory.GetFiles(L_TableFolders[d], "*.sql").ToList();
                for (int f = 0; f < L_Files.Count; f++)
                {
                    if (G_DoCancel == true)
                    {
                        return;
                    }
                    _AppendScript_FromFile(G_ScriptBuilder, L_Files[f]);
                }


                
                _GetIdentity_ON_OFF(L_TableName, L_HasIdentity, true); // Turn Identity Insert OFF

                _ExeScript(G_ScriptBuilder);
            }
        }


        private bool _CheckForIdentity(string P_TableFolder)
        {
            if (File.Exists(Path.Combine(P_TableFolder, G_IdentityFileName)) == true)
            {
                string L_Text = File.ReadAllText(Path.Combine(P_TableFolder, G_IdentityFileName));

                return L_Text.Trim().Equals("1");
            }
            return false;
        }


        private void _GetIdentity_ON_OFF(StringBuilder P_TableName, bool P_HasIdentity, bool P_IsOff)
        {
            if (P_HasIdentity == true)
            {
                G_ScriptBuilder.Append(Environment.NewLine);
                G_ScriptBuilder.Append("SET IDENTITY_INSERT ");
                G_ScriptBuilder.Append(P_TableName);
                if (P_IsOff == true)
                {
                    G_ScriptBuilder.Append(" OFF");
                }
                else
                {
                    G_ScriptBuilder.Append(" ON");
                }
                G_ScriptBuilder.Append(Environment.NewLine);
            }
        }
    }

  
}

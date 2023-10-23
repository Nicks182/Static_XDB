
namespace Services
{
    public partial class Srv_SMO
    {

        private void _Remake_TableConstraints(DB.ProjectInfo P_ProjectInfo)
        {
            if (G_DoCancel == true)
            {
                return;
            }
            G_ScriptBuilder.Clear();
            G_Srv_Progress._SetProgress(7, "Remake Table Constraints...");
            Srv_SMO_Type L_Srv_SMO_Type = Srv_SMO_Type.Contraints;

            _Check_Directory(_Get_File_Folder(L_Srv_SMO_Type));

            List<string> L_Files = Directory.GetFiles(_Get_File_Folder(L_Srv_SMO_Type), "*.sql").ToList();

            _AppendScript_Start(G_ScriptBuilder);
            for (int f = 0; f < L_Files.Count; f++)
            {
                if (G_DoCancel == true)
                {
                    return;
                }
                _AppendScript_FromFile(G_ScriptBuilder, L_Files[f]);
            }

            // Execute built script...
            _ExeScript(G_ScriptBuilder);
            
        }

    }

  
}

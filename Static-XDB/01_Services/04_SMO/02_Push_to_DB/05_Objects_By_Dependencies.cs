
namespace Services
{
    public partial class Srv_SMO
    {

        private void _Remake_Objects_By_Dependencies(DB.ProjectInfo P_ProjectInfo)
        {
            if (G_DoCancel == true)
            {
                return;
            }
            G_Srv_Progress._SetProgress(4, "Remake Procs, Funcs, Views, Triggers, Synonyms... ");
            G_ScriptBuilder.Clear();
            _Check_Directory(_Get_File_Folder(Srv_SMO_Type.View));
            _Check_Directory(_Get_File_Folder(Srv_SMO_Type.Func));
            _Check_Directory(_Get_File_Folder(Srv_SMO_Type.Proc));
            _Check_Directory(_Get_File_Folder(Srv_SMO_Type.Trig));
            _Check_Directory(_Get_File_Folder(Srv_SMO_Type.Syn));

            List<string> L_Files = File.ReadAllLines(G_DependenciesOrderFileName).ToList();

            
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


using Microsoft.SqlServer.Management.Smo;

namespace Services
{
    public partial class Srv_SMO
    {
        private void _Push_To_Files_Tables()
        {
            if (G_DoCancel == true)
            {
                return;
            }
            _Check_And_Clear_Directory(_Get_File_Folder(Srv_SMO_Type.Table));
            _Check_And_Clear_Directory(_Get_File_Folder(Srv_SMO_Type.Contraints));
            //List<Table> L_List = G_Database.Tables.Cast<Table>().Where(x => !x.IsSystemObject && L_Exclusions.Contains(x.Name) == false).ToList();
            var L_List = _Get_Tables(); // G_Database.Tables.Cast<Table>().Where(x => !x.IsSystemObject).ToList();

            IEnumerable<string> L_Scripts;
            foreach (Table L_Object in L_List)
            {
                if (G_DoCancel == true)
                {
                    return;
                }
                G_Srv_Progress._SetProgress(2, "Pushing Tables: " + L_Object.Name);
                L_Scripts = G_Scripter.EnumScript(new[] { L_Object.Urn });
                _White_Scripts(L_Object.Name, L_Scripts.ToList(), Srv_SMO_Type.Table);
            }
        }

        public void _White_Scripts_Table(string P_ObjectName, List<string> P_Scripts, Srv_SMO_Type P_SMO_Type)
        {
            G_ScriptBuilder.Clear();

            int L_ConstraintsStartAt = 0;
            for (int i = 0; i < P_Scripts.Count; i++)
            {
                G_ScriptBuilder.AppendLine(_CleanScript(P_Scripts[i]));
                _White_Scripts_AppendGo(P_SMO_Type);

                if (P_Scripts[i].StartsWith("CREATE TABLE") == true)
                {
                    L_ConstraintsStartAt = i + 1; // Get everything AFTER the CREATE statement
                    break;
                }
            }

            _Write_To_File(P_ObjectName, P_SMO_Type, G_ScriptBuilder);

            _White_Scripts_Table_Constraints(P_ObjectName, P_Scripts, L_ConstraintsStartAt);

        }

        // Table Constraints are stored apart from the Table Create scripts so we can easily create the DB and all it's objects (Including Data) and then apply the constraints as the last step when Pushing to DB.
        public void _White_Scripts_Table_Constraints(string P_ObjectName, List<string> P_Scripts, int P_StartAt)
        {
            G_ScriptBuilder.Clear();

            if (P_StartAt < P_Scripts.Count)
            {
                for (int i = P_StartAt; i < P_Scripts.Count; i++)
                {
                    G_ScriptBuilder.AppendLine(_CleanScript(P_Scripts[i]));
                    _White_Scripts_AppendGo(Srv_SMO_Type.Contraints);
                }

                _Write_To_File(P_ObjectName, Srv_SMO_Type.Contraints, G_ScriptBuilder);
            }
        }

    }

  
}

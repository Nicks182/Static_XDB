using System.Text;

using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;

namespace Services
{
    public partial class Srv_SMO
    {
        

        private void _Push_To_Files_Order()
        {
            if (G_DoCancel == true)
            {
                return;
            }
            G_Srv_Progress._SetProgress(9, "Pushing Object Order...");
            Dictionary<string, string> L_Objects = new Dictionary<string, string>();
            List<Urn> L_Urns = new List<Urn>();
            if (G_DoCancel == true)
            {
                return;
            }
            //Views
            List<View> L_Views = _Get_Views();// G_Database.Views.Cast<View>().Where(x => !x.IsSystemObject).ToList();
            L_Urns.AddRange(L_Views.Select(x => x.Urn));
            foreach (var L_Object in L_Views)
            {
                if (G_DoCancel == true)
                {
                    return;
                }
                L_Objects.Add(L_Object.Urn.Value, _Get_File_Path(L_Object.Name, Srv_SMO_Type.View));
            }

            //Functions
            List<UserDefinedFunction> L_Functions = _Get_Functions();// G_Database.UserDefinedFunctions.Cast<UserDefinedFunction>().Where(x => !x.IsSystemObject).ToList();
            L_Urns.AddRange(L_Functions.Select(x => x.Urn));
            foreach (var L_Object in L_Functions)
            {
                if (G_DoCancel == true)
                {
                    return;
                }
                L_Objects.Add(L_Object.Urn.Value, _Get_File_Path(L_Object.Name, Srv_SMO_Type.Func));
            }

            //Procs
            List<StoredProcedure> L_Procs = _Get_Procedures();// G_Database.StoredProcedures.Cast<StoredProcedure>().Where(x => !x.IsSystemObject).ToList();
            L_Urns.AddRange(L_Procs.Select(x => x.Urn));
            foreach (var L_Object in L_Procs)
            {
                if (G_DoCancel == true)
                {
                    return;
                }
                L_Objects.Add(L_Object.Urn.Value, _Get_File_Path(L_Object.Name, Srv_SMO_Type.Proc));
            }

            //Triggers
            List<DatabaseDdlTrigger> L_Triggers = _Get_Triggers();// G_Database.Triggers.Cast<Trigger>().Where(x => !x.IsSystemObject).ToList();
            L_Urns.AddRange(L_Triggers.Select(x => x.Urn));
            foreach (var L_Object in L_Triggers)
            {
                if (G_DoCancel == true)
                {
                    return;
                }
                L_Objects.Add(L_Object.Urn.Value, _Get_File_Path(L_Object.Name, Srv_SMO_Type.Trig));
            }

            //Synonyms
            List<Synonym> L_Synonyms = _Get_Synonyms();// G_Database.Synonyms.Cast<Synonym>().ToList();
            L_Urns.AddRange(L_Synonyms.Select(x => x.Urn));
            foreach (var L_Object in L_Synonyms)
            {
                if (G_DoCancel == true)
                {
                    return;
                }
                L_Objects.Add(L_Object.Urn.Value, _Get_File_Path(L_Object.Name, Srv_SMO_Type.Syn));
            }

            // Write to file...
            StringBuilder L_OrderList = new StringBuilder();

            if (L_Urns.Count > 0)
            {
                // Sort
                List<Urn> L_SortedUrns = _Push_To_Files_Order_SortDependencies(G_Database, L_Urns).ToList();
                foreach (Urn L_Urn in L_SortedUrns)
                {
                    if (G_DoCancel == true)
                    {
                        return;
                    }
                    if (L_Objects.ContainsKey(L_Urn.Value))
                    {
                        L_OrderList.Append(L_Objects[L_Urn.Value]);
                        L_OrderList.Append(Environment.NewLine);
                    }
                }
            }

            File.WriteAllText(G_DependenciesOrderFileName, L_OrderList.ToString());
        }

        private IEnumerable<Urn> _Push_To_Files_Order_SortDependencies(Database P_Database, List<Urn> P_Urns)
        {
            var L_Walker = new DependencyWalker(P_Database.Parent);
            var L_Tree = L_Walker.DiscoverDependencies(P_Urns.ToArray(), DependencyType.Parents);
            var L_Dependencies = L_Walker.WalkDependencies(L_Tree);
            return L_Dependencies.Where(x => x.Urn.Type != "Table").Select(x => x.Urn);
        }


    }

  
}

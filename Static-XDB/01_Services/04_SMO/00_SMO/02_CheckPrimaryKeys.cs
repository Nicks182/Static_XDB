using System.Text;

using Microsoft.SqlServer.Management.Smo;

namespace Services
{
    public partial class Srv_SMO
    {
        private bool _Missing_PrimaryKeys()
        {

            List<string> L_IgnoreList = new List<string>();

            L_IgnoreList.AddRange(_Get_IgnoreList(DB.Ignore_Type.Table));
            L_IgnoreList.AddRange(_Get_IgnoreList(DB.Ignore_Type.Data));

            List<Table> L_List = G_Database.Tables.Cast<Table>()
                .Where(
                    x => !x.IsSystemObject
                    && L_IgnoreList.Contains(x.Name) == false
                    && x.Columns.Cast<Column>().Where(c => c.InPrimaryKey == true).Count() == 0
                ).ToList();

            if (L_List.Count > 0)
            {
                StringBuilder L_TableNames = new StringBuilder();

                L_TableNames.AppendLine("The following tables do not have any primary key fields. Either add a primary key field or add the Table to the ignore list.");

                for (int i = 0; i < L_List.Count; i++)
                {
                    L_TableNames.AppendLine((i + 1).ToString() + ": " + L_List[i].Name);
                }

                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, L_TableNames.ToString());

                return true;
            }

            return false;
        }
    }

}

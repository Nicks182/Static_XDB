using System.Text;

namespace Services
{
    public partial class Srv_SMO
    {
        private void _White_Scripts(string P_ObjectName, List<string> P_Scripts, Srv_SMO_Type P_SMO_Type)
        {
            switch(P_SMO_Type)
            {
                case Srv_SMO_Type.Table:
                    _White_Scripts_Table(P_ObjectName, P_Scripts, P_SMO_Type);
                    break;

                default:
                    G_ScriptBuilder.Clear();

                    for (int i = 0; i < P_Scripts.Count; i++)
                    {
                        G_ScriptBuilder.AppendLine(_CleanScript(P_Scripts[i]));
                        _White_Scripts_AppendGo(P_SMO_Type);

                    }

                    _Write_To_File(P_ObjectName, P_SMO_Type, G_ScriptBuilder);
                    break;
            }
            
        }

        private void _White_Scripts_AppendGo(Srv_SMO_Type P_SMO_Type)
        {
            //G_ScriptBuilder.AppendLine("GO");
            _White_Scripts_AppendGo(G_ScriptBuilder, P_SMO_Type);
        }

        private void _White_Scripts_AppendGo(StringBuilder P_StringBuilder, Srv_SMO_Type P_SMO_Type)
        {
            P_StringBuilder.AppendLine("GO");
        }

    }

  
}

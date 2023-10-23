using System.Collections.Generic;
using System.Data;
using System.Text;

using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;


namespace Services
{
    public class Srv_SMO_Object_Info
    {
        public string ObjectName { get; set; }
        public string FilePath { get; set; }
        public Srv_SMO_Type SMO_Type { get; set; }
        public string Script { get; set; }
        
    }

    public partial class Srv_SMO
    {
        public Srv_SMO_Object_Info _Script_Single_Object(string P_ObjectName, Srv_SMO_Type P_Srv_SMO_Type)
        {
            Srv_SMO_Object_Info L_Srv_SMO_Object_Info = null;

            if (G_IsServerUp == true)
            {
                List<string> L_Scripts = _Script_Single_Script_Urn(P_ObjectName, P_Srv_SMO_Type);
                StringBuilder L_DBScript = new StringBuilder();
                for (int i = 0; i < L_Scripts.Count; i++)
                {
                    L_DBScript.AppendLine(_CleanScript(L_Scripts[i]));
                    _White_Scripts_AppendGo(L_DBScript, P_Srv_SMO_Type);
                }

                L_Srv_SMO_Object_Info = new Srv_SMO_Object_Info
                {
                    FilePath = _Get_File_Path(P_ObjectName, P_Srv_SMO_Type),
                    ObjectName = P_ObjectName,
                    Script = L_DBScript.ToString(),
                    SMO_Type = P_Srv_SMO_Type
                };
            }
            return L_Srv_SMO_Object_Info;
        }


        public List<Srv_SMO_Object_Info> _Script_Single_Data(string P_ObjectName)
        {
            List<Srv_SMO_Object_Info> L_Srv_SMO_Object_Infos = new List<Srv_SMO_Object_Info>();

            if (G_IsServerUp == true)
            {
                Table L_Table = _Get_Table_Data().Where(t => t.Name.Equals(P_ObjectName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                L_Srv_SMO_Object_Infos = _Script_Single_Data(L_Table);
            }
            return L_Srv_SMO_Object_Infos;
        }

        public List<Srv_SMO_Object_Info> _Script_Single_Data(Table P_Table)
        {
            List<Srv_SMO_Object_Info> L_Srv_SMO_Object_Infos = new List<Srv_SMO_Object_Info>();

            if (G_IsServerUp == true)
            {
                Srv_SMO_Type L_Srv_SMO_Type = Srv_SMO_Type.Data;
                G_Scripter.Options.ScriptSchema = false;
                G_Scripter.Options.ScriptData = true;
                G_Scripter.Options.NoIdentities = true;
                G_Scripter.Options.ExtendedProperties = true;

                DataTable L_PrimaryKeyValues = _Make_Script_Get_Data_For_FileName(P_Table);

                StringBuilder L_TableFolder = new StringBuilder(System.IO.Path.Combine(_Get_File_Folder(Srv_SMO_Type.Data), P_Table.Name));

                List<string> L_Scripts = _Script_Single_Script_Urn(P_Table.Urn, L_Srv_SMO_Type);
                StringBuilder L_DBScript = new StringBuilder();
                for (int i = 0; i < L_Scripts.Count; i++)
                {
                    L_DBScript.Clear();
                    L_DBScript.AppendLine(_CleanScript(L_Scripts[i]));
                    _White_Scripts_AppendGo(L_DBScript, L_Srv_SMO_Type);

                    L_Srv_SMO_Object_Infos.Add(new Srv_SMO_Object_Info
                    {
                        FilePath = _FileNameFromRow(L_TableFolder, L_PrimaryKeyValues.Rows[i]),
                        ObjectName = P_Table.Name,
                        Script = L_DBScript.ToString(),
                        SMO_Type = L_Srv_SMO_Type
                    });
                }

                
            }
            return L_Srv_SMO_Object_Infos;
        }


        public Srv_SMO_Type _Convert_Type(string P_Tracking_Object_Type)
        {
            switch (P_Tracking_Object_Type)
            {
                case "P":
                    return Srv_SMO_Type.Proc;

                case "FN":
                    return Srv_SMO_Type.Func;

                case "TR":
                    return Srv_SMO_Type.Trig;

                case "V":
                    return Srv_SMO_Type.View;

                case "SN":
                    return Srv_SMO_Type.Syn;

                default: // U
                    return Srv_SMO_Type.Table;
            }


        }


        private List<string> _Script_Single_Script_Urn(string P_ObjectName, Srv_SMO_Type P_Srv_SMO_Type)
        {
            Urn L_Urn = _Script_Single_Get_Urn(P_ObjectName, P_Srv_SMO_Type);
            return _Script_Single_Script_Urn(L_Urn, P_Srv_SMO_Type);
        }

        private List<string> _Script_Single_Script_Urn(Urn P_Urn, Srv_SMO_Type P_Srv_SMO_Type)
        {
            List<string> L_UrnScripts = new List<string>();

            if (P_Urn is not null)
            {
                switch (P_Srv_SMO_Type)
                {
                    case Srv_SMO_Type.Table:
                        L_UrnScripts = _Script_Single_Script_Urn_Table(P_Urn, P_Srv_SMO_Type);
                        break;

                    case Srv_SMO_Type.Contraints:
                        L_UrnScripts = _Script_Single_Script_Urn_Constraints(P_Urn, P_Srv_SMO_Type);
                        break;

                    default:
                        L_UrnScripts = G_Scripter.EnumScript(new[] { P_Urn }).ToList();
                        break;
                }
            }

            return L_UrnScripts;
        }

        private List<string> _Script_Single_Script_Urn_Table(Urn P_Urn, Srv_SMO_Type P_SMO_Type)
        {
            List<string> L_Scripts_Table = new List<string>();
            List<string> L_Scripts = G_Scripter.EnumScript(new[] { P_Urn }).ToList();

            for (int i = 0; i < L_Scripts.Count; i++)
            {
                L_Scripts_Table.Add(L_Scripts[i]);

                if (L_Scripts[i].StartsWith("CREATE TABLE") == true)
                {
                    break;
                }
            }
            return L_Scripts_Table;
        }

        private List<string> _Script_Single_Script_Urn_Constraints(Urn P_Urn, Srv_SMO_Type P_SMO_Type)
        {
            List<string> L_Scripts_Constraints = new List<string>();
            List<string> L_Scripts = G_Scripter.EnumScript(new[] { P_Urn }).ToList();

            int L_ConstraintsStartAt = 0;
            for (int i = 0; i < L_Scripts.Count; i++)
            {
                if (L_Scripts[i].StartsWith("CREATE TABLE") == true)
                {
                    L_ConstraintsStartAt = i + 1; // Get everything AFTER the CREATE statement
                    break;
                }
            }

            if (L_ConstraintsStartAt < L_Scripts.Count)
            {
                for (int i = L_ConstraintsStartAt; i < L_Scripts.Count; i++)
                {
                    L_Scripts_Constraints.Add(L_Scripts[i]);
                }


            }


            return L_Scripts_Constraints;
        }

        private Urn _Script_Single_Get_Urn(string P_ObjectName, Srv_SMO_Type P_Srv_SMO_Type)
        {
            Urn L_Urn = null;
            switch (P_Srv_SMO_Type)
            {
                case Srv_SMO_Type.Proc:
                    StoredProcedure L_Proc = _Get_Procedures(true).Where(p => p.Name.Equals(P_ObjectName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (L_Proc is not null)
                    {
                        L_Urn = L_Proc.Urn;
                    }
                    break;

                case Srv_SMO_Type.User:
                    User L_Usr = _Get_Users(true).Where(p => p.Name.Equals(P_ObjectName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (L_Usr is not null)
                    {
                        L_Urn = L_Usr.Urn;
                    }
                    break;

                case Srv_SMO_Type.Func:
                    UserDefinedFunction L_Fnc = _Get_Functions(true).Where(p => p.Name.Equals(P_ObjectName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (L_Fnc is not null)
                    {
                        L_Urn = L_Fnc.Urn;
                    }
                    break;

                case Srv_SMO_Type.Schema:
                    Schema L_Sma = _Get_Schemas(true).Where(p => p.Name.Equals(P_ObjectName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (L_Sma is not null)
                    {
                        L_Urn = L_Sma.Urn;
                    }
                    break;

                case Srv_SMO_Type.Syn:
                    Synonym L_Syn = _Get_Synonyms(true).Where(p => p.Name.Equals(P_ObjectName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (L_Syn is not null)
                    {
                        L_Urn = L_Syn.Urn;
                    }
                    break;

                case Srv_SMO_Type.Table:
                case Srv_SMO_Type.Contraints:
                    Table L_Tbl = _Get_Tables(true).Where(p => p.Name.Equals(P_ObjectName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (L_Tbl is not null)
                    {
                        L_Urn = L_Tbl.Urn;
                    }
                    break;

                case Srv_SMO_Type.Trig:
                    DatabaseDdlTrigger L_Tgr = _Get_Triggers(true).Where(p => p.Name.Equals(P_ObjectName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (L_Tgr is not null)
                    {
                        L_Urn = L_Tgr.Urn;
                    }
                    break;

                case Srv_SMO_Type.View:
                    View L_Viw = _Get_Views(true).Where(p => p.Name.Equals(P_ObjectName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (L_Viw is not null)
                    {
                        L_Urn = L_Viw.Urn;
                    }
                    break;
            }

            return L_Urn;
        }

    }


}

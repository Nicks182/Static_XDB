
using Services;
using Services.DB;
using SharpHTML;
using System.Collections.Generic;
using System.Text;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Projects_Import_Body_Info(Srv_ProjExportImport_Info P_Srv_ProjExportImport_Info)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Import_Body_Info");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("Name:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item(P_Srv_ProjExportImport_Info.ProjectInfo.Name, false));

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("Description:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item(P_Srv_ProjExportImport_Info.ProjectInfo.Description, false));

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("Server:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item(P_Srv_ProjExportImport_Info.ProjectInfo.Server, false));

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("Port:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item(P_Srv_ProjExportImport_Info.ProjectInfo.Port, false));

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("Database:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item(P_Srv_ProjExportImport_Info.ProjectInfo.DBName, false));

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("SQL Version:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item(Srv_MSSQL._GetSQLVersion_Text(P_Srv_ProjExportImport_Info.ProjectInfo.SQLVersion), false));

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("Username:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item(P_Srv_ProjExportImport_Info.ProjectInfo.Username, false));

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("Password:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item(P_Srv_ProjExportImport_Info.ProjectInfo.Password, false));

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("Use Intergrated:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item(P_Srv_ProjExportImport_Info.ProjectInfo.Integrated.ToString(), false));

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("Trust Server Certificate:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item(P_Srv_ProjExportImport_Info.ProjectInfo.TrustServerCertificate.ToString(), false));

            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("Ignored:", true));
            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Item("", false));


            L_HTML_Object.Add_Child(_Projects_Import_Body_Info_Ignores(P_Srv_ProjExportImport_Info.Ignores));

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Import_Body_Info_Item(string P_Text, bool P_NoWordWrap)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.NoWordWrap.ToString(), Convert.ToInt32(P_NoWordWrap).ToString());

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new System.Text.StringBuilder(P_Text)
            });

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Import_Body_Info_Ignores(List<Services.DB.Ignore> P_Ignores)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Import_Body_Info_Ignores");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("Type"));
            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("Name"));

            for (int i = 0; i < P_Ignores.Count; i++)
            {
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_Cell(P_Ignores[i].Type.ToString()));
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_Cell(P_Ignores[i].Name));
            }

            return L_HTML_Object;
        }



        private HTML_Object _Projects_Import_Body_Info_Grid_Header(string P_Text)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Body_Grid_Cell");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Body_Grid_Header");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsDiv,
                Children = new List<HTML_Object>
                {
                    new HTML_Object
                    {
                        Type = HTML_Object_Type.IsRaw,
                        RawValue = new StringBuilder(P_Text)
                    }
                }
            });

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Import_Body_Info_Grid_Cell(string P_Text)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Body_Grid_Cell");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsDiv,
                Children = new List<HTML_Object>
                {
                    new HTML_Object
                    {
                        Type = HTML_Object_Type.IsRaw,
                        RawValue = new StringBuilder(P_Text)
                    }
                }
            });

            return L_HTML_Object;
        }


    }
}


using SharpHTML;
using Services;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Get_Projects_Edit_Form_SQLVersion_Modal(List<MSSQL_Version> P_MSSQL_Versions)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Modal(new SH_Component_Info_Modal
            {
                Id = "Project_SQLVersion_Modal",
                Caption = "Choose: SQL Version",
                Content_Body = _Get_Projects_Edit_Form_SQLVersion_Modal_Body(P_MSSQL_Versions),
                Content_Footer = _Get_Projects_Edit_Form_SQLVersion_Modal_Footer(),
            });

            return L_HTML_Object;
        }


        public HTML_Object _Get_Projects_Edit_Form_SQLVersion_Modal_Body(List<MSSQL_Version> P_MSSQL_Versions)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Edit_Form_SQLVersion_Modal");

            for(int i = 0; i < P_MSSQL_Versions.Count; i ++)
            {
                L_HTML_Object.Add_Child(_Get_Projects_Edit_Form_SQLVersion_Modal_Body_Btn(P_MSSQL_Versions[i]));
            }

            return L_HTML_Object;
        }

        public HTML_Object _Get_Projects_Edit_Form_SQLVersion_Modal_Body_Btn(MSSQL_Version P_MSSQL_Version)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = P_MSSQL_Version.Description,
                Text_Align = SH_Components_Info_Pos.Center,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Projects_Select_SQLVersions,
                Data = P_MSSQL_Version.Version,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "Project_SQLVersion_Modal",
                    }
                }
            }));


            return L_HTML_Object;
        }

        public HTML_Object _Get_Projects_Edit_Form_SQLVersion_Modal_Footer()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Edit_Form_SQLVersion_Footer");

            L_HTML_Object.Add_Child(_Get_Projects_Edit_Form_SQLVersion_Modal_Footer_CancelBtn());

            return L_HTML_Object;
        }

        public HTML_Object _Get_Projects_Edit_Form_SQLVersion_Modal_Footer_CancelBtn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Cancel",
                Icon = SH_Components_IconTypes.arrow_back_ios_new,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.DoNothing,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "Project_SQLVersion_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }

    }
}

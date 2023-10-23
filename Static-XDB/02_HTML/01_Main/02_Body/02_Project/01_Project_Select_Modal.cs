
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Main_Project_Select_Modal(List<Services.DB.ProjectInfo> P_ProjectInfos)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Modal(new SH_Component_Info_Modal
            {
                Id = "_Main_Project_Select_Modal",
                Caption = "Choose: Project",
                Content_Body = _Main_Project_Select_Modal_Body(P_ProjectInfos),
                Content_Footer = _Main_Project_Select_Modal_Footer(),
            });

            return L_HTML_Object;
        }

        private HTML_Object _Main_Project_Select_Modal_Body(List<Services.DB.ProjectInfo> P_ProjectInfos)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Project_Select_Modal_Body");

            if (P_ProjectInfos.Count == 0)
            {
                L_HTML_Object.Add_Child(_Main_Project_Select_Modal_Body_NoItems());
            }
            else
            {
                for (int i = 0; i < P_ProjectInfos.Count; i++)
                {
                    L_HTML_Object.Add_Child(_Main_Project_Select_Modal_Body_Item(P_ProjectInfos[i]));
                }
            }

            return L_HTML_Object;
        }

        private HTML_Object _Main_Project_Select_Modal_Body_NoItems()
        {
            HTML_Object L_HTML_Object = G_SH_Components._PlainText(new SH_Components_Info
            {
                Value = "No projects found!"
            });

            return L_HTML_Object;
        }

        private HTML_Object _Main_Project_Select_Modal_Body_Item(Services.DB.ProjectInfo P_ProjectInfo)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = P_ProjectInfo.Name
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Data = P_ProjectInfo.Id,
                Message_Type = Services.TM_Message_Type.Main_Project_Select_Set,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "_Main_Project_Select_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }

        private HTML_Object _Main_Project_Select_Modal_Footer()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Project_Select_Modal_Footer");

            L_HTML_Object.Add_Child(_Main_Project_Select_Modal_Footer_CancelBtn());

            return L_HTML_Object;
        }

        private HTML_Object _Main_Project_Select_Modal_Footer_CancelBtn()
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
                        SourceId = "_Main_Project_Select_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }
    }
}

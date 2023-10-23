using Services;
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _PushIt_Modal(string P_UniqueId)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Modal(new SH_Component_Info_Modal
            {
                Id = "PushIt_Modal",
                Caption = "Push To?",
                Content_Body = _PushIt_Modal_Body(P_UniqueId),
                Content_Footer = _PushIt_Modal_Footer(),
                HasCloseBtn = false,
                CanCloseOnMask = false,
            });

            return L_HTML_Object;
        }

        public HTML_Object _PushIt_Modal_Body(string P_UniqueId)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "PushIt_Modal_Body");

            L_HTML_Object.Add_Child(_PushIt_Modal_Body_PushIt_Files(P_UniqueId));
            L_HTML_Object.Add_Child(_PushIt_Modal_Body_PushIt_DB(P_UniqueId));

            return L_HTML_Object;
        }

        public HTML_Object _PushIt_Modal_Body_PushIt_Files(string P_UniqueId)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Files!"
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                UniqueId = P_UniqueId,
                Message_Type = Services.TM_Message_Type.PushIt_To_Files,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "PushIt_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }

        public HTML_Object _PushIt_Modal_Body_PushIt_DB(string P_UniqueId)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "DB!"
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                UniqueId = P_UniqueId,
                Message_Type = Services.TM_Message_Type.PushIt_To_DB,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "PushIt_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }


        public HTML_Object _PushIt_Modal_Footer()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "PushIt_Modal_Footer");

            L_HTML_Object.Add_Child(_PushIt_Modal_Footer_CancelBtn());

            return L_HTML_Object;
        }

        public HTML_Object _PushIt_Modal_Footer_CancelBtn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Cancel",
                Icon = SH_Components_IconTypes.cancel,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "PushIt_Modal_Footer_CancelBtn");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.DoNothing,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "PushIt_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }

    }
}

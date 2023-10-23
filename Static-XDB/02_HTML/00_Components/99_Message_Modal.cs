
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Message_Modal(string P_MessageText)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Modal(new SH_Component_Info_Modal
            {
                Id = "Message_Modal",
                Caption = "Info",
                Content_Body = _Message_Modal_Body(P_MessageText),
                Content_Footer = _Message_Modal_Footer(),
            });

            return L_HTML_Object;
        }

        private HTML_Object _Message_Modal_Body(string P_MessageText)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Message_Modal_Body");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new System.Text.StringBuilder(P_MessageText.Replace("\n", "<br />"))
            });

            return L_HTML_Object;
        }



        private HTML_Object _Message_Modal_Footer()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "FolderBrowser_Modal_Footer");

            L_HTML_Object.Add_Child(_Message_Modal_Footer_OKBtn());

            return L_HTML_Object;
        }

        private HTML_Object _Message_Modal_Footer_OKBtn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "OK",
                Icon = SH_Components_IconTypes.arrow_back_ios_new,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "FolderBrowser_Modal_Footer_CancelBtn");

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.DoNothing,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "Message_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }

        


    }

}

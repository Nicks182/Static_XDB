
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _IgnoredObjects_Edit_Footer()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Edit_Footer");

            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_Footer_CancelBtn());
            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_Footer_SaveBtn());

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Edit_Footer_CancelBtn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Cancel",
                Icon = SH_Components_IconTypes.arrow_back_ios_new,
                Icon_Pos = SH_Components_Info_Pos.Left,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Edit_Footer_CancelBtn");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Ignores_Modify_Close
            }));

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Edit_Footer_SaveBtn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Save",
                Icon = SH_Components_IconTypes.save,
                Icon_Pos = SH_Components_Info_Pos.Right,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Edit_Footer_SaveBtn");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Ignores_Modify_Save,
            }));

            return L_HTML_Object;
        }

    }
}

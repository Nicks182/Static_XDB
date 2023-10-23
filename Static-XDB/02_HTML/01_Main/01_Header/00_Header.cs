
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Main_SubHeader()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), HTML_Components_Names.Div_Header.ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Header");
            //L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            L_HTML_Object.Add_Child(_Main_SubHeader_Projects());
            L_HTML_Object.Add_Child(_Main_SubHeader_Ignore());

            return L_HTML_Object;
        }

        private HTML_Object _Main_SubHeader_Projects()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Projects",
                Text_Align = SH_Components_Info_Pos.Center,
                Icon = SH_Components_IconTypes.database,
                Icon_Pos = SH_Components_Info_Pos.Left,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Projects_Show
            }));

            return L_HTML_Object;
        }

        private HTML_Object _Main_SubHeader_Ignore()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Ignore...",
                Text_Align = SH_Components_Info_Pos.Center,
                Icon = SH_Components_IconTypes.block,
                Icon_Pos = SH_Components_Info_Pos.Left,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Ignores_Show,
                Data = "Schema", // Show Schema items by default.
            }));

            return L_HTML_Object;
        }

    }
}


using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Main_Footer()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "PushBtns");

            L_HTML_Object.Add_Child(_Main_Footer_PushBtn());

            return L_HTML_Object;
        }

        public HTML_Object _Main_Footer_PushBtn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Push it!",
                Text_Align = SH_Components_Info_Pos.Center,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.PushIt
            }));

            return L_HTML_Object;
        }
    }
}

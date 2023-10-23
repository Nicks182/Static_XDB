﻿
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Tracking_Data_Footer()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Child(_Tracking_Data_Footer_Close_Btn());

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Data_Footer_Close_Btn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Back",
                Icon = SH_Components_IconTypes.arrow_back_ios_new,
                Icon_Pos = SH_Components_Info_Pos.Left,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Init
            }));

            return L_HTML_Object;
        }
    }
}

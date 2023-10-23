
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Tracking_Data_SubHeader()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_SubHeader");

            L_HTML_Object.Add_Child(_Tracking_Data_SubHeader_ObjectChanges_Btn());
            

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Data_SubHeader_ObjectChanges_Btn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Check for Data Changes"
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "");

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), HTML_Components._PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Tracking_Check_Data,
            }));


            return L_HTML_Object;
        }

    }
}

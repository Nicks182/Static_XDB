using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _IgnoredObjects_SubHeader(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_SubHeader");

            SH_State_Item_Control L_SH_State_Item_Control = P_SH_State_Item.G_Controls.Where(c => c.Id.Equals("ProjectInfoId")).FirstOrDefault();

            L_HTML_Object.Add_Child(_IgnoredObjects_SubHeader_Import_Btn(L_SH_State_Item_Control));
            L_HTML_Object.Add_Child(_IgnoredObjects_SubHeader_Export_Btn(L_SH_State_Item_Control));

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_SubHeader_Import_Btn(SH_State_Item_Control P_SH_State_Item_Control)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Import",
                Icon = SH_Components_IconTypes.download
            });

            if (P_SH_State_Item_Control is not null)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
                {
                    Data = P_SH_State_Item_Control.Value.ToString(),
                    Message_Type = Services.TM_Message_Type.Ignores_Import
                }));
            }
            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_SubHeader_Export_Btn(SH_State_Item_Control P_SH_State_Item_Control)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Export",
                Icon = SH_Components_IconTypes.publish
            });

            if (P_SH_State_Item_Control is not null)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
                {
                    Data = P_SH_State_Item_Control.Value.ToString(),
                    Message_Type = Services.TM_Message_Type.Ignores_Export
                }));
            }
            
            return L_HTML_Object;
        }


    }
}

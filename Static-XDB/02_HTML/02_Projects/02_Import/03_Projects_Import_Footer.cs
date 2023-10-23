
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Projects_Import_Footer(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Import_Footer");

            L_HTML_Object.Add_Child(_Projects_Import_Footer_CancelBtn(P_SH_State_Item));
            L_HTML_Object.Add_Child(_Projects_Import_Footer_SaveBtn(P_SH_State_Item));

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Import_Footer_CancelBtn(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Cancel",
                Icon = SH_Components_IconTypes.arrow_back_ios_new,
                Icon_Pos = SH_Components_Info_Pos.Left,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Import_Footer_CancelBtn");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                UniqueId = P_SH_State_Item.Id,
                Message_Type = Services.TM_Message_Type.Projects_Import_Cancel
            }));

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Import_Footer_SaveBtn(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Save",
                Icon = SH_Components_IconTypes.save,
                Icon_Pos = SH_Components_Info_Pos.Right,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Import_Footer_SaveBtn");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Projects_Import_Save
            }));

            return L_HTML_Object;
        }




    }
}

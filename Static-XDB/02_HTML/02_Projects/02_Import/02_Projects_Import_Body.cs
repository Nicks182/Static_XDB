
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Projects_Import_Body(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Import_Body");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            foreach(var L_Item in P_SH_State_Item.G_Controls.Where(x => x.IsHidden == false))
            {
                L_HTML_Object.Add_Child(_Projects_Import_Body_Item(L_Item));
            }

            //L_HTML_Object.Add_Child(_Projects_Import_Body_LoadInfo_Btn(P_SH_State_Item));
            L_HTML_Object.Add_Child(_Projects_Import_Body_ProjectInfo());

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Import_Body_Item(SH_State_Item_Control P_StateControl)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Form_Item(P_StateControl);

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Import_Body_LoadInfo_Btn(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Load"
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                UniqueId = P_SH_State_Item.Id,
                Message_Type = Services.TM_Message_Type.Projects_Import_Load
            }));

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Import_Body_ProjectInfo()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };
            
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), HTML_Components_Names.Div_Project_Import_Info.ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Import_Body_Info_Holder");
            //L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");
            

            return L_HTML_Object;
        }

    }
}

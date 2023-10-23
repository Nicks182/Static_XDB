using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Main_Body_Project(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), HTML_Components_Names.Div_Project.ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Body_Section");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            L_HTML_Object.Add_Child(_Main_Body_Section_Header("Project Info:"));
            
            foreach (var L_Item in P_SH_State_Item.G_Controls.Where(c => c.Id.Contains("Main_Project_")).ToList())
            {
                //L_HTML_Object.Add_Child(G_SH_Components._Form_Item(L_Item));
                L_HTML_Object.Add_Child(_Main_Body_Project_Caption(L_Item));
                L_HTML_Object.Add_Child(_Main_Body_Project_Value(L_Item));
            }

            L_HTML_Object.Add_Child(_Main_Body_Project_Edit_Btn());

            return L_HTML_Object;
        }

        public HTML_Object _Main_Body_Project_Caption(SH_State_Item_Control P_SH_State_Item_Control)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsLabel };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Body_Section_Item_Caption");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_SH_State_Item_Control.Caption)
            });

            return L_HTML_Object;
        }

        public HTML_Object _Main_Body_Project_Value(SH_State_Item_Control P_SH_State_Item_Control)
        {
            return G_SH_Components._Form_Item_Input(P_SH_State_Item_Control);
        }

        private HTML_Object _Main_Body_Project_Edit_Btn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Edit Projects...",
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

    }
}

using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Main_Body_Project_GITInfo(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), HTML_Components_Names.Div_GITInfo.ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Body_Section");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            L_HTML_Object.Add_Child(_Main_Body_Section_Header("GIT Info:"));

            foreach (var L_Item in P_SH_State_Item.G_Controls.Where(c => c.Id.Contains("Main_GitInfo_")).ToList())
            {
                //L_HTML_Object.Add_Child(G_SH_Components._Form_Item(L_Item));
                L_HTML_Object.Add_Child(_Main_Body_Project_GITInfo_Item_Caption(L_Item));
                L_HTML_Object.Add_Child(_Main_Body_Project_GITInfo_Item_Control(L_Item));
            }

            return L_HTML_Object;
        }

        public HTML_Object _Main_Body_Project_GITInfo_Item_Caption(SH_State_Item_Control P_SH_State_Item_Control)
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

        public HTML_Object _Main_Body_Project_GITInfo_Item_Control(SH_State_Item_Control P_SH_State_Item_Control)
        {
            return G_SH_Components._Form_Item_Input(P_SH_State_Item_Control);
        }

    }
}

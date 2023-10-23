
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Project_Edit_Body(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Edit_Form_Body");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            foreach(var L_Item in P_SH_State_Item.G_Controls.Where(x => x.IsHidden == false))
            {
                L_HTML_Object.Add_Child(_Project_Edit_Body_Item(L_Item));
            }

            return L_HTML_Object;
        }

        private HTML_Object _Project_Edit_Body_Item(SH_State_Item_Control P_StateControl)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Form_Item(P_StateControl);

            return L_HTML_Object;
        }


    }
}

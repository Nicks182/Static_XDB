
using Services;
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {

        private HTML_Object _IgnoredObjects_Edit_Form_Body(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Edit_Form_Body");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            SH_State_Item_Control L_State_Control = P_SH_State_Item.G_Controls.Where(c => c.Id == "IgnoreType").FirstOrDefault();

            Services.DB.Ignore_Type L_Ignore_Type = (Services.DB.Ignore_Type)Enum.Parse(typeof(Services.DB.Ignore_Type), L_State_Control.Value.ToString());

            foreach (var L_Item in P_SH_State_Item.G_Controls.Where(x => x.IsHidden == false && x.Components_Type == SH_Components_Types.Checkbox && (Services.DB.Ignore_Type)x.MetaData["IgnoreType"] == L_Ignore_Type))
            {
                L_HTML_Object.Add_Child(_IgnoredObjects_Edit_Form_Body_Item(L_Item));
            }

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Edit_Form_Body_Item(SH_State_Item_Control P_StateControl)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Form_Item(P_StateControl);

            return L_HTML_Object;
        }


    }
}

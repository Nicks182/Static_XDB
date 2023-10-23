using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Main_Body(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Body");

            L_HTML_Object.Add_Child(_Main_Body_Project(P_SH_State_Item));
            L_HTML_Object.Add_Child(_Main_Body_DBInfo(P_SH_State_Item));
            L_HTML_Object.Add_Child(_Main_Body_Project_GITInfo(P_SH_State_Item));

            return L_HTML_Object;
        }

        public HTML_Object _Main_Body_Section_Header(string P_Text)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsLabel };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Body_Section_Header");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_Text)
            });

            return L_HTML_Object;
        }

    }
}

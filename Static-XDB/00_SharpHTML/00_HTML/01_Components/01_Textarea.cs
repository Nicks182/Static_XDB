using Static_XDB.HTML;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public HTML_Object _Textarea(SH_Components_Info P_Info)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsTextarea };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), P_Info.Id);
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.CompType.ToString(), Convert.ToInt32(SH_Components_Types.Textarea).ToString());

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.IsReadonly.ToString(), P_Info.IsReadonly.ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.IsHidden.ToString(), P_Info.IsHidden.ToString());

            if (P_Info.IsFocus == true)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.autofocus.ToString(), "");
            }

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new System.Text.StringBuilder(P_Info.Value)
            });

            return L_HTML_Object;
        }
    }
}

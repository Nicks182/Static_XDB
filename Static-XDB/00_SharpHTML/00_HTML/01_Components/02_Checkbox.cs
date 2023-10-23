using Static_XDB.HTML;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public HTML_Object _Checkbox(SH_Components_Info P_Info)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsButton };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.CompType.ToString(), Convert.ToInt32(SH_Components_Types.Checkbox).ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Value.ToString(), _Checkbox_DefaultValue(P_Info.Value));

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.IsReadonly.ToString(), P_Info.IsReadonly.ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.IsHidden.ToString(), P_Info.IsHidden.ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), "_SharpHTML_Checkbox_Change(this);");

            if (string.IsNullOrEmpty(P_Info.Id) == false)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), P_Info.Id);
            }

            if (P_Info.IsFocus == true)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.autofocus.ToString(), "");
            }

            L_HTML_Object.Add_Child(_Checkbox_Icon_Check(P_Info));

            return L_HTML_Object;
        }


        public HTML_Object _Checkbox_Icon_Check(SH_Components_Info P_Info)
        {
            HTML_Object L_HTML_Object = _Icon(new SH_Components_IconInfo
            {
                IconType = SH_Components_IconTypes.done
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), "Check");
            

            return L_HTML_Object;
        }

        

        private string _Checkbox_DefaultValue(object P_Value)
        {
            if (P_Value is not null)
            {
                return P_Value.ToString();
            }

            return "0";
        }
    }
}

using Static_XDB.HTML;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public HTML_Object _Progressbar(SH_Components_Info P_Info)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsButton };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.CompType.ToString(), Convert.ToInt32(SH_Components_Types.Progressbar).ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.IsHidden.ToString(), P_Info.IsHidden.ToString());

            L_HTML_Object.Add_Attribute("style", "--ProgressbarWidth: " + P_Info.Value + ";");

            if (string.IsNullOrEmpty(P_Info.Id) == false)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), P_Info.Id);
            }

            L_HTML_Object.Add_Child(_Progressbar_Value(P_Info));
            L_HTML_Object.Add_Child(_Progressbar_Text(P_Info));

            return L_HTML_Object;
        }

        private HTML_Object _Progressbar_Value(SH_Components_Info P_Info)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            return L_HTML_Object;
        }

        private HTML_Object _Progressbar_Text(SH_Components_Info P_Info)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsLabel };



            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new System.Text.StringBuilder(P_Info.Value)
            });

            return L_HTML_Object;
        }

    }

}

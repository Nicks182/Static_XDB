using Static_XDB.HTML;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public HTML_Object _Form(HTML_Object P_Header, HTML_Object P_Body, HTML_Object P_Footer)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.CompType.ToString(), "70");

            if (P_Header is not null)
            {
                L_HTML_Object.Add_Child(_Form_Header(P_Header));
            }

            if (P_Body is not null)
            {
                L_HTML_Object.Add_Child(_Form_Body(P_Body));
            }

            if (P_Footer is not null)
            {
                L_HTML_Object.Add_Child(_Form_Footer(P_Footer));
            }

            return L_HTML_Object;
        }


        public HTML_Object _Form_Header(HTML_Object P_Header)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.CompType.ToString(), "70.0");

            L_HTML_Object.Add_Child(P_Header);

            return L_HTML_Object;
        }


        public HTML_Object _Form_Body(HTML_Object P_Body)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.CompType.ToString(), "70.1");

            L_HTML_Object.Add_Child(P_Body);

            return L_HTML_Object;
        }

        public HTML_Object _Form_Footer(HTML_Object P_Footer)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.CompType.ToString(), "70.2");

            L_HTML_Object.Add_Child(P_Footer);

            return L_HTML_Object;
        }

    }

}

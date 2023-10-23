using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Screen(string P_HeaderText, HTML_Object P_SubHeader, HTML_Object P_Info, HTML_Object P_Body, HTML_Object P_Footer)
        {
            return _Screen(_Screen_Default_Header(P_HeaderText), P_SubHeader, P_Info, P_Body, P_Footer);
        }

        public HTML_Object _Screen(HTML_Object P_Header, HTML_Object P_SubHeader, HTML_Object P_Info, HTML_Object P_Body, HTML_Object P_Footer)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), "Div_Screen");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Screen");

            L_HTML_Object.Add_Child(_Screen_Get_Child(P_Header, "Screen_Header", true));
            if (P_SubHeader is not null)
            {
                L_HTML_Object.Add_Child(_Screen_Get_Child(P_SubHeader, "Screen_Sub_Header"));
            }

            L_HTML_Object.Add_Child(_Screen_Get_Body(P_Info, P_Body));

            if (P_Footer is not null)
            {
                L_HTML_Object.Add_Child(_Screen_Get_Child(P_Footer, "Screen_Footer"));
            }

            return L_HTML_Object;
        }

        private HTML_Object _Screen_Get_Body(HTML_Object P_Info, HTML_Object P_Body)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Screen_Body");

            if (P_Info is not null)
            {
                L_HTML_Object.Add_Child(_Screen_Get_Child(P_Info, "Screen_Body_Info"));
            }
            if (P_Body is not null)
            {
                L_HTML_Object.Add_Child(_Screen_Get_Child(P_Body, "Screen_Body_Content"));
            }
            return L_HTML_Object;
        }

        private HTML_Object _Screen_Get_Child(HTML_Object P_HTML_Object, string P_ClassName, bool P_HasBorder = false)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), P_ClassName);

            if(P_HasBorder == true)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");
            }

            L_HTML_Object.Add_Child(P_HTML_Object);

            return L_HTML_Object;
        }


        public HTML_Object _Screen_Default_Header(string P_HeaderText)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Screen_Header_Default");

            L_HTML_Object.Add_Child(_Screen_Default_Header_Info());
            L_HTML_Object.Add_Child(_Screen_Default_Header_Text(P_HeaderText));

            return L_HTML_Object;
        }

        private HTML_Object _Screen_Default_Header_Info()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Icon = SH_Components_IconTypes.help,
                Icon_Pos = SH_Components_Info_Pos.Center
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Screen_Header_Default_Info");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), "_Screen_Show_Info();");

            return L_HTML_Object;
        }

        private HTML_Object _Screen_Default_Header_Text(string P_HeaderText)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Screen_Header_Default_Text");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_HeaderText)
            });

            return L_HTML_Object;
        }




    }

    
}

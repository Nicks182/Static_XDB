using Static_XDB.HTML;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public HTML_Object _FolderBrowser(SH_Components_Info P_Info)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsButton };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.CompType.ToString(), Convert.ToInt32(SH_Components_Types.FolderBrowser).ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.IsReadonly.ToString(), P_Info.IsReadonly.ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.IsHidden.ToString(), P_Info.IsHidden.ToString());

            if (string.IsNullOrEmpty(P_Info.Id) == false)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), P_Info.Id);
            }

            if (P_Info.IsFocus == true)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.autofocus.ToString(), "");
            }

            L_HTML_Object.Add_Child(_FolderBrowser_Caption(P_Info));
            L_HTML_Object.Add_Child(_FolderBrowser_Icon(P_Info));

            return L_HTML_Object;
        }

        private HTML_Object _FolderBrowser_Caption(SH_Components_Info P_Info)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsLabel };

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new System.Text.StringBuilder(P_Info.Value)
            });

            return L_HTML_Object;
        }

        private HTML_Object _FolderBrowser_Icon(SH_Components_Info P_Info)
        {
            if(P_Info.Icon == SH_Components_IconTypes.None)
            {
                P_Info.Icon = SH_Components_IconTypes.folder_open;
            }

            HTML_Object L_HTML_Object = _Icon(new SH_Components_IconInfo
            {
                IconType = P_Info.Icon
            });

            return L_HTML_Object;
        }


    }

}

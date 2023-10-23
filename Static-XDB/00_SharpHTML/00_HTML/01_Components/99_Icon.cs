using Static_XDB.HTML;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public HTML_Object _Icon(SH_Components_IconInfo P_IconInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsSpan };

            if(string.IsNullOrEmpty(P_IconInfo.Id) == false)
            {
                L_HTML_Object.Add_Attribute("Id", P_IconInfo.Id);
            }

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.CompType.ToString(), "99");
            //L_HTML_Object.Add_Attribute("Animation", P_IconInfo.Animation);

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new System.Text.StringBuilder(P_IconInfo.IconType.ToString())
            });

            return L_HTML_Object;
        }

        

    }

    public enum SH_Components_IconTypes
    {
        None,
        keyboard_double_arrow_left,
        keyboard_double_arrow_right,
        search,
        tab_new_right,
        done,
        close,
        database,
        drive_file_move,
        dns,
        add,
        add_to_queue,
        edit,
        delete_forever,
        arrow_back_ios_new,
        arrow_forward_ios,
        block,
        save,
        help,
        expand_more,
        folder_open,
        drive_folder_upload,
        cancel,
        compare_arrows,
        download,
        publish,
        difference,
    }
}

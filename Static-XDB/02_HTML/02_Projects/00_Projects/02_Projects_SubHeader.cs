using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Projects_SubHeader()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_SubHeader");

            L_HTML_Object.Add_Child(_Projects_SubHeader_Add_Btn());
            L_HTML_Object.Add_Child(_Projects_SubHeader_Import_Btn());

            return L_HTML_Object;
        }

        private HTML_Object _Projects_SubHeader_Add_Btn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "New",
                Icon = SH_Components_IconTypes.add,
                IsFlat = 1,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_SubHeader_Btn_Add");

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Projects_Edit
            }));

            return L_HTML_Object;
        }

        private HTML_Object _Projects_SubHeader_Import_Btn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Import",
                Icon = SH_Components_IconTypes.download
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_SubHeader_Btn_Import");

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Projects_Import
            }));
            
            return L_HTML_Object;
        }

        


    }
}

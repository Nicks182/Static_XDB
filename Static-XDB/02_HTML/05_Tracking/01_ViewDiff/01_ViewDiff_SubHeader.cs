using System.Text;

using SharpHTML;
using Services;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _ViewDiff_SubHeader(Srv_Tracking_DiffInfo P_Srv_Tracking_DiffInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "ViewDiff_SubHeader");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                NoClean = true,
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder("Line Changes: <b>" + P_Srv_Tracking_DiffInfo.TotalChanges.ToString() + "</b>")
            });

            return L_HTML_Object;
        }

        private HTML_Object _ViewDiff_SubHeader_ObjectChanges_Btn()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "");

            L_HTML_Object.Add_Child(_ViewDiff_SubHeader_ObjectChanges_Btn());


            return L_HTML_Object;
        }

    }
}

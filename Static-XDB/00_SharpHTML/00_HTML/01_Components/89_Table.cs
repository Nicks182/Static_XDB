using Static_XDB.HTML;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public HTML_Object _Table(SH_Components_TableInfo P_TableInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsTable };

            if (string.IsNullOrEmpty(P_TableInfo.Id) == false)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), P_TableInfo.Id);
            }

            if(P_TableInfo.Header is not null)
            {
                L_HTML_Object.Add_Child(_Table_Head(P_TableInfo));
            }

            if (P_TableInfo.BodyRows is not null)
            {
                L_HTML_Object.Add_Child(_Table_Body(P_TableInfo));
            }

            if (P_TableInfo.Footer is not null)
            {
                L_HTML_Object.Add_Child(_Table_Footer(P_TableInfo));
            }

            return L_HTML_Object;
        }

        public HTML_Object _Table_Head(SH_Components_TableInfo P_TableInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsTableHead };

            if (string.IsNullOrEmpty(P_TableInfo.Id) == false)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), P_TableInfo.Id + "_Head");
            }

            for(int i = 0; i < P_TableInfo.Header.Count; i++)
            {
                L_HTML_Object.Add_Child(P_TableInfo.Header[i]);
            }

            return L_HTML_Object;
        }

        public HTML_Object _Table_Body(SH_Components_TableInfo P_TableInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsTableBody };

            if (string.IsNullOrEmpty(P_TableInfo.Id) == false)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), P_TableInfo.Id + "_Body");
            }

            for (int i = 0; i < P_TableInfo.BodyRows.Count; i++)
            {
                L_HTML_Object.Add_Child(P_TableInfo.BodyRows[i]);
            }

            return L_HTML_Object;
        }

        public HTML_Object _Table_Footer(SH_Components_TableInfo P_TableInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsTableFoot };

            if (string.IsNullOrEmpty(P_TableInfo.Id) == false)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), P_TableInfo.Id + "_Foot");
            }

            for (int i = 0; i < P_TableInfo.Footer.Count; i++)
            {
                L_HTML_Object.Add_Child(P_TableInfo.Footer[i]);
            }

            return L_HTML_Object;
        }

        public HTML_Object _Table_Item(HTML_Object_Type P_ItemType, string P_Id, HTML_Object P_Content)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = P_ItemType };

            if (string.IsNullOrEmpty(P_Id) == false)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), P_Id);
            }

            if (P_Content is not null)
            {
                L_HTML_Object.Add_Child(P_Content);
            }

            return L_HTML_Object;
        }

    }

    public class SH_Components_TableInfo
    {
        public string Id { get; set; }
        public List<HTML_Object> Header { get; set; }
        public List<HTML_Object> BodyRows { get; set; }
        public List<HTML_Object> Footer { get; set; }
    }
}

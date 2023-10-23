
namespace SharpHTML
{
    public partial class Srv_HTML_Gen
    {
        private void _BuildElement_Tag(HTML_Object P_HTML_Object)
        {
            switch (P_HTML_Object.Type)
            {
                case HTML_Object_Type.IsDiv:
                    G_HtmlString.Append("div");
                    break;

                case HTML_Object_Type.IsImg:
                    G_HtmlString.Append("img");
                    break;

                case HTML_Object_Type.IsInput:
                    G_HtmlString.Append("input");
                    break;

                case HTML_Object_Type.IsTextarea:
                    G_HtmlString.Append("textarea");
                    break;

                case HTML_Object_Type.IsLabel:
                    G_HtmlString.Append("label");
                    break;

                case HTML_Object_Type.IsButton:
                    G_HtmlString.Append("button");
                    break;

                case HTML_Object_Type.IsSpan:
                    G_HtmlString.Append("span");
                    break;

                case HTML_Object_Type.IsTable:
                    G_HtmlString.Append("table");
                    break;

                case HTML_Object_Type.IsTableHead:
                    G_HtmlString.Append("thead");
                    break;

                case HTML_Object_Type.IsTableBody:
                    G_HtmlString.Append("tbody");
                    break;

                case HTML_Object_Type.IsTableFoot:
                    G_HtmlString.Append("tfoot");
                    break;

                case HTML_Object_Type.IsTableTR:
                    G_HtmlString.Append("tr");
                    break;

                case HTML_Object_Type.IsTableTH:
                    G_HtmlString.Append("th");
                    break;

                case HTML_Object_Type.IsTableTD:
                    G_HtmlString.Append("td");
                    break;

                case HTML_Object_Type.IsFieldset:
                    G_HtmlString.Append("fieldset");
                    break;

                case HTML_Object_Type.IsFieldsetLegend:
                    G_HtmlString.Append("legend");
                    break;

                case HTML_Object_Type.IsParagraph:
                    G_HtmlString.Append("p");
                    break;
            }
        }

    }

}

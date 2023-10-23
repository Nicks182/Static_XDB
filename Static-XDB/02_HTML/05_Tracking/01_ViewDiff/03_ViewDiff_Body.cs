using System.Text;
using System.Web;
using DiffPlex.DiffBuilder.Model;

using Services;
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _ViewDiff_Body(Srv_Tracking_DiffInfo P_Srv_Tracking_DiffInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "ViewDiff_Body");

            L_HTML_Object.Add_Child(_ViewDiff_Body_Panel(true, P_Srv_Tracking_DiffInfo.Diffs.OldText));
            L_HTML_Object.Add_Child(_ViewDiff_Body_Panel(false, P_Srv_Tracking_DiffInfo.Diffs.NewText));

            return L_HTML_Object;
        }

        private HTML_Object _ViewDiff_Body_Panel(bool P_IsOld, List<DiffPiece> P_DiffPaneModel)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "ViewDiff_Body_Panel");
            
            L_HTML_Object.Add_Child(_ViewDiff_Body_DiffHeader(P_IsOld, P_DiffPaneModel));
            L_HTML_Object.Add_Child(_ViewDiff_Body_DiffPane(P_IsOld, P_DiffPaneModel));

            return L_HTML_Object;
        }


        private HTML_Object _ViewDiff_Body_DiffHeader(bool P_IsOld, List<DiffPiece> P_DiffPaneModel)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "ViewDiff_Body_DiffHeader");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_IsOld ? "File" : "Database")
            });

            return L_HTML_Object;
        }

        private HTML_Object _ViewDiff_Body_DiffPane(bool P_IsOld, List<DiffPiece> P_DiffPaneModel)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "ViewDiff_Body_DiffPane");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.onscroll.ToString(), "_Tracking_ViewDiff_ScrollChange(this);");

            //_HTML_Object.Add_Child(_Tracking_Body_Grid(P_Tracking_Objects));

            foreach(var L_Line in  P_DiffPaneModel)//.Where(l => l.Type != ChangeType.Unchanged))
            {
                //L_HTML_Object.Add_Child(_ViewDiff_Body_DiffPane_Line(L_Line));

                L_HTML_Object.Add_Child(_ViewDiff_Body_DiffPane_Line_Number(P_IsOld, L_Line));
                L_HTML_Object.Add_Child(_ViewDiff_Body_DiffPane_Line_ChangeText(P_IsOld, L_Line));
                L_HTML_Object.Add_Child(_ViewDiff_Body_DiffPane_Line_Text(P_IsOld, L_Line));
            }

            return L_HTML_Object;
        }

        //private HTML_Object _ViewDiff_Body_DiffPane_Line(DiffPiece P_Line)
        //{
        //    HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

        //    L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "ViewDiff_Body_DiffPane_Line");
        //    L_HTML_Object.Add_Attribute(HTML_Attribute_Names.DiffType.ToString(), _ViewDiff_Body_DiffPane_Line_Type(P_Line));

        //    L_HTML_Object.Add_Child(_ViewDiff_Body_DiffPane_Line_Number(P_Line));
        //    L_HTML_Object.Add_Child(_ViewDiff_Body_DiffPane_Line_Text(P_Line));

        //    return L_HTML_Object;
        //}

        private HTML_Object _ViewDiff_Body_DiffPane_Line_Number(bool P_IsOld, DiffPiece P_Line)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsSpan };
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "ViewDiff_Body_DiffPane_Line");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.DiffType.ToString(), _ViewDiff_Body_DiffPane_Line_Type(P_IsOld, P_Line));
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.DiffAlign.ToString(), "1");

            StringBuilder L_Text = new StringBuilder();

            if (P_Line.Position is not null)
            {
                L_Text.Append(P_Line.Position.Value.ToString());
            }

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = L_Text
            });

            return L_HTML_Object;
        }

        private HTML_Object _ViewDiff_Body_DiffPane_Line_ChangeText(bool P_IsOld, DiffPiece P_Line)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsSpan };
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "ViewDiff_Body_DiffPane_Line");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.DiffType.ToString(), _ViewDiff_Body_DiffPane_Line_Type(P_IsOld, P_Line));

            StringBuilder L_Text = new StringBuilder();

            

            var L_ChangeType = _ViewDiff_Body_DiffPane_Line_ChangeType(P_IsOld, P_Line);

            switch (L_ChangeType)
            {
                case ChangeType.Inserted:
                    L_Text.Append("+");
                    break;

                case ChangeType.Deleted:
                    L_Text.Append("-");
                    break;

                default:
                    L_Text.Append(" ");
                    break;
            }

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = L_Text
            });
            
            return L_HTML_Object;
        }

        private HTML_Object _ViewDiff_Body_DiffPane_Line_Text(bool P_IsOld, DiffPiece P_Line)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsLabel };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "ViewDiff_Body_DiffPane_Line");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.DiffType.ToString(), _ViewDiff_Body_DiffPane_Line_Type(P_IsOld, P_Line));

            StringBuilder L_Text = new StringBuilder();

            if (P_IsOld == false)
            {
                string bla = "";
            }

            if (P_IsOld == false && P_Line.Type == ChangeType.Modified)
            {
                for (int i = 0; i < P_Line.SubPieces.Count; i++)
                {
                    if (P_Line.SubPieces[i].Type == ChangeType.Inserted)
                    {
                        
                        L_Text.Append("<span class=\"ViewDiff_Body_DiffPane_Line\" DiffType=\"1\" >" + HttpUtility.HtmlEncode(P_Line.SubPieces[i].Text) + "</span>");
                    }
                    else
                    {
                        L_Text.Append(HttpUtility.HtmlEncode(P_Line.SubPieces[i].Text));
                    }
                }
            }
            else if (string.IsNullOrEmpty(P_Line.Text) == false)
            {
                L_Text.Append(P_Line.Text);
            }

            L_HTML_Object.Add_Child(new HTML_Object
            {
                NoClean = true,
                Type = HTML_Object_Type.IsRaw,
                RawValue = L_Text
            });

            return L_HTML_Object;
        }

        private HTML_Object _ViewDiff_Body_DiffPane_Line_Text_Modified(bool P_IsOld, DiffPiece P_Line)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsParagraph };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "ViewDiff_Body_DiffPane_Line");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.DiffType.ToString(), "1");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_Line.Text)
            });

            return L_HTML_Object;
        }

        private ChangeType _ViewDiff_Body_DiffPane_Line_ChangeType(bool P_IsOld, DiffPiece P_Line)
        {
            var L_ChangeType = P_Line.Type;
            if (L_ChangeType == ChangeType.Modified)
            {
                L_ChangeType = (P_IsOld) ? ChangeType.Deleted : ChangeType.Inserted;
            }

            return L_ChangeType;
        }

        private string _ViewDiff_Body_DiffPane_Line_Type(bool P_IsOld, DiffPiece P_Line)
        {
            var L_ChangeType = _ViewDiff_Body_DiffPane_Line_ChangeType(P_IsOld, P_Line);

            switch (L_ChangeType)
            {
                case ChangeType.Modified:
                    
                    if (P_IsOld == true)
                    {
                        return "0";
                    }
                    return "1";

                case ChangeType.Deleted:
                    return "2";

                case ChangeType.Inserted:
                    return "3";

                case ChangeType.Imaginary:
                    return "4";

                default:
                    return "0";
            }
        }
    }
}

using System.Text;
using System.Web;

namespace SharpHTML
{
    public partial class Srv_HTML_Gen
    {
        private void _BuildElement(HTML_Object P_HTML_Object)
        {
            if (P_HTML_Object.Type == HTML_Object_Type.IsRaw)
            {
                _BuildElement_Raw(P_HTML_Object);
            }
            else
            {
                _BuildElement_Open(P_HTML_Object);

                for (int i = 0; i < P_HTML_Object.Children.Count; i++)
                {
                    _BuildElement(P_HTML_Object.Children[i]);
                }

                _BuildElement_Close(P_HTML_Object);
            }
        }

        private void _BuildElement_Open(HTML_Object P_HTML_Object)
        {
                G_HtmlString.Append('<');
                _BuildElement_Tag(P_HTML_Object);
                _BuildAttributes(P_HTML_Object);
                G_HtmlString.Append('>');
        }

        private void _BuildElement_Close(HTML_Object P_HTML_Object)
        {
            G_HtmlString.Append('<');
            G_HtmlString.Append('/');
            _BuildElement_Tag(P_HTML_Object);
            G_HtmlString.Append('>');
        }


        private void _BuildElement_Raw(HTML_Object P_HTML_Object)
        {
            if (P_HTML_Object.RawValue != null)
            {
                if (P_HTML_Object.NoClean == true)
                {
                    G_HtmlString.Append(P_HTML_Object.RawValue.ToString());
                }
                else
                {
                    G_HtmlString.Append(_Clean(P_HTML_Object.RawValue.ToString()));
                }
            }
        }



    }

}

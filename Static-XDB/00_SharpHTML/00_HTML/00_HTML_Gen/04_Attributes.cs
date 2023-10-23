
namespace SharpHTML
{
    public partial class Srv_HTML_Gen
    {
        private void _BuildAttributes(HTML_Object P_HTML_Object)
        {
            // Example:
            // SomeAttributeName="SomeValue"
            for (int i = 0; i < P_HTML_Object.Attributes.Count; i++)
            {
                G_HtmlString.Append(' ');
                G_HtmlString.Append(_Clean(P_HTML_Object.Attributes[i].Name));
                G_HtmlString.Append('=');
                G_HtmlString.Append('"');
                G_HtmlString.Append(_Clean(P_HTML_Object.Attributes[i].Value.ToString()));
                G_HtmlString.Append('"');
            }
        }
    }

}

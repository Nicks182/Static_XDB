using System.Text;
using System.Web;

namespace SharpHTML
{
    public partial class Srv_HTML_Gen
    {
        StringBuilder G_HtmlString = new StringBuilder();

        public StringBuilder _BuildHtml(HTML_Object P_HTML_Object)
        {
            G_HtmlString.Clear();
            _BuildElement(P_HTML_Object);
            //_GenerateHtml(P_HTML_Object);
            return G_HtmlString;
        }

        public StringBuilder _BuildHtml(List<HTML_Object> P_HTML_Objects)
        {
            G_HtmlString.Clear();
            for (int i = 0; i < P_HTML_Objects.Count; i++)
            {
                _BuildElement(P_HTML_Objects[i]);
                //_GenerateHtml(P_HTML_Objects[i]);
            }
            return G_HtmlString;
        }



        private string _Clean(string P_Value)
        {
            return HttpUtility.HtmlEncode(P_Value);
        }
        
    
    }

}


using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Projects(List<Services.DB.ProjectInfo> P_ProjectInfos)
        {
            return _Screen(
                "Projects",
                _Projects_SubHeader(), 
                _Projects_Info(), 
                _Projects_Body(P_ProjectInfos), 
                _Projects_Footer());
        }

        

    }
}

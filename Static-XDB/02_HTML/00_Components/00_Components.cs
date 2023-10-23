
using Services;
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        SH_Components G_SH_Components = null;
        public HTML_Components()
        {
            G_SH_Components = new SH_Components();
        }

        public static string _PushMessage_Event(TM_Message P_TM_Message)
        {
            return
            "_PushMessage('" +
                SH_ActionGen._CreateAction(P_TM_Message) +
            "');";
        }

        public HTML_Object _Get_Busy()
        {
            return G_SH_Components._Busy_Modal();
        }
    }

    
}

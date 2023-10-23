
using SharpHTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        public void _IgnoredObjects_Remove(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            DB.Ignore L_Ignore = G_Srv_DB.Ignore_Get(P_TM_Message.Data);

            G_Srv_DB.Ignore_Delete(L_Ignore);

            P_TM_Message.Actions.Clear();

            _IgnoredObjects_Show_Render(P_TM_Message, L_State_Item, L_Ignore.ProjectInfoId);
        }

    }
}

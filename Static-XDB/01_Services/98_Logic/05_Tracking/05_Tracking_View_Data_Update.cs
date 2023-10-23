using System.Text;
using Microsoft.SqlServer.Management.Smo;
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        private async void _Tracking_View_Data_Update(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "ProjectInfoId").FirstOrDefault();

            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());

            await G_Srv_Tracking._Check_DB_Data(L_ProjectInfo);

            _Tracking_View_Data(P_TM_Message, G_Srv_DB.Tracking_Data_GetAll().Find(td => td.Changed > 0).ToList());

            G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.TransportMessage, SH_ActionGen._ToJSON_String(P_TM_Message));
        }


    }
}

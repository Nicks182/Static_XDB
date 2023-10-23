
using SharpHTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public async void _PushIt_To_Files(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "Main_Project_Id").FirstOrDefault();

            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());

            G_Srv_SMO = new Srv_SMO(G_Srv_MessageBus, G_Srv_DB, L_ProjectInfo);

            await G_Srv_SMO._Push_To_Files();
        }
    }
}

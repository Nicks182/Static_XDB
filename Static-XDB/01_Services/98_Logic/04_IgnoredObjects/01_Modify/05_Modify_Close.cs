
using SharpHTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        public void _IgnoredObjects_Close(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();
            SH_State_Item L_State_Item_Parent = G_SH_State.Get_Current_Parent();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "ProjectInfoId").FirstOrDefault();

            _IgnoredObjects_Show_Render(P_TM_Message, L_State_Item_Parent, L_State_Control.Value.ToString());

            G_SH_State._Remove(L_State_Item.Id);
            G_SH_State.Set_Focus(L_State_Item_Parent);
        }


    }
}

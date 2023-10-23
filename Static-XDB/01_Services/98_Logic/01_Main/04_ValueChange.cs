using SharpHTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _ValueChange(TM_Message P_TM_Message)
        {
            SH_Action L_SH_Action = P_TM_Message.Actions.Where(a => a.SourceId == P_TM_Message.Data).FirstOrDefault();
            if (L_SH_Action is not null)
            {
                SH_State_Item L_State_Item = G_SH_State.Get_Current();

                SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == L_SH_Action.SourceId).FirstOrDefault();

                switch(L_State_Control.Components_Type)
                {
                    case SH_Components_Types.Checkbox:
                        int L_CurrentVal = Convert.ToInt32(L_State_Control.Value);
                        if (L_CurrentVal == 1)
                        {
                            L_State_Control.Value = 0;
                        }
                        else
                        {
                            L_State_Control.Value = 1;
                        }
                        break;

                    default:
                        L_State_Control.Value = L_SH_Action.Value;
                        break;
                }
                

            }

            P_TM_Message.Message_Type = TM_Message_Type.DoNothing;
        }
    }
}

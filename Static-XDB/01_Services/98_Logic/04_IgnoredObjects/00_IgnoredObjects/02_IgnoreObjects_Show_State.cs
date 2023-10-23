
using SharpHTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public SH_State_Item _IgnoredObjects_Show_State(string P_ParentId, DB.ProjectInfo P_ProjectInfo)
        {

            SH_State_Item L_SH_FormState_Item = new SH_State_Item();
            L_SH_FormState_Item.ParentId = P_ParentId;

            L_SH_FormState_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "ProjectInfoId",
                IsHidden = true,
                Value = P_ProjectInfo.Id,
            });

            L_SH_FormState_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "ProjectInfoName",
                IsHidden = true,
                Value = P_ProjectInfo.Name,
            });

            G_SH_State.Add(L_SH_FormState_Item);

            return L_SH_FormState_Item;


        }


        
    }

    
}

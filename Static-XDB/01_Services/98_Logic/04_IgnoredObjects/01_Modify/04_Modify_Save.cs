
using SharpHTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        public void _IgnoredObjects_Save(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_ProjectId = L_State_Item.G_Controls.Where(c => c.Id == "ProjectInfoId").FirstOrDefault();

            _IgnoredObjects_Save_ClearAllExisting(L_ProjectId.Value.ToString());

            foreach (var L_SCtrl in L_State_Item.G_Controls.Where(c => c.Components_Type == SH_Components_Types.Checkbox && c.Value.ToString().Equals("1")))
            {
                G_Srv_DB.Ignore_Save(new DB.Ignore
                {
                    Name = L_SCtrl._Get_MetaValue("Name").ToString(),
                    ProjectInfoId = L_ProjectId.Value.ToString(),
                    Type = _IgnoredObjects_Save_GetIgnoreType(L_SCtrl._Get_MetaValue("IgnoreType").ToString())
                });
            }

            P_TM_Message.Message_Type = TM_Message_Type.Ignores_Modify_Close;
            P_TM_Message.Actions.Clear();
            _IgnoredObjects_Close(P_TM_Message);
        }

        private DB.Ignore_Type _IgnoredObjects_Save_GetIgnoreType(string P_Type)
        {
            return (DB.Ignore_Type)Enum.Parse(typeof(DB.Ignore_Type), P_Type);
        }

        private void _IgnoredObjects_Save_ClearAllExisting(string P_ProjectId)
        {
            List<DB.Ignore> L_List = G_Srv_DB.Ignore_GetAll().Find(i => i.ProjectInfoId == P_ProjectId).ToList();

            for(int i = 0; i < L_List.Count; i++) 
            {
                G_Srv_DB.Ignore_Delete(L_List[i]);
            }
        }

    }
}

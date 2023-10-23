using System.Text;

using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        public void _Projects_Show_SQLVersion_Modal(TM_Message P_TM_Message)
        {
            

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Get_Projects_Edit_Form_SQLVersion_Modal(Srv_MSSQL._GetSqlVersions())));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_ModalHolder.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = true
            });

            P_TM_Message.Actions.Clear();
            P_TM_Message.Message_Type = TM_Message_Type.ShowModal;
            
        }

        public void _Projects_Select_SQLVersion(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            MSSQL_Version L_MSSQL_Version = Srv_MSSQL._GetSqlVersions().Where(sv => sv.Version.Equals(P_TM_Message.Data)).FirstOrDefault();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "Project_SQLVersion").FirstOrDefault();

            L_State_Control.Value = L_MSSQL_Version.Version;

            P_TM_Message.Actions.Clear();
            P_TM_Message.Actions.Add(new SH_Action
            {
                Action_Type = SH_Action_Type.SetValue,
                SourceId = "Project_SQLVersion",
                Value = L_MSSQL_Version.Description
            });

            P_TM_Message.Message_Type = TM_Message_Type.DoNothing;

        }

    }


}

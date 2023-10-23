using System.Text;

using SharpHTML;
using Static_XDB.HTML;


namespace Services
{
    public partial class Srv_Logic
    {
        public void _FolderBrowser(TM_Message P_TM_Message)
        {
            switch (P_TM_Message.Message_Type)
            {
                case TM_Message_Type.FolderBrowser_Show:
                    _FolderBrowser_Show(P_TM_Message);
                    break;

                case TM_Message_Type.FolderBrowser_GoTo:
                    _FolderBrowser_GoTo(P_TM_Message);
                    break;

                case TM_Message_Type.FolderBrowser_GoUp:
                    _FolderBrowser_GoUp(P_TM_Message);
                    break;

                case TM_Message_Type.FolderBrowser_Select:
                    _FolderBrowser_Select(P_TM_Message);
                    break;

                case TM_Message_Type.FolderBrowser_Cancel:
                    _FolderBrowser_Cancel(P_TM_Message);
                    break;

            }

        }

        public void _FolderBrowser_Show(TM_Message P_TM_Message)
        {
            G_Srv_DriveBrowser = new Srv_DriveBrowser(Srv_DriveBrowser_ItemTypes.Only_Directories);

            SH_State_Item L_FolderBrowser_State = _FolderBrowser_Get_State(P_TM_Message);

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._FolderBrowser_Modal(G_Srv_DriveBrowser)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_ModalHolder.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = true
            });

            P_TM_Message.Actions.Clear();
            P_TM_Message.Message_Type = TM_Message_Type.ShowModal;
        }

        public void _FolderBrowser_GoTo(TM_Message P_TM_Message)
        {

            SH_State_Item L_FolderBrowser_State = G_SH_State.Get_Current();

            G_Srv_DriveBrowser.Go_To(P_TM_Message.Data);

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._FolderBrowser_Body_CurrentPath(G_Srv_DriveBrowser)));
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._FolderBrowser_Body_Content(G_Srv_DriveBrowser)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_FolderBrowser_Modal_Body.ToString(),
                HTML = L_Html.ToString()
            });

            P_TM_Message.Actions.Clear();
            P_TM_Message.Message_Type = TM_Message_Type.DoNothing;

        }

        public void _FolderBrowser_GoUp(TM_Message P_TM_Message)
        {
            SH_State_Item L_FolderBrowser_State = G_SH_State.Get_Current();

            G_Srv_DriveBrowser.Go_Up();

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._FolderBrowser_Body_CurrentPath(G_Srv_DriveBrowser)));
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._FolderBrowser_Body_Content(G_Srv_DriveBrowser)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_FolderBrowser_Modal_Body.ToString(),
                HTML = L_Html.ToString()
            });

            P_TM_Message.Actions.Clear();
            P_TM_Message.Message_Type = TM_Message_Type.DoNothing;


        }

        public void _FolderBrowser_Select(TM_Message P_TM_Message)
        {
            SH_State_Item L_FolderBrowser_State = G_SH_State.Get_Current();
            SH_State_Item_Control L_ParentState_Id = L_FolderBrowser_State.G_Controls.Where(c => c.Id.Equals("ParentState_Id")).FirstOrDefault();
            SH_State_Item_Control L_ParentState_Control_Id = L_FolderBrowser_State.G_Controls.Where(c => c.Id.Equals("ParentState_Control_Id")).FirstOrDefault();


            SH_State_Item L_Parent_State = G_SH_State.Get(L_ParentState_Id.Value.ToString());
            SH_State_Item_Control L_Parent_State_Control = L_Parent_State.G_Controls.Where(c => c.Id.Equals(L_ParentState_Control_Id.Value.ToString())).FirstOrDefault();

            L_Parent_State_Control.Value = G_Srv_DriveBrowser.GetCurrentLocation().FullPath;

            P_TM_Message.Actions.Clear();
            P_TM_Message.Actions.Add(new SH_Action
            {
                Action_Type = SH_Action_Type.SetValue,
                SourceId = L_Parent_State_Control.Id,
                Value = L_Parent_State_Control.Value
            });

            P_TM_Message.Message_Type = TM_Message_Type.DoNothing;
            G_SH_State.Set_Focus(L_Parent_State);
        }

        public void _FolderBrowser_Cancel(TM_Message P_TM_Message)
        {



        }

        public SH_State_Item _FolderBrowser_Get_State(TM_Message P_TM_Message)
        {
            SH_State_Item L_FolderBrowser_State = new SH_State_Item();

            L_FolderBrowser_State.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "ParentState_Id",
                Value = P_TM_Message.UniqueId
            });

            L_FolderBrowser_State.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "ParentState_Control_Id",
                Value = P_TM_Message.Data
            });

            G_SH_State.Add(L_FolderBrowser_State);

            return L_FolderBrowser_State;
        }

    }
}

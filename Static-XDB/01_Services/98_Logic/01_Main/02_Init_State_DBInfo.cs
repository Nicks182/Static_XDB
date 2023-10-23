
using SharpHTML;

namespace Services
{
    public partial class Srv_Logic
    {
        private List<SH_State_Item_Control> _Init_Get_MainState_DBInfo(DB.ProjectInfo P_ProjectInfo)
        {
            List<SH_State_Item_Control> L_SH_State_Item_Controls = new List<SH_State_Item_Control>();

            L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_Online(P_ProjectInfo));
            
            L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_Server(P_ProjectInfo));
            L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_Port(P_ProjectInfo));
            //L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_Username(P_ProjectInfo));
            //L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_Password(P_ProjectInfo));
            L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_Integrated(P_ProjectInfo));
            L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_Trust(P_ProjectInfo));
            L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_DBBranch(P_ProjectInfo));
            
            L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_DBLastCommit(P_ProjectInfo));
            L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_DBLastCommitMsg(P_ProjectInfo));
            L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_DBCommitter(P_ProjectInfo));
            L_SH_State_Item_Controls.Add(_Init_Get_MainState_DBInfo_DBDatePushed(P_ProjectInfo));

            return L_SH_State_Item_Controls;
        }

        private SH_State_Item_Control _Init_Get_MainState_DBInfo_Online(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_DBInfo_IsOnline";
            L_SH_State_Item_Control.Caption = "Is Online?";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            L_SH_State_Item_Control.Value = "Unkown";
            L_SH_State_Item_Control.Text = "Unkown";

            return L_SH_State_Item_Control;
        }

        private SH_State_Item_Control _Init_Get_MainState_DBInfo_Server(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_DBInfo_Server";
            L_SH_State_Item_Control.Caption = "Server:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            if (P_ProjectInfo is not null && string.IsNullOrEmpty(P_ProjectInfo.Server) == false)
            {
                L_SH_State_Item_Control.Value = P_ProjectInfo.Server;
                L_SH_State_Item_Control.Text = P_ProjectInfo.Server;
            }
            else
            {
                L_SH_State_Item_Control.Value = "...";
                L_SH_State_Item_Control.Text = "...";
            }

            return L_SH_State_Item_Control;
        }

        private SH_State_Item_Control _Init_Get_MainState_DBInfo_Port(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_DBInfo_Port";
            L_SH_State_Item_Control.Caption = "Port:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            if (P_ProjectInfo is not null && string.IsNullOrEmpty(P_ProjectInfo.Port) == false)
            {
                L_SH_State_Item_Control.Value = P_ProjectInfo.Port;
                L_SH_State_Item_Control.Text = P_ProjectInfo.Port;
            }
            else
            {
                L_SH_State_Item_Control.Value = "...";
                L_SH_State_Item_Control.Text = "...";
            }

            return L_SH_State_Item_Control;
        }

        //private SH_State_Item_Control _Init_Get_MainState_DBInfo_Username(DB.ProjectInfo P_ProjectInfo)
        //{
        //    SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
        //    L_SH_State_Item_Control.Id = "Main_DBInfo_Username";
        //    L_SH_State_Item_Control.Caption = "Username:";
        //    L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
        //    L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
        //    if (P_ProjectInfo is not null && string.IsNullOrEmpty(P_ProjectInfo.Username) == false)
        //    {
        //        L_SH_State_Item_Control.Value = P_ProjectInfo.Username;
        //        L_SH_State_Item_Control.Text = P_ProjectInfo.Username;
        //    }
        //    else
        //    {
        //        L_SH_State_Item_Control.Value = "...";
        //        L_SH_State_Item_Control.Text = "...";
        //    }

        //    return L_SH_State_Item_Control;
        //}

        //private SH_State_Item_Control _Init_Get_MainState_DBInfo_Password(DB.ProjectInfo P_ProjectInfo)
        //{
        //    SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
        //    L_SH_State_Item_Control.Id = "Main_DBInfo_Password";
        //    L_SH_State_Item_Control.Caption = "Password:";
        //    L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
        //    L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
        //    if (P_ProjectInfo is not null && string.IsNullOrEmpty(P_ProjectInfo.Password) == false)
        //    {
        //        L_SH_State_Item_Control.Value = "******";
        //        L_SH_State_Item_Control.Text = "******";
        //    }
        //    else
        //    {
        //        L_SH_State_Item_Control.Value = "...";
        //        L_SH_State_Item_Control.Text = "...";
        //    }

        //    return L_SH_State_Item_Control;
        //}

        private SH_State_Item_Control _Init_Get_MainState_DBInfo_Integrated(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_DBInfo_Integrated";
            L_SH_State_Item_Control.Caption = "Integrated:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            if (P_ProjectInfo is not null)
            {
                L_SH_State_Item_Control.Value = P_ProjectInfo.Integrated;
                L_SH_State_Item_Control.Text = P_ProjectInfo.Integrated.ToString();
            }
            else
            {
                L_SH_State_Item_Control.Value = "...";
                L_SH_State_Item_Control.Text = "...";
            }

            return L_SH_State_Item_Control;
        }

        private SH_State_Item_Control _Init_Get_MainState_DBInfo_Trust(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_DBInfo_Trust";
            L_SH_State_Item_Control.Caption = "Trust Server:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            if (P_ProjectInfo is not null)
            {
                L_SH_State_Item_Control.Value = P_ProjectInfo.TrustServerCertificate;
                L_SH_State_Item_Control.Text = P_ProjectInfo.TrustServerCertificate.ToString();
            }
            else
            {
                L_SH_State_Item_Control.Value = "...";
                L_SH_State_Item_Control.Text = "...";
            }

            return L_SH_State_Item_Control;
        }

        private SH_State_Item_Control _Init_Get_MainState_DBInfo_DBBranch(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_DBInfo_DBBranch";
            L_SH_State_Item_Control.Caption = "With Branch:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            L_SH_State_Item_Control.Value = "Unkown";
            L_SH_State_Item_Control.Text = "Unkown";

            return L_SH_State_Item_Control;
        }


        private SH_State_Item_Control _Init_Get_MainState_DBInfo_DBLastCommit(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_DBInfo_DBLastCommit";
            L_SH_State_Item_Control.Caption = "With Commit:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            L_SH_State_Item_Control.Value = "Unkown";
            L_SH_State_Item_Control.Text = "Unkown";

            return L_SH_State_Item_Control;
        }

        private SH_State_Item_Control _Init_Get_MainState_DBInfo_DBLastCommitMsg(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_DBInfo_DBLastCommitMsg";
            L_SH_State_Item_Control.Caption = "With Commit Msg:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            L_SH_State_Item_Control.Value = "Unkown";
            L_SH_State_Item_Control.Text = "Unkown";

            return L_SH_State_Item_Control;
        }

        private SH_State_Item_Control _Init_Get_MainState_DBInfo_DBCommitter(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_DBInfo_DBCommitter";
            L_SH_State_Item_Control.Caption = " With Committer:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            L_SH_State_Item_Control.Value = "Unkown";
            L_SH_State_Item_Control.Text = "Unkown";

            return L_SH_State_Item_Control;
        }

        private SH_State_Item_Control _Init_Get_MainState_DBInfo_DBDatePushed(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_DBInfo_DBDatePushed";
            L_SH_State_Item_Control.Caption = "Date Pushed:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            L_SH_State_Item_Control.Value = "Unkown";
            L_SH_State_Item_Control.Text = "Unkown";

            return L_SH_State_Item_Control;
        }

    }
}

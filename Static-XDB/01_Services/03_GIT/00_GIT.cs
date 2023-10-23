
using LibGit2Sharp;

namespace Services
{
    public partial class Srv_GIT
    {
        private Srv_MessageBus G_Srv_MessageBus;
        
        public Srv_GIT(Srv_MessageBus P_Srv_MessageBus)
        {
            G_Srv_MessageBus = P_Srv_MessageBus;
            
        }

        public static Srv_GIT_Info _Get_GIT_Info(DB.ProjectInfo P_ProjectInfo)
        {
            Srv_GIT_Info L_Srv_GIT_Info = new Srv_GIT_Info();

            if (P_ProjectInfo is not null)
            {
                Repository L_Repository = _Get_Repository(P_ProjectInfo);

                if (L_Repository is not null)
                {
                    L_Srv_GIT_Info.Branch = L_Repository.Head.FriendlyName;
                    L_Srv_GIT_Info.Committer = L_Repository.Head.Tip.Committer.Name;
                    L_Srv_GIT_Info.LastCommit = L_Repository.Head.Tip.Sha;

                    L_Srv_GIT_Info.LastCommitMsg = L_Repository.Head.Tip.MessageShort;
                    L_Srv_GIT_Info.ProjectFolder = P_ProjectInfo.ProjectFolder;

                    L_Srv_GIT_Info.Remote = L_Repository.Config.GetValueOrDefault<string>("remote.origin.url");
                }
            }
            return L_Srv_GIT_Info;
        }


        private static Repository _Get_Repository(DB.ProjectInfo P_ProjectInfo)
        {
            try
            {
                if (string.IsNullOrEmpty(P_ProjectInfo.ProjectFolder) == false)
                {
                    if (LibGit2Sharp.Repository.IsValid(P_ProjectInfo.ProjectFolder) == true)
                    {
                        return new Repository(LibGit2Sharp.Repository.Discover(P_ProjectInfo.ProjectFolder));
                    }
                    //using (var git = new Repository(LibGit2Sharp.Repository.Discover(P_ProjectInfo.ProjectFolder)))
                    //{
                    //    return git.Head.FriendlyName;
                    //}
                }
            }
            catch (Exception ex)
            {
                
            }

            return null;
        }

    }

    public class Srv_GIT_Info
    {
        public string Branch { get; set; } = "NA";
        public string LastCommit { get; set; } = "NA";
        public string LastCommitMsg { get; set; } = "NA";
        public string Committer { get; set; } = "NA";
        public string Remote { get; set; } = "NA";
        public string ProjectFolder { get; set; } = "NA";
    }
}


namespace Services
{
    public class Srv_ScriptsFolder
    {
        const string G_ScriptsFolder = "Scripts";
        public static string _Get(DB.ProjectInfo P_ProjectInfo)
        {
            string L_Path = Path.Combine(P_ProjectInfo.ProjectFolder, G_ScriptsFolder);
            if(Directory.Exists(L_Path) == false)
            {
                Directory.CreateDirectory(L_Path);
            }
            return L_Path;
        }


    }
}


using DiffPlex.DiffBuilder.Model;
using Microsoft.SqlServer.Management.Smo;
using Services.DB;
using System.Text;

namespace Services
{
    public partial class Srv_Tracking
    {
        public Srv_Tracking_DiffInfo _ViewDiff(DB.ProjectInfo P_ProjectInfo, string P_Tracking_Object_Id)
        {
            Srv_Tracking_DiffInfo L_Srv_Tracking_DiffInfo = new Srv_Tracking_DiffInfo();

            DB.Tracking_Object L_Tracking_Object = G_Srv_DB.Tracking_Object_GetAll().Find(to => to.Id.Equals(P_Tracking_Object_Id)).FirstOrDefault();

            DiffPlex.DiffBuilder.SideBySideDiffBuilder L_SideBySideDiffBuilder = new DiffPlex.DiffBuilder.SideBySideDiffBuilder();

            Srv_SMO L_Srv_SMO = new Srv_SMO(G_Srv_MessageBus, G_Srv_DB, P_ProjectInfo);
            
            Srv_SMO_Type L_Srv_SMO_Type = L_Srv_SMO._Convert_Type(L_Tracking_Object.ObjectType);
            Srv_SMO_Object_Info L_Srv_SMO_Object_Info = L_Srv_SMO._Script_Single_Object(L_Tracking_Object.ObjectName, L_Srv_SMO_Type);

            SideBySideDiffModel L_Model_Temp = L_SideBySideDiffBuilder.BuildDiffModel(_ViewDiff_GetFileText(L_Srv_SMO_Object_Info.FilePath), L_Srv_SMO_Object_Info.Script);

            L_Srv_Tracking_DiffInfo.ProjectId = P_ProjectInfo.Id;
            L_Srv_Tracking_DiffInfo.ProjectName = P_ProjectInfo.Name;
            L_Srv_Tracking_DiffInfo.ObjectName = L_Tracking_Object.ObjectName;
            L_Srv_Tracking_DiffInfo.Diffs.NewText.AddRange(L_Model_Temp.NewText.Lines);
            L_Srv_Tracking_DiffInfo.Diffs.OldText.AddRange(L_Model_Temp.OldText.Lines);

            L_Srv_Tracking_DiffInfo.TotalChanges = L_Srv_Tracking_DiffInfo.Diffs.NewText.Where(l =>
                    l.Type == ChangeType.Deleted
                    || l.Type == ChangeType.Inserted
                    || l.Type == ChangeType.Modified
                    || l.Type == ChangeType.Imaginary).Count();

            return L_Srv_Tracking_DiffInfo;
        }


        public Srv_Tracking_DiffInfo _ViewDiff_Data(Srv_SMO P_Srv_SMO, DB.ProjectInfo P_ProjectInfo, string P_TableName)
        {
            string L_FolderPath = Path.Combine(P_Srv_SMO._Get_File_Folder(Srv_SMO_Type.Data), P_TableName);
            if (Directory.Exists(L_FolderPath) == false)
            {
                return null;
            }

            Srv_Tracking_DiffInfo L_Srv_Tracking_DiffInfo = new Srv_Tracking_DiffInfo();
            L_Srv_Tracking_DiffInfo.ProjectId = P_ProjectInfo.Id;
            L_Srv_Tracking_DiffInfo.ProjectName = P_ProjectInfo.Name;
            L_Srv_Tracking_DiffInfo.ObjectName = P_TableName;

            DiffPlex.DiffBuilder.SideBySideDiffBuilder L_SideBySideDiffBuilder = new DiffPlex.DiffBuilder.SideBySideDiffBuilder();

            

            List<string> L_Files = Directory.GetFiles(L_FolderPath, "*.sql").ToList();
            List<Srv_SMO_Object_Info> L_Srv_SMO_Object_Infos = P_Srv_SMO._Script_Single_Data(P_TableName);

            StringBuilder L_OldText_Main = new StringBuilder();
            StringBuilder L_NewText_Main = new StringBuilder();
            StringBuilder L_OldText_Temp = new StringBuilder();
            StringBuilder L_NewText_Temp = new StringBuilder();
            Srv_SMO_Object_Info L_Srv_SMO_Object_Info = null;
            SideBySideDiffModel L_Model_Temp = null;
            for (int f = 0; f < L_Files.Count; f++)
            {
                L_OldText_Temp.Clear();
                L_NewText_Temp.Clear();

                L_Srv_SMO_Object_Info = L_Srv_SMO_Object_Infos.Where(fi => fi.FilePath.Equals(L_Files[f])).FirstOrDefault();

                L_OldText_Temp.Append(_ViewDiff_GetFileText(L_Files[f]));
                if (L_Srv_SMO_Object_Info is not null && string.IsNullOrEmpty(L_Srv_SMO_Object_Info.Script) == false)
                {
                    L_NewText_Temp.Append(L_Srv_SMO_Object_Info.Script);
                }

                L_Model_Temp = L_SideBySideDiffBuilder.BuildDiffModel(L_OldText_Temp.ToString(), L_NewText_Temp.ToString());
                
                if (L_Model_Temp.NewText.HasDifferences == true)
                {
                    L_Srv_Tracking_DiffInfo.Diffs.NewText.AddRange(L_Model_Temp.NewText.Lines);
                    L_Srv_Tracking_DiffInfo.Diffs.OldText.AddRange(L_Model_Temp.OldText.Lines);
                }
            }

            for (int i = 0; i < L_Srv_SMO_Object_Infos.Count; i++)
            {
                if (File.Exists(L_Srv_SMO_Object_Infos[i].FilePath) == false)
                {
                    L_OldText_Temp.Clear();
                    L_NewText_Temp.Clear();

                    L_NewText_Temp.Append(L_Srv_SMO_Object_Infos[i].Script);

                    L_Model_Temp = L_SideBySideDiffBuilder.BuildDiffModel(L_OldText_Temp.ToString(), L_NewText_Temp.ToString());

                    if (L_Model_Temp.NewText.HasDifferences == true)
                    {
                        L_Srv_Tracking_DiffInfo.Diffs.NewText.AddRange(L_Model_Temp.NewText.Lines);
                        L_Srv_Tracking_DiffInfo.Diffs.OldText.AddRange(L_Model_Temp.OldText.Lines);
                    }
                }

                
            }

            int L_LineNumber = 0;
            for(int i = 0; i < L_Srv_Tracking_DiffInfo.Diffs.NewText.Count; i++)
            {
                if (L_Srv_Tracking_DiffInfo.Diffs.NewText[i].Type != ChangeType.Imaginary)
                {
                    L_LineNumber++;
                    L_Srv_Tracking_DiffInfo.Diffs.NewText[i].Position = L_LineNumber;
                }
            }

            L_LineNumber = 0;
            for (int i = 0; i < L_Srv_Tracking_DiffInfo.Diffs.OldText.Count; i++)
            {
                if (L_Srv_Tracking_DiffInfo.Diffs.OldText[i].Type != ChangeType.Imaginary)
                {
                    L_LineNumber++;
                    L_Srv_Tracking_DiffInfo.Diffs.OldText[i].Position = L_LineNumber;
                }
            }

            L_Srv_Tracking_DiffInfo.TotalChanges = L_Srv_Tracking_DiffInfo.Diffs.NewText.Where(l =>
                    l.Type == ChangeType.Deleted
                    || l.Type == ChangeType.Inserted
                    || l.Type == ChangeType.Modified
                    || l.Type == ChangeType.Imaginary).Count();

            return L_Srv_Tracking_DiffInfo;
        }

        private string _ViewDiff_GetFileText(string P_FilePath)
        {
            if (File.Exists(P_FilePath) == false)
            {
                return "File could not be found: " + Path.Combine(Environment.CurrentDirectory, P_FilePath);
            }
            return File.ReadAllText(P_FilePath);
        }
    }

    public class Srv_Tracking_DiffInfo
    {
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ObjectName { get; set; }
        public int TotalChanges { get; set; } = 0;
        public bool IsData { get; set; } = false;

        public Srv_Tracking_DiffInfo_Model Diffs { get; set; } = new Srv_Tracking_DiffInfo_Model();
    }

    public class Srv_Tracking_DiffInfo_Model
    {
        public List<DiffPiece> OldText { get; set; } = new List<DiffPiece>();
        public List<DiffPiece> NewText { get; set; } = new List<DiffPiece>();
    }
}

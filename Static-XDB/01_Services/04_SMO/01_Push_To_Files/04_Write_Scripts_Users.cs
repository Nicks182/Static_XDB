
namespace Services
{
    public partial class Srv_SMO
    {
        private void _Push_To_Files_Users()
        {
            if (G_DoCancel == true)
            {
                return;
            }
            Srv_SMO_Type L_Type = Srv_SMO_Type.User;
            _Check_And_Clear_Directory(_Get_File_Folder(L_Type));
            //List<Table> L_List = G_Database.Tables.Cast<Table>().Where(x => !x.IsSystemObject && L_Exclusions.Contains(x.Name) == false).ToList();
            var L_List = _Get_Users(); // G_Database.Users.Cast<User>().Where(x => !x.IsSystemObject).ToList();

            IEnumerable<string> L_Scripts;
            foreach (var L_Object in L_List)
            {
                if (G_DoCancel == true)
                {
                    return;
                }
                G_Srv_Progress._SetProgress(1, "Pushing Users: " + L_Object.Name);
                L_Scripts = G_Scripter.EnumScript(new[] { L_Object.Urn });
                _White_Scripts(_CleanObjectName(L_Object.Name), L_Scripts.ToList(), L_Type);
            }
        }


    }

  
}

using Microsoft.SqlServer.Management.Smo;

namespace Services
{
    public partial class Srv_SMO
    {
        public List<Srv_SMO_Object> _Get_SMO_Objects()
        {
            List<Srv_SMO_Object> L_Srv_SMO_Objects = new List<Srv_SMO_Object>();

            if (G_IsServerUp == true)
            {
                G_Database = G_Server.Databases[G_ProjectInfo.DBName];

                foreach (var L_Obj in _Get_Schemas(true))
                {
                    L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                    {
                        Name = L_Obj.Name,
                        IsIgnore = false,
                        IgnoreType = DB.Ignore_Type.Schema
                    });
                }

                foreach (var L_Obj in _Get_Users(true))
                {
                    L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                    {
                        Name = L_Obj.Name,
                        IsIgnore = false,
                        IgnoreType = DB.Ignore_Type.User
                    });
                }

                foreach (var L_Obj in _Get_Tables(true))
                {
                    L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                    {
                        Name = L_Obj.Name,
                        IsIgnore = false,
                        IgnoreType = DB.Ignore_Type.Table
                    });
                }

                foreach (var L_Obj in _Get_Views(true))
                {
                    L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                    {
                        Name = L_Obj.Name,
                        IsIgnore = false,
                        IgnoreType = DB.Ignore_Type.View
                    });
                }

                foreach (var L_Obj in _Get_Procedures(true))
                {
                    L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                    {
                        Name = L_Obj.Name,
                        IsIgnore = false,
                        IgnoreType = DB.Ignore_Type.Proc
                    });
                }

                foreach (var L_Obj in _Get_Functions(true))
                {
                    L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                    {
                        Name = L_Obj.Name,
                        IsIgnore = false,
                        IgnoreType = DB.Ignore_Type.Func
                    });
                }

                foreach (var L_Obj in _Get_Triggers(true))
                {
                    L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                    {
                        Name = L_Obj.Name,
                        IsIgnore = false,
                        IgnoreType = DB.Ignore_Type.Trig
                    });
                }

                foreach (var L_Obj in _Get_Synonyms(true))
                {
                    L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                    {
                        Name = L_Obj.Name,
                        IsIgnore = false,
                        IgnoreType = DB.Ignore_Type.Syn
                    });
                }

                foreach (var L_Obj in _Get_Table_Data(true))
                {
                    L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                    {
                        Name = L_Obj.Name,
                        IsIgnore = false,
                        IgnoreType = DB.Ignore_Type.Data
                    });
                }
            }

            return L_Srv_SMO_Objects;
        }

        public List<Srv_SMO_Object> _Get_SMO_Objects(DB.Ignore_Type P_Ignore_Type)
        {
            List<Srv_SMO_Object> L_Srv_SMO_Objects = new List<Srv_SMO_Object>();

            if (G_IsServerUp == true)
            {
                G_Database = G_Server.Databases[G_ProjectInfo.DBName];

                switch (P_Ignore_Type)
                {
                    case DB.Ignore_Type.Schema:
                        foreach (var L_Obj in _Get_Schemas(true))
                        {
                            L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                            {
                                Name = L_Obj.Name,
                                IsIgnore = false,
                                IgnoreType = P_Ignore_Type
                            });
                        }
                        break;

                    case DB.Ignore_Type.User:
                        foreach (var L_Obj in _Get_Users(true))
                        {
                            L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                            {
                                Name = L_Obj.Name,
                                IsIgnore = false,
                                IgnoreType = P_Ignore_Type
                            });
                        }
                        break;

                    case DB.Ignore_Type.Table:
                        foreach (var L_Obj in _Get_Tables(true))
                        {
                            L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                            {
                                Name = L_Obj.Name,
                                IsIgnore = false,
                                IgnoreType = P_Ignore_Type
                            });
                        }
                        break;

                    case DB.Ignore_Type.View:
                        foreach (var L_Obj in _Get_Views(true))
                        {
                            L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                            {
                                Name = L_Obj.Name,
                                IsIgnore = false,
                                IgnoreType = P_Ignore_Type
                            });
                        }
                        break;

                    case DB.Ignore_Type.Proc:
                        foreach (var L_Obj in _Get_Procedures(true))
                        {
                            L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                            {
                                Name = L_Obj.Name,
                                IsIgnore = false,
                                IgnoreType = P_Ignore_Type
                            });
                        }
                        break;

                    case DB.Ignore_Type.Func:
                        foreach (var L_Obj in _Get_Functions(true))
                        {
                            L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                            {
                                Name = L_Obj.Name,
                                IsIgnore = false,
                                IgnoreType = P_Ignore_Type
                            });
                        }
                        break;

                    case DB.Ignore_Type.Trig:
                        foreach (var L_Obj in _Get_Triggers(true))
                        {
                            L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                            {
                                Name = L_Obj.Name,
                                IsIgnore = false,
                                IgnoreType = P_Ignore_Type
                            });
                        }
                        break;

                    case DB.Ignore_Type.Syn:
                        foreach (var L_Obj in _Get_Synonyms(true))
                        {
                            L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                            {
                                Name = L_Obj.Name,
                                IsIgnore = false,
                                IgnoreType = P_Ignore_Type
                            });
                        }
                        break;

                    case DB.Ignore_Type.Data:
                        foreach (var L_Obj in _Get_Table_Data(true))
                        {
                            L_Srv_SMO_Objects.Add(new Srv_SMO_Object
                            {
                                Name = L_Obj.Name,
                                IsIgnore = false,
                                IgnoreType = P_Ignore_Type
                            });
                        }
                        break;
                }
            }

            return L_Srv_SMO_Objects;
        }

        private List<string> _Get_IgnoreList(DB.Ignore_Type P_Ignore_Type)
        {
            return G_Srv_DB.Ignore_GetAll().Find(i => i.Type == P_Ignore_Type).Select(i => i.Name).ToList();
        }

        private List<Schema> _Get_Schemas(bool P_GetAll = false)
        {
            List<string> L_IgnoreList = new List<string>();

            if (P_GetAll == false)
            {
                L_IgnoreList = _Get_IgnoreList(DB.Ignore_Type.Schema);
            }

            return G_Database.Schemas.Cast<Schema>().Where(x => !x.IsSystemObject && L_IgnoreList.Contains(x.Name) == false).ToList();
        }

        private List<User> _Get_Users(bool P_GetAll = false)
        {
            List<string> L_IgnoreList = new List<string>();

            if (P_GetAll == false)
            {
                L_IgnoreList = _Get_IgnoreList(DB.Ignore_Type.User);
            }

            return G_Database.Users.Cast<User>().Where(x => !x.IsSystemObject && L_IgnoreList.Contains(x.Name) == false).ToList();
        }

        private List<Table> _Get_Tables(bool P_GetAll = false)
        {
            List<string> L_IgnoreList = new List<string>();

            if (P_GetAll == false)
            {
                L_IgnoreList = _Get_IgnoreList(DB.Ignore_Type.Table);
            }

            return G_Database.Tables.Cast<Table>().Where(x => !x.IsSystemObject && L_IgnoreList.Contains(x.Name) == false).ToList();
        }

        private List<View> _Get_Views(bool P_GetAll = false)
        {
            List<string> L_IgnoreList = new List<string>();

            if (P_GetAll == false)
            {
                L_IgnoreList = _Get_IgnoreList(DB.Ignore_Type.View);
            }

            return G_Database.Views.Cast<View>().Where(x => !x.IsSystemObject && L_IgnoreList.Contains(x.Name) == false).ToList();
        }

        private List<StoredProcedure> _Get_Procedures(bool P_GetAll = false)
        {
            List<string> L_IgnoreList = new List<string>();

            if (P_GetAll == false)
            {
                L_IgnoreList = _Get_IgnoreList(DB.Ignore_Type.Proc);
            }

            return G_Database.StoredProcedures.Cast<StoredProcedure>().Where(x => !x.IsSystemObject && L_IgnoreList.Contains(x.Name) == false).ToList();
        }

        private List<UserDefinedFunction> _Get_Functions(bool P_GetAll = false)
        {
            List<string> L_IgnoreList = new List<string>();

            if (P_GetAll == false)
            {
                L_IgnoreList = _Get_IgnoreList(DB.Ignore_Type.Func);
            }

            return G_Database.UserDefinedFunctions.Cast<UserDefinedFunction>().Where(x => !x.IsSystemObject && L_IgnoreList.Contains(x.Name) == false).ToList();
        }

        private List<DatabaseDdlTrigger> _Get_Triggers(bool P_GetAll = false)
        {
            List<string> L_IgnoreList = new List<string>();

            if (P_GetAll == false)
            {
                L_IgnoreList = _Get_IgnoreList(DB.Ignore_Type.Trig);
            }

            return G_Database.Triggers.Cast<DatabaseDdlTrigger>().Where(x => !x.IsSystemObject && L_IgnoreList.Contains(x.Name) == false).ToList();
        }

        private List<Synonym> _Get_Synonyms(bool P_GetAll = false)
        {
            List<string> L_IgnoreList = new List<string>();

            if (P_GetAll == false)
            {
                L_IgnoreList = _Get_IgnoreList(DB.Ignore_Type.Syn);
            }

            return G_Database.Synonyms.Cast<Synonym>().Where(x => L_IgnoreList.Contains(x.Name) == false).ToList();
        }

        public List<Table> _Get_Table_Data(bool P_GetAll = false)
        {
            List<string> L_IgnoreList = new List<string>();

            if (P_GetAll == false)
            {
                L_IgnoreList = _Get_IgnoreList(DB.Ignore_Type.Data);
            }

            return G_Database.Tables.Cast<Table>().Where(x => !x.IsSystemObject && L_IgnoreList.Contains(x.Name) == false).ToList();
        }

    }

    public class Srv_SMO_Object
    {
        public string Name { get; set; }
        public bool IsIgnore { get; set; } = false;
        public DB.Ignore_Type IgnoreType { get; set; }
        
    }
}

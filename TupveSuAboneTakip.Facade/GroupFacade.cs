using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TupveSuAboneTakip.DAL;
using TupveSuAboneTakip.Entities;

namespace TupveSuAboneTakip.Facade
{
    public static class GroupFacade
    {
        public static Group SelectByID(int groupID)
        {
            Group g = null;
            try
            {
                SqlDataReader dr = DatabaseProvider.RunExecuteReader("sp_Group_SelectByID", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("GroupID", groupID) });
                if (dr.Read())
                {
                    g = new Group();
                    g.GroupID = Convert.ToInt32(dr["GroupID"]);
                    g.GroupName = dr["GroupName"].ToString();
                }
                dr.Close();
                return g;
            }

            catch (SqlException sqEx)
            {

                throw sqEx;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        
        public static List<Group> SelectAll()
        {
            List<Group> groups = new List<Group>();
            try
            {
                SqlDataReader dr = DatabaseProvider.RunExecuteReader("sp_Populate_GroupCombobox", CommandType.StoredProcedure, null);
                while (dr.Read())
                {
                    Group g = new Group();
                    g.GroupID = Convert.ToInt32(dr["GroupID"]);
                    g.GroupName = dr["GroupName"].ToString();
                    groups.Add(g);
                }
                dr.Close();
                return groups;
            }
            catch (SqlException sqEx)
            {

                throw sqEx;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}

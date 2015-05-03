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
    public static class DistrictFacade
    {
        public static List<District> SelectAll()
        {
            List<District> districts = new List<District>();
            try
            {
                SqlDataReader dr = DatabaseProvider.RunExecuteReader("sp_Populate_DistrictCombobox", CommandType.StoredProcedure, null);
                while (dr.Read())
                {
                    District d = new District();
                    d.DistrictID = Convert.ToInt32(dr["DistrictID"]);
                    d.DistrictName = dr["DistrictName"].ToString();
                    districts.Add(d);
                }
                dr.Close();
                return districts;
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

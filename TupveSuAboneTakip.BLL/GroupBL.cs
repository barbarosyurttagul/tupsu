using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TupveSuAboneTakip.Entities;
using TupveSuAboneTakip.Facade;

namespace TupveSuAboneTakip.BLL
{
    public static class GroupBL
    {
        public static List<Group> SelectAll()
        {         
            try
            {
                return GroupFacade.SelectAll();
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

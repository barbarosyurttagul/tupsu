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
    public static class CustomerFacade
    {
        #region Insert(Customer customerToSave)
        /// <summary>
        /// Inserts given parameters to Customer Table on the database
        /// </summary>
        /// <param name="customerToSave">Derived from Customer Entity class</param>
        /// <returns>int</returns>
        public static int Insert(Customer customerToSave)
        {
            string query = "sp_Customer_Insert";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RecordDate", customerToSave.RecordDate),
                new SqlParameter("@FirstName", customerToSave.FirstName),
                new SqlParameter("@LastName", customerToSave.LastName),
                new SqlParameter("@Phone", customerToSave.Phone),
                new SqlParameter("@GSM", customerToSave.GSM),
                new SqlParameter("@GroupID", customerToSave.GroupID),
                new SqlParameter("@DistrictID", customerToSave.DistrictID),
                new SqlParameter("@Road", customerToSave.Road),
                new SqlParameter("@Street", customerToSave.Street),
                new SqlParameter("@SiteName", customerToSave.SiteName),
                new SqlParameter("@ApartmentName", customerToSave.ApartmentName),
                new SqlParameter("@Block", customerToSave.Block),
                new SqlParameter("@Floor", customerToSave.Floor),
                new SqlParameter("@ApartmentNumber", customerToSave.ApartmentNumber),
                new SqlParameter("@FlatNumber", customerToSave.FlatNumber),
                new SqlParameter("@AddressDetail", customerToSave.AddressDetail),
                new SqlParameter("@FirmName", customerToSave.FirmName),
                new SqlParameter("@CityName", customerToSave.CityName),
                new SqlParameter("@TownName", customerToSave.TownName)
            };

            try
            {
                return DatabaseProvider.RunExecuteNonQuery(query, CommandType.StoredProcedure, parameters);
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
        #endregion

        #region SelectAll()
        /// <summary>
        /// Selects all customers from Table Customer
        /// </summary>
        /// <returns>List<Customer></returns>
        public static List<Customer> SelectAll()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                SqlDataReader dr = DatabaseProvider.RunExecuteReader("sp_Customer_SelectAll", CommandType.StoredProcedure, null);
                while (dr.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                    customer.FirstName = dr["FirstName"].ToString();
                    customer.LastName = dr["LastName"].ToString();
                    customer.Phone = dr["Phone"].ToString();
                    customer.GSM = dr["GSM"].ToString();
                    customer.GroupID = Convert.ToInt32(dr["GroupID"]);
                    customer.DistrictID = Convert.ToInt32(dr["DistrictID"]);
                    customer.Road = dr["Road"].ToString();
                    customer.Street = dr["Street"].ToString();
                    customer.SiteName = dr["SiteName"].ToString();
                    customer.ApartmentName = dr["ApartmentName"].ToString();
                    customer.Block = dr["Block"].ToString();
                    customer.Floor = Convert.ToByte(dr["Floor"]);
                    customer.ApartmentNumber = dr["ApartmentNumber"].ToString();
                    customer.FlatNumber = Convert.ToByte(dr["FlatNumber"]);
                    customer.AddressDetail = dr["AddressDetail"].ToString();
                    customer.FirmName = dr["FirmName"].ToString();
                    customer.CityName = dr["CityName"].ToString();
                    customer.TownName = dr["TownName"].ToString();

                    customer.GroupOf = GroupFacade.SelectByID(customer.GroupID);
                    customers.Add(customer);
                }
                dr.Close();
                return customers;
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
        #endregion

        public static int Update(Customer customerToUpdate)
        {
            string query = "sp_Customer_Update";


            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FirstName", customerToUpdate.FirstName),
                new SqlParameter("@LastName", customerToUpdate.LastName),
                new SqlParameter("@Phone", customerToUpdate.Phone),
                new SqlParameter("@GSM", customerToUpdate.GSM),
                new SqlParameter("@GroupID", customerToUpdate.GroupID),
                new SqlParameter("@DistrictID", customerToUpdate.DistrictID),
                new SqlParameter("@Road", customerToUpdate.Road),
                new SqlParameter("@Street", customerToUpdate.Street),
                new SqlParameter("@SiteName", customerToUpdate.SiteName),
                new SqlParameter("@ApartmentName", customerToUpdate.ApartmentName),
                new SqlParameter("@Block", customerToUpdate.Block),
                new SqlParameter("@Floor", customerToUpdate.Floor),
                new SqlParameter("@ApartmentNumber", customerToUpdate.ApartmentNumber),
                new SqlParameter("@FlatNumber", customerToUpdate.FlatNumber),
                new SqlParameter("@AddressDetail", customerToUpdate.AddressDetail),
                new SqlParameter("@FirmName", customerToUpdate.FirmName),
                new SqlParameter("@CityName", customerToUpdate.CityName),
                new SqlParameter("@TownName", customerToUpdate.TownName)
            }; 
          

            try
            {
                return DatabaseProvider.RunExecuteNonQuery(query, CommandType.StoredProcedure, parameters);
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

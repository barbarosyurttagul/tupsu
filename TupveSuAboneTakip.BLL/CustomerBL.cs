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
    public static class CustomerBL
    {
        #region Insert(Customer customerToSave)
        /// <summary>
        /// Inserts given parameters to Customer Table on the database
        /// </summary>
        /// <param name="customerToSave">Derived from Customer Entity class</param>
        /// <returns>int</returns>
        public static int Insert(Customer customerToSave)
        {
            try
            {
                return CustomerFacade.Insert(customerToSave);
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

        #region Save(Customer customer)
        /// <summary>
        /// Inserts or updates Customer info
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static int Save(Customer customer)
        {
            try
            {
                if (customer.CustomerID > 0)
                    return CustomerFacade.Update(customer);

                return CustomerFacade.Insert(customer);
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
        /// Runs CustomerFacade.SelectAll()
        /// </summary>
        /// <returns>List<Customer></returns>
        public static List<Customer> SelectAll()
        {
            try
            {
                return CustomerFacade.SelectAll();
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
    }
}

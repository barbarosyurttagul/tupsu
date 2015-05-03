using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TupveSuAboneTakip.BLL;
using TupveSuAboneTakip.Entities;
using System.Data.SqlClient;
using TupveSuAboneTakip.Facade;
using System.Configuration;

namespace TupveSuAboneTakipWinFormUI.CustomerForms
{
    public partial class CustomerSave : UserControl
    {
        #region SINGLETON
        private static CustomerSave frm;
        private CustomerSave()
        {
            InitializeComponent();
            
            this.Load += CustomerSave_Load;
        }

        void CustomerSave_Load(object sender, EventArgs e)
        {
            btnSaveCustomer.Enabled = false;
            cmbGroupID.DataSource = GroupBL.SelectAll();
            cmbGroupID.DisplayMember = "GroupName";
            cmbGroupID.ValueMember = "GroupID";
            cmbDistrictID.DataSource = DistrictBL.SelectAll();
            cmbDistrictID.DisplayMember = "DistrictName";
            cmbDistrictID.ValueMember = "DistrictID";
            this.Size = this.Parent.Size;
            PopulateGridView();
        }

        public static CustomerSave CreateInstance()
        {
            if (frm == null)
                frm = new CustomerSave();
            return frm;
        } 
        #endregion

        #region GLOBAL VARIABLES, REFERENCES
        List<Customer> customers; 
        #endregion

        #region EVENTS
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            btnSaveCustomer.Enabled = true;
            btnNewCustomer.Enabled = false;
            btnDeleteCostomer.Enabled = false;
            foreach (Control item in grpCustomerInfo.Controls)
            {
                if ((item == item as TextBox))
                    item.Text = "";
            }
        }
        
        
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {           
            try
            {               
                    Customer customer = new Customer();
                    customer.AddressDetail = txtAddressDetail.Text;
                    customer.ApartmentName = txtApartmentName.Text;
                    customer.ApartmentNumber = txtApartmentNumber.Text;
                    customer.Block = txtBlock.Text;
                    customer.CityName = txtCityName.Text;
                    customer.CustomerID = Convert.ToInt32(txtCustomerID.Text);
                    customer.DistrictID = Convert.ToInt32(cmbDistrictID.SelectedValue);
                    customer.FirmName = txtFirmName.Text;
                    customer.FirstName = txtFirstName.Text;
                    if (txtFlatNumber.Text != "")
                        customer.FlatNumber = Convert.ToInt32(txtFlatNumber.Text);
                    else
                        customer.FlatNumber = 0;
                    if (txtFloor.Text != "")
                        customer.Floor = Convert.ToInt32(txtFloor.Text);
                    else
                        customer.Floor = 0;
                    customer.GroupID = Convert.ToInt32(cmbDistrictID.SelectedValue);
                    customer.GSM = txtGSM.Text;
                    customer.LastName = txtLastName.Text;
                    customer.Phone = txtPhone.Text;
                    customer.RecordDate = dateTimePicker1.Value;
                    customer.Road = txtRoad.Text;
                    customer.SiteName = txtSiteName.Text;
                    customer.Street = txtStreet.Text;
                    customer.TownName = txtTownName.Text;
                    if (CustomerBL.Insert(customer) > 0)
                    { 
                        MessageBox.Show("Kayıt Başarılı");
                        PopulateGridView();//datagridview yeniden yüklendi              
                    }             
                    btnSaveCustomer.Enabled = false;
                    btnNewCustomer.Enabled = true;
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


        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control item in pnlSearch.Controls)
            {
                if ((item == item as TextBox))
                    item.Text = "";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            //deneme
            List<Customer> searched = customers.Where(c => c.GroupOf.GroupName.ToUpper().Contains(txtSearchGroup.Text.ToUpper()) &&
                                                           c.FirmName.ToUpper().Contains(txtSearchFirmName.Text.ToUpper()) &&
                                                           c.FirstName.ToUpper().Contains(txtSearchFirstName.Text.ToUpper()) &&
                                                           c.LastName.ToUpper().Contains(txtSearchLastName.Text.ToUpper()) &&
                                                           c.Phone.ToUpper().Contains(txtSearchPhone.Text.ToUpper())).ToList();
            if (txtSearchCustomerID.Text != "")
                searched = searched.Where(s => s.CustomerID == Convert.ToInt32(txtSearchCustomerID.Text)).ToList();
            dgvCustomerList.DataSource = searched;
        }

        #region SEARCH EVENTS

        private void Ara(object sender, EventArgs e)
        {
            List<Customer> searched=new List<Customer>();
            if (txtSearchCustomerID.Text == "")
            {
               searched = customers.Where(c => c.FirmName.ToUpper().StartsWith(txtSearchFirmName.Text.ToUpper()) &&
                                                               c.FirstName.ToUpper().StartsWith(txtSearchFirstName.Text.ToUpper()) &&
                                                               c.LastName.ToUpper().StartsWith(txtSearchLastName.Text.ToUpper()) &&
                                                               c.GroupOf.GroupName.ToUpper().StartsWith(txtSearchGroup.Text.ToUpper())&&
                                                               c.Phone.ToUpper().StartsWith(txtSearchPhone.Text.ToUpper())).ToList();
            }
            else if (txtSearchCustomerID.Text != "")
            {
                searched = customers.Where(c => c.FirmName.ToUpper().StartsWith(txtSearchFirmName.Text.ToUpper()) &&
                                                               c.FirstName.ToUpper().StartsWith(txtSearchFirstName.Text.ToUpper()) &&
                                                               c.LastName.ToUpper().StartsWith(txtSearchLastName.Text.ToUpper()) &&
                                                               c.GroupOf.GroupName.ToUpper().StartsWith(txtSearchGroup.Text.ToUpper()) &&
                                                               c.CustomerID==Convert.ToInt32(txtSearchCustomerID.Text) &&
                                                               c.Phone.ToUpper().StartsWith(txtSearchPhone.Text.ToUpper())).ToList();
            }            
            dgvCustomerList.DataSource = searched;                     
        }

        private void txtSearchFirmName_TextChanged(object sender, EventArgs e)
        {
            Ara(sender, e);
        }
        
        private void txtSearchFirstName_TextChanged(object sender, EventArgs e)
        {
            Ara(sender, e);
        }
        
        private void txtSearchLastName_TextChanged(object sender, EventArgs e)
        {
            Ara(sender, e);
        }

        private void txtSearchCustomerID_TextChanged(object sender, EventArgs e)
        {
            Ara(sender, e);
        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {
            Ara(sender, e);
        }
        
        private void txtSearchGroup_TextChanged(object sender, EventArgs e)
        {
            Ara(sender, e);
        }
        #endregion

        #region KEYPRESS EVENTS
        private void txtSearchCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtFloor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtFlatNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        } 
        #endregion

        #endregion
        

        #region METHODS
        public void PopulateGridView()
        {
            try
            {
                dgvCustomerList.AutoGenerateColumns = false;
                customers = CustomerBL.SelectAll();
                dgvCustomerList.DataSource = customers;
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

        private void dgvCustomerList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        

        

        

        

        

        

        

       

        

        

        
    }
}

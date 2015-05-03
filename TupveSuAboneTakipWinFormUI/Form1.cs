using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TupveSuAboneTakipWinFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                pnlMain.Controls.Clear();
                CustomerForms.CustomerSave cs = CustomerForms.CustomerSave.CreateInstance();
                pnlMain.Controls.Add(cs);
                cs.Anchor = pnlMain.Anchor;
            }
            catch (SqlException sqEx)
            {

                MessageBox.Show(sqEx.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

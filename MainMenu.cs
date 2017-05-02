using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Cui_Jall_Restraurent__Management
{
    public partial class MainMenu : Form
    {
        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void subCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           User_Registration frm = new User_Registration();
            //frm.lblUser.Text = lblUser.Text;
            frm.Reset();
            frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void membershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

  

       

       
          
        

       

       

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblTime.Text = System.DateTime.Now.ToString();
        }

 

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Logs frm = new Logs();
          //  frm.Reset();
//          frm.lblUser.Text = lblUser.Text;
            //frm.ShowDialog();
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer2.Enabled = false;
        }

    

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

 

        private void membershipToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = new SqlCommand("Select RTRIM(Customer.CustomerID),RTRIM(Name),RTRIM(City),RTRIM(Type),Convert(Varchar(10),DateFrom,103),Convert(varchar(10),DateTo,103) from Membership,CustomerMembership,Customer where Customer.C_ID=CustomerMembership.CustomerID and Membership.M_ID=CustomerMembership.MembershipID order by billdate", cc.con);
                cc.rdr = cc.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dgw.Rows.Clear();
                while (cc.rdr.Read() == true)
                {
                    dgw.Rows.Add(cc.rdr[0], cc.rdr[1], cc.rdr[2], cc.rdr[3], cc.rdr[4], cc.rdr[5]);
                }
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //button1.PerformClick();
        }


   
        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer2.Enabled = true;
                if ((!System.IO.Directory.Exists("C:\\DBBackup")))
                {
                    System.IO.Directory.CreateDirectory("C:\\DBBackup");
                }
                string destdir = "C:\\DBBackup\\Management " + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".bak";
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string cb = "backup database [" + System.Windows.Forms.Application.StartupPath + "\\Management.mdf] to disk='" + destdir + "'with init,stats=10";
                cc.cmd = new SqlCommand(cb);
                cc.cmd.Connection = cc.con;
                cc.cmd.ExecuteReader();
                cc.con.Close();
                //st1 = lblUser.Text;
                st2 = "Successfully backup the database";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully performed", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restoreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = openFileDialog1;
                _with1.Filter = ("DB Backup File|*.bak;");
                _with1.FilterIndex = 4;
                //Clear the file name
                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    timer2.Enabled = true;
                    SqlConnection.ClearAllPools();
                    cc.con = new SqlConnection(cs.DBConn);
                    cc.con.Open();
                    string cb = "USE Master ALTER DATABASE [" + System.Windows.Forms.Application.StartupPath + "\\Management.mdf] SET Single_User WITH Rollback Immediate Restore database [" + System.Windows.Forms.Application.StartupPath + "\\Management.mdf] FROM disk='" + openFileDialog1.FileName + "' WITH REPLACE ALTER DATABASE [" + System.Windows.Forms.Application.StartupPath + "\\Management.mdf] SET Multi_User ";
                    cc.cmd = new SqlCommand(cb);
                    cc.cmd.Connection = cc.con;
                    cc.cmd.ExecuteReader();
                    cc.con.Close();
                   // st1 = lblUser.Text;
                    st2 = "Successfully restore the database";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void supplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void membershipToolStripMenuItem2_Click(object sender, EventArgs e)
        {
           
        }

        private void fitnessMeasureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //st1 = lblUser.Text;
            st2 = "Successfully logged out";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            this.Hide();
            Login frm = new Login();
            frm.Show();
            frm.UserID.Text = "";
            frm.Password.Text = "";
            frm.ProgressBar1.Visible = false;
            frm.UserID.Focus();
        }
        
        private void frmMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void masterEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Entry en = new Customer_Entry();
            en.Show();

        }

       

        private void hallCustomerMealBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerBilling mBill = new CustomerBilling();
            mBill.Show();
        }

        private void mealStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuStock mStock = new MenuStock();
            mStock.Show();

        }

        private void mealPriceSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrice m = new MenuPrice();
            m.Show();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void supplierEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplier s = new Supplier();
            s.Show();

        }

        private void mealTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MenuCategory mc = new MenuCategory();
            mc.Show();
        }

        private void subCategoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Menu_Sub_Category subC = new Menu_Sub_Category();
            subC.Show();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lblUserType_Click(object sender, EventArgs e)
        {

        }
    }
}

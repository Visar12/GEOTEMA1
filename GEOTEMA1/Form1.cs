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
using GEOTEMA1;

namespace GEOTEMA1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
          
     
      
      



      
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=WIN-KD901UP14EP;Initial Catalog=Geotema;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            String username, user_password;
            username = txt_username.Text;
            user_password = txt_password.Text;
           
            try
            {
                SqlConnection con = new SqlConnection("Data Source=WIN-KD901UP14EP;Initial Catalog=Geotema;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select *from tbl_Login where Username=@Username and Password=@Password",con); 
                cmd.Parameters.AddWithValue("@Username",txt_username.Text);
                cmd.Parameters.AddWithValue("@Password", txt_password.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtable = new DataTable();
                da.Fill(dtable);
                if(dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    user_password=txt_password.Text;
                    // page that needs to be loaded next 
                    Menuform form2 = new Menuform();
                        form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();
                }
            }

            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
              con.Close();  
            }

            

            }

         

        private void button2_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
            txt_username.Focus();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res==DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

      
    }
}

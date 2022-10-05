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

namespace GEOTEMA1
{
    public partial class Menuform : Form
    {
        string connectuonString = @"Data Source=WIN-KD901UP14EP;Initial Catalog=Geotema;Integrated Security=True";
            
        public Menuform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(SqlConnection sqlcon=new SqlConnection(connectuonString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select tbl_Land.Land,tbl_Land.Verdensdel,tbl_Rang.Rang,tbl_Rang.Fødselsrate from tbl_Land inner join tbl_Rang on tbl_Land.LandId=RangId", sqlcon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                //method 1 -direct method 

                dgv1.DataSource = dtbl;

            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
           using(SqlConnection sqlcon2=new SqlConnection(connectuonString))
            {
                sqlcon2.Open();
                SqlDataAdapter sqlDa2 = new SqlDataAdapter("select tbl_Land.Land,tbl_Land.Verdensdel,tbl_Rang.Rang,tbl_Rang.Fødselsrate,\r\nRank()OVER(ORDER BY Fødselsrate DESC)AS [PLACERING]\r\nfrom tbl_Land inner join tbl_Rang on tbl_Land.LandId=RangId ORDER BY Fødselsrate DESC",sqlcon2);
                DataTable dtbl2 = new DataTable();
                sqlDa2.Fill(dtbl2);

                dgv1.DataSource = dtbl2;
            }
        }

        private void Laveste_Click(object sender, EventArgs e)
        {
            using(SqlConnection sqlcon3= new SqlConnection(connectuonString))
            {
                sqlcon3.Open();
                SqlDataAdapter sqlDa3 = new SqlDataAdapter("select tbl_Land.Land,tbl_Land.Verdensdel,tbl_Rang.Rang,tbl_Rang.Fødselsrate, Rank()OVER(ORDER BY Fødselsrate ASC)AS [PLACERING] from tbl_Land inner join tbl_Rang on tbl_Land.LandId=RangId ORDER BY Fødselsrate ASC", sqlcon3);
                DataTable dtbl3 = new DataTable();
                sqlDa3.Fill(dtbl3);

                dgv1.DataSource = dtbl3;
            }
        }
    }
}

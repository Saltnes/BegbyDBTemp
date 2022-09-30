using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BegbyDBTemp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonGetByName_Click(object sender, EventArgs e)
        {
            DBLayer dbl = new DBLayer();
            GridView1.DataSource = dbl.GetByName(TextBoxSearch.Text);
            GridView1.DataBind();
        }

       


        private void BindGrid()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.People", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
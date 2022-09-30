using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BegbyDBTemp
{
    public class DBLayer
    {
        public DataTable GetByName(string name)
        {
            SqlParameter param;
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.People WHERE first_name=@name", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@name", SqlDbType.NVarChar);
                param.Value = name;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }

            return dt;
        }
    }
}
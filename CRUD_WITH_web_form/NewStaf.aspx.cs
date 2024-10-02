using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace CRUD_WITH_web_form
{
    public partial class NewStaf : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // On initial page load, populate the GridView with all staff data
                LoadData();
            }
        }

        // Insert new staff record
        protected void Insert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Staf (Name, Possition, Salary) VALUES (@Name, @Possition, @Salary)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Possition", txtPosition.Text);
                cmd.Parameters.AddWithValue("@Salary", int.Parse(txtSalary.Text));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // Reload data to show new entry
                LoadData();
            }
        }

        // Read or Load data into GridView
        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Staf", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                StaffGridView.DataSource = dt;
                StaffGridView.DataBind();
            }
        }

        // Update staff record
        protected void Update_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Staf SET Name=@Name, Possition=@Possition, Salary=@Salary WHERE StafID=@StafID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StafID", int.Parse(txtStafID.Text));
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Possition", txtPosition.Text);
                cmd.Parameters.AddWithValue("@Salary", int.Parse(txtSalary.Text));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // Reload data to reflect updates
                LoadData();
            }
        }

        // Delete staff record
        protected void Delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Staf WHERE StafID=@StafID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StafID", int.Parse(txtStafID.Text));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // Reload data to reflect deletion
                LoadData();
            }
        }
    }
}

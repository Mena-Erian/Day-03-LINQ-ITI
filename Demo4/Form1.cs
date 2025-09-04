using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Demo4
{
    public partial class Form1 : Form
    {
        class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string GroupName { get; set; }
            public DateTime ModifiedDate { get; set; }

            public override string ToString()
                => $"{Id}: {Name} ({GroupName}) - {ModifiedDate}";
        }

        string conStr = string.Empty;
        SqlConnection connection;
        SqlCommand cmd;
        public Form1()
        {
            conStr = new ConfigurationBuilder().AddJsonFile("appSetting.json").Build().GetSection("connection1").Value;
            connection = new SqlConnection(conStr);
            cmd = new SqlCommand("select * from [HumanResources].[Department]", connection);



            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            lstBoxDepartments.ValueMember = "Id";
            lstBoxDepartments.DisplayMember = "Name";
            while (reader.Read())
            {
                //reader.GetInt16(0);
                //lstBoxDepartments.Items.Add(reader.GetString(1));
                lstBoxDepartments.Items.Add(
                    new Department { Id = reader.GetInt16(0), Name = (string)reader["name"], GroupName = reader.GetString(2), ModifiedDate = reader.GetDateTime(3) });
            }

            connection.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = (lstBoxDepartments.SelectedItem as Department).Id.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var deptName = txtDptName.Text;
            var deptId = (lstBoxDepartments.SelectedItem as Department).Id;
            cmd.Parameters.Clear();
            cmd.CommandText = $"Update [HumanResources].[Department] Set Name = '{deptName}' where DepartmentID ={deptId}";
            connection.Open();
            int x = cmd.ExecuteNonQuery();
            connection.Close();
            Text = x.ToString();
        }
    }
}

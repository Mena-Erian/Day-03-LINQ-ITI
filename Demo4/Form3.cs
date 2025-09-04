using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4
{
    public partial class Form3 : Form
    {
        string conStr = string.Empty;
        SqlConnection connection;
        SqlCommand cmd;
        DataTable dt;// =new DataTable();
        SqlDataAdapter adapter;
        SqlCommand deptLstCommand;
        DataTable deptDt;
        SqlDataAdapter deptAdapter;
        public Form3()
        {
            conStr = new ConfigurationBuilder().AddJsonFile("appSetting.json").Build().GetSection("connection2").Value;
            connection = new SqlConnection(conStr);
            cmd = new SqlCommand("select * from Students", connection);
            deptLstCommand = new SqlCommand("Select * from Departments", connection);
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            gvStudents.DataSource = dt;
            gvStudents.Columns[0].Visible = false;
            deptDt = new DataTable();
            SqlCommandBuilder deptbuilder = new SqlCommandBuilder(deptAdapter);
            //deptAdapter.UpdateCommand = deptbuilder.GetUpdateCommand();

            deptAdapter = new SqlDataAdapter(deptLstCommand);
            deptAdapter.Fill(deptDt);

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.HeaderText = "Department";
            column.DataSource = deptDt;
            column.DisplayMember = "name";
            column.ValueMember = "id";
            column.DataPropertyName = "deptNo";
            gvStudents.Columns.Add(column);

        }

        private void gvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gvStudents.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapter.Update(deptDt);
        }
    }
}

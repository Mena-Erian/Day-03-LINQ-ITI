using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4
{
    public partial class Form2 : Form
    {
        string conStr = string.Empty;
        SqlConnection connection;
        SqlCommand cmd;
        DataTable dt;// =new DataTable();
        SqlDataAdapter adapter;
        BindingSource bindingSource;
        BindingNavigator navigator;
        public Form2()
        {
            conStr = new ConfigurationBuilder().AddJsonFile("appSetting.json").Build().GetSection("connection1").Value;
            connection = new SqlConnection(conStr);
            cmd = new SqlCommand("select * from [HumanResources].[Department]", connection);

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            //dt2 = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();
            adapter.InsertCommand = sqlCommandBuilder.GetInsertCommand();
            adapter.DeleteCommand = sqlCommandBuilder.GetDeleteCommand();

            bindingSource = new BindingSource(dt, "");
            navigator = new BindingNavigator(true);
            navigator.BindingSource = bindingSource;
            Controls.Add(navigator);


            // Complex Binding
            lstBoxDept.DataSource = bindingSource;
            lstBoxDept.ValueMember = "DepartmentID";
            lstBoxDept.DisplayMember = "Name";


            //Simple Binding => Two Way DataBinding
            lblDptdId.DataBindings.Add("Text", bindingSource, "DepartmentId");
            txtDptName.DataBindings.Add("Text", bindingSource, "Name");
            numUpDownCapacity.DataBindings.Add("Value", bindingSource, "capacity");
            chkStatus.DataBindings.Add("Checked", bindingSource, "status");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            foreach (DataRow row in dt.Rows)
            {
                Debug.WriteLine(row.RowState.ToString());
            }
            adapter.Update(dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource.MoveNext();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bindingSource.MoveFirst();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bindingSource.MoveLast();
        }


        //private void lstBoxDept_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Text = lstBoxDept.SelectedValue.ToString();
        //}
    }
}

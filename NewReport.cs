using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace C969PerformanceAssessment
{
    public partial class NewReport : Form
    {
        string myConnectionString = "server=localhost;port=3306;username=root;password=Passw0rd!;database=client_schedule";

        public NewReport()
        {
            InitializeComponent();
            LoadAppointmentTypeData();
            LoadConsultantData();
            LoadCustomerData();
        }

        private void NewReport_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Hide();
        }

        private void LoadAppointmentTypeData()
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);

            string selectQuery = @"SELECT type FROM appointment";
            conn.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cbApppointmentType.Items.Add(reader.GetString("type"));
            }

            reader.Close();
        }

        private void LoadConsultantData()
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);

            string selectQuery = @"SELECT userName FROM user";
            conn.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cbConsultant.Items.Add(reader.GetString("userName"));
            }
            reader.Close();
        }

        private void LoadCustomerData()
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);

            string selectQuery = @"SELECT customerName FROM customer";
            conn.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cbCustomer.Items.Add(reader.GetString("customerName"));
            }
            reader.Close();
        }

        private void btnRunAppTypeReport_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();

            DateTime dtNow = DateTime.Now;
            DateTime dt30Days = DateTime.Now.AddDays(30);
            string type = cbApppointmentType.Text;

            string getAppointmentType = @"SELECT * FROM appointment WHERE type = @type and start BETWEEN @dtNow and @dt30Days";

            DataTable dataTable = new DataTable();

            MySqlCommand command = new MySqlCommand(getAppointmentType, conn);
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@dtNow", dtNow);
            command.Parameters.AddWithValue("@dt30Days", dt30Days);

            int adapter = new MySqlDataAdapter(command).Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DVGNewReport.DataSource = dataTable;
                DVGNewReport.Columns[0].HeaderText = "Appointment ID";
                DVGNewReport.Columns[1].Visible = false;
                DVGNewReport.Columns[2].Visible = false;
                DVGNewReport.Columns[3].HeaderText = "Title";
                DVGNewReport.Columns[4].HeaderText = "Description";
                DVGNewReport.Columns[5].HeaderText = "Location";
                DVGNewReport.Columns[6].HeaderText = "Contact";
                DVGNewReport.Columns[7].HeaderText = "Type";
                DVGNewReport.Columns[8].HeaderText = "Customer";
                DVGNewReport.Columns[9].HeaderText = "Start";
                DVGNewReport.Columns[10].HeaderText = "End";
                DVGNewReport.Columns[11].Visible = false;
                DVGNewReport.Columns[12].Visible = false;
                DVGNewReport.Columns[13].Visible = false;
                DVGNewReport.Columns[14].Visible = false;
            }
        }

        private void btnRunConsultantReport_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();

            string userName = cbConsultant.Text;
            int userID = 0;

            string getUserID = @"SELECT userId FROM user WHERE userName = @userName";

            MySqlCommand commandUser = new MySqlCommand(getUserID, conn);
            commandUser.Parameters.AddWithValue("@userName", userName);

            MySqlDataReader readerUser = commandUser.ExecuteReader();

            while (readerUser.Read())
            {
                userID = readerUser.GetInt32("userId");
            }
            readerUser.Close();

            string getUserType = @"SELECT * FROM appointment WHERE userId = @userID";

            DataTable dataTable = new DataTable();

            MySqlCommand command = new MySqlCommand(getUserType, conn);
            command.Parameters.AddWithValue("@userID", userID);

            int adapter = new MySqlDataAdapter(command).Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DVGNewReport.DataSource = dataTable;
                DVGNewReport.Columns[0].HeaderText = "Appointment ID";
                DVGNewReport.Columns[1].Visible = false;
                DVGNewReport.Columns[2].Visible = false;
                DVGNewReport.Columns[3].HeaderText = "Title";
                DVGNewReport.Columns[4].HeaderText = "Description";
                DVGNewReport.Columns[5].HeaderText = "Location";
                DVGNewReport.Columns[6].HeaderText = "Contact";
                DVGNewReport.Columns[7].HeaderText = "Type";
                DVGNewReport.Columns[8].HeaderText = "Customer";
                DVGNewReport.Columns[9].HeaderText = "Start";
                DVGNewReport.Columns[10].HeaderText = "End";
                DVGNewReport.Columns[11].Visible = false;
                DVGNewReport.Columns[12].Visible = false;
                DVGNewReport.Columns[13].Visible = false;
                DVGNewReport.Columns[14].Visible = false;
            }
        }

        private void btnRunCustomerReport_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();

            string customerName = cbCustomer.Text;
            int customerID = 0;

            //getting customerID for the appointment sql statement below 
            string getCustomerID = @"SELECT customerId FROM customer WHERE customerName = @customerName";

            MySqlCommand command = new MySqlCommand(getCustomerID, conn);
            command.Parameters.AddWithValue("@customerName", customerName);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customerID = reader.GetInt32("customerId");
            }
            reader.Close();

            string getAppointmentType = @"SELECT * FROM appointment WHERE customerId = @customerID";

            DataTable dataTable = new DataTable();

            MySqlCommand commandCustomer = new MySqlCommand(getAppointmentType, conn);
            commandCustomer.Parameters.AddWithValue("@customerID", customerID);

            int adapter = new MySqlDataAdapter(commandCustomer).Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DVGNewReport.DataSource = dataTable;
                DVGNewReport.Columns[0].HeaderText = "Appointment ID";
                DVGNewReport.Columns[1].Visible = false;
                DVGNewReport.Columns[2].Visible = false;
                DVGNewReport.Columns[3].HeaderText = "Title";
                DVGNewReport.Columns[4].HeaderText = "Description";
                DVGNewReport.Columns[5].HeaderText = "Location";
                DVGNewReport.Columns[6].HeaderText = "Contact";
                DVGNewReport.Columns[7].HeaderText = "Type";
                DVGNewReport.Columns[8].HeaderText = "Customer";
                DVGNewReport.Columns[9].HeaderText = "Start";
                DVGNewReport.Columns[10].HeaderText = "End";
                DVGNewReport.Columns[11].Visible = false;
                DVGNewReport.Columns[12].Visible = false;
                DVGNewReport.Columns[13].Visible = false;
                DVGNewReport.Columns[14].Visible = false;
            }
        }
    }
}

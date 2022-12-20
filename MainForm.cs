using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969PerformanceAssessment
{
    public partial class MainForm : Form
    {
        string myConnectionString = "server=localhost;port=3306;username=root;password=Passw0rd!;database=client_schedule";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           DVGAppointments.DataSource = GetAppointmentData();

            DVGAppointments.Columns[0].HeaderText = "Appointment ID";
            DVGAppointments.Columns[1].Visible = false;
            DVGAppointments.Columns[2].Visible = false;
            DVGAppointments.Columns[3].HeaderText = "Title";
            DVGAppointments.Columns[4].HeaderText = "Description";
            DVGAppointments.Columns[5].HeaderText = "Location";
            DVGAppointments.Columns[6].HeaderText = "Contact";
            DVGAppointments.Columns[7].HeaderText = "Type";
            DVGAppointments.Columns[8].HeaderText = "Customer";
            DVGAppointments.Columns[9].HeaderText = "Start";
            DVGAppointments.Columns[10].HeaderText = "End";
            DVGAppointments.Columns[11].Visible = false;
            DVGAppointments.Columns[12].Visible = false;
            DVGAppointments.Columns[13].Visible = false;
            DVGAppointments.Columns[14].Visible = false;
            DVGAppointments.Columns[15].Visible = false;
            DVGAppointments.Columns[16].HeaderText = "User";
            DVGAppointments.Columns[17].Visible = false;
            DVGAppointments.Columns[18].Visible = false;
            DVGAppointments.Columns[19].Visible = false;
            DVGAppointments.Columns[20].Visible = false;
            DVGAppointments.Columns[21].Visible = false;
            DVGAppointments.Columns[22].Visible = false;

            DVGCustomers.DataSource = GetCustomerData();
            AppointmentReminder();
            DVGCustomers.Columns[0].HeaderText = "Customer Name";
            DVGCustomers.Columns[1].HeaderText = "Address";
            DVGCustomers.Columns[2].HeaderText = "Address 2";
            DVGCustomers.Columns[3].HeaderText = "Zip Code";
            DVGCustomers.Columns[4].HeaderText = "Phone Number";
            DVGCustomers.Columns[5].HeaderText = "City";
            DVGCustomers.Columns[6].HeaderText = "Country";
        }

        private DataTable GetAppointmentData()
        {
            DataTable dtAppointments = new DataTable();

            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM appointment, user", con))
                {
                    con.Open();

                    int adaptor = new MySqlDataAdapter(cmd).Fill(dtAppointments);

                    for (int index = 0; index < dtAppointments.Rows.Count; index++)
                    {
                        dtAppointments.Rows[index]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dtAppointments.Rows[index]["start"], TimeZoneInfo.Local).ToString();
                        dtAppointments.Rows[index]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dtAppointments.Rows[index]["end"], TimeZoneInfo.Local).ToString();
                    }
                }
            }
            
            return dtAppointments;
        }

        private DataTable GetCustomerData()
        {
            DataTable dtCustomers = new DataTable();

            MySqlConnection con = new MySqlConnection(myConnectionString);
            con.Open();

            string customerData = @"SELECT DISTINCT customerName, address, address2, postalCode, phone, city, country 
                                    FROM customer
                                    INNER JOIN address
                                        ON customer.addressId = address.addressId
                                    INNER JOIN city
                                        ON address.cityId = city.cityId
                                    INNER JOIN country 
                                        ON country.countryId = city.countryId";

            MySqlCommand customerCommand = new MySqlCommand(customerData, con);

            int adapter = new MySqlDataAdapter(customerCommand).Fill(dtCustomers);

            DVGCustomers.DataSource = dtCustomers;

            con.Close();
  
            return dtCustomers;
        }

        private void newAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.Show();
            this.Hide();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
            this.Hide();
        }

        private void newReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewReport newReport = new NewReport();
            newReport.Show();
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateAppointment_Click(object sender, EventArgs e)
        {
            UpdateAppointment updateAppointment = new UpdateAppointment();

            updateAppointment.txtAppointmentID.Text = DVGAppointments.CurrentRow.Cells[0].Value.ToString();
            updateAppointment.txtAppointmentTitle.Text = DVGAppointments.CurrentRow.Cells[3].Value.ToString();
            updateAppointment.txtAppointmentDescription.Text = DVGAppointments.CurrentRow.Cells[4].Value.ToString();
            updateAppointment.txtAppointmentLocation.Text = DVGAppointments.CurrentRow.Cells[5].Value.ToString();
            updateAppointment.txtAppointmentContact.Text = DVGAppointments.CurrentRow.Cells[6].Value.ToString();
            updateAppointment.cbAppointmentType.Text = DVGAppointments.CurrentRow.Cells[7].Value.ToString();
            updateAppointment.cbCustomerPick.Text = DVGAppointments.CurrentRow.Cells[8].Value.ToString();
            updateAppointment.cbUserPick.Text = DVGAppointments.CurrentRow.Cells[16].Value.ToString();
            updateAppointment.dtpStartDateTime.Text = DVGAppointments.CurrentRow.Cells[9].Value.ToString();
            updateAppointment.dtpEndDateTime.Text = DVGAppointments.CurrentRow.Cells[10].Value.ToString();

            updateAppointment.Show();
            this.Hide();
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer();

            updateCustomer.txtCustomerNameInput.Text = DVGCustomers.CurrentRow.Cells[0].Value.ToString();
            updateCustomer.txtAddressLine1Input.Text = DVGCustomers.CurrentRow.Cells[1].Value.ToString();
            updateCustomer.txtAddressLine2Input.Text = DVGCustomers.CurrentRow.Cells[2].Value.ToString();
            updateCustomer.txtZipCodeInput.Text = DVGCustomers.CurrentRow.Cells[3].Value.ToString();
            updateCustomer.txtPhoneNumberInput.Text = DVGCustomers.CurrentRow.Cells[4].Value.ToString();
            updateCustomer.txtCityInput.Text = DVGCustomers.CurrentRow.Cells[5].Value.ToString();
            updateCustomer.txtCountryInput.Text = DVGCustomers.CurrentRow.Cells[6].Value.ToString();

            updateCustomer.Show();
            this.Hide();
        }

        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            int index;
            string deleteAppointmentMessage = "Are you sure you want to delete? This action cannot be undone.";
            DialogResult messageBoxResult = MessageBox.Show("", deleteAppointmentMessage, MessageBoxButtons.OKCancel);
            string appointmentID = DVGAppointments.CurrentRow.Cells[0].Value.ToString();

            if (DVGAppointments.CurrentCell.ColumnIndex == 0)
            {
                DataGridViewRow row = DVGAppointments.Rows[DVGAppointments.NewRowIndex];
                if (messageBoxResult == DialogResult.OK)
                {
                    index = DVGAppointments.CurrentCell.RowIndex;
                    DVGAppointments.Rows.RemoveAt(index);

                    string customerName = DVGAppointments.CurrentRow.Cells[0].Value.ToString();
                    int customerID = 0;
             

                    MySqlConnection con = new MySqlConnection(myConnectionString);
                    con.Open();

                    string getCustomerID = @"SELECT customerId FROM customer WHERE customerName = @customerName";
                    MySqlCommand command = new MySqlCommand(getCustomerID, con);
                    command.Parameters.AddWithValue("@customerName", customerName);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        customerID = reader.GetInt32("customerId");
                    }
                    reader.Close();

                    string getAppointmentID = @"SELECT appoinmentId FROM appointment WHERE customerId = @customerID";
                    MySqlCommand command2 = new MySqlCommand(getAppointmentID, con);
                    command.Parameters.AddWithValue("@customerId", customerID);

                    MySqlDataReader readerAppointment = command.ExecuteReader();

                    while (readerAppointment.Read())
                    {
                        customerID = readerAppointment.GetInt32("appointmentId");
                    }
                    readerAppointment.Close();

                    string sqlDeleteAppointment = @"DELETE FROM appointment WHERE appointmentId = @appointmentID";
                    MySqlCommand deleteAppointment = new MySqlCommand(sqlDeleteAppointment, con);

                    deleteAppointment.Parameters.AddWithValue("@appointmentID", appointmentID);

                    deleteAppointment.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int index;
            string deleteAppointmentMessage = "Are you sure you want to delete? This action cannot be undone.";
            DialogResult messageBoxResult = MessageBox.Show("", deleteAppointmentMessage, MessageBoxButtons.OKCancel);

            if (DVGCustomers.CurrentCell.ColumnIndex == 0)
            {
                DataGridViewRow row = DVGCustomers.Rows[DVGCustomers.NewRowIndex];
                if (messageBoxResult == DialogResult.OK)
                {
                    index = DVGCustomers.CurrentCell.RowIndex;
                    DVGCustomers.Rows.RemoveAt(index);

                    string customerName = DVGCustomers.CurrentRow.Cells[0].Value.ToString();
                    int customerID = 0;

                    MySqlConnection con = new MySqlConnection(myConnectionString);
                    con.Open();

                    string getCustomerID = @"SELECT customerId FROM customer WHERE customerName = @customerName";
                    MySqlCommand command = new MySqlCommand(getCustomerID, con);
                    command.Parameters.AddWithValue("@customerName", customerName);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        customerID = reader.GetInt32("customerId");
                    }
                    reader.Close();

                    DataTable dataTable = new DataTable();

                    string getAppointmentData = @"SELECT * FROM appointment WHERE customerId = @customerID";
                    MySqlCommand newCommand = new MySqlCommand(getAppointmentData, con);

                    newCommand.Parameters.AddWithValue("@customerID", customerID);

                    int adapter = new MySqlDataAdapter(newCommand).Fill(dataTable);

                    if (dataTable.Rows.Count <= 0)
                    {
                        string sqlDeleteCustomer = @"DELETE FROM customer WHERE customerId = @customerID";
                        MySqlCommand deleteCustomer = new MySqlCommand(sqlDeleteCustomer, con);

                        deleteCustomer.Parameters.AddWithValue("@customerID", customerID);

                        deleteCustomer.ExecuteNonQuery();
                    }
                    else
                    {
                        string sqlDeleteAppointment = @"DELETE FROM appointment WHERE customerId = @customerID";
                        MySqlCommand deleteAppointment = new MySqlCommand(sqlDeleteAppointment, con);

                        deleteAppointment.Parameters.AddWithValue("@customerID", customerID);

                        deleteAppointment.ExecuteNonQuery();

                        string sqlDeleteCustomer = @"DELETE FROM customer WHERE customerId = @customerID";
                        MySqlCommand deleteCustomer = new MySqlCommand(sqlDeleteCustomer, con);

                        deleteCustomer.Parameters.AddWithValue("@customerID", customerID);

                        deleteCustomer.ExecuteNonQuery();
                    }

                    con.Close();
                }
            }
        }

        public void AppointmentReminder()
        {
            var userName = DVGAppointments.CurrentRow.Cells[16].Value.ToString();
            int userID = 0;

            var startTime = DateTime.Now.ToUniversalTime();
            var endTime = DateTime.Now.AddMinutes(15).ToUniversalTime();

            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();

            string userIDStatement = @"SELECT userId FROM user WHERE userName = @userName";
            MySqlCommand commandUser = new MySqlCommand(userIDStatement, conn);
            commandUser.Parameters.AddWithValue("@userName", userName);

            MySqlDataReader readerUser = commandUser.ExecuteReader();

            while (readerUser.Read())
            {
                userID = readerUser.GetInt32("userId");
            }
            readerUser.Close();

            string appointmentSQLStatement = @"SELECT * FROM appointment WHERE userId = @userID and start BETWEEN @start and @end";

            DataTable dataTable = new DataTable();

            MySqlCommand commandAppointment = new MySqlCommand(appointmentSQLStatement, conn);
            commandAppointment.Parameters.AddWithValue("@userID", userID);
            commandAppointment.Parameters.AddWithValue("@start", startTime);
            commandAppointment.Parameters.AddWithValue("@end", endTime);

            int adapter = new MySqlDataAdapter(commandAppointment).Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                string alertMessage = "Your appointment will begin in 15 minutes";
                DialogResult dialogResult = MessageBox.Show("", alertMessage, MessageBoxButtons.OK);
            }
        }

        private void rdbtnByWeek_CheckedChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();

            DateTime dtNow = DateTime.Now;
            DateTime dt7Days = DateTime.Now.AddDays(7);
            string sqlByWeekStatment = @"SELECT * FROM appointment WHERE start BETWEEN @dtNow and @dt7Days";

            DataTable dataTable = new DataTable();

            MySqlCommand command = new MySqlCommand(sqlByWeekStatment, conn);

            command.Parameters.AddWithValue("@dtNow", dtNow);
            command.Parameters.AddWithValue("@dt7Days", dt7Days);

            int adapter = new MySqlDataAdapter(command).Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DVGAppointments.DataSource = dataTable;
            }
        }

        private void rdbtnByMonth_CheckedChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();

            DateTime dtNow = DateTime.Now;
            DateTime dt30Days = DateTime.Now.AddDays(30);
            string sqlByMonthStatment = @"SELECT * FROM appointment WHERE start BETWEEN @dtNow and @dt30Days";

            DataTable dataTable = new DataTable();

            MySqlCommand command = new MySqlCommand(sqlByMonthStatment, conn);

            command.Parameters.AddWithValue("@dtNow", dtNow);
            command.Parameters.AddWithValue("@dt30Days", dt30Days);

            int adapter = new MySqlDataAdapter(command).Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DVGAppointments.DataSource = dataTable;
            }
        }

        private void rdbtnAllAppointments_CheckedChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();

            string sqlAllAppsStatment = @"SELECT * FROM appointment";

            DataTable dataTable = new DataTable();

            MySqlCommand command = new MySqlCommand(sqlAllAppsStatment, conn);

            int adapter = new MySqlDataAdapter(command).Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DVGAppointments.DataSource = dataTable;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969PerformanceAssessment
{
    public partial class AddAppointment : Form
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString = "server=localhost;port=3306;username=root;password=Passw0rd!;database=client_schedule";

        public AddAppointment()
        {
            InitializeComponent();
            LoadAppointmentTypes();
            LoadCustomerData();
            LoadUserData();
        }

        public bool IsFormValid()
        {

            if (txtAppointmentTitle.Text == null)
            {
                MessageBox.Show("Appointment title is missing.");
                return false;
            }

            if (txtAppointmentDescription.Text == null)
            {
                MessageBox.Show("Appointment description is missing.");
                return false;
            }

            if (txtAppointmentLocation.Text == null)
            {
                MessageBox.Show("Appointment location is missing.");
                return false;
            }

            if (cbAppointmentType.SelectedItem == null)
            {
                MessageBox.Show("Appointment type is missing.");
                return false;
            }

            if (txtAppointmentContact.Text == null)
            {
                MessageBox.Show("Appointment contact is missing.");
                return false;
            }

            if (cbCustomerPick.SelectedItem == null)
            {
                MessageBox.Show("Appointment customer is missing.");
                return false;
            }

            if (cbUserPick.SelectedItem == null)
            {
                MessageBox.Show("Appointment user is missing.");
                return false;
            }

            if (dtpStartDateTime.Value == null)
            {
                MessageBox.Show("Appointment start date is missing.");
                return false;
            }
            else if (dtpStartDateTime.Value > dtpEndDateTime.Value)
            {
                MessageBox.Show("Appointment start date cannot be after the appoinment end time.");
                return false;
            }
            else if (IsOutsideBusinessHours())
            {
                return false;
            }


            if (dtpEndDateTime.Value == null)
            {
                MessageBox.Show("Appointment end date is missing.");
                return false;
            }
            else if (dtpEndDateTime.Value < dtpStartDateTime.Value)
            {
                MessageBox.Show("Appointment end date cannot be before the appoinment start time.");
                return false;
            }
            else if (IsOutsideBusinessHours())
            {
                return false;
            }

            if (IsOverlapAppointment())
            {
                return false;
            }

            return true;
        }

        public void GetDBConnection()
        {
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Hide();
        }

        public void AddAppointmentToDb()
        {
            var currentUser = Environment.UserName;

            string appointmentTitle = txtAppointmentTitle.Text;
            string appointmentDescription = txtAppointmentDescription.Text;
            string appointmentContact = txtAppointmentContact.Text;
            string appointmentType = cbAppointmentType.Text;
            string appointmentLocation = txtAppointmentLocation.Text;
            string customerName = cbCustomerPick.Text;
            string userName = cbUserPick.Text;
            int customerID = 0;
            var userID = 0;
            DateTime appointmentStart = dtpStartDateTime.Value.ToUniversalTime();
            DateTime appointmentEnd = dtpEndDateTime.Value.ToUniversalTime();
            DateTime appointmentCreateDate = DateTime.Today;
            string appointmentCreatedBy = currentUser;
            DateTime appointmentLastUpdate = DateTime.Today;
            string appointmentLastUpdateBy = currentUser;

            //getting customer ID from customer to add to appointment table 
            string getCustomerID = @"SELECT customerId FROM customer WHERE customerName = @customerName";

            GetDBConnection();

            MySqlCommand command = new MySqlCommand(getCustomerID, conn);
            command.Parameters.AddWithValue("@customerName", customerName);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customerID = reader.GetInt32("customerId");
            }
            reader.Close();

            string getUserID = @"SELECT userId FROM user WHERE userName = @userName";

            MySqlCommand commandUser = new MySqlCommand(getUserID, conn);
            commandUser.Parameters.AddWithValue("@userName", userName);

            MySqlDataReader readerUser = commandUser.ExecuteReader();

            while (readerUser.Read())
            {
                userID = readerUser.GetInt32("userId");
            }
            readerUser.Close();

            try
            {
                string insertAppointmentDB = @"INSERT INTO appointment VALUES(null, @customerId, @userId, @title, @description, @location, @contact, @type, @url, 
                                             @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                MySqlConnection conn = new MySqlConnection(myConnectionString);
                MySqlCommand insertCommand = new MySqlCommand(insertAppointmentDB, conn);

                insertCommand.Parameters.AddWithValue("@customerId", customerID);
                insertCommand.Parameters.AddWithValue("@userId", userID);
                insertCommand.Parameters.AddWithValue("@title", appointmentTitle);
                insertCommand.Parameters.AddWithValue("@description", appointmentDescription);
                insertCommand.Parameters.AddWithValue("@location", appointmentLocation);
                insertCommand.Parameters.AddWithValue("@contact", appointmentContact);
                insertCommand.Parameters.AddWithValue("@type", appointmentType);
                insertCommand.Parameters.AddWithValue("@url", customerName);
                insertCommand.Parameters.AddWithValue("@start", appointmentStart);
                insertCommand.Parameters.AddWithValue("@end", appointmentEnd);
                insertCommand.Parameters.AddWithValue("@createDate", appointmentCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", appointmentCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", appointmentLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", appointmentLastUpdateBy);

                conn.Open();
                insertCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmitAppointment_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                AddAppointmentToDb();

                MainForm mainForm = new MainForm();
                mainForm.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Form is invalid. Please review and resubmit.");
            }
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {

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
                cbCustomerPick.Items.Add(reader.GetString("customerName"));
            }
            reader.Close();
        }

        private void LoadUserData()
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);

            string selectQuery = @"SELECT userName FROM user";
            conn.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cbUserPick.Items.Add(reader.GetString("userName"));
            }

            reader.Close();
        }

        private bool IsOverlapAppointment()
        {
            DataTable dataTable = new DataTable();
            GetDBConnection();

            DateTime start = dtpStartDateTime.Value.ToUniversalTime();
            DateTime end = dtpEndDateTime.Value.ToUniversalTime();
            int userID = 0;
            string userName = cbUserPick.Text;

            string getUserID = @"SELECT userId FROM user WHERE userName = @userName";

            MySqlCommand commandUser = new MySqlCommand(getUserID, conn);
            commandUser.Parameters.AddWithValue("@userName", userName);

            MySqlDataReader readerUser = commandUser.ExecuteReader();

            while (readerUser.Read())
            {
                userID = readerUser.GetInt32("userId");
            }
            readerUser.Close();

            string getStartTime = @"SELECT start FROM appointment WHERE userId = @userID and start >= @start and start < @end";
            string secondSQLStatement = @"SELECT end FROM appointment WHERE userId = @userID and end > @start and end <= @end";
            string thirdSQLStatement = @"SELECT start, end FROM appointment WHERE userId = @userID and start <= @start and end >= @end";

            MySqlCommand command = new MySqlCommand(getStartTime, conn);
            command.Parameters.AddWithValue("@userID", userID);
            command.Parameters.AddWithValue("@start", start);
            command.Parameters.AddWithValue("@end", end);

            MySqlCommand command2 = new MySqlCommand(secondSQLStatement, conn);
            command2.Parameters.AddWithValue("@userID", userID);
            command2.Parameters.AddWithValue("@start", start);
            command2.Parameters.AddWithValue("@end", end);

            MySqlCommand command3 = new MySqlCommand(thirdSQLStatement, conn);
            command3.Parameters.AddWithValue("@userID", userID);
            command3.Parameters.AddWithValue("@start", start);
            command3.Parameters.AddWithValue("@end", end);

            int adapter = new MySqlDataAdapter(command).Fill(dataTable);
            int adapter1 = new MySqlDataAdapter(command2).Fill(dataTable);
            int adapter2 = new MySqlDataAdapter(command3).Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("There is already an appointment at this time. Please select a new start time.");
                return true;
            }

            return false;
        }

        private bool IsOutsideBusinessHours()
        { 
            var start = dtpStartDateTime.Value.TimeOfDay;
            var end = dtpEndDateTime.Value.TimeOfDay;

            TimeSpan businessStartTime, businessEndTime;
            businessStartTime = new TimeSpan(08, 00, 00);
            businessEndTime = new TimeSpan(17, 30, 00);

            if (start < businessStartTime || end > businessEndTime)
            {
                //lambda expression - improves progam by making the code more concise
                Action<string> businessMessage = x => MessageBox.Show(x);
                businessMessage("Appointment is outside business hours. Please update time and resubmit.");

                return true;
            }

            return false;
        }

        private void LoadAppointmentTypes()
        {
            List<string> appointmentTypes = new List<string>
            {
                "",
                "Scrum",
                "Presentation",
                "Orientation - New Hire",
                "Scrum of Scrums",
                "Customer - New Contract",
                "Customer - Exisitng Contract"
            };

            //lambda expression - to simplify loaded type cb dropdown
            appointmentTypes = appointmentTypes.OrderBy(type => type).ToList();
            cbAppointmentType.DataSource = appointmentTypes;
        }
    }
}

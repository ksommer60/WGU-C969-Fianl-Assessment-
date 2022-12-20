using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace C969PerformanceAssessment
{
    public partial class AddCustomer : Form
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString = "server=localhost;username=root;password=Passw0rd!;database=client_schedule";

        public AddCustomer()
        {
            InitializeComponent();
        }

        public bool IsFormValid()
        {
            if (txtCustomerNameInput.Text == null)
            {
                MessageBox.Show("Customer name is missing.");
                return false;
            }

            if (txtAddressLine1Input == null)
            {
                MessageBox.Show("Address line 1 is missing.");
                return false;
            }

            if (txtCityInput.Text == null)
            {
                MessageBox.Show("City is missing.");
                return false;
            }

            if (txtZipCodeInput.Text == null)
            {
                MessageBox.Show("Zip code is missing.");
                return false;
            }

            if (txtCountryInput.Text == null)
            {
                MessageBox.Show("Country is missing.");
                return false;
            }

            if (txtPhoneNumberInput.Text == null)
            {
                MessageBox.Show("Phone number is missing.");
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

        public void AddCustomerToDB()
        {
            var currentUser = Environment.UserName;
            string customerName = txtCustomerNameInput.Text;
            int isActive = 1;
            DateTime customerCreateDate = DateTime.Today;
            string customerCreatedBy = currentUser;
            DateTime customerLastUpdate = DateTime.Today;
            string customerLastUpdateBy = currentUser;
            var addressLine1 = txtAddressLine1Input.Text;
            int addressID = 0;

            //getting address ID from address to add to customer table 
            string getAddressID = @"SELECT addressId FROM address WHERE address = @addressLine1";

            GetDBConnection();

            MySqlCommand command = new MySqlCommand(getAddressID, conn);
            command.Parameters.AddWithValue("@addressLine1", addressLine1);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                addressID = reader.GetInt32("addressId");
            }
            reader.Close();

            try
            {
                string insertCustomerDB = @"INSERT INTO customer VALUES(null, @customerName, @addressId, @isActive, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                MySqlCommand insertCommand = new MySqlCommand(insertCustomerDB, conn);

                insertCommand.Parameters.AddWithValue("@customerName", customerName);
                insertCommand.Parameters.AddWithValue("@addressId", addressID);
                insertCommand.Parameters.AddWithValue("@isActive", isActive);
                insertCommand.Parameters.AddWithValue("@createDate", customerCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", customerCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", customerLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", customerLastUpdateBy);

                conn.Open();
                insertCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddAddressToDB()
        {
            var currentUser = Environment.UserName;
            var addressLine1 = txtAddressLine1Input.Text;
            var addressLine2 = txtAddressLine2Input.Text;
            int zipCode = int.Parse(txtZipCodeInput.Text);
            var phoneNumber = txtPhoneNumberInput.Text;
            var addressCreateDate = DateTime.Today;
            var addressCreatedBy = currentUser;
            var addressLastUpdate = DateTime.Today;
            var addressLastUpdateBy = currentUser;
            var cityName = txtCityInput.Text;
            int cityID = 0;

            //getting city ID from city to add to address table
            string getCityID = @"SELECT cityId FROM city WHERE city = @cityName";

            GetDBConnection();

            MySqlCommand command = new MySqlCommand(getCityID, conn);
            command.Parameters.AddWithValue("@cityName", cityName);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cityID = reader.GetInt32("cityId");
            }
            reader.Close();

            try
            {
                string insertAddressDB = @"INSERT INTO address VALUES(null, @address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)"; 
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                MySqlCommand insertCommand = new MySqlCommand(insertAddressDB, conn);

                insertCommand.Parameters.AddWithValue("@address", addressLine1);
                insertCommand.Parameters.AddWithValue("@address2", addressLine2);
                insertCommand.Parameters.AddWithValue("@cityId", cityID);
                insertCommand.Parameters.AddWithValue("@postalCode", zipCode);
                insertCommand.Parameters.AddWithValue("@phone", phoneNumber);
                insertCommand.Parameters.AddWithValue("@createDate", addressCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", addressCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", addressLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", addressLastUpdateBy);

                conn.Open();
                insertCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddCityToDB()
        {
            var currentUser = Environment.UserName;
            var customerCity = txtCityInput.Text;
            var cityCreateDate = DateTime.Today;
            var cityCreatedBy = currentUser;
            var cityLastUpdate = DateTime.Today;
            var cityLastUpdateBy = currentUser;
            int countryID = 0;
            var countryName = txtCountryInput.Text;

            //getting country ID from country to add to city table
            string getCountryID = @"SELECT countryId FROM country WHERE country = @countryName";

            GetDBConnection();

            MySqlCommand command = new MySqlCommand(getCountryID, conn);
            command.Parameters.AddWithValue("@countryName", countryName);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                countryID = reader.GetInt32("countryId");
            }
            reader.Close();

            try
            {
                string insertCityDB = @"INSERT INTO city VALUES(null, @city, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)"; 
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                MySqlCommand insertCommand = new MySqlCommand(insertCityDB, conn);

                insertCommand.Parameters.AddWithValue("@city", customerCity);
                insertCommand.Parameters.AddWithValue("@countryId", countryID);
                insertCommand.Parameters.AddWithValue("@createDate", cityCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", cityCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", cityLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", cityLastUpdateBy);

                conn.Open();
                insertCommand.ExecuteNonQuery(); 
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddCountryToDB()
        {
            var currentUser = Environment.UserName;
            var customerCountry = txtCountryInput.Text;
            var countryCreateDate = DateTime.Today;
            var countryCreatedBy = currentUser;
            var countryLastUpdate = DateTime.Today;
            var countryLastUpdateBy = currentUser;

            try
            {
                string insertCountryDB = @"INSERT INTO country VALUES(null, @country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                MySqlCommand insertCommand = new MySqlCommand(insertCountryDB, conn);

                insertCommand.Parameters.AddWithValue("@country", customerCountry);
                insertCommand.Parameters.AddWithValue("@createDate", countryCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", countryCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", countryLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", countryLastUpdateBy);

                conn.Open();
                insertCommand.ExecuteNonQuery(); 
                conn.Close();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
        
        private void btnCancelCustomerForm_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {

            if (IsFormValid())
            {
                AddCountryToDB();
                AddCityToDB();
                AddAddressToDB();
                AddCustomerToDB();

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Form is invalid. Please verify all fields and click Save again.");
            }
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

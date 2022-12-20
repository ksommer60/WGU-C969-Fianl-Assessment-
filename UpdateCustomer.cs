using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace C969PerformanceAssessment
{
    public partial class UpdateCustomer : Form
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString = "server=localhost;port=3306;uid=root;pwd=Passw0rd!;database=client_schedule";

        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
           
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

        public void UpdateDBCustomer()
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
            int customerID = 0; 

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

            //getting address ID from address 
            string getCustomerID = @"SELECT customerId FROM customer WHERE customerName = @customerName";

            MySqlCommand commandCustomer = new MySqlCommand(getCustomerID, conn);
            commandCustomer.Parameters.AddWithValue("@customerName", customerName);

            MySqlDataReader readerCustomer = commandCustomer.ExecuteReader();

            while (readerCustomer.Read())
            {
                customerID = readerCustomer.GetInt32("customerId");
            }
            readerCustomer.Close();

            try
            {
                string updateDBCustomer = @"UPDATE customer SET customerName = @customerName, addressId = @addressID, active = @isActive, createDate = @customerCreateDate, createdBy = @customerCreatedBy,
                                          lastUpdate = @customerLastUpdate, lastUpdateBy = @customerLastUpdateBy WHERE customerId = @customerID"; 

                MySqlConnection conn = new MySqlConnection(myConnectionString);
                MySqlCommand updateCommand = new MySqlCommand(updateDBCustomer, conn);

                updateCommand.Parameters.AddWithValue("@customerID", customerID);
                updateCommand.Parameters.AddWithValue("@customerName", customerName);
                updateCommand.Parameters.AddWithValue("@addressID", addressID);
                updateCommand.Parameters.AddWithValue("@isActive", isActive);
                updateCommand.Parameters.AddWithValue("@customerCreateDate", customerCreateDate);
                updateCommand.Parameters.AddWithValue("@customerCreatedBy", customerCreatedBy);
                updateCommand.Parameters.AddWithValue("@customerLastUpdate", customerLastUpdate);
                updateCommand.Parameters.AddWithValue("@customerLastUpdateBy", customerLastUpdateBy);

                conn.Open();
                updateCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateDBAddress()
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
            int addressID = 0;

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

            //getting address ID from address 
            string getAddressID = @"SELECT addressId FROM address WHERE address = @addressLine1";

            MySqlCommand commandAddress = new MySqlCommand(getAddressID, conn);
            commandAddress.Parameters.AddWithValue("@addressLine1", addressLine1);

            MySqlDataReader readerAddress = commandAddress.ExecuteReader();

            while (readerAddress.Read())
            {
                addressID = readerAddress.GetInt32("addressId");
            }
            readerAddress.Close();

            try
            {
                string updateDBAddress = @"UPDATE address SET address = @addressLine1, address2 = @addressLine2, cityId = @cityID, postalCode = @zipCode, phone = @phoneNumber,
                                         createDate = @addressCreateDate, createdBy = @addressCreatedBy, lastUpdate = @addressLastUpdate, lastUpdateBy = @addressLastUpdateBy
                                         WHERE addressId = @addressID";

                MySqlConnection conn = new MySqlConnection(myConnectionString);
                MySqlCommand updateCommand = new MySqlCommand(updateDBAddress, conn);

                updateCommand.Parameters.AddWithValue("@addressID", addressID);
                updateCommand.Parameters.AddWithValue("@addressLine1", addressLine1);
                updateCommand.Parameters.AddWithValue("@addressLine2", addressLine2);
                updateCommand.Parameters.AddWithValue("@cityID", cityID);
                updateCommand.Parameters.AddWithValue("@zipCode", zipCode);
                updateCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                updateCommand.Parameters.AddWithValue("@addressCreateDate", addressCreateDate);
                updateCommand.Parameters.AddWithValue("@addressCreatedBy", addressCreatedBy);
                updateCommand.Parameters.AddWithValue("@addressLastUpdate", addressLastUpdate);
                updateCommand.Parameters.AddWithValue("@addressLastUpdateBy", addressLastUpdateBy);  

                conn.Open();
                updateCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateDBCity()
        {
            var currentUser = Environment.UserName;
            var customerCity = txtCityInput.Text;
            var cityCreateDate = DateTime.Today;
            var cityCreatedBy = currentUser;
            var cityLastUpdate = DateTime.Today;
            var cityLastUpdateBy = currentUser;
            int countryID = 0;
            int cityID = 0;
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

            //getting city ID from city 
            string getCityID = @"SELECT cityId FROM city WHERE city = @customerCity";

            MySqlCommand commandCity = new MySqlCommand(getCityID, conn);
            commandCity.Parameters.AddWithValue("@customerCity", customerCity);

            MySqlDataReader readerCity = commandCity.ExecuteReader();

            while (readerCity.Read())
            {
                cityID = readerCity.GetInt32("cityId");
            }
            readerCity.Close();

            try
            {
                string updateDBCity = @"UPDATE city SET city = @customerCity, countryId = @countryID, createDate = @cityCreateDate, createdBy = @cityCreatedBy, 
                                      lastUpdate = @cityLastUpdate, lastUpdateBy = @cityLastUpdateBy WHERE cityId = @cityID";

                MySqlConnection conn = new MySqlConnection(myConnectionString);
                MySqlCommand updateCommand = new MySqlCommand(updateDBCity, conn);

                updateCommand.Parameters.AddWithValue("cityID", cityID);
                updateCommand.Parameters.AddWithValue("@customerCity", customerCity);
                updateCommand.Parameters.AddWithValue("@countryID", countryID);
                updateCommand.Parameters.AddWithValue("@cityCreateDate", cityCreateDate);
                updateCommand.Parameters.AddWithValue("@cityCreatedBy", cityCreatedBy);
                updateCommand.Parameters.AddWithValue("@cityLastUpdate", cityLastUpdate);
                updateCommand.Parameters.AddWithValue("@cityLastUpdateBy", cityLastUpdateBy);

                conn.Open();
                updateCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateDBCountry()
        {
            var currentUser = Environment.UserName;
            var customerCountry = txtCountryInput.Text;
            var countryCreateDate = DateTime.Today;
            var countryCreatedBy = currentUser;
            var countryLastUpdate = DateTime.Today;
            var countryLastUpdateBy = currentUser;
            int countryID = 0; 

            //getting country ID from country to add to city table
            string getCountryID = @"SELECT countryId FROM country WHERE country = @customerCountry";

            GetDBConnection();

            MySqlCommand command = new MySqlCommand(getCountryID, conn);
            command.Parameters.AddWithValue("@customerCountry", customerCountry);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                countryID = reader.GetInt32("countryId");
            }
            reader.Close();

            try
            {
                string updateDBCountry = @"UPDATE country SET country = @customerCountry, createDate = @countryCreateDate, createdBy = @countryCreatedBy, 
                                           lastUpdate = @countryLastUpdate, lastUpdateBy = @countryLastUpdateBy WHERE countryId = @countryID"; 

                MySqlConnection conn = new MySqlConnection(myConnectionString);
                MySqlCommand updateCommand = new MySqlCommand(updateDBCountry, conn);

                updateCommand.Parameters.AddWithValue("@countryID", countryID);
                updateCommand.Parameters.AddWithValue("@customerCountry", customerCountry);
                updateCommand.Parameters.AddWithValue("@countryCreateDate", countryCreateDate);
                updateCommand.Parameters.AddWithValue("@countryCreatedBy", countryCreatedBy);
                updateCommand.Parameters.AddWithValue("@countryLastUpdate", countryLastUpdate);
                updateCommand.Parameters.AddWithValue("@countryLastUpdateBy", countryLastUpdateBy);

                conn.Open();
                updateCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveUpdatedCustomer_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                UpdateDBCountry();
                UpdateDBCity();
                UpdateDBAddress();
                UpdateDBCustomer();

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Form is invalid. Please review and resubmit.");
            }
        }

        private void btnCancelCustomerForm_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}

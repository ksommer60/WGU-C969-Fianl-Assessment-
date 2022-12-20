using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace C969PerformanceAssessment
{
    public partial class LoginForm : Form
    {
        MySql.Data.MySqlClient.MySqlConnection conn; 
        string myConnectionString;

        string errorLoginMessage = "Invalid username or password. Please review and resubmit.";
        string errorLoginHeader = "Login error"; 
        
        public LoginForm()
        {
            InitializeComponent();

            if (CultureInfo.CurrentCulture.Name == "esp")
            {
                lblLogin.Text = @"Acceso";
                lblUsername.Text = @"Nombre de usuario";
                lblPassword.Text = @"Clave";
                btnLoginUser.Text = @"Acceso";
                btnCancelLogin.Text = @"Cancelar";
                errorLoginHeader = "Error de inicio de sesion";
                errorLoginMessage = "Usuario o contrasena invalido. Por favor revise y vuelva a enviar.";
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnLoginUser_Click(object sender, EventArgs e)
        {
            var username = txtUsernameInput.Text.Trim();
            var password = txtPasswordInput.Text;
            DateTime createDate = DateTime.Today;
            var createdBy = username;
            var lastUpdate = DateTime.Today;
            var lastUpdatedBy = username;

            myConnectionString = "server=localhost;port=3306;username=root;password=Passw0rd!;database=client_schedule";

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

            string checkDBLogin = @"SELECT * FROM user WHERE username = @loginname and password = @password";

            DataTable dataTable = new DataTable();

            MySqlCommand mySqlCommand = new MySqlCommand(checkDBLogin);
            mySqlCommand.Parameters.AddWithValue("@loginname", username);
            mySqlCommand.Parameters.AddWithValue("@password", password);

            mySqlCommand.Connection = conn;

            int adapter = new MySqlDataAdapter(mySqlCommand).Fill(dataTable);

            string folderPath = @"C:\UserLoginLog";
            string fileName = @"\LoginLog.txt";
            fileName = folderPath + fileName;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); 
            }

            if (dataTable.Rows.Count <= 0)
            {
                MessageBox.Show(errorLoginMessage);

                using (StreamWriter userLoginFile = File.AppendText(fileName))
                {
                    string loginResult = "Failed login for user: " + username + DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss");

                    userLoginFile.WriteLine(loginResult);
                    userLoginFile.Close();
                }
                return;
            }
            else
            {
                using (StreamWriter userLoginFile = File.AppendText(fileName))
                {
                    string loginResult = "User " + username + " logged in at " + DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss");

                    userLoginFile.WriteLine(loginResult);
                    userLoginFile.Close();
                }
               
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
        }

        private void btnCancelLogin_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }



    }
}


namespace C969PerformanceAssessment
{
    partial class AddAppointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtAppointmentTitle = new System.Windows.Forms.TextBox();
            this.txtAppointmentLocation = new System.Windows.Forms.TextBox();
            this.txtAppointmentContact = new System.Windows.Forms.TextBox();
            this.txtAppointmentDescription = new System.Windows.Forms.TextBox();
            this.dtpStartDateTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSubmitAppointment = new System.Windows.Forms.Button();
            this.btnCancelAppointment = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCustomerPick = new System.Windows.Forms.ComboBox();
            this.cbUserPick = new System.Windows.Forms.ComboBox();
            this.cbAppointmentType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Appointment ";
            // 
            // txtAppointmentTitle
            // 
            this.txtAppointmentTitle.Location = new System.Drawing.Point(157, 105);
            this.txtAppointmentTitle.Name = "txtAppointmentTitle";
            this.txtAppointmentTitle.Size = new System.Drawing.Size(293, 20);
            this.txtAppointmentTitle.TabIndex = 1;
            // 
            // txtAppointmentLocation
            // 
            this.txtAppointmentLocation.Location = new System.Drawing.Point(157, 257);
            this.txtAppointmentLocation.Name = "txtAppointmentLocation";
            this.txtAppointmentLocation.Size = new System.Drawing.Size(293, 20);
            this.txtAppointmentLocation.TabIndex = 2;
            // 
            // txtAppointmentContact
            // 
            this.txtAppointmentContact.Location = new System.Drawing.Point(157, 283);
            this.txtAppointmentContact.Name = "txtAppointmentContact";
            this.txtAppointmentContact.Size = new System.Drawing.Size(293, 20);
            this.txtAppointmentContact.TabIndex = 7;
            // 
            // txtAppointmentDescription
            // 
            this.txtAppointmentDescription.Location = new System.Drawing.Point(157, 133);
            this.txtAppointmentDescription.Multiline = true;
            this.txtAppointmentDescription.Name = "txtAppointmentDescription";
            this.txtAppointmentDescription.Size = new System.Drawing.Size(293, 120);
            this.txtAppointmentDescription.TabIndex = 8;
            // 
            // dtpStartDateTime
            // 
            this.dtpStartDateTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDateTime.Location = new System.Drawing.Point(157, 395);
            this.dtpStartDateTime.Name = "dtpStartDateTime";
            this.dtpStartDateTime.Size = new System.Drawing.Size(293, 20);
            this.dtpStartDateTime.TabIndex = 9;
            // 
            // dtpEndDateTime
            // 
            this.dtpEndDateTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDateTime.Location = new System.Drawing.Point(157, 421);
            this.dtpEndDateTime.Name = "dtpEndDateTime";
            this.dtpEndDateTime.Size = new System.Drawing.Size(293, 20);
            this.dtpEndDateTime.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(59, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Start";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(59, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Customer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(59, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(59, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Contact";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(59, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Location";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(61, 421);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "End ";
            // 
            // btnSubmitAppointment
            // 
            this.btnSubmitAppointment.Location = new System.Drawing.Point(155, 481);
            this.btnSubmitAppointment.Name = "btnSubmitAppointment";
            this.btnSubmitAppointment.Size = new System.Drawing.Size(83, 37);
            this.btnSubmitAppointment.TabIndex = 22;
            this.btnSubmitAppointment.Text = "Submit";
            this.btnSubmitAppointment.UseVisualStyleBackColor = true;
            this.btnSubmitAppointment.Click += new System.EventHandler(this.btnSubmitAppointment_Click);
            // 
            // btnCancelAppointment
            // 
            this.btnCancelAppointment.Location = new System.Drawing.Point(255, 481);
            this.btnCancelAppointment.Name = "btnCancelAppointment";
            this.btnCancelAppointment.Size = new System.Drawing.Size(83, 37);
            this.btnCancelAppointment.TabIndex = 23;
            this.btnCancelAppointment.Text = "Cancel";
            this.btnCancelAppointment.UseVisualStyleBackColor = true;
            this.btnCancelAppointment.Click += new System.EventHandler(this.btnCancelAppointment_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "User";
            // 
            // cbCustomerPick
            // 
            this.cbCustomerPick.FormattingEnabled = true;
            this.cbCustomerPick.Location = new System.Drawing.Point(157, 337);
            this.cbCustomerPick.Name = "cbCustomerPick";
            this.cbCustomerPick.Size = new System.Drawing.Size(293, 21);
            this.cbCustomerPick.TabIndex = 26;
            // 
            // cbUserPick
            // 
            this.cbUserPick.FormattingEnabled = true;
            this.cbUserPick.Location = new System.Drawing.Point(157, 364);
            this.cbUserPick.Name = "cbUserPick";
            this.cbUserPick.Size = new System.Drawing.Size(293, 21);
            this.cbUserPick.TabIndex = 27;
            // 
            // cbAppointmentType
            // 
            this.cbAppointmentType.FormattingEnabled = true;
            this.cbAppointmentType.Location = new System.Drawing.Point(157, 308);
            this.cbAppointmentType.Name = "cbAppointmentType";
            this.cbAppointmentType.Size = new System.Drawing.Size(293, 21);
            this.cbAppointmentType.TabIndex = 28;
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 560);
            this.Controls.Add(this.cbAppointmentType);
            this.Controls.Add(this.cbUserPick);
            this.Controls.Add(this.cbCustomerPick);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelAppointment);
            this.Controls.Add(this.btnSubmitAppointment);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpEndDateTime);
            this.Controls.Add(this.dtpStartDateTime);
            this.Controls.Add(this.txtAppointmentDescription);
            this.Controls.Add(this.txtAppointmentContact);
            this.Controls.Add(this.txtAppointmentLocation);
            this.Controls.Add(this.txtAppointmentTitle);
            this.Controls.Add(this.label1);
            this.Name = "AddAppointment";
            this.Text = "AddAppointment";
            this.Load += new System.EventHandler(this.AddAppointment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAppointmentTitle;
        private System.Windows.Forms.TextBox txtAppointmentLocation;
        private System.Windows.Forms.TextBox txtAppointmentContact;
        private System.Windows.Forms.TextBox txtAppointmentDescription;
        private System.Windows.Forms.DateTimePicker dtpStartDateTime;
        private System.Windows.Forms.DateTimePicker dtpEndDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSubmitAppointment;
        private System.Windows.Forms.Button btnCancelAppointment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCustomerPick;
        public System.Windows.Forms.ComboBox cbUserPick;
        private System.Windows.Forms.ComboBox cbAppointmentType;
    }
}
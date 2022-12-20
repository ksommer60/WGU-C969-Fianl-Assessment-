
namespace C969PerformanceAssessment
{
    partial class NewReport
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
            this.DVGNewReport = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbApppointmentType = new System.Windows.Forms.ComboBox();
            this.cbConsultant = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRunAppTypeReport = new System.Windows.Forms.Button();
            this.btnRunConsultantReport = new System.Windows.Forms.Button();
            this.btnRunCustomerReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DVGNewReport)).BeginInit();
            this.SuspendLayout();
            // 
            // DVGNewReport
            // 
            this.DVGNewReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DVGNewReport.Location = new System.Drawing.Point(12, 91);
            this.DVGNewReport.Name = "DVGNewReport";
            this.DVGNewReport.Size = new System.Drawing.Size(966, 367);
            this.DVGNewReport.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(379, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Report";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(881, 548);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 31);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Appointment Type";
            // 
            // cbApppointmentType
            // 
            this.cbApppointmentType.FormattingEnabled = true;
            this.cbApppointmentType.Location = new System.Drawing.Point(136, 478);
            this.cbApppointmentType.Name = "cbApppointmentType";
            this.cbApppointmentType.Size = new System.Drawing.Size(218, 21);
            this.cbApppointmentType.TabIndex = 7;
            // 
            // cbConsultant
            // 
            this.cbConsultant.FormattingEnabled = true;
            this.cbConsultant.Location = new System.Drawing.Point(136, 518);
            this.cbConsultant.Name = "cbConsultant";
            this.cbConsultant.Size = new System.Drawing.Size(218, 21);
            this.cbConsultant.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 523);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Consultant";
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(136, 558);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(218, 21);
            this.cbCustomer.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 563);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = " Customer";
            // 
            // btnRunAppTypeReport
            // 
            this.btnRunAppTypeReport.Location = new System.Drawing.Point(372, 478);
            this.btnRunAppTypeReport.Name = "btnRunAppTypeReport";
            this.btnRunAppTypeReport.Size = new System.Drawing.Size(97, 21);
            this.btnRunAppTypeReport.TabIndex = 12;
            this.btnRunAppTypeReport.Text = "Run Report";
            this.btnRunAppTypeReport.UseVisualStyleBackColor = true;
            this.btnRunAppTypeReport.Click += new System.EventHandler(this.btnRunAppTypeReport_Click);
            // 
            // btnRunConsultantReport
            // 
            this.btnRunConsultantReport.Location = new System.Drawing.Point(372, 518);
            this.btnRunConsultantReport.Name = "btnRunConsultantReport";
            this.btnRunConsultantReport.Size = new System.Drawing.Size(97, 21);
            this.btnRunConsultantReport.TabIndex = 13;
            this.btnRunConsultantReport.Text = "Run Report";
            this.btnRunConsultantReport.UseVisualStyleBackColor = true;
            this.btnRunConsultantReport.Click += new System.EventHandler(this.btnRunConsultantReport_Click);
            // 
            // btnRunCustomerReport
            // 
            this.btnRunCustomerReport.Location = new System.Drawing.Point(372, 558);
            this.btnRunCustomerReport.Name = "btnRunCustomerReport";
            this.btnRunCustomerReport.Size = new System.Drawing.Size(97, 21);
            this.btnRunCustomerReport.TabIndex = 14;
            this.btnRunCustomerReport.Text = "Run Report";
            this.btnRunCustomerReport.UseVisualStyleBackColor = true;
            this.btnRunCustomerReport.Click += new System.EventHandler(this.btnRunCustomerReport_Click);
            // 
            // NewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 604);
            this.Controls.Add(this.btnRunCustomerReport);
            this.Controls.Add(this.btnRunConsultantReport);
            this.Controls.Add(this.btnRunAppTypeReport);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbConsultant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbApppointmentType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DVGNewReport);
            this.Name = "NewReport";
            this.Text = "NewReport";
            this.Load += new System.EventHandler(this.NewReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DVGNewReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DVGNewReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbApppointmentType;
        private System.Windows.Forms.ComboBox cbConsultant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRunAppTypeReport;
        private System.Windows.Forms.Button btnRunConsultantReport;
        private System.Windows.Forms.Button btnRunCustomerReport;
    }
}
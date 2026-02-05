namespace Management
{
    partial class Top
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
            label1 = new Label();
            btnSalesData = new Button();
            btnTransmission = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 20F);
            label1.Location = new Point(151, 42);
            label1.Name = "label1";
            label1.Size = new Size(209, 37);
            label1.TabIndex = 0;
            label1.Text = "売上管理システム";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSalesData
            // 
            btnSalesData.Font = new Font("Yu Gothic UI", 12F);
            btnSalesData.Location = new Point(41, 115);
            btnSalesData.Name = "btnSalesData";
            btnSalesData.Size = new Size(195, 61);
            btnSalesData.TabIndex = 1;
            btnSalesData.Text = "売上管理";
            btnSalesData.UseVisualStyleBackColor = true;
            btnSalesData.Click += btnSalesData_Click;
            // 
            // btnTransmission
            // 
            btnTransmission.Font = new Font("Yu Gothic UI", 12F);
            btnTransmission.Location = new Point(275, 115);
            btnTransmission.Name = "btnTransmission";
            btnTransmission.Size = new Size(195, 61);
            btnTransmission.TabIndex = 2;
            btnTransmission.Text = "送受信管理";
            btnTransmission.UseVisualStyleBackColor = true;
            btnTransmission.Click += btnTransmission_Click;
            // 
            // Top
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(516, 227);
            Controls.Add(btnTransmission);
            Controls.Add(btnSalesData);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Top";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "トップ画面";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSalesData;
        private Button btnTransmission;
    }
}
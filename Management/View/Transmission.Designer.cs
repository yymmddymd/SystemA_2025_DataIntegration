namespace Management
{
    partial class Transmission
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblCaption = new Label();
            gbxFilter = new GroupBox();
            cbxError = new CheckBox();
            cbxRetry = new CheckBox();
            cbxProceed = new CheckBox();
            cbxReceive = new CheckBox();
            cbxSend = new CheckBox();
            dtpEnd = new DateTimePicker();
            lblSeparator = new Label();
            dtpStart = new DateTimePicker();
            lblStatus = new Label();
            lblCategory = new Label();
            lblRange = new Label();
            btnClear = new Button();
            btnSearch = new Button();
            dgvResult = new DataGridView();
            RowProcessedAt = new DataGridViewTextBoxColumn();
            RowCategory = new DataGridViewTextBoxColumn();
            RowFileName = new DataGridViewTextBoxColumn();
            RowStatus = new DataGridViewTextBoxColumn();
            RowOutputMessage = new DataGridViewTextBoxColumn();
            btnUpdate = new Button();
            btnClose = new Button();
            gbxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResult).BeginInit();
            SuspendLayout();
            // 
            // lblCaption
            // 
            lblCaption.AutoSize = true;
            lblCaption.Font = new Font("Yu Gothic UI Semibold", 14F, FontStyle.Bold);
            lblCaption.Location = new Point(42, 32);
            lblCaption.Margin = new Padding(5, 0, 5, 0);
            lblCaption.Name = "lblCaption";
            lblCaption.Size = new Size(157, 38);
            lblCaption.TabIndex = 0;
            lblCaption.Text = "送受信管理";
            // 
            // gbxFilter
            // 
            gbxFilter.Controls.Add(cbxError);
            gbxFilter.Controls.Add(cbxRetry);
            gbxFilter.Controls.Add(cbxProceed);
            gbxFilter.Controls.Add(cbxReceive);
            gbxFilter.Controls.Add(cbxSend);
            gbxFilter.Controls.Add(dtpEnd);
            gbxFilter.Controls.Add(lblSeparator);
            gbxFilter.Controls.Add(dtpStart);
            gbxFilter.Controls.Add(lblStatus);
            gbxFilter.Controls.Add(lblCategory);
            gbxFilter.Controls.Add(lblRange);
            gbxFilter.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            gbxFilter.Location = new Point(42, 108);
            gbxFilter.Margin = new Padding(5);
            gbxFilter.Name = "gbxFilter";
            gbxFilter.Padding = new Padding(5);
            gbxFilter.Size = new Size(953, 226);
            gbxFilter.TabIndex = 17;
            gbxFilter.TabStop = false;
            gbxFilter.Text = "検索条件";
            // 
            // cbxError
            // 
            cbxError.AutoSize = true;
            cbxError.Checked = true;
            cbxError.CheckState = CheckState.Checked;
            cbxError.Location = new Point(465, 164);
            cbxError.Margin = new Padding(5);
            cbxError.Name = "cbxError";
            cbxError.Size = new Size(74, 29);
            cbxError.TabIndex = 15;
            cbxError.Text = "異常";
            cbxError.UseVisualStyleBackColor = true;
            // 
            // cbxRetry
            // 
            cbxRetry.AutoSize = true;
            cbxRetry.Checked = true;
            cbxRetry.CheckState = CheckState.Checked;
            cbxRetry.Location = new Point(336, 164);
            cbxRetry.Margin = new Padding(5);
            cbxRetry.Name = "cbxRetry";
            cbxRetry.Size = new Size(105, 29);
            cbxRetry.TabIndex = 14;
            cbxRetry.Text = "再送待ち";
            cbxRetry.UseVisualStyleBackColor = true;
            // 
            // cbxProceed
            // 
            cbxProceed.AutoSize = true;
            cbxProceed.Checked = true;
            cbxProceed.CheckState = CheckState.Checked;
            cbxProceed.Location = new Point(212, 164);
            cbxProceed.Margin = new Padding(5);
            cbxProceed.Name = "cbxProceed";
            cbxProceed.Size = new Size(108, 29);
            cbxProceed.TabIndex = 13;
            cbxProceed.Text = "処理済み";
            cbxProceed.UseVisualStyleBackColor = true;
            // 
            // cbxReceive
            // 
            cbxReceive.AutoSize = true;
            cbxReceive.Checked = true;
            cbxReceive.CheckState = CheckState.Checked;
            cbxReceive.Location = new Point(314, 110);
            cbxReceive.Margin = new Padding(5);
            cbxReceive.Name = "cbxReceive";
            cbxReceive.Size = new Size(74, 29);
            cbxReceive.TabIndex = 11;
            cbxReceive.Text = "受信";
            cbxReceive.UseVisualStyleBackColor = true;
            // 
            // cbxSend
            // 
            cbxSend.AutoSize = true;
            cbxSend.Checked = true;
            cbxSend.CheckState = CheckState.Checked;
            cbxSend.Location = new Point(212, 110);
            cbxSend.Margin = new Padding(5);
            cbxSend.Name = "cbxSend";
            cbxSend.Size = new Size(74, 29);
            cbxSend.TabIndex = 10;
            cbxSend.Text = "送信";
            cbxSend.UseVisualStyleBackColor = true;
            // 
            // dtpEnd
            // 
            dtpEnd.CustomFormat = "yyyy/MM";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(419, 50);
            dtpEnd.Margin = new Padding(5);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.ShowUpDown = true;
            dtpEnd.Size = new Size(155, 31);
            dtpEnd.TabIndex = 8;
            // 
            // lblSeparator
            // 
            lblSeparator.AutoSize = true;
            lblSeparator.Location = new Point(380, 56);
            lblSeparator.Margin = new Padding(5, 0, 5, 0);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new Size(30, 25);
            lblSeparator.TabIndex = 7;
            lblSeparator.Text = "～";
            // 
            // dtpStart
            // 
            dtpStart.CustomFormat = "yyyy/MM";
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(212, 50);
            dtpStart.Margin = new Padding(5);
            dtpStart.Name = "dtpStart";
            dtpStart.ShowUpDown = true;
            dtpStart.Size = new Size(155, 31);
            dtpStart.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.FromArgb(224, 224, 224);
            lblStatus.Location = new Point(45, 158);
            lblStatus.Margin = new Padding(5, 0, 5, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(149, 36);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "ステータス";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCategory
            // 
            lblCategory.BackColor = Color.FromArgb(224, 224, 224);
            lblCategory.Location = new Point(45, 102);
            lblCategory.Margin = new Padding(5, 0, 5, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(149, 36);
            lblCategory.TabIndex = 9;
            lblCategory.Text = "分類";
            lblCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRange
            // 
            lblRange.BackColor = Color.FromArgb(224, 224, 224);
            lblRange.Location = new Point(45, 50);
            lblRange.Margin = new Padding(5, 0, 5, 0);
            lblRange.Name = "lblRange";
            lblRange.Size = new Size(149, 36);
            lblRange.TabIndex = 5;
            lblRange.Text = "期間";
            lblRange.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnClear.Location = new Point(1356, 256);
            btnClear.Margin = new Padding(5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(188, 78);
            btnClear.TabIndex = 2;
            btnClear.Text = "条件クリア";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnSearch.Location = new Point(1144, 256);
            btnSearch.Margin = new Padding(5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(188, 78);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvResult
            // 
            dgvResult.AllowUserToAddRows = false;
            dgvResult.AllowUserToDeleteRows = false;
            dgvResult.AllowUserToResizeColumns = false;
            dgvResult.AllowUserToResizeRows = false;
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResult.Columns.AddRange(new DataGridViewColumn[] { RowProcessedAt, RowCategory, RowFileName, RowStatus, RowOutputMessage });
            dgvResult.Location = new Point(42, 370);
            dgvResult.Margin = new Padding(5);
            dgvResult.Name = "dgvResult";
            dgvResult.ReadOnly = true;
            dgvResult.RowHeadersVisible = false;
            dgvResult.RowHeadersWidth = 51;
            dgvResult.RowTemplate.Height = 40;
            dgvResult.RowTemplate.ReadOnly = true;
            dgvResult.ScrollBars = ScrollBars.Vertical;
            dgvResult.Size = new Size(1502, 488);
            dgvResult.TabIndex = 16;
            // 
            // RowProcessedAt
            // 
            RowProcessedAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            RowProcessedAt.HeaderText = "処理日時";
            RowProcessedAt.MinimumWidth = 6;
            RowProcessedAt.Name = "RowProcessedAt";
            RowProcessedAt.ReadOnly = true;
            RowProcessedAt.Width = 120;
            // 
            // RowCategory
            // 
            RowCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            RowCategory.FillWeight = 60F;
            RowCategory.HeaderText = "分類";
            RowCategory.MinimumWidth = 6;
            RowCategory.Name = "RowCategory";
            RowCategory.ReadOnly = true;
            RowCategory.Width = 84;
            // 
            // RowFileName
            // 
            RowFileName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            RowFileName.FillWeight = 150F;
            RowFileName.HeaderText = "ファイル名";
            RowFileName.MinimumWidth = 6;
            RowFileName.Name = "RowFileName";
            RowFileName.ReadOnly = true;
            RowFileName.Width = 117;
            // 
            // RowStatus
            // 
            RowStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            RowStatus.FillWeight = 60F;
            RowStatus.HeaderText = "ステータス";
            RowStatus.MinimumWidth = 6;
            RowStatus.Name = "RowStatus";
            RowStatus.ReadOnly = true;
            RowStatus.Width = 116;
            // 
            // RowOutputMessage
            // 
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            RowOutputMessage.DefaultCellStyle = dataGridViewCellStyle2;
            RowOutputMessage.HeaderText = "出力メッセージ";
            RowOutputMessage.MinimumWidth = 6;
            RowOutputMessage.Name = "RowOutputMessage";
            RowOutputMessage.ReadOnly = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Enabled = false;
            btnUpdate.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnUpdate.Location = new Point(1140, 892);
            btnUpdate.Margin = new Padding(5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(188, 78);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "更新";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnClose.Location = new Point(1356, 892);
            btnClose.Margin = new Padding(5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(188, 78);
            btnClose.TabIndex = 4;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // Transmission
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1574, 1004);
            ControlBox = false;
            Controls.Add(btnUpdate);
            Controls.Add(btnClose);
            Controls.Add(dgvResult);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(gbxFilter);
            Controls.Add(lblCaption);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            MaximizeBox = false;
            Name = "Transmission";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "送受信管理";
            gbxFilter.ResumeLayout(false);
            gbxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCaption;
        private GroupBox gbxFilter;
        private CheckBox cbxReceive;
        private CheckBox cbxSend;
        private DateTimePicker dtpEnd;
        private Label lblSeparator;
        private DateTimePicker dtpStart;
        private Label lblStatus;
        private Label lblCategory;
        private Label lblRange;
        private CheckBox cbxProceed;
        private CheckBox cbxRetry;
        private CheckBox cbxError;
        private Button btnClear;
        private Button btnSearch;
        private DataGridView dgvResult;
        private Button btnUpdate;
        private Button btnClose;
        private DataGridViewTextBoxColumn RowProcessedAt;
        private DataGridViewTextBoxColumn RowCategory;
        private DataGridViewTextBoxColumn RowFileName;
        private DataGridViewTextBoxColumn RowStatus;
        private DataGridViewTextBoxColumn RowOutputMessage;
    }
}
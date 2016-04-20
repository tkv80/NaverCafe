namespace NaverCafe
{
    partial class FamousCamp
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
            this.lbCamp = new System.Windows.Forms.ListBox();
            this.lbSite = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnInsert = new System.Windows.Forms.Button();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.gbReservation = new System.Windows.Forms.GroupBox();
            this.lbReservation = new System.Windows.Forms.ListBox();
            this.cbAsync = new System.Windows.Forms.CheckBox();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnStartReservation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCarNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCell = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbSiteNumber = new System.Windows.Forms.ListBox();
            this.cbPeople = new System.Windows.Forms.ComboBox();
            this.cbStayDay = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbLog.SuspendLayout();
            this.gbReservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCamp
            // 
            this.lbCamp.FormattingEnabled = true;
            this.lbCamp.ItemHeight = 12;
            this.lbCamp.Location = new System.Drawing.Point(232, 94);
            this.lbCamp.Name = "lbCamp";
            this.lbCamp.Size = new System.Drawing.Size(183, 136);
            this.lbCamp.TabIndex = 0;
            // 
            // lbSite
            // 
            this.lbSite.FormattingEnabled = true;
            this.lbSite.ItemHeight = 12;
            this.lbSite.Location = new System.Drawing.Point(6, 256);
            this.lbSite.Name = "lbSite";
            this.lbSite.Size = new System.Drawing.Size(220, 88);
            this.lbSite.TabIndex = 1;
            this.lbSite.SelectedIndexChanged += new System.EventHandler(this.lbSite_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(230, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "＃ 캠핑장";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(4, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "＃ 사이트";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.monthCalendar1.Location = new System.Drawing.Point(6, 70);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(6, 391);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(409, 23);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "예약추가";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.txtLog);
            this.gbLog.Location = new System.Drawing.Point(6, 544);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(412, 104);
            this.gbLog.TabIndex = 26;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "로그";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(6, 20);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(400, 74);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // gbReservation
            // 
            this.gbReservation.Controls.Add(this.lbReservation);
            this.gbReservation.Controls.Add(this.cbAsync);
            this.gbReservation.Controls.Add(this.numInterval);
            this.gbReservation.Controls.Add(this.btnDelete);
            this.gbReservation.Controls.Add(this.btnStartReservation);
            this.gbReservation.Location = new System.Drawing.Point(6, 420);
            this.gbReservation.Name = "gbReservation";
            this.gbReservation.Size = new System.Drawing.Size(412, 118);
            this.gbReservation.TabIndex = 25;
            this.gbReservation.TabStop = false;
            this.gbReservation.Text = "예약";
            // 
            // lbReservation
            // 
            this.lbReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReservation.FormattingEnabled = true;
            this.lbReservation.ItemHeight = 12;
            this.lbReservation.Location = new System.Drawing.Point(7, 20);
            this.lbReservation.Name = "lbReservation";
            this.lbReservation.Size = new System.Drawing.Size(399, 64);
            this.lbReservation.TabIndex = 17;
            // 
            // cbAsync
            // 
            this.cbAsync.AutoSize = true;
            this.cbAsync.Location = new System.Drawing.Point(380, 144);
            this.cbAsync.Name = "cbAsync";
            this.cbAsync.Size = new System.Drawing.Size(60, 16);
            this.cbAsync.TabIndex = 16;
            this.cbAsync.Text = "비동기";
            this.cbAsync.UseVisualStyleBackColor = true;
            // 
            // numInterval
            // 
            this.numInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numInterval.Location = new System.Drawing.Point(280, 90);
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(44, 21);
            this.numInterval.TabIndex = 14;
            this.numInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(6, 89);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "선택삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnStartReservation
            // 
            this.btnStartReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartReservation.Location = new System.Drawing.Point(331, 89);
            this.btnStartReservation.Name = "btnStartReservation";
            this.btnStartReservation.Size = new System.Drawing.Size(75, 23);
            this.btnStartReservation.TabIndex = 12;
            this.btnStartReservation.Text = "예약시작";
            this.btnStartReservation.UseVisualStyleBackColor = true;
            this.btnStartReservation.Click += new System.EventHandler(this.btnStartReservation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCarNumber);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtCell);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 64);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "유저정보";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(353, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "＃차번호";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(169, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "＃이메일";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(76, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 29;
            this.label4.Text = "＃전화번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(4, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "＃이름";
            // 
            // txtCarNumber
            // 
            this.txtCarNumber.Location = new System.Drawing.Point(355, 35);
            this.txtCarNumber.Name = "txtCarNumber";
            this.txtCarNumber.Size = new System.Drawing.Size(51, 21);
            this.txtCarNumber.TabIndex = 3;
            this.txtCarNumber.Text = "7896";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(171, 35);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(178, 21);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "tkv80@naver.com";
            // 
            // txtCell
            // 
            this.txtCell.Location = new System.Drawing.Point(78, 35);
            this.txtCell.Name = "txtCell";
            this.txtCell.Size = new System.Drawing.Size(87, 21);
            this.txtCell.TabIndex = 1;
            this.txtCell.Text = "010-8226-7979";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(7, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(65, 21);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "김태권";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(233, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "＃ 사이트자리";
            // 
            // lbSiteNumber
            // 
            this.lbSiteNumber.FormattingEnabled = true;
            this.lbSiteNumber.ItemHeight = 12;
            this.lbSiteNumber.Location = new System.Drawing.Point(232, 256);
            this.lbSiteNumber.Name = "lbSiteNumber";
            this.lbSiteNumber.Size = new System.Drawing.Size(183, 88);
            this.lbSiteNumber.TabIndex = 29;
            // 
            // cbPeople
            // 
            this.cbPeople.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeople.FormattingEnabled = true;
            this.cbPeople.Location = new System.Drawing.Point(80, 350);
            this.cbPeople.Name = "cbPeople";
            this.cbPeople.Size = new System.Drawing.Size(60, 20);
            this.cbPeople.TabIndex = 30;
            // 
            // cbStayDay
            // 
            this.cbStayDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStayDay.FormattingEnabled = true;
            this.cbStayDay.Location = new System.Drawing.Point(232, 350);
            this.cbStayDay.Name = "cbStayDay";
            this.cbStayDay.Size = new System.Drawing.Size(60, 20);
            this.cbStayDay.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(4, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "＃추가인원";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(156, 354);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 12);
            this.label9.TabIndex = 33;
            this.label9.Text = "＃숙박일수";
            // 
            // FamousCamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 657);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbStayDay);
            this.Controls.Add(this.cbPeople);
            this.Controls.Add(this.lbSiteNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbReservation);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSite);
            this.Controls.Add(this.lbCamp);
            this.Name = "FamousCamp";
            this.Text = "FamousCamp";
            this.gbLog.ResumeLayout(false);
            this.gbReservation.ResumeLayout(false);
            this.gbReservation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCamp;
        private System.Windows.Forms.ListBox lbSite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.GroupBox gbReservation;
        private System.Windows.Forms.CheckBox cbAsync;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnStartReservation;
        private System.Windows.Forms.ListBox lbReservation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCell;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCarNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbSiteNumber;
        private System.Windows.Forms.ComboBox cbPeople;
        private System.Windows.Forms.ComboBox cbStayDay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
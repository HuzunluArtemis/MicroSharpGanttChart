namespace MicroSharpGanttChart.ChartFuncs
{
    partial class FormTimeBlock
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.chkHatch = new System.Windows.Forms.CheckBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(12, 63);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(58, 13);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "Start Time:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(12, 89);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(55, 13);
            this.lblEndTime.TabIndex = 0;
            this.lblEndTime.Text = "End Time:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(265, 20);
            this.txtName.TabIndex = 1;
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(15, 32);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(56, 17);
            this.chkVisible.TabIndex = 2;
            this.chkVisible.Text = "Visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // chkHatch
            // 
            this.chkHatch.AutoSize = true;
            this.chkHatch.Location = new System.Drawing.Point(110, 34);
            this.chkHatch.Name = "chkHatch";
            this.chkHatch.Size = new System.Drawing.Size(67, 17);
            this.chkHatch.TabIndex = 2;
            this.chkHatch.Text = "Hatched";
            this.chkHatch.UseVisualStyleBackColor = true;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(110, 57);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(265, 20);
            this.dtStart.TabIndex = 3;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(110, 83);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(265, 20);
            this.dtEnd.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(194, 109);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Confirm Changes";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(300, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.IndianRed;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.ForeColor = System.Drawing.Color.Black;
            this.btnColor.Location = new System.Drawing.Point(357, 32);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(18, 18);
            this.btnColor.TabIndex = 30;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(306, 36);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 31;
            this.lblColor.Text = "Color:";
            // 
            // FormTimeBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 140);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.chkHatch);
            this.Controls.Add(this.chkVisible);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblName);
            this.Name = "FormTimeBlock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormTimeBlockSettings";
            this.Load += new System.EventHandler(this.FormTimeBlockSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.CheckBox chkHatch;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblColor;
        internal System.Windows.Forms.DateTimePicker dtStart;
        internal System.Windows.Forms.DateTimePicker dtEnd;
    }
}
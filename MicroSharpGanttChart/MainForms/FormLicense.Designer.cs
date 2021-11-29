namespace MicroSharpGanttChart
{
    partial class FormLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLicense));
            this.rtxtLicense = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxtLicense
            // 
            this.rtxtLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtLicense.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtxtLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLicense.Location = new System.Drawing.Point(0, 0);
            this.rtxtLicense.Name = "rtxtLicense";
            this.rtxtLicense.ReadOnly = true;
            this.rtxtLicense.ShowSelectionMargin = true;
            this.rtxtLicense.Size = new System.Drawing.Size(397, 377);
            this.rtxtLicense.TabIndex = 1;
            this.rtxtLicense.Text = resources.GetString("rtxtLicense.Text");
            // 
            // FormLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 377);
            this.Controls.Add(this.rtxtLicense);
            this.Name = "FormLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormLicense";
            this.Load += new System.EventHandler(this.FormLicense_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtxtLicense;
    }
}
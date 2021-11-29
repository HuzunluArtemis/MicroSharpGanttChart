using ColorPickerWPF;
using GanttChart;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MicroSharpGanttChart.ChartFuncs
{
    public partial class FormTimeBlock : Form
    {

        internal Row row;
        internal TimeBlock TimeBlock;
        internal int process;
        // 0=edit timeblock
        // 1= add timeblock

        public FormTimeBlock()
        {
            InitializeComponent();
        }

        private void FormTimeBlockSettings_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = Locales.Local.logo1;

            // make custom datepicker
            this.dtStart.Format = DateTimePickerFormat.Custom;
            string dateFormat = "dd MMMM yyyy, 'Hour (00-24):' H";
            this.dtStart.CustomFormat = dateFormat;
            this.dtEnd.Format = DateTimePickerFormat.Custom;
            this.dtEnd.CustomFormat = dateFormat;

            // load from object
            switch (process)
            {
                case 0:
                    txtName.Text = TimeBlock.Text;
                    chkVisible.Checked = TimeBlock.IsVisible;
                    chkHatch.Checked = TimeBlock.Hatch;
                    dtStart.Value = TimeBlock.StartTime;
                    dtEnd.Value = TimeBlock.EndTime;
                    btnColor.BackColor = TimeBlock.Color;
                    break;
                case 1:
                    txtName.Text = Locales.Local.defaultTimeBlockName;
                    chkVisible.Checked = Settings.Default.defaultTimeBlockVisible;
                    chkHatch.Checked = Settings.Default.defaultTimeBlockHatched;
                    btnColor.BackColor = Settings.Default.defaultTimeBlockBackColor;
                    btnOK.Text = Locales.Local.strAddTimeBlockTitle;

                    break;
            }


            //do translate
            this.lblName.Text = Locales.Local.timeblockNameLabel;
            this.chkVisible.Text = Locales.Local.timeblockVisible;
            this.chkHatch.Text = Locales.Local.timeblockHatched;
            this.lblColor.Text = Locales.Local.timeblockColor;
            this.lblStartTime.Text = Locales.Local.timeblockStartTime;
            this.lblEndTime.Text = Locales.Local.timeblockEndTime;
            this.btnOK.Text = Locales.Local.timeblockConfirmChanges;
            this.btnCancel.Text = Locales.Local.timeblockCancel;
            if (process == 0)
            {
                this.Text = string.Format(Locales.Local.timeblockTitle, TimeBlock.Text);
            }
            if (process == 1)
            {
                this.Text = Locales.Local.strAddTimeBlockTitle;
            }



            //unselect HelperFuncs.StringFuncs.UnselectTextbox(txtName);
            HelperFuncs.StringFuncs.SelectAllTextBox(txtName);


        }

        private void pickColor(Button button)
        {
            if (Settings.Default.UseSystemColorPicker)
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.AnyColor = true;
                colorDialog.AllowFullOpen = true;
                Color color = colorDialog.Color;
                DialogResult result = colorDialog.ShowDialog();
                switch (result)
                {
                    case DialogResult.OK:

                        color = colorDialog.Color;
                        button.BackColor = color;
                        button.ForeColor = Color.Black;
                        button.Refresh();
                        button.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                // tp
                System.Windows.Media.Color color = new System.Windows.Media.Color();
                ColorPickerWindow colorPicker = new ColorPickerWindow();
                colorPicker.Title = "Renk Seçici";
                bool ok = ColorPickerWindow.ShowDialog(out color);
                if (ok)
                {
                    btnColor.Invoke((MethodInvoker)(() => btnColor.BackColor = ColorConvert.ToDrawingColor(color)));
                }
                // tp
            }


        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            pickColor(btnColor);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (process)
            {
                case 0:
                    TimeBlock.Text = txtName.Text;
                    TimeBlock.IsVisible = chkVisible.Checked;
                    TimeBlock.Hatch = chkHatch.Checked;
                    TimeBlock.StartTime = dtStart.Value;
                    TimeBlock.EndTime = dtEnd.Value;
                    TimeBlock.Color = btnColor.BackColor;
                    break;
                case 1:
                    {
                        TimeBlock TimeBlock = new TimeBlock();
                        TimeBlock.Text = txtName.Text;
                        TimeBlock.IsVisible = chkVisible.Checked;
                        TimeBlock.Hatch = chkHatch.Checked;
                        TimeBlock.StartTime = dtStart.Value;
                        TimeBlock.EndTime = dtEnd.Value;
                        TimeBlock.Color = btnColor.BackColor;
                        row.TimeBlocks.Add(TimeBlock);
                        break;
                    }
            }

            this.Close();

        }
    }
}

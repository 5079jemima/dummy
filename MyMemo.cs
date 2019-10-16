using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WindowsApplication1
{
    public partial class MyMemo : DevExpress.XtraEditors.XtraUserControl
    {
        public MyMemo()
        {
            InitializeComponent();
            progressBarControl1.Properties.Maximum = memoEdit1.Properties.MaxLength;
            UpdateControls();
        }

        void UpdateControls(int value)
        {
            progressBarControl1.EditValue = value;
            labelControl1.Text = String.Format("Remaining character count:{0}", memoEdit1.Properties.MaxLength - value); ;
        }

        void UpdateControls()
        {
            UpdateControls(memoEdit1.Text.Length);
        }

        private void memoEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            UpdateControls();
        }
    }
}

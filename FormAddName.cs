using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;

namespace VideoCombine
{
    public partial class FormAddName : DevExpress.XtraEditors.XtraForm
    {
        public TextEdit TextEditName
        {
            get { return textEditName; }
            set { textEditName = value; }
        }
        public FormAddName()
        {
            InitializeComponent();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
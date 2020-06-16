using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VideoCombine
{
    public partial class FormPlayer : DevExpress.XtraEditors.XtraForm
    {
        private string _path;
        public FormPlayer(string playPath)
        {
            InitializeComponent();
            player.enableContextMenu = false;
            _path = playPath;
        }

        private void FormPlayer_Load(object sender, EventArgs e)
        {
            bool exist = File.Exists(_path);
            if (exist)
            {
                player.URL = _path;
                player.Ctlcontrols.play();
            }
        }
        private void FormPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.Ctlcontrols.stop();
            player.close();
            player.Dispose();
        }
    }
}
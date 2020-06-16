using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace VideoCombine
{
    public partial class FormVideos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<VideoInfo> _videoInfoList;
        private List<VideoInfo> _selectVideoInfoList;

        public List<VideoInfo> SelectVideoInfoList
        {
            get { return _selectVideoInfoList; }
            set { _selectVideoInfoList = value; }
        }
        public FormVideos(List<VideoInfo> videoInfoList)
        {
            InitializeComponent();
            _videoInfoList = videoInfoList;
        }

        private void FormVideos_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _videoInfoList;
        }

        private void repositoryItemCheckEdit1_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
        {
            string val = "";
            if (e.Value != null)
            {
                val = e.Value.ToString();
            }
            else
            {
                val = "False";//默认为不选   
            }
            switch (val)
            {
                case "True":
                case "Yes":
                case "1":
                    e.CheckState = CheckState.Checked;
                    break;
                case "False":
                case "No":
                case "0":
                    e.CheckState = CheckState.Unchecked;
                    break;
                default:
                    e.CheckState = CheckState.Checked;
                    break;
            }
            e.Handled = true;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            _selectVideoInfoList = GetSelectVideos();
            if (_selectVideoInfoList == null) return;
            this.DialogResult = DialogResult.OK;
        }

        private List<VideoInfo> GetSelectVideos()
        {
            List<VideoInfo> selectVideoInfoList = new List<VideoInfo>();
            if (gridView1.SelectedRowsCount <= 0)
            {
                MessageBox.Show(@"请选择要添加的视频。", @"添加提示", MessageBoxButtons.OK);
                selectVideoInfoList = null;
            }
            else
            {
                var index = gridView1.GetSelectedRows();
                selectVideoInfoList.AddRange(index.Select(t => (VideoInfo)gridView1.GetRow(t)));
            }
            return selectVideoInfoList;
        }
    }
}
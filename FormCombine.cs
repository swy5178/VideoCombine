using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraNavBar;
using DevExpress.XtraSplashScreen;
using MediaToolkit;
using MediaToolkit.Model;

namespace VideoCombine
{
    public partial class FormCombine : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<VideoInfo> _videoInfoList;//视频资源列表
        private List<VideoInfo> _sceneVideoInfoList;//场景视频列表
        private string _ffmpegPath = Application.StartupPath + "\\ffmpeg.exe";
        private bool _changeMark = false;
        private NavBarItemLink _navBarItemLink;
        public FormCombine()
        {
            InitializeComponent();
        }

        private void FormCombine_Load(object sender, EventArgs e)
        {
            LoadSceneList();
        }

        #region 工具方法

        /// <summary>加载场景列表信息</summary>
        private void LoadSceneList()
        {
            Dictionary<string, Image> sceneNameImageDic = VideoHelper.GetSceneNameImageDic();
            foreach (var pair in sceneNameImageDic)
            {
                AddItemToNavBar(pair.Key, pair.Value);
            }
            navBarGroupVideos.SelectedLinkIndex = -1;
            navBarGroupVideos.ItemChanged += navBarGroupVideos_ItemChanged;
            navBarGroupVideos.SelectedLinkIndex = 0;
        }
        /// <summary>删除场景Item</summary>
        private void DeleteSceneItem()
        {
            navBarGroupVideos.ItemChanged -= navBarGroupVideos_ItemChanged;
            int index = navBarGroupVideos.SelectedLinkIndex;
            navBarGroupVideos.ItemLinks.RemoveAt(index);
            navBarGroupVideos.ItemChanged += navBarGroupVideos_ItemChanged;
            navBarGroupVideos.SelectedLinkIndex = index - 1;
        }
        /// <summary>添加场景item</summary>
        /// <param name="sceneName"></param>
        private void AddSceneItem(string sceneName)
        {
            string resourcesPath = FileHelper.GetFileAbsolutePath("Resources\\") + "item.png";
            Image image = Image.FromFile(resourcesPath);
            Bitmap bmp = new Bitmap(image);
            image.Dispose();
            NavBarItem navBarItem = new NavBarItem
            {
                Caption = sceneName,
                LargeImage = bmp,
                LargeImageSize = new Size(120, 90),
                Name = "navBarItem" + sceneName
            };
            navBarGroupVideos.ItemLinks.Insert(1, navBarItem);
        }

        /// <summary>刷新场景图片</summary>
        private void FreshSceneItem(NavBarItemLink narBarItemLink)
        {
            bool isExistThumbnail = true;
            string itemPath = FileHelper.GetFileAbsolutePath("Resources\\") + "item.png";
            string sceneName = narBarItemLink.Caption;
            string pathName = FileHelper.GetFileAbsolutePath("CombVideos\\") + sceneName + ".mp4";
            string imagePath = FileHelper.GetFileAbsolutePath("VideoThumbnails\\") + sceneName + ".jpg";
            if (!File.Exists(imagePath))
                isExistThumbnail = VideoHelper.CreateThumbnail(pathName, imagePath);
            Image image = isExistThumbnail ? Image.FromFile(imagePath) : Image.FromFile(itemPath);
            Bitmap bmp = new Bitmap(image);
            image.Dispose();
            narBarItemLink.Item.LargeImage = bmp;
        }
        /// <summary>刷新视频资源列表</summary>
        private void FreshVideosList()
        {
            ShowMessage();
            _videoInfoList = VideoHelper.GetSourceVideosList();
            gridControl1.DataSource = _videoInfoList;
            HideMessage();
        }
        /// <summary>刷新场景item对应的视频列表</summary>
        /// <param name="item"></param>
        private void FreshSceneVideoList(string item)
        {
            _sceneVideoInfoList = VideoHelper.GetCurrentSceneVideosData(item);
            gridControl1.DataSource = _sceneVideoInfoList;
        }
        /// <summary>
        /// 添加一个场景信息到场景列表
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="sceneImage"></param>
        private void AddItemToNavBar(string sceneName, Image sceneImage)
        {
            NavBarItem navBarItem = new NavBarItem
            {
                Caption = sceneName,
                LargeImage = sceneImage,
                LargeImageSize = new Size(120, 90),
                Name = "navBarItem" + sceneName
            };
            navBarGroupVideos.ItemLinks.Add(navBarItem);
        }
        /// <summary>
        /// 获取选中的视频
        /// </summary>
        /// <returns></returns>
        private List<VideoInfo> GetSelectVideos()
        {
            List<VideoInfo> videoInfoList = new List<VideoInfo>();
            if (gridView1.SelectedRowsCount <= 0)
            {
                MessageBox.Show(@"请选择要删除的视频。", @"删除提示", MessageBoxButtons.OK);
                videoInfoList = null;
            }
            else
            {
                var index = gridView1.GetSelectedRows();
                videoInfoList.AddRange(index.Select(t => (VideoInfo)gridView1.GetRow(t)));
            }
            return videoInfoList;
        }
        /// <summary>加载打开文件对话框</summary>
        /// <returns></returns>
        private OpenFileDialog LoadOpenFileDlg()
        {
            string videoPath = XmlHelper.ReadNodeDataOfLMSettings("/root/OpenFilePath");
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = @"视频文件|*.mp4;*.mov;*.avi;*.mkv;*.flv;*.wmv;",
                InitialDirectory = videoPath,
                Multiselect = true
            };
            if (dlg.ShowDialog() != DialogResult.OK) return dlg;

            string openFilePath = Path.GetDirectoryName(dlg.FileName);
            XmlHelper.UpdateNodestring("/root/OpenFilePath", openFilePath); //更新保存本次打开文件的路径
            return dlg;
        }
        /// <summary>拷贝添加的视频到视频源文件夹</summary>
        /// <param name="fromFileList"></param>
        /// <param name="toFileList"></param>
        private void CopyVideo(List<string> fromFileList, List<string> toFileList)
        {
            if (FileHelper.IsExistSameNameFiles(toFileList))
            {
                DialogResult dialogResult = MessageBox.Show(@"视频资源文件夹存在同名文件，是否覆盖它？", @"复制提示", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                    ShellFileOperation.Copy(fromFileList, toFileList, true);
                else if (dialogResult == DialogResult.No)
                    ShellFileOperation.Copy(fromFileList, toFileList, false);
                FreshVideosList();
            }
            else
            {
                ShellFileOperation.Copy(fromFileList, toFileList, false);
                FreshVideosList();
            }
        }

        private void SwapVideo(List<VideoInfo> list, int index1, int index2)
        {
            VideoInfo videoInfo1 = list[index1];
            VideoInfo tempVideoInfo = list[index2];
            list[index2] = videoInfo1;
            list[index1] = tempVideoInfo;
        }
        private void VideoMoveUp()
        {
            var index = gridView1.FocusedRowHandle;
            if (index < 0)
            {
                MessageBox.Show(@"请选中一条视频上移！", @"上移提示", MessageBoxButtons.OK);
                return;
            }
            if (index > 0)
            {
                SwapVideo(_sceneVideoInfoList, index, index - 1);
                gridControl1.DataSource = null;
                gridControl1.DataSource = _sceneVideoInfoList;
                gridView1.FocusedRowHandle = index - 1;
            }

        }
        private void VideoMoveDown()
        {
            var index = gridView1.FocusedRowHandle;
            if (index < 0)
            {
                MessageBox.Show(@"请选中一条视频下移！", @"下移提示", MessageBoxButtons.OK);
                return;
            }
            if (index < gridView1.RowCount - 1)
            {
                SwapVideo(_sceneVideoInfoList, index, index + 1);
                gridControl1.DataSource = null;
                gridControl1.DataSource = _sceneVideoInfoList;
                gridView1.FocusedRowHandle = index + 1;
            }

        }

        /// <summary>视频预览播放</summary>
        /// <param name="videoName"></param>
        /// <param name="videoFormat"></param>
        private void PlayVideo(string videoName, string videoFormat)
        {
            string newVideoName = videoName;
            if (videoName.Contains(videoFormat))
                newVideoName = videoName.Replace(videoFormat, "");
            string path = FileHelper.GetFileAbsolutePath("SourceVideos\\") + newVideoName + videoFormat;
            bool exist = File.Exists(path);
            if (exist)
            {
                FormPlayer formPlayer = new FormPlayer(path);
                formPlayer.ShowDialog();

            }
        }

        /// <summary>视频合并操作</summary>
        /// <param name="narBarItemLink"></param>
        private void VideoCombine(NavBarItemLink narBarItemLink)
        {
            if (_sceneVideoInfoList.Count == 0)
            {
                MessageBox.Show("请添加视频");
                return;
            }
            //等待窗口调用
            ShowMessage();
            foreach (var videoInfo in _sceneVideoInfoList)
            {
                string cmdConvert;//转换命令
                string convertVideoName = FileHelper.GetFileAbsolutePath("SourceVideos\\") + videoInfo.VideoName + ".mp4";
                string tempVideoName = FileHelper.GetFileAbsolutePath("SourceVideos\\") + videoInfo.VideoName + ".ts";
                if (!videoInfo.VideoFormat.Equals(".mp4"))
                {
                    cmdConvert = VideoHelper.ConvertToMp4Cmd(videoInfo.VideoPath, convertVideoName);
                    VideoHelper.RunFFMpeg(_ffmpegPath, cmdConvert);
                }
                //文件格式转换mp4->mpegts
                cmdConvert = VideoHelper.Mp4ToTsCmd(convertVideoName, tempVideoName);
                VideoHelper.RunFFMpeg(_ffmpegPath, cmdConvert);
            }
            string itemCaption = narBarItemLink.Caption;
            //创建或更新视频列表.txt
            VideoHelper.CreateOrUpdateVideoList(_sceneVideoInfoList, itemCaption);
            //视频合并命令
            string cmdCombine = VideoHelper.GetCombineCmd(_sceneVideoInfoList, itemCaption);
            if (VideoHelper.RunFFMpeg(_ffmpegPath, cmdCombine))
            {
                //刷新当前场景的截图
                FreshSceneItem(narBarItemLink);
                VideoHelper.DeleteTempVideos(_sceneVideoInfoList);
                simpleButtonCombine.Visible = false;
            }
            HideMessage();
        }
        
        private void VideoCombine1(NavBarItemLink narBarItemLink)
        {
            if (_sceneVideoInfoList.Count == 0)
            {
                MessageBox.Show("请添加视频");
                return;
            }
            //等待窗口调用
            ShowMessage();
            for (int i = 0; i < _sceneVideoInfoList.Count; i++)
            {
                SplashScreenManager.Default.SetWaitFormCaption("正在处理第" + (i + 1) + "个视频,请稍后...");
                SplashScreenManager.Default.SetWaitFormCaption("正在处理第" + (i + 1) + "个视频,请稍后...");
                VideoInfo videoInfo = _sceneVideoInfoList[i];
                string cmdConvert;//转换命令
                string convertVideoName = FileHelper.GetFileAbsolutePath("SourceVideos\\") + videoInfo.VideoName + ".mp4";
                string tempVideoName = FileHelper.GetFileAbsolutePath("SourceVideos\\") + videoInfo.VideoName + ".ts";
                if (!videoInfo.VideoFormat.Equals(".mp4"))
                {
                    cmdConvert = VideoHelper.ConvertToMp4Cmd(videoInfo.VideoPath, convertVideoName);
                    VideoHelper.RunFFMpeg(_ffmpegPath, cmdConvert);
                }
                //文件格式转换mp4->mpegts
                cmdConvert = VideoHelper.Mp4ToTsCmd(convertVideoName, tempVideoName);
                VideoHelper.RunFFMpeg(_ffmpegPath, cmdConvert);
            }
            string itemCaption = narBarItemLink.Caption;
            //创建或更新视频列表.txt
            VideoHelper.CreateOrUpdateVideoList(_sceneVideoInfoList, itemCaption);
            //视频合并命令
            string cmdCombine = VideoHelper.GetCombineCmd(_sceneVideoInfoList, itemCaption);
            VideoHelper.RunFFMpeg(_ffmpegPath, cmdCombine);
            //刷新当前场景的截图
            FreshSceneItem(narBarItemLink);
            VideoHelper.DeleteTempVideos(_sceneVideoInfoList);
            HideMessage();
        }

        /// <summary>新增场景时，判断名称是否存在 </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        private bool IsExistScene(string sceneName)
        {
            foreach (NavBarItem item in navBarControlVideo.Items)
            {
                if (item.Caption.Equals(sceneName))
                {
                    MessageBox.Show(@"场景名称已存在！");
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 事件

        private void repositoryItemCheckEdit1_QueryCheckStateByValue(object sender, QueryCheckStateByValueEventArgs e)
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
        //处理item切换之前的事务
        private void navBarControl1_LinkPressed(object sender, NavBarLinkEventArgs e)
        {
            _navBarItemLink = navBarGroupVideos.SelectedLink;
        }
        //场景切换事件
        private void navBarGroupVideos_ItemChanged(object sender, EventArgs e)
        {
            //修改提示在这写是避免当前item点击而没有changed时的提示
            if (_changeMark)
            {
                DialogResult dialogResult = MessageBox.Show("\"" + _navBarItemLink.Caption + "\"已修改，要先保存吗？", @"保存提示", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    VideoCombine(_navBarItemLink);
                }
                _changeMark = false;
                simpleButtonCombine.Visible = false;
            }
            if (navBarGroupVideos.SelectedLink.ItemName.Equals("navBarItemAll"))
            {
                simpleButtonUp.Visible = false;
                simpleButtonDown.Visible = false;
                simpleButtonCombine.Visible = false;
                FreshVideosList();
            }
            else
            {
                simpleButtonUp.Visible = true;
                simpleButtonDown.Visible = true;
                string item = navBarGroupVideos.SelectedLink.Caption;
                FreshSceneVideoList(item);
            }
        }
        //添加视频
        private void simpleButtonAdds_Click(object sender, EventArgs e)
        {
            if (navBarGroupVideos.SelectedLink.ItemName.Equals("navBarItemAll"))
            {   //视频资源添加
                var dlg = LoadOpenFileDlg();
                List<string> fromFileList = dlg.FileNames.ToList();
                List<string> toFileList = FileHelper.GetCopyToFilesList(dlg.SafeFileNames);
                //拷贝添加的视频到视频源文件夹
                CopyVideo(fromFileList, toFileList);
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            }
            else
            {
                FormVideos formVideos = new FormVideos(_videoInfoList);
                DialogResult dialogResult = formVideos.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    List<VideoInfo> addVideoInfoList = formVideos.SelectVideoInfoList;
                    foreach (VideoInfo videoInfo in addVideoInfoList)
                    {
                        string videoName = videoInfo.VideoName;
                        if (videoInfo.VideoName.Contains(videoInfo.VideoFormat))
                        {
                            videoName = videoInfo.VideoName.Replace(videoInfo.VideoFormat, "");
                            videoInfo.VideoName = videoName;
                        }
                    }
                    //原场景视频+添加的场景视频，Union去重，Concat不去重
                    _sceneVideoInfoList = _sceneVideoInfoList.Union(addVideoInfoList).ToList<VideoInfo>();
                    gridControl1.DataSource = _sceneVideoInfoList;
                    _changeMark = true;
                    simpleButtonCombine.Visible = true;
                }
            }
        }
        //删除视频
        private void simpleButtonDel_Click(object sender, EventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;
            List<VideoInfo> videoInfoList = GetSelectVideos();
            if (videoInfoList == null) return;
            if (navBarGroupVideos.SelectedLink.ItemName.Equals("navBarItemAll"))
            {   //视频资源删除
                DialogResult dialogResult = MessageBox.Show(@"确定要永久性的删除选中的视频吗？", @"删除提示", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //删除本地视频
                    foreach (var videoInfo in videoInfoList)
                    {
                        ShellFileOperation.Delete(videoInfo.VideoPath);
                    }
                    FreshVideosList();
                    gridView1.FocusedRowHandle = rowHandle - 1;
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(@"确定要移除当前场景下选中的视频吗？", @"移除提示", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //移除选中视频
                    _sceneVideoInfoList = _sceneVideoInfoList.Except(videoInfoList).ToList();
                    gridControl1.DataSource = _sceneVideoInfoList;
                    _changeMark = true;
                    simpleButtonCombine.Visible = true;
                }
            }
        }
        //添加场景
        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            FormAddName formAddName = new FormAddName();
            DialogResult dialogResult = formAddName.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string sceneName = formAddName.TextEditName.Text;

                if (FileHelper.IsValidFileName(sceneName) && !IsExistScene(sceneName))
                    AddSceneItem(sceneName);
            }
        }
        //删除场景
        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            if (navBarGroupVideos.SelectedLink.ItemName.Equals("navBarItemAll")) return;
            string videoName = navBarGroupVideos.SelectedLink.Caption;
            if (MessageBox.Show(@"确定删除选中的场景吗？", @"删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VideoHelper.DeleteScene(videoName);
                DeleteSceneItem();
            }
        }

        private void simpleButtonUp_Click(object sender, EventArgs e)
        {
            VideoMoveUp();
            _changeMark = true;
            simpleButtonCombine.Visible = true;
        }

        private void simpleButtonDown_Click(object sender, EventArgs e)
        {
            VideoMoveDown();
            _changeMark = true;
            simpleButtonCombine.Visible = true;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (!e.Column.FieldName.Equals("VideoImage")) return;
            string videoName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VideoName").ToString();
            string videoFormat = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VideoFormat").ToString();
            PlayVideo(videoName, videoFormat);
        }
        //视频合并操作
        private void simpleButtonCombine_Click(object sender, EventArgs e)
        {
            VideoCombine(navBarGroupVideos.SelectedLink);
            _changeMark = false;
        }


        #endregion

        #region 等待窗口

        private SplashScreenManager _loadForm;
        /// <summary>
        /// 等待窗体管理对象
        /// </summary>
        private SplashScreenManager LoadForm
        {
            get
            {
                if (_loadForm == null)
                {
                    this._loadForm = new SplashScreenManager(this, typeof(FrmWaitForm1), true, true);
                    this._loadForm.ClosingDelay = 0;
                }
                return _loadForm;
            }
        }
        /// <summary>
        /// 显示等待窗体
        /// </summary>
        private void ShowMessage()
        {
            bool flag = !this.LoadForm.IsSplashFormVisible;
            if (flag)
            {
                this.LoadForm.ShowWaitForm();
            }
        }
        /// <summary>
        /// 关闭等待窗体
        /// </summary>
        private void HideMessage()
        {
            bool isSplashFormVisible = this.LoadForm.IsSplashFormVisible;
            if (isSplashFormVisible)
            {
                this.LoadForm.CloseWaitForm();
            }
        }

        #endregion
    }
}
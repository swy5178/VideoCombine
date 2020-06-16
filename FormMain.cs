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
using CalAlgorithm;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors.Internal;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraSplashScreen;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;

namespace VideoCombine
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            axWindowsMediaPlayer.enableContextMenu = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadSceneList();
        }

        #region 工具方法
        /// <summary>加载视频列表信息</summary>
        private void LoadSceneList()
        {
            Dictionary<string, Image> sceneNameImageDic = VideoHelper.GetSceneNameImageDic();
            navBarControlVideos.Items.Clear();
            foreach (var pair in sceneNameImageDic)
            {
                AddItemToNavBar(pair.Key, pair.Value);
            }
        }
        /// <summary>
        /// 添加一个视频信息到视频列表
        /// </summary>
        /// <param name="videoName"></param>
        /// <param name="videoImage"></param>
        private void AddItemToNavBar(string videoName, Image videoImage)
        {
            NavBarItem navBarItem = new NavBarItem
            {
                Caption = videoName,
                LargeImage = videoImage,
                LargeImageSize = new Size(120, 90),
                Name = "navBarItem" + videoName
            };
            navBarGroupVideos.ItemLinks.Add(navBarItem);
        }
        /// <summary>场景播放</summary>
        /// <param name="sceneName"></param>
        private void PlayScene(string sceneName)
        {
            string path = FileHelper.GetFileAbsolutePath("CombVideos\\") + sceneName + ".mp4";
            bool exist = File.Exists(path);
            if (exist)
            {
                axWindowsMediaPlayer.URL = path;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
        }
        #endregion

        #region 事件

        private void barButtonItemManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            //等待窗口调用
            SplashScreenManager.ShowForm(typeof(FrmWaitForm));
            FormCombine ribbonForm = new FormCombine();
            ribbonForm.ShowDialog();
            SplashScreenManager.CloseForm();
            //重新加载场景列表
            LoadSceneList();
        }
        /// <summary>
        /// 单击标签播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarControlVideos_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string sceneName = e.Link.Caption;
            PlayScene(sceneName);
        }
        #endregion
        
    }
}
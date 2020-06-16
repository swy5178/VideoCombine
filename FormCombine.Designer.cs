namespace VideoCombine
{
    partial class FormCombine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCombine));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonAdds = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDown = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonUp = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCombine = new DevExpress.XtraEditors.SimpleButton();
            this.navBarControlVideo = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupVideos = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemAll = new DevExpress.XtraNavBar.NavBarItem();
            this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1174, 27);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "重命名";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "删除场景";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 781);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1174, 31);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.navBarControlVideo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.simpleButtonAdd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.simpleButtonDelete, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1174, 754);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(159, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemPictureEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1012, 690);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "视频资源列表";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 100;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "视频名称";
            this.gridColumn1.FieldName = "VideoName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "视频截图";
            this.gridColumn2.ColumnEdit = this.repositoryItemPictureEdit1;
            this.gridColumn2.FieldName = "VideoImage";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.repositoryItemPictureEdit1.ZoomAccelerationFactor = 1D;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "视频格式";
            this.gridColumn3.FieldName = "VideoFormat";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "视频时长";
            this.gridColumn4.FieldName = "VideoDuration";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "视频尺寸";
            this.gridColumn5.FieldName = "VideoResolution";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "选择状态";
            this.gridColumn7.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn7.FieldName = "status";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.QueryCheckStateByValue += new DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventHandler(this.repositoryItemCheckEdit1_QueryCheckStateByValue);
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "视频路径";
            this.gridColumn6.FieldName = "VideoPath";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonAdds);
            this.panelControl1.Controls.Add(this.simpleButtonDown);
            this.panelControl1.Controls.Add(this.simpleButtonUp);
            this.panelControl1.Controls.Add(this.simpleButtonDel);
            this.panelControl1.Controls.Add(this.simpleButtonCombine);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(159, 699);
            this.panelControl1.Name = "panelControl1";
            this.tableLayoutPanel1.SetRowSpan(this.panelControl1, 2);
            this.panelControl1.Size = new System.Drawing.Size(1012, 52);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButtonAdds
            // 
            this.simpleButtonAdds.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonAdds.Image")));
            this.simpleButtonAdds.Location = new System.Drawing.Point(27, 5);
            this.simpleButtonAdds.Name = "simpleButtonAdds";
            this.simpleButtonAdds.Size = new System.Drawing.Size(101, 39);
            this.simpleButtonAdds.TabIndex = 2;
            this.simpleButtonAdds.Text = "添加";
            this.simpleButtonAdds.Click += new System.EventHandler(this.simpleButtonAdds_Click);
            // 
            // simpleButtonDown
            // 
            this.simpleButtonDown.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonDown.Image")));
            this.simpleButtonDown.Location = new System.Drawing.Point(780, 5);
            this.simpleButtonDown.Name = "simpleButtonDown";
            this.simpleButtonDown.Size = new System.Drawing.Size(101, 39);
            this.simpleButtonDown.TabIndex = 1;
            this.simpleButtonDown.Text = "下移";
            this.simpleButtonDown.Click += new System.EventHandler(this.simpleButtonDown_Click);
            // 
            // simpleButtonUp
            // 
            this.simpleButtonUp.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonUp.Image")));
            this.simpleButtonUp.Location = new System.Drawing.Point(673, 5);
            this.simpleButtonUp.Name = "simpleButtonUp";
            this.simpleButtonUp.Size = new System.Drawing.Size(101, 39);
            this.simpleButtonUp.TabIndex = 1;
            this.simpleButtonUp.Text = "上移";
            this.simpleButtonUp.Click += new System.EventHandler(this.simpleButtonUp_Click);
            // 
            // simpleButtonDel
            // 
            this.simpleButtonDel.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonDel.Image")));
            this.simpleButtonDel.Location = new System.Drawing.Point(134, 5);
            this.simpleButtonDel.Name = "simpleButtonDel";
            this.simpleButtonDel.Size = new System.Drawing.Size(101, 39);
            this.simpleButtonDel.TabIndex = 1;
            this.simpleButtonDel.Text = "删除";
            this.simpleButtonDel.Click += new System.EventHandler(this.simpleButtonDel_Click);
            // 
            // simpleButtonCombine
            // 
            this.simpleButtonCombine.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCombine.Image")));
            this.simpleButtonCombine.Location = new System.Drawing.Point(887, 5);
            this.simpleButtonCombine.Name = "simpleButtonCombine";
            this.simpleButtonCombine.Size = new System.Drawing.Size(101, 39);
            this.simpleButtonCombine.TabIndex = 0;
            this.simpleButtonCombine.Text = "保存";
            this.simpleButtonCombine.Click += new System.EventHandler(this.simpleButtonCombine_Click);
            // 
            // navBarControlVideo
            // 
            this.navBarControlVideo.ActiveGroup = this.navBarGroupVideos;
            this.navBarControlVideo.AllowDrop = false;
            this.navBarControlVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControlVideo.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.navBarControlVideo.ExplorerBarShowGroupButtons = false;
            this.navBarControlVideo.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupVideos});
            this.navBarControlVideo.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItemAll});
            this.navBarControlVideo.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInControl;
            this.navBarControlVideo.Location = new System.Drawing.Point(3, 3);
            this.navBarControlVideo.Name = "navBarControlVideo";
            this.navBarControlVideo.OptionsNavPane.ExpandedWidth = 150;
            this.navBarControlVideo.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBarControlVideo.Size = new System.Drawing.Size(150, 690);
            this.navBarControlVideo.TabIndex = 2;
            this.navBarControlVideo.Text = "展示场景";
            this.navBarControlVideo.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarControl1_LinkPressed);
            // 
            // navBarGroupVideos
            // 
            this.navBarGroupVideos.Caption = "展示场景";
            this.navBarGroupVideos.Expanded = true;
            this.navBarGroupVideos.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navBarGroupVideos.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroupVideos.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemAll)});
            this.navBarGroupVideos.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupVideos.LargeImage")));
            this.navBarGroupVideos.Name = "navBarGroupVideos";
            this.navBarGroupVideos.SelectedLinkIndex = 0;
            // 
            // navBarItemAll
            // 
            this.navBarItemAll.CanDrag = false;
            this.navBarItemAll.Caption = "所有视频";
            this.navBarItemAll.LargeImage = global::VideoCombine.Properties.Resources.chart2_32x32;
            this.navBarItemAll.Name = "navBarItemAll";
            // 
            // simpleButtonAdd
            // 
            this.simpleButtonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleButtonAdd.Location = new System.Drawing.Point(3, 699);
            this.simpleButtonAdd.Name = "simpleButtonAdd";
            this.simpleButtonAdd.Size = new System.Drawing.Size(150, 23);
            this.simpleButtonAdd.TabIndex = 3;
            this.simpleButtonAdd.Text = "场景添加";
            this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
            // 
            // simpleButtonDelete
            // 
            this.simpleButtonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleButtonDelete.Location = new System.Drawing.Point(3, 728);
            this.simpleButtonDelete.Name = "simpleButtonDelete";
            this.simpleButtonDelete.Size = new System.Drawing.Size(150, 23);
            this.simpleButtonDelete.TabIndex = 3;
            this.simpleButtonDelete.Text = "场景删除";
            this.simpleButtonDelete.Click += new System.EventHandler(this.simpleButtonDelete_Click);
            // 
            // FormCombine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 812);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCombine";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "展示场景管理";
            this.Load += new System.EventHandler(this.FormCombine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAdds;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCombine;
        private DevExpress.XtraNavBar.NavBarControl navBarControlVideo;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupVideos;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAdd;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDelete;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDown;
        private DevExpress.XtraEditors.SimpleButton simpleButtonUp;
        private DevExpress.XtraNavBar.NavBarItem navBarItemAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}
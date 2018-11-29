namespace servermonitoring
{
    partial class baseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TabPageA = new DevExpress.XtraTab.XtraTabPage();
            this.panelA = new System.Windows.Forms.Panel();
            this.TabPageTotal = new DevExpress.XtraTab.XtraTabPage();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.TabPageB = new DevExpress.XtraTab.XtraTabPage();
            this.panelB = new System.Windows.Forms.Panel();
            this.TabPageD = new DevExpress.XtraTab.XtraTabPage();
            this.panelD = new System.Windows.Forms.Panel();
            this.TabPageE = new DevExpress.XtraTab.XtraTabPage();
            this.panelE = new System.Windows.Forms.Panel();
            this.TabPageF = new DevExpress.XtraTab.XtraTabPage();
            this.panelF = new System.Windows.Forms.Panel();
            this.TabPageH = new DevExpress.XtraTab.XtraTabPage();
            this.panelH = new System.Windows.Forms.Panel();
            this.TabPageJ = new DevExpress.XtraTab.XtraTabPage();
            this.panelJ = new System.Windows.Forms.Panel();
            this.TabPageL = new DevExpress.XtraTab.XtraTabPage();
            this.panelL = new System.Windows.Forms.Panel();
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPageO = new DevExpress.XtraTab.XtraTabPage();
            this.panelO = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.TabPageA.SuspendLayout();
            this.TabPageTotal.SuspendLayout();
            this.TabPageB.SuspendLayout();
            this.TabPageD.SuspendLayout();
            this.TabPageE.SuspendLayout();
            this.TabPageF.SuspendLayout();
            this.TabPageH.SuspendLayout();
            this.TabPageJ.SuspendLayout();
            this.TabPageL.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.TabPageO.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "File";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Move";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Log";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1862, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 893);
            this.barDockControlBottom.Size = new System.Drawing.Size(1862, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 871);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1862, 22);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 871);
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Images = this.imageList1;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 22);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.TabPageA;
            this.xtraTabControl2.Size = new System.Drawing.Size(1862, 871);
            this.xtraTabControl2.TabIndex = 4;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPageTotal,
            this.TabPageA,
            this.TabPageB,
            this.TabPageD,
            this.TabPageE,
            this.TabPageF,
            this.TabPageH,
            this.TabPageJ,
            this.TabPageL,
            this.TabPageO});
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_16x16.png");
            this.imageList1.Images.SetKeyName(1, "folderclose16x16.png");
            // 
            // TabPageA
            // 
            this.TabPageA.Controls.Add(this.panelA);
            this.TabPageA.ImageIndex = 0;
            this.TabPageA.Name = "TabPageA";
            this.TabPageA.Size = new System.Drawing.Size(1856, 840);
            this.TabPageA.Text = "부산";
            // 
            // panelA
            // 
            this.panelA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelA.Location = new System.Drawing.Point(0, 0);
            this.panelA.Name = "panelA";
            this.panelA.Size = new System.Drawing.Size(1856, 840);
            this.panelA.TabIndex = 2;
            // 
            // TabPageTotal
            // 
            this.TabPageTotal.Controls.Add(this.panelTotal);
            this.TabPageTotal.ImageIndex = 1;
            this.TabPageTotal.Name = "TabPageTotal";
            this.TabPageTotal.Size = new System.Drawing.Size(1856, 840);
            this.TabPageTotal.Text = "전체";
            // 
            // panelTotal
            // 
            this.panelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotal.Location = new System.Drawing.Point(0, 0);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(1856, 840);
            this.panelTotal.TabIndex = 5;
            // 
            // TabPageB
            // 
            this.TabPageB.Controls.Add(this.panelB);
            this.TabPageB.ImageIndex = 1;
            this.TabPageB.Name = "TabPageB";
            this.TabPageB.Size = new System.Drawing.Size(1856, 840);
            this.TabPageB.Text = "순천";
            // 
            // panelB
            // 
            this.panelB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelB.Location = new System.Drawing.Point(0, 0);
            this.panelB.Name = "panelB";
            this.panelB.Size = new System.Drawing.Size(1856, 840);
            this.panelB.TabIndex = 3;
            // 
            // TabPageD
            // 
            this.TabPageD.Controls.Add(this.panelD);
            this.TabPageD.ImageIndex = 1;
            this.TabPageD.Name = "TabPageD";
            this.TabPageD.Size = new System.Drawing.Size(1856, 840);
            this.TabPageD.Text = "스텐";
            // 
            // panelD
            // 
            this.panelD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelD.Location = new System.Drawing.Point(0, 0);
            this.panelD.Name = "panelD";
            this.panelD.Size = new System.Drawing.Size(1856, 840);
            this.panelD.TabIndex = 4;
            // 
            // TabPageE
            // 
            this.TabPageE.Controls.Add(this.panelE);
            this.TabPageE.ImageIndex = 1;
            this.TabPageE.Name = "TabPageE";
            this.TabPageE.Size = new System.Drawing.Size(1856, 840);
            this.TabPageE.Text = "서울";
            // 
            // panelE
            // 
            this.panelE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelE.Location = new System.Drawing.Point(0, 0);
            this.panelE.Name = "panelE";
            this.panelE.Size = new System.Drawing.Size(1856, 840);
            this.panelE.TabIndex = 4;
            // 
            // TabPageF
            // 
            this.TabPageF.Controls.Add(this.panelF);
            this.TabPageF.ImageIndex = 1;
            this.TabPageF.Name = "TabPageF";
            this.TabPageF.Size = new System.Drawing.Size(1856, 840);
            this.TabPageF.Text = "해외지사";
            // 
            // panelF
            // 
            this.panelF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelF.Location = new System.Drawing.Point(0, 0);
            this.panelF.Name = "panelF";
            this.panelF.Size = new System.Drawing.Size(1856, 840);
            this.panelF.TabIndex = 4;
            // 
            // TabPageH
            // 
            this.TabPageH.Controls.Add(this.panelH);
            this.TabPageH.ImageIndex = 1;
            this.TabPageH.Name = "TabPageH";
            this.TabPageH.Size = new System.Drawing.Size(1856, 840);
            this.TabPageH.Text = "2공장";
            // 
            // panelH
            // 
            this.panelH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelH.Location = new System.Drawing.Point(0, 0);
            this.panelH.Name = "panelH";
            this.panelH.Size = new System.Drawing.Size(1856, 840);
            this.panelH.TabIndex = 4;
            // 
            // TabPageJ
            // 
            this.TabPageJ.Controls.Add(this.panelJ);
            this.TabPageJ.ImageIndex = 1;
            this.TabPageJ.Name = "TabPageJ";
            this.TabPageJ.Size = new System.Drawing.Size(1856, 840);
            this.TabPageJ.Text = "청도";
            // 
            // panelJ
            // 
            this.panelJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelJ.Location = new System.Drawing.Point(0, 0);
            this.panelJ.Name = "panelJ";
            this.panelJ.Size = new System.Drawing.Size(1856, 840);
            this.panelJ.TabIndex = 4;
            // 
            // TabPageL
            // 
            this.TabPageL.Controls.Add(this.panelL);
            this.TabPageL.ImageIndex = 1;
            this.TabPageL.Name = "TabPageL";
            this.TabPageL.Size = new System.Drawing.Size(1856, 840);
            this.TabPageL.Text = "율촌";
            // 
            // panelL
            // 
            this.panelL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelL.Location = new System.Drawing.Point(0, 0);
            this.panelL.Name = "panelL";
            this.panelL.Size = new System.Drawing.Size(1856, 840);
            this.panelL.TabIndex = 4;
            // 
            // tray
            // 
            this.tray.ContextMenuStrip = this.trayMenu;
            this.tray.Icon = ((System.Drawing.Icon)(resources.GetObject("tray.Icon")));
            this.tray.Text = "tray";
            this.tray.Visible = true;
            this.tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tray_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.종료ToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(94, 26);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.종료ToolStripMenuItem.Text = "Exit";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // TabPageO
            // 
            this.TabPageO.Controls.Add(this.panelO);
            this.TabPageO.ImageIndex = 1;
            this.TabPageO.Name = "TabPageO";
            this.TabPageO.Size = new System.Drawing.Size(1856, 840);
            this.TabPageO.Text = "베트남";
            // 
            // panelO
            // 
            this.panelO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelO.Location = new System.Drawing.Point(0, 0);
            this.panelO.Name = "panelO";
            this.panelO.Size = new System.Drawing.Size(1856, 840);
            this.panelO.TabIndex = 5;
            // 
            // baseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1862, 893);
            this.Controls.Add(this.xtraTabControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "baseForm";
            this.Text = "서버 모니터링";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.baseForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.baseForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.TabPageA.ResumeLayout(false);
            this.TabPageTotal.ResumeLayout(false);
            this.TabPageB.ResumeLayout(false);
            this.TabPageD.ResumeLayout(false);
            this.TabPageE.ResumeLayout(false);
            this.TabPageF.ResumeLayout(false);
            this.TabPageH.ResumeLayout(false);
            this.TabPageJ.ResumeLayout(false);
            this.TabPageL.ResumeLayout(false);
            this.trayMenu.ResumeLayout(false);
            this.TabPageO.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage TabPageA;
        private System.Windows.Forms.Panel panelA;
        private DevExpress.XtraTab.XtraTabPage TabPageB;
        private System.Windows.Forms.Panel panelB;
        private DevExpress.XtraTab.XtraTabPage TabPageD;
        private System.Windows.Forms.Panel panelD;
        private DevExpress.XtraTab.XtraTabPage TabPageE;
        private System.Windows.Forms.Panel panelE;
        private DevExpress.XtraTab.XtraTabPage TabPageF;
        private System.Windows.Forms.Panel panelF;
        private DevExpress.XtraTab.XtraTabPage TabPageH;
        private System.Windows.Forms.Panel panelH;
        private DevExpress.XtraTab.XtraTabPage TabPageJ;
        private System.Windows.Forms.Panel panelJ;
        private DevExpress.XtraTab.XtraTabPage TabPageL;
        private System.Windows.Forms.Panel panelL;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private DevExpress.XtraTab.XtraTabPage TabPageTotal;
        private System.Windows.Forms.Panel panelTotal;
        private DevExpress.XtraTab.XtraTabPage TabPageO;
        private System.Windows.Forms.Panel panelO;


    }
}
